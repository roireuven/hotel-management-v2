using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;
        internal int GetIdBillMax()
        {
            string query = "USP_GetIdBillMax";
            object result = DataProvider.Instance.ExecuteScalar(query);
            return result != null && result != DBNull.Value ? (int)result : -1;
        }
        internal int GetIdBillFromIdRoom(int idRoom)
        {
            string query = "USP_GetIdBillFromIdRoom @idRoom";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idRoom });
            if (data.Rows.Count == 0) return -1;
            Bill bill = new Bill(data.Rows[0]);
            return bill.Id;
        }
        internal bool IsExistsBill(int idRoom)// > 0 Tồn tại Bill
        {
            string query = "USP_IsExistBillOfRoom @idRoom";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { idRoom }).Rows.Count > 0;
        }
        internal bool InsertBill(int idReceiveRoom, string staffSetUp)
        {
            string query = "USP_InsertBill @idReceiveRoom , @staffSetUp";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idReceiveRoom, staffSetUp }) > 0;
        }
        internal DataTable ShowBill(int idRoom)
        {
            string query = "USP_ShowBill @idRoom";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { idRoom });
        }
        internal DataTable ShowBillPreView(int idBill)
        {
            string query = "USP_ShowBillPreView @idRoom";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { idBill });
        }
        internal DataRow ShowBillRoom(int idRoom)
        {
            string query = "USP_ShowBillRoom @getToday , @idRoom";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { DateTime.Now.Date, idRoom });
            if (data.Rows.Count == 0) return null;
            return data.Rows[0];
        }
        internal bool UpdateRoomPrice(int idBill)
        {
            string query = "USP_UpdateBill_RoomPrice @idBill";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idBill }) > 0;
        }
        internal bool UpdateServicePrice(int idBill)
        {
            string query = "USP_UpdateBill_ServicePrice @idBill";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idBill }) > 0;
        }
        internal bool UpdateOther(int idBill, int discount)
        {
            string query = "USP_UpdateBill_Other @idBill , @discount";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idBill, discount }) > 0;
        }
        internal DataTable LoaddFullBill()
        {
            string query = "USP_LoadFullBill";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        internal DataTable SearchBill(string text, int mode)
        {
            string query = "USP_SearchBill @string , @mode";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { text, mode });
        }

        internal static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return instance; }
            private set => instance = value;
        }
    }
}
