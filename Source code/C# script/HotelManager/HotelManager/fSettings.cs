using HotelManager.DAO;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fSettings : Form
    {
        public fSettings()
        {
            InitializeComponent();
            LoadSettings();
        }

        #region Load
        private void LoadSettings()
        {
            txbHotelName.Text = SettingsDAO.Instance.GetSettingString("HotelName");
            txbHotelEmail.Text = SettingsDAO.Instance.GetSettingString("HotelEmail");
            txbHotelPhone.Text = SettingsDAO.Instance.GetSettingString("HotelPhone");
            txbHotelCurrency.Text = SettingsDAO.Instance.GetSettingString("HotelCurrency");
            txbHotelAddress.Text = SettingsDAO.Instance.GetSettingString("HotelAddress");

            numMaxGuests.Value = (decimal)SettingsDAO.Instance.GetSettingValue("MaxGuests");
            if (numMaxGuests.Value == 0) numMaxGuests.Value = 3;
            numSurchargeRate.Value = (decimal)SettingsDAO.Instance.GetSettingValue("SurchargeRate");
            txbCheckInTime.Text = SettingsDAO.Instance.GetSettingString("CheckInTime");
            if (string.IsNullOrEmpty(txbCheckInTime.Text)) txbCheckInTime.Text = "14:00";
            txbCheckOutTime.Text = SettingsDAO.Instance.GetSettingString("CheckOutTime");
            if (string.IsNullOrEmpty(txbCheckOutTime.Text)) txbCheckOutTime.Text = "12:00";

            numDefaultTax.Value = (decimal)SettingsDAO.Instance.GetSettingValue("DefaultTaxRate");
            numServiceTax.Value = (decimal)SettingsDAO.Instance.GetSettingValue("ServiceTaxRate");
            numPeakMultiplier.Value = (decimal)SettingsDAO.Instance.GetSettingValue("PeakMultiplier");
            if (numPeakMultiplier.Value == 0) numPeakMultiplier.Value = 1.5m;
            numOffMultiplier.Value = (decimal)SettingsDAO.Instance.GetSettingValue("OffSeasonMultiplier");
            if (numOffMultiplier.Value == 0) numOffMultiplier.Value = 1.0m;

            string peakStart = SettingsDAO.Instance.GetSettingString("PeakSeasonStart");
            string peakEnd = SettingsDAO.Instance.GetSettingString("PeakSeasonEnd");
            string offStart = SettingsDAO.Instance.GetSettingString("OffSeasonStart");
            string offEnd = SettingsDAO.Instance.GetSettingString("OffSeasonEnd");

            if (!string.IsNullOrEmpty(peakStart))
                try { dtpPeakStart.Value = DateTime.Parse(peakStart); } catch { }
            if (!string.IsNullOrEmpty(peakEnd))
                try { dtpPeakEnd.Value = DateTime.Parse(peakEnd); } catch { }
            if (!string.IsNullOrEmpty(offStart))
                try { dtpOffStart.Value = DateTime.Parse(offStart); } catch { }
            if (!string.IsNullOrEmpty(offEnd))
                try { dtpOffEnd.Value = DateTime.Parse(offEnd); } catch { }
        }
        #endregion

        #region Save Settings
        private void BtnSaveSettings_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Save all settings?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            bool ok = true;
            ok &= SettingsDAO.Instance.SaveSetting("HotelName", 0, txbHotelName.Text.Trim());
            ok &= SettingsDAO.Instance.SaveSetting("HotelEmail", 0, txbHotelEmail.Text.Trim());
            ok &= SettingsDAO.Instance.SaveSetting("HotelPhone", 0, txbHotelPhone.Text.Trim());
            ok &= SettingsDAO.Instance.SaveSetting("HotelCurrency", 0, txbHotelCurrency.Text.Trim());
            ok &= SettingsDAO.Instance.SaveSetting("HotelAddress", 0, txbHotelAddress.Text.Trim());

            ok &= SettingsDAO.Instance.SaveSetting("MaxGuests", (double)numMaxGuests.Value, "Max guests per room");
            ok &= SettingsDAO.Instance.SaveSetting("SurchargeRate", (double)numSurchargeRate.Value, "Surcharge rate percentage");
            ok &= SettingsDAO.Instance.SaveSetting("CheckInTime", 0, txbCheckInTime.Text.Trim());
            ok &= SettingsDAO.Instance.SaveSetting("CheckOutTime", 0, txbCheckOutTime.Text.Trim());

            ok &= SettingsDAO.Instance.SaveSetting("DefaultTaxRate", (double)numDefaultTax.Value, "Default tax rate");
            ok &= SettingsDAO.Instance.SaveSetting("ServiceTaxRate", (double)numServiceTax.Value, "Service tax rate");
            ok &= SettingsDAO.Instance.SaveSetting("PeakMultiplier", (double)numPeakMultiplier.Value, "Peak season price multiplier");
            ok &= SettingsDAO.Instance.SaveSetting("OffSeasonMultiplier", (double)numOffMultiplier.Value, "Off season price multiplier");
            ok &= SettingsDAO.Instance.SaveSetting("PeakSeasonStart", 0, dtpPeakStart.Value.ToString("yyyy-MM-dd"));
            ok &= SettingsDAO.Instance.SaveSetting("PeakSeasonEnd", 0, dtpPeakEnd.Value.ToString("yyyy-MM-dd"));
            ok &= SettingsDAO.Instance.SaveSetting("OffSeasonStart", 0, dtpOffStart.Value.ToString("yyyy-MM-dd"));
            ok &= SettingsDAO.Instance.SaveSetting("OffSeasonEnd", 0, dtpOffEnd.Value.ToString("yyyy-MM-dd"));

            if (ok)
                MessageBox.Show("Settings saved successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Some settings could not be saved.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion

        #region Backup & Restore
        private void BtnExportAll_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "ZIP Archive|*.zip";
            sfd.Title = "Export All Data";
            sfd.FileName = "HotelData_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".zip";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                bool success = SettingsDAO.Instance.ExportAllToZip(sfd.FileName);
                Cursor = Cursors.Default;
                if (success)
                    MessageBox.Show("All data exported successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Export failed.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnImportData_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "ZIP Archive|*.zip|JSON File|*.json";
            ofd.Title = "Import Data";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DialogResult confirm = MessageBox.Show(
                    "Importing data may add duplicate records. Continue?",
                    "Confirm Import", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm != DialogResult.Yes) return;

                Cursor = Cursors.WaitCursor;
                bool success = false;
                string ext = Path.GetExtension(ofd.FileName).ToLower();
                if (ext == ".zip")
                    success = SettingsDAO.Instance.ImportFromZip(ofd.FileName);
                Cursor = Cursors.Default;

                if (success)
                    MessageBox.Show("Data imported successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Import failed or no records imported.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportSingleTable(string tableName)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV File|*.csv";
            sfd.Title = "Export " + tableName;
            sfd.FileName = tableName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                bool success = SettingsDAO.Instance.ExportTableToCsvFile(tableName, sfd.FileName);
                Cursor = Cursors.Default;
                if (success)
                    MessageBox.Show(tableName + " exported successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Export failed.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Single Table Export Handlers
        private void BtnExportRooms_Click(object sender, EventArgs e) { ExportSingleTable("Room"); }
        private void BtnExportGuests_Click(object sender, EventArgs e) { ExportSingleTable("Customer"); }
        private void BtnExportBookings_Click(object sender, EventArgs e) { ExportSingleTable("BookRoom"); }
        private void BtnExportServices_Click(object sender, EventArgs e) { ExportSingleTable("Service"); }
        private void BtnExportInvoices_Click(object sender, EventArgs e) { ExportSingleTable("Bill"); }
        private void BtnExportInventory_Click(object sender, EventArgs e) { ExportSingleTable("BillDetails"); }
        private void BtnExportMenu_Click(object sender, EventArgs e) { ExportSingleTable("ServiceType"); }
        private void BtnExportStore_Click(object sender, EventArgs e) { ExportSingleTable("RoomType"); }
        private void BtnExportTickets_Click(object sender, EventArgs e) { ExportSingleTable("ReceiveRoom"); }
        private void BtnExportAccounts_Click(object sender, EventArgs e) { ExportSingleTable("Staff"); }
        private void BtnExportTransactions_Click(object sender, EventArgs e) { ExportSingleTable("REPORT"); }
        private void BtnExportPOSSales_Click(object sender, EventArgs e) { ExportSingleTable("StatusBill"); }
        private void BtnExportRestaurant_Click(object sender, EventArgs e) { ExportSingleTable("StaffType"); }
        private void BtnExportSvcRequests_Click(object sender, EventArgs e) { ExportSingleTable("ReceiveRoomDetails"); }
        private void BtnExportMessages_Click(object sender, EventArgs e) { ExportSingleTable("Parameter"); }
        #endregion

        #region Close
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
