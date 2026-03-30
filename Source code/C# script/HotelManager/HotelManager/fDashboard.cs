using HotelManager.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fDashboard : Form
    {
        public fDashboard()
        {
            InitializeComponent();
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            try
            {
                lblArrivals.Text = PmsDAO.Instance.GetTodayArrivals().ToString();
                lblDepartures.Text = PmsDAO.Instance.GetTodayDepartures().ToString();

                double occupancy = PmsDAO.Instance.GetOccupancyPercent();
                lblOccupancy.Text = occupancy.ToString("0.#") + "%";
                progressOccupancy.Value = Math.Min((int)occupancy, 100);

                decimal revpar = PmsDAO.Instance.GetRevPAR(DateTime.Now.Month, DateTime.Now.Year);
                lblRevPAR.Text = revpar.ToString("C0", CultureInfo.GetCultureInfo("en-US"));

                int total = PmsDAO.Instance.GetTotalRooms();
                int occupied = PmsDAO.Instance.GetOccupiedRooms();
                int available = PmsDAO.Instance.GetAvailableRooms();

                lblTotal.Text = "Total Rooms: " + total;
                lblOccupied.Text = "Occupied: " + occupied;
                lblAvailable.Text = "Available: " + available;

                decimal basePrice = 500000m;
                decimal dynamicPrice = PmsDAO.Instance.CalculateDynamicPrice(basePrice);
                string pricingStatus;
                if (dynamicPrice > basePrice)
                    pricingStatus = "SURGE — High demand detected\nPrice multiplier active (" +
                                    ((dynamicPrice / basePrice)).ToString("0.##") + "x)";
                else if (dynamicPrice < basePrice)
                    pricingStatus = "DISCOUNT — Low demand\nReduced rate active (" +
                                    ((dynamicPrice / basePrice)).ToString("0.##") + "x)";
                else
                    pricingStatus = "STANDARD — Normal pricing\nNo adjustment needed";
                lblPricing.Text = pricingStatus;

                LoadDirtyRooms();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load dashboard data:\n" + ex.Message,
                    "Dashboard Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadDirtyRooms()
        {
            try
            {
                DataTable dirty = PmsDAO.Instance.GetDirtyRooms();
                dgvDirtyRooms.DataSource = dirty;
                lblHousekeepingTitle.Text = "Housekeeping (" + dirty.Rows.Count + " dirty)";
            }
            catch
            {
                lblHousekeepingTitle.Text = "Housekeeping (error)";
            }
        }

        private void BtnCloseTop_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCloseDashboard_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnRefreshDirty_Click(object sender, EventArgs e)
        {
            LoadDirtyRooms();
        }

        private void BtnParseEmail_Click(object sender, EventArgs e)
        {
            string text = txtEmailInput.Text;
            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("Please paste a booking email or text to parse.",
                    "No Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Dictionary<string, string> parsed = PmsDAO.ParseBookingEmail(text);

            lblParsedName.Text = "Name: " + (parsed.ContainsKey("Name") ? parsed["Name"] : "--");
            lblParsedCheckIn.Text = "Check-In: " + (parsed.ContainsKey("CheckIn") ? parsed["CheckIn"] : "--");
            lblParsedCheckOut.Text = "Check-Out: " + (parsed.ContainsKey("CheckOut") ? parsed["CheckOut"] : "--");
            lblParsedPrice.Text = "Price: " + (parsed.ContainsKey("Price") ? "$" + parsed["Price"] : "--");
        }

        private void BtnAnalyze_Click(object sender, EventArgs e)
        {
            string text = txtGuestNotes.Text;
            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("Please enter guest notes or review text to analyze.",
                    "No Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sentiment = PmsDAO.AnalyzeGuestSentiment(text);
            lblSentiment.Text = "Sentiment: " + sentiment;

            switch (sentiment)
            {
                case "Positive":
                    lblSentiment.BackColor = Color.FromArgb(40, 167, 69);
                    lblSentiment.ForeColor = Color.White;
                    break;
                case "Negative":
                    lblSentiment.BackColor = Color.FromArgb(220, 53, 69);
                    lblSentiment.ForeColor = Color.White;
                    break;
                default:
                    lblSentiment.BackColor = Color.FromArgb(255, 193, 7);
                    lblSentiment.ForeColor = Color.Black;
                    break;
            }
        }
    }
}
