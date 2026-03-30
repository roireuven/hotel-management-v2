using HotelManager.DAO;
using HotelManager.DTO;
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
    public partial class fManagement: Form
    {
        private string userName;
        public fManagement(string userName)
        {
            this.userName = userName;
            InitializeComponent();
            fLoad();
            ApplyLanguage();
            LanguageManager.LanguageChanged += (s, e) => ApplyLanguage();
        }
        public bool IsAdmin()
        {
            var staffType = AccountTypeDAO.Instance.GetStaffTypeByUserName(userName);
            return staffType != null && staffType.Id == 1;
        }
        void fLoad()
        {
            panelLeft.Width = 220;
        }

        private void ApplyLanguage()
        {
            label2.Text = LanguageManager.Get("hotel_management");
            titleBookRoom.Text = LanguageManager.Get("tile_book_room");
            titleRecieveRoom.Text = LanguageManager.Get("tile_check_in");
            title.Text = LanguageManager.Get("tile_revenue");
            titleManageRoom.Text = LanguageManager.Get("tile_rooms");
            metroTile8.Text = LanguageManager.Get("tile_staff");
            metroTile2.Text = LanguageManager.Get("tile_services");
            titlePay.Text = LanguageManager.Get("tile_payment");
            metroTile17.Text = LanguageManager.Get("tile_customers");
            metroTile16.Text = LanguageManager.Get("tile_invoices");
            metroTile13.Text = LanguageManager.Get("tile_regulations");
            btnAccountProfile.ButtonText = "    " + LanguageManager.Get("btn_profile");
            btnLogOut.ButtonText = "    " + LanguageManager.Get("btn_logout");
            btnHelp.ButtonText = "    Dashboard";
            btnIntroduce.ButtonText = "    " + LanguageManager.Get("btn_language");
            btnAccountProfile.Text = btnAccountProfile.ButtonText;
            btnLogOut.Text = btnLogOut.ButtonText;
            btnHelp.Text = btnHelp.ButtonText;
            btnIntroduce.Text = btnIntroduce.ButtonText;
            panelLeft.Invalidate(true);
        }

        private bool CheckAccess(string nameform)
        {
            return AccessDAO.Instance.CheckAccess(userName, nameform);
        }
       
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show(LanguageManager.Get("confirm_exit"), LanguageManager.Get("notification"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void btnNavigationPanel_Click_1(object sender, EventArgs e)
        {
            // no-op in full-screen mode
        }

        private void titleSignUpRoom_Click(object sender, EventArgs e)
        {
            if (CheckAccess("fBookRoom"))
            {
                Hide();
                fBookRoom f = new fBookRoom();
                f.ShowDialog();
                Show();
            }
            else MessageBox.Show(LanguageManager.Get("no_access"), LanguageManager.Get("warning"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void titleRecieveRoom_Click(object sender, EventArgs e)
        {
            if (CheckAccess("fReceiveRoom"))
            {
                this.Hide();
                fReceiveRoom f = new fReceiveRoom();
                f.ShowDialog();
                this.Show();
            }
            else MessageBox.Show(LanguageManager.Get("no_access"), LanguageManager.Get("warning"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void titleSendRoom_Click(object sender, EventArgs e)
        {
            if (CheckAccess("fUseService"))
            {
                this.Hide();
                fUseService f = new fUseService(userName);
                f.ShowDialog();
                this.Show();
            }
            else MessageBox.Show(LanguageManager.Get("no_access"), LanguageManager.Get("warning"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void titlePay_Click(object sender, EventArgs e)
        {
            if (CheckAccess("fUseService"))
            {
                this.Hide();
                fUseService f = new fUseService(userName);
                f.ShowDialog();
                this.Show();
            }
            else MessageBox.Show(LanguageManager.Get("no_access"), LanguageManager.Get("warning"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void titleManageRoom_Click(object sender, EventArgs e)
        {
            if (CheckAccess("froom"))
            {
                this.Hide();
                fRoom fProfile = new fRoom();
                fProfile.ShowDialog();
                this.Show();
            }
            else MessageBox.Show(LanguageManager.Get("no_access"), LanguageManager.Get("warning"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnAccountProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            fProfile fProfile = new fProfile(userName);
            fProfile.ShowDialog();
            this.Show();
        }

        private void metroTile17_Click(object sender, EventArgs e)
        {
            if (CheckAccess("fcustomer"))
            {
                this.Hide();
                fCustomer customer = new fCustomer();
                customer.ShowDialog();
                this.Show();
            }
            else MessageBox.Show(LanguageManager.Get("no_access"), LanguageManager.Get("warning"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void metroTile13_Click(object sender, EventArgs e)
        {
            if (CheckAccess("fparameter"))
            {
                this.Hide();
                fParameter parameter = new fParameter();
                parameter.ShowDialog();
                this.Show();
            }
            else MessageBox.Show(LanguageManager.Get("no_access"), LanguageManager.Get("warning"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void metroTile8_Click(object sender, EventArgs e)
        {
            if (CheckAccess("fstaff"))
            {
                this.Hide();
                fStaff fProfile = new fStaff();
                fProfile.ShowDialog();
                this.Show();
            }
            else MessageBox.Show(LanguageManager.Get("no_access"), LanguageManager.Get("warning"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void metroTile2_Click(object sender, EventArgs e)
        { 
            if (CheckAccess("fservice"))
            {
                this.Hide();
                fService fProfile = new fService();
                fProfile.ShowDialog();
                this.Show();
            }
            else MessageBox.Show(LanguageManager.Get("no_access"), LanguageManager.Get("warning"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnIntroduce_Click(object sender, EventArgs e)
        {
            LanguageManager.Toggle();
        }

        private void title_Click(object sender, EventArgs e)
        {
            if(CheckAccess("freport"))
            {
                this.Hide();
                fReport fAbout = new fReport();
                fAbout.ShowDialog();
                this.Show();
            }
            else MessageBox.Show(LanguageManager.Get("no_access"), LanguageManager.Get("warning"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void metroTile16_Click(object sender, EventArgs e)
        {
            if (CheckAccess("fBill"))
            {
                this.Hide();
                fBill fAbout = new fBill();
                fAbout.ShowDialog();
                this.Show();
            }
            else MessageBox.Show(LanguageManager.Get("no_access"), LanguageManager.Get("warning"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            this.Hide();
            fDashboard dashboard = new fDashboard();
            dashboard.ShowDialog();
            this.Show();
        }

        private void panelRight_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
