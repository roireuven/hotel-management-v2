using HotelManager.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fLogin : Form
    {
        private int failedAttempts = 0;
        private DateTime lockoutUntil = DateTime.MinValue;

        public fLogin()
        {
            InitializeComponent();
            ApplyLanguage();
            LanguageManager.LanguageChanged += (s, e) => ApplyLanguage();
        }

        private void ApplyLanguage()
        {
            label1.Text = LanguageManager.Get("username_label");
            label4.Text = LanguageManager.Get("password_label");
            btnLogin.ButtonText = LanguageManager.Get("btn_login");
            btnExit_.ButtonText = LanguageManager.Get("btn_exit");
            btnLogin.Invalidate();
            btnExit_.Invalidate();
        }

        public bool Login()
        {
            if (string.IsNullOrWhiteSpace(txbUserName.Text) || string.IsNullOrWhiteSpace(txbPassWord.Text))
                return false;
            return AccountDAO.Instance.Login(txbUserName.Text.Trim(), txbPassWord.Text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbUserName.Text))
            {
                MessageBox.Show(LanguageManager.Get("validation_username"), LanguageManager.Get("validation"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txbPassWord.Text))
            {
                MessageBox.Show(LanguageManager.Get("validation_password"), LanguageManager.Get("validation"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DateTime.Now < lockoutUntil)
            {
                int seconds = (int)(lockoutUntil - DateTime.Now).TotalSeconds;
                MessageBox.Show(LanguageManager.Get("login_locked_wait", seconds), LanguageManager.Get("locked"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (Login())
                {
                    failedAttempts = 0;
                    this.Hide();
                    fManagement f = new fManagement(txbUserName.Text.Trim());
                    f.ShowDialog();
                    txbPassWord.Text = string.Empty;
                    this.Show();
                }
                else
                {
                    failedAttempts++;
                    if (failedAttempts >= 5)
                    {
                        lockoutUntil = DateTime.Now.AddSeconds(30);
                        MessageBox.Show(LanguageManager.Get("login_locked"), LanguageManager.Get("locked"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(LanguageManager.Get("login_failed") + LanguageManager.Get("attempts_remaining", 5 - failedAttempts), LanguageManager.Get("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(LanguageManager.Get("connection_error") + ex.Message, LanguageManager.Get("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit__Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txbPassWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnLogin_Click_1(sender, EventArgs.Empty);
        }
    }
}
