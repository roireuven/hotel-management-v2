using HotelManager.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fPrintBill : Form
    {
        public fPrintBill()
        {
            InitializeComponent();
        }
        public void SetPrintBill(int idBill, string dateOfCreate)
        {
            ShowBillPreView(idBill);
            ShowInfo(idBill);
            lblIDBill.Text = idBill.ToString();
            lblDateCreate.Text = dateOfCreate;
            lblStaffSetUp.Text = AccountDAO.Instance.GetStaffSetUp(idBill).DisplayName;
        }
        public fPrintBill(int idRoom,int idBill)
        {
            InitializeComponent();
            ShowBillPreView(idBill);
            ShowInfo(idBill);
            lblIDBill.Text = idBill.ToString();
            lblDateCreate.Text = DateTime.Now.ToString();
            lblStaffSetUp.Text = AccountDAO.Instance.GetStaffSetUp(idBill).DisplayName;
        }
        int id = 0;
        public void ShowBillPreView(int idBill)
        {
            listViewUseService.Items.Clear();
            DataTable dataTable = BillDAO.Instance.ShowBillPreView(idBill);
            CultureInfo cultureInfo = new CultureInfo("vi-vn");
            int _totalPrice = 0;
            foreach (DataRow item in dataTable.Rows)
            {
                ListViewItem listViewItem = new ListViewItem(id.ToString());
                id++;

                ListViewItem.ListViewSubItem subItem1 = new ListViewItem.ListViewSubItem(listViewItem, item["Service Name"].ToString());
                ListViewItem.ListViewSubItem subItem2 = new ListViewItem.ListViewSubItem(listViewItem, ((int)item["Unit Price"]).ToString("c0", cultureInfo));
                ListViewItem.ListViewSubItem subItem3 = new ListViewItem.ListViewSubItem(listViewItem, ((int)item["Quantity"]).ToString());
                ListViewItem.ListViewSubItem subItem4 = new ListViewItem.ListViewSubItem(listViewItem, ((int)item["Total Amount"]).ToString("c0", cultureInfo));


                _totalPrice += (int)item["Total Amount"];

                listViewItem.SubItems.Add(subItem1);
                listViewItem.SubItems.Add(subItem2);
                listViewItem.SubItems.Add(subItem3);
                listViewItem.SubItems.Add(subItem4);

                listViewUseService.Items.Add(listViewItem);
            }

            ListViewItem listViewItemTotalPrice = new ListViewItem();
            ListViewItem.ListViewSubItem subItemTotalPrice = new ListViewItem.ListViewSubItem(listViewItemTotalPrice, _totalPrice.ToString("c0", cultureInfo));
            ListViewItem.ListViewSubItem _subItem1 = new ListViewItem.ListViewSubItem(listViewItemTotalPrice, "");
            ListViewItem.ListViewSubItem _subItem2 = new ListViewItem.ListViewSubItem(listViewItemTotalPrice, "");
            ListViewItem.ListViewSubItem _subItem3 = new ListViewItem.ListViewSubItem(listViewItemTotalPrice, "");
            listViewItemTotalPrice.SubItems.Add(_subItem1);
            listViewItemTotalPrice.SubItems.Add(_subItem2);
            listViewItemTotalPrice.SubItems.Add(_subItem3);
            listViewItemTotalPrice.SubItems.Add(subItemTotalPrice);
            listViewUseService.Items.Add(listViewItemTotalPrice);

            id = 1;
        }
        public bool IsExistsBill(int idRoom)
        {
            return BillDAO.Instance.IsExistsBill(idRoom);
        }
        public void ShowInfo(int idBill)
        {
            string query = "USP_ShowBillInfo @idBill";
            DataRow data = DataProvider.Instance.ExecuteQuery(query, new object[] { idBill }).Rows[0];
            CultureInfo cultureInfo = new CultureInfo("vi-vn");
            lblCustomerName.Text = data["FullName"].ToString();
            lblIDCard.Text = data["IDCard"].ToString();
            lblPhoneNumber.Text = ((int)data["Phone"]).ToString();
            lblCustomerTypeName.Text = data["CustomerType"].ToString();
            lblAddress.Text = data["Address"].ToString();
            lblNationality.Text= data["Nationality"].ToString();
            lblRoomName.Text= data["RoomName"].ToString();
            lblRoomTypeName.Text= data["RoomType"].ToString();
            lblRoomPrice_.Text=((int)data["UnitPrice"]).ToString("c0",cultureInfo);
            lblDateCheckIn.Text=((DateTime)data["CheckInDate"]).ToString().Split(' ')[0];
            DateTime dateCheckIn= (DateTime)data["CheckInDate"];
            DateTime dateCheckOut = (DateTime)data["CheckOutDate"];
            int days = dateCheckOut.Subtract(dateCheckIn).Days;
            lblDays.Text = days.ToString();
            lblPeoples.Text = RoomDAO.Instance.GetPeoples(idBill).ToString();
            lblSurcharge.Text= ((int)data["Surcharge"]).ToString("c0", cultureInfo);
            lblServicePrice.Text= ((int)data["ServicePrice"]).ToString("c0", cultureInfo);
            lblRoomPrice.Text= ((int)data["RoomPrice"]).ToString("c0", cultureInfo);
            lblTotalPrice.Text= ((int)data["TotalPrice"]).ToString("c0", cultureInfo);
            lblFinalPrice.Text= ((int)data["TotalPrice"]*((100-(int)data["Discount"])/100.0)).ToString("c0", cultureInfo);
            lblDiscount.Text= ((int)data["Discount"]).ToString()+" %";
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnClose__Click(object sender, EventArgs e)
        {
            Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap,58,70);
            bitmap.Dispose();
        }
        Bitmap bitmap;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();
            bitmap = new Bitmap(708, 647, graphics);
            Graphics _graphics = Graphics.FromImage(bitmap);
            _graphics.CopyFromScreen(this.Location.X, this.Location.Y+28,0,0,new Size(708, 647));
            bitmap.Save(Application.StartupPath+ @"\Bill.Png", ImageFormat.Png);
            bitmap = new Bitmap(Application.StartupPath + @"\Bill.Png");
            if (printDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }
    }
}
