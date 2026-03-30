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
    public partial class fUpdateCustomerInfo : Form
    {
        string idCard;
        public fUpdateCustomerInfo(string _idCard)
        {
            InitializeComponent();
            idCard = _idCard;
            LoadCustomerType();
            LoadCustomerInfo(_idCard);
        }
        public void LoadCustomerType()
        {
            cbCustomerType.DataSource = CustomerTypeDAO.Instance.LoadListCustomerType();
            cbCustomerType.DisplayMember = "Name";
        }
        public void LoadCustomerInfo(string idCard)
        {
            Customer customer = CustomerDAO.Instance.GetInfoByIdCard(idCard);
            txbIDCard.Text = customer.IdCard.ToString();
            txbFullName.Text = customer.Name;
            txbAddress.Text = customer.Address;
            dpkDateOfBirth.Value = customer.DateOfBirth;
            cbSex.Text = customer.Sex;
            txbPhoneNumber.Text = customer.PhoneNumber.ToString();
            cbNationality.Text = customer.Nationality;
            cbCustomerType.Text = CustomerTypeDAO.Instance.GetNameByIdCard(idCard);
        }
        public void UpdateCustomer()
        {
            int idCustomerType = (cbCustomerType.SelectedItem as CustomerType).Id;
            CustomerDAO.Instance.UpdateCustomer(CustomerDAO.Instance.GetInfoByIdCard(idCard).Id,txbFullName.Text,txbIDCard.Text,idCustomerType,int.Parse(txbPhoneNumber.Text),dpkDateOfBirth.Value,txbAddress.Text,cbSex.Text,cbNationality.Text);
        }
        public void ClearData()
        {
            txbIDCard.Text = txbFullName.Text = txbAddress.Text = txbPhoneNumber.Text = cbNationality.Text = String.Empty;
        }
        public bool IsIdCardExists(string idCard)
        {
            return CustomerDAO.Instance.IsIdCardExists(idCard);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClose__Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void txbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (txbFullName.Text != string.Empty && txbIDCard.Text != string.Empty && txbAddress.Text != string.Empty && cbNationality.Text != string.Empty && txbPhoneNumber.Text != string.Empty)
            {
                //Check whether ID card is duplicate
                if (!IsIdCardExists(txbIDCard.Text)||txbIDCard.Text==idCard)
                {
                    UpdateCustomer();
                    MessageBox.Show("Customer information updated successfully.", "Notification.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                    LoadCustomerInfo(idCard);
                }
                else
                    MessageBox.Show("Invalid ID card.\nPlease try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Please enter all required information.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
