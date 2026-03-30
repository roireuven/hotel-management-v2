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
    public partial class fAddCustomer : Form
    {
        public fAddCustomer()
        {
            InitializeComponent();
            LoadFullCustomerType();
        }
        private void LoadFullCustomerType()
        {
            DataTable table = GetFullCustomerType();
            comboBoxCustomerType.DataSource = table;
            comboBoxCustomerType.DisplayMember = "Name";
            if (table.Rows.Count > 0)
                comboBoxCustomerType.SelectedIndex = 0;
        }
        private DataTable GetFullCustomerType()
        {
            return CustomerTypeDAO.Instance.LoadFullCustomerType();
        }
        private void Clean()
        {
            txbFullName.Text = string.Empty;
            txbAddress.Text = string.Empty;
            txbIDCard.Text = string.Empty;
            txbNationality.Text = string.Empty;
            txbPhoneNumber.Text = string.Empty;
        }
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to add a new customer?", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                if (CheckDate())
                {
                    InsertCustomer();
                }
                else
                    MessageBox.Show("Date of birth must be before today", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private bool CheckDate()
        {
            if (DateTime.Now.Subtract(datepickerDateOfBirth.Value).Days <= 0)
                return false;
            else return true;
        }
        private void InsertCustomer()
        {
            if (!CheckFillInText(new Control[] { txbPhoneNumber, txbFullName, txbIDCard, txbNationality, txbAddress, comboBoxCustomerType }))
            {
                MessageBox.Show("Fields cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Customer customer = GetCustomerNow();
                if (CustomerDAO.Instance.InsertCustomer(customer))
                {
                    MessageBox.Show("Added successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clean();
                }
                else
                    MessageBox.Show("Customer already exists\nDuplicate national ID number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch
            {
                MessageBox.Show("Error adding customer", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static bool CheckFillInText(Control[] controls)
        {
            foreach (var control in controls)
            {
                if (control.Text == string.Empty)
                    return false;
            }
            return true;
        }
        private Customer GetCustomerNow()
        {
            fStaff.Trim(new Bunifu.Framework.UI.BunifuMetroTextbox[] { txbAddress, txbFullName, txbIDCard });
            Customer customer = new Customer();
            customer.IdCard = txbIDCard.Text;
            int id = comboBoxCustomerType.SelectedIndex;
            customer.IdCustomerType = (int)((DataTable)comboBoxCustomerType.DataSource).Rows[id]["id"];
            customer.Name = txbFullName.Text;
            customer.Sex = comboBoxSex.Text;
            customer.PhoneNumber = int.Parse(txbPhoneNumber.Text);
            customer.DateOfBirth = datepickerDateOfBirth.Value;
            customer.Nationality = txbNationality.Text;
            customer.Address = txbAddress.Text;
            return customer;
        }

        private void btnClose__Click(object sender, EventArgs e)
        {
            Close();
        }
        private void TxbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
