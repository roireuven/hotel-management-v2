using System;
using System.Collections.Generic;

namespace HotelManager
{
    public static class LanguageManager
    {
        public enum Language { English, Vietnamese }

        private static Language _current = Language.English;
        private static Dictionary<string, string> _vi = new Dictionary<string, string>();
        private static Dictionary<string, string> _en = new Dictionary<string, string>();

        public static event EventHandler LanguageChanged;

        static LanguageManager()
        {
            // Login
            Set("login_title", "Login", "Đăng Nhập");
            Set("username_label", "Username:", "Tên đăng nhập:");
            Set("password_label", "Password:", "Mật khẩu:");
            Set("btn_login", "Log In", "Đăng Nhập");
            Set("btn_exit", "Exit", "Thoát");
            Set("validation_username", "Please enter your username.", "Vui lòng nhập tên đăng nhập.");
            Set("validation_password", "Please enter your password.", "Vui lòng nhập mật khẩu.");
            Set("login_failed", "Invalid username or password.\nPlease try again!", "Tên đăng nhập không tồn tại hoặc mật khẩu không đúng.\nVui lòng nhập lại!");
            Set("login_locked", "Too many failed attempts. Account locked for 30 seconds.", "Quá nhiều lần đăng nhập thất bại. Tài khoản bị khóa 30 giây.");
            Set("login_locked_wait", "Too many failed attempts. Please wait {0} seconds.", "Quá nhiều lần thất bại. Vui lòng đợi {0} giây.");
            Set("attempts_remaining", " ({0} attempts remaining)", " (còn {0} lần thử)");
            Set("validation", "Validation", "Xác thực");
            Set("locked", "Locked", "Đã khóa");
            Set("connection_error", "Connection error: ", "Lỗi kết nối: ");

            // Dashboard
            Set("hotel_management", "Hotel Management", "Quản Lí Khách Sạn");
            Set("tile_book_room", "Book Room", "Đặt Phòng");
            Set("tile_check_in", "Check In", "Nhận Phòng");
            Set("tile_revenue", "Revenue Report", "Thống Kê Doanh Thu");
            Set("tile_rooms", "Room Management", "Quản Lí Phòng");
            Set("tile_staff", "Staff Management", "Quản Lí Nhân Viên");
            Set("tile_services", "Service Management", "Quản Lí Dịch Vụ");
            Set("tile_payment", "Services & Payment", "Sử Dụng Dịch Vụ Và Thanh Toán");
            Set("tile_customers", "Customer Management", "Quản Lí Khách Hàng");
            Set("tile_invoices", "Invoice Management", "Quản Lí Hóa Đơn");
            Set("tile_regulations", "Regulations", "Quy Định");
            Set("btn_profile", "Profile", "Thông Tin Cá Nhân");
            Set("btn_logout", "Log Out", "Đăng Xuất");
            Set("btn_help", "Help", "Trợ Giúp");
            Set("btn_about", "About", "Giới Thiệu");
            Set("confirm_exit", "Do you want to exit?", "Bạn có muốn thoát không?");
            Set("notification", "Notification", "Thông báo");
            Set("no_access", "You don't have access.", "Bạn không có quyền truy cập.");
            Set("warning", "Warning", "Cảnh báo");
            Set("btn_language", "Vietnamese", "English");

            // Common
            Set("error", "Error", "Lỗi");
            Set("success", "Success", "Thành công");
            Set("close", "Close", "Đóng");
            Set("cancel", "Cancel", "Hủy");
            Set("update", "Update", "Cập Nhật");
            Set("add", "Add", "Thêm");
            Set("delete", "Delete", "Xoá");
            Set("search", "Search", "Tìm Kiếm");
            Set("cancel_search", "Clear", "Huỷ Tìm");
            Set("export", "Export", "Xuất");
            Set("functions", "Functions", "Chức Năng");
            Set("save_changes", "Save Changes", "Lưu Thay Đổi");
            Set("confirm", "Confirm", "Xác nhận");
            Set("yes", "Yes", "Có");
            Set("no", "No", "Không");

            // Booking
            Set("customer_search", "Customer Search", "Tìm Kiếm Khách Hàng");
            Set("id_card_label", "Citizen ID / CMND:", "Thẻ căn cước/ CMND:");
            Set("customer_info", "Customer Information", "Thông Tin Khách Hàng");
            Set("full_name", "Full Name:", "Họ và tên:");
            Set("date_of_birth", "Date of Birth:", "Ngày sinh:");
            Set("gender", "Gender:", "Giới tính:");
            Set("phone_number", "Phone Number:", "Số điện thoại:");
            Set("address", "Address:", "Địa chỉ:");
            Set("nationality", "Nationality:", "Quốc tịch:");
            Set("customer_type", "Customer Type:", "Loại khách hàng:");
            Set("male", "Male", "Nam");
            Set("female", "Female", "Nữ");
            Set("other", "Other", "Khác");
            Set("room_type_info", "Room Type Information", "Thông Tin Loại Phòng");
            Set("room_type", "Room Type:", "Loại phòng:");
            Set("room_type_code", "Room Type Code:", "Mã loại phòng:");
            Set("room_type_name", "Room Type Name:", "Tên loại phòng:");
            Set("price", "Price:", "Giá:");
            Set("max_people", "Max People:", "Số lượng người tối đa:");
            Set("registration_info", "Registration Info", "Thông Tin Đăng Kí");
            Set("check_in_date", "Check-in Date:", "Ngày nhận:");
            Set("check_out_date", "Check-out Date:", "Ngày trả:");
            Set("nights", "Nights:", "Số đêm:");
            Set("today_bookings", "Today's Bookings", "Danh Sách Đặt Phòng Trong Ngày");
            Set("view_details", "View Details", "Xem Chi Tiết");
            Set("go_to_checkin", "Go to Check-in", "Chuyển đến nhận phòng");
            Set("book_room_btn", "Book Room", "Đặt Phòng");
            Set("id_not_found", "Citizen ID does not exist.\nPlease enter again.", "Thẻ căn cước/ CMND không tồn tại.\nVui lòng nhập lại.");
            Set("confirm_booking", "Do you want to book this room?", "Bạn có muốn đặt phòng không?");
            Set("booking_success", "Room booked successfully.", "Đặt phòng thành công.");
            Set("fill_all_info", "Please enter complete information.", "Vui lòng nhập đầy đủ thông tin.");

            // Check-in
            Set("booking_code", "Booking Code:", "Mã đặt phòng:");
            Set("checkin_info", "Check-in Information", "Thông Tin Nhận Phòng");
            Set("room_name", "Room Name:", "Tên phòng:");
            Set("vacant_rooms", "Vacant Rooms", "Danh Sách Phòng Trống");
            Set("room_label", "Room:", "Phòng:");
            Set("add_customer", "Add Customer", "Thêm Khách Hàng");
            Set("check_in_btn", "Check In", "Nhận Phòng");
            Set("today_checkins", "Today's Check-ins", "Danh Sách Nhận Phòng Trong Ngày");
            Set("booking_not_found", "Booking code does not exist.\nPlease enter again.", "Mã đặt phòng không tồn tại.\nVui lòng nhập lại.");
            Set("confirm_checkin", "Do you want to check in?", "Bạn có muốn nhận phòng không?");
            Set("checkin_success", "Check-in successful.", "Nhận phòng thành công.");
            Set("search_booking_first", "Please search for the booking code first.", "Vui lòng tìm kiếm mã đặt phòng trước.");
            Set("select_room", "Please select a room.", "Vui lòng chọn phòng.");
            Set("checkin_failed", "Failed to create check-in slip.\nPlease try again.", "Tạo phiếu nhận phòng thất bại.\nVui lòng nhập lại.");
            Set("invalid_checkin_date", "Check-in date is invalid.\nPlease enter again.", "Ngày nhận phòng không hợp lệ.\nVui lòng nhập lại.");

            // Room management
            Set("room_management", "Room Management", "Quản Lí Phòng");
            Set("room_list", "Room List", "Danh Sách Phòng");
            Set("room_info", "Room Information", "Thông Tin Phòng");
            Set("room_code", "Room Code:", "Mã phòng:");
            Set("room_name_label", "Room Name:", "Tên Phòng:");
            Set("room_price", "Room Price:", "Giá phòng:");
            Set("max_occupants", "Max Occupants:", "Số người tối đa:");
            Set("status", "Status:", "Trạng Thái:");
            Set("add_room", "Add Room", "Thêm Phòng");
            Set("edit_room_type", "Edit Room Type", "Sửa Loại Phòng");
            Set("update_room", "Update Room", "Cập Nhật Phòng");
            Set("search_room", "Room Code / Name:", "Mã/ Tên phòng:");

            // Staff
            Set("staff_management", "Staff Management", "Quản Lí Nhân Viên");
            Set("staff_list", "Staff List", "Danh Sách Nhân Viên");
            Set("staff_info", "Staff Information", "Thông Tin Nhân Viên");
            Set("staff_account", "Staff Account", "Tài Khoản Nhân Viên");
            Set("staff_type", "Staff Type:", "Loại nhân viên:");
            Set("start_date", "Start Date:", "Ngày vào làm:");
            Set("add_staff", "Add Staff", "Thêm Nhân Viên");
            Set("update_staff", "Update Staff", "Cập Nhật Nhân Viên");
            Set("reset_password", "Reset Password", "Đặt Lại Mật Khẩu");
            Set("access_rights", "Access Rights", "Quyền Truy Cập");
            Set("confirm_update_staff", "Do you want to update this employee?", "Bạn có muốn cập nhật nhân viên này không?");
            Set("confirm_reset_pw", "Do you want to reset the password for username {0}?", "Bạn có muốn đặt lại mật khẩu với tên đăng nhập {0} không?");
            Set("username_empty", "Username cannot be empty.", "Không được để trống tên đăng nhập.");
            Set("export_success", "Export successful.", "Xuất thành công.");
            Set("export_failed", "Export failed.", "Lỗi xuất thất bại.");
            Set("export_needs_office", "Error (Office installation required).", "Lỗi (Cần cài đặt Office).");

            // Customer
            Set("customer_management", "Customer Management", "Quản Lí Khách Hàng");
            Set("customer_list", "Customer List", "Danh Sách Khách Hàng");
            Set("customer_code", "Customer Code:", "Mã khách hàng:");
            Set("confirm_update_customer", "Do you want to update this customer?", "Bạn có muốn cập nhật khách hàng này không?");
            Set("dob_invalid", "Date of birth must be before today.", "Ngày sinh phải nhỏ hơn ngày hiện tại.");
            Set("field_empty", "Cannot be left empty.", "Không được để trống.");
            Set("added_success", "Added successfully.", "Thêm thành công.");
            Set("customer_exists", "Customer already exists.\nDuplicate national ID.", "Khách Hàng đã tồn tại.\nTrùng số chứng minh nhân dân.");
            Set("add_customer_error", "Error adding customer.", "Lỗi thêm khách hàng.");
            Set("customer_not_found", "This customer does not exist.", "Khách hàng này chưa tồn tại.");
            Set("data_not_changed", "You have not changed the data.", "Bạn chưa thay đổi dữ liệu.");
            Set("updated_success", "Updated successfully.", "Cập nhật thành công.");
            Set("update_error", "Update error.", "Lỗi cập nhật.");

            // Services & Payment
            Set("services_payment", "Services & Payment", "Sử Dụng Dịch Vụ Và Thanh Toán");
            Set("room_list_label", "Room List", "Danh Sách Phòng");
            Set("selected_room", "Selected Room", "Phòng đang chọn");
            Set("service_list", "Service List", "Danh sách dịch vụ");
            Set("service_type_label", "Service Type:", "Loại dịch vụ:");
            Set("service_label", "Service:", "Dịch vụ:");
            Set("quantity", "Quantity:", "Số lượng:");
            Set("add_service", "Add Service", "Thêm Dịch Vụ");
            Set("pay", "Pay", "Thanh Toán");
            Set("discount", "Discount:", "Giảm giá:");
            Set("total", "Total:", "Tổng tiền:");
            Set("service_invoice", "Service Invoice", "Hóa đơn dịch vụ");
            Set("room_invoice", "Room Invoice", "Hóa đơn tiền phòng");
            Set("surcharge_policy", "Surcharge Policy", "Chính sách phụ thu");
            Set("invalid_quantity", "Invalid quantity.\nPlease enter again.", "Số lượng không hợp lệ.\nVui lòng nhập lại.");
            Set("select_room_first", "Please select a room first.", "Vui lòng chọn phòng trước.");
            Set("confirm_payment", "Are you sure you want to pay for {0}?", "Bạn có chắc chắn thanh toán cho {0} không?");
            Set("payment_success", "Payment successful!", "Thanh toán thành công!");

            // Invoice
            Set("invoice_management", "Invoice Management", "Quản Lí Hoá Đơn");
            Set("invoice_list", "Invoice List", "Danh Sách Hoá Đơn");
            Set("invoice_info", "Invoice Information", "Thông Tin Hoá Đơn");
            Set("invoice_code", "Invoice Code:", "Mã hoá đơn:");
            Set("unit_price", "Unit Price:", "Đơn giá:");
            Set("created_by", "Created By:", "Nhân viên tạo:");
            Set("created_date", "Created Date:", "Ngày tạo:");
            Set("amount", "Amount:", "Thành tiền:");
            Set("invoice_details", "Invoice Details", "Chi Tiết Hóa Đơn");
            Set("invoice_not_paid", "Invoice not paid.\nYou do not have access.", "Hoá đơn chưa thanh toán.\nBạn không có quyền truy cập.");

            // Profile
            Set("personal_info", "Personal Information", "Thông Tin Cá Nhân");
            Set("account_info", "Account Information", "Thông Tin Tài Khoản");
            Set("account_type", "Account Type:", "Loại tài khoản:");
            Set("display_name", "Display Name:", "Tên hiển thị:");
            Set("username_label2", "Username:", "Tên đăng nhập:");
            Set("basic_info", "Basic Information", "Thông Tin Cơ Bản");
            Set("security", "Security", "Bảo Mật");
            Set("current_password", "Password:", "Mật khẩu:");
            Set("new_password", "New Password:", "Mật khẩu mới:");
            Set("confirm_new_password", "Confirm New Password:", "Xác nhận mật khẩu mới:");
            Set("account_updated", "Account information updated successfully.", "Cập nhật thông tin tài khoản thành công.");
            Set("display_name_invalid", "Display name is invalid.\nPlease enter again.", "Tên hiển thị không hợp lệ.\nVui lòng nhập lại.");
            Set("password_updated", "Password updated successfully.", "Cập nhật mật khẩu thành công.");
            Set("new_password_invalid", "New password is invalid.\nPlease enter again.", "Mật khẩu mới không hợp lệ.\nVui lòng nhập lại.");
            Set("password_invalid", "Password is invalid.\nPlease enter again.", "Mật khẩu không hợp lệ.\nVui lòng nhập lại.");
            Set("basic_info_updated", "Basic information updated successfully.", "Cập nhật thông tin cơ bản thành công.");
            Set("basic_info_invalid", "Basic information is invalid.\nPlease enter again.", "Thông tin cơ bản không hợp lệ.\nVui lòng nhập lại.");

            // Revenue Report
            Set("revenue_report", "Revenue Report", "Báo Cáo Doanh Thu");
            Set("month_label", "Month:", "Tháng:");
            Set("year_label", "Year:", "Năm:");
            Set("view_results", "View Results", "Xem Kết Quả");
            Set("revenue_chart_title", "Revenue by Room Type", "Tỉ lệ doanh thu theo loại phòng");
            Set("invalid_month", "Month is invalid.\nPlease enter again.", "Tháng không hợp lệ.\nVui lòng nhập lại.");

            // Regulations
            Set("regulations", "Regulations", "Qui Định");
            Set("regulation_list", "Regulation List", "Danh Sách Qui Định");
            Set("regulation_info", "Regulation Details", "Thông Tin Qui Định");
            Set("value_label", "Value:", "Giá trị:");
            Set("description_label", "Description:", "Miêu tả:");
            Set("name_label", "Name:", "Tên:");
            Set("confirm_update", "Do you want to update?", "Bạn có muốn cập nhật không?");
            Set("cannot_update", "Cannot update (no such surcharge).", "Không thể cập nhật (Không có phụ thu này).");
            Set("value_empty", "Value cannot be empty.", "Không được để trống giá trị.");
            Set("unknown_error", "Unknown error.", "Lỗi không xác định.");

            // Access rights
            Set("access_management", "Access Rights", "Quyền Truy Cập");
            Set("current_permissions", "Current Permissions", "Quyền hiện tại");
            Set("remaining_permissions", "Remaining Permissions", "Các quyền còn lại");
            Set("staff_type_label", "Staff Type", "Loại Nhân Viên");
            Set("staff_type_name", "Staff Type Name:", "Tên loại nhân viên:");
            Set("add_new", "Add New", "Thêm mới");
            Set("rename", "Rename", "Sửa tên");
            Set("confirm_delete_staff_type", "Do you want to delete this staff type?", "Bạn có muốn xoá loại nhân viên này không?");
            Set("deleted_success", "Deleted successfully.", "Xoá thành công.");
            Set("delete_failed_has_staff", "Delete failed; employees of this type already exist.", "Xoá thất bại, đã tồn tại nhân viên loại này.");

            // Service management
            Set("service_management", "Service Management", "Quản Lí Dịch Vụ");
            Set("service_info", "Service Information", "Thông Tin Dịch Vụ");
            Set("service_code", "Service Code:", "Mã dịch vụ:");
            Set("service_name", "Service Name:", "Tên dịch vụ:");
            Set("edit_service_type", "Edit Service Type", "Sửa Loại Dịch Vụ");

            // About
            Set("about_title", "About", "Giới Thiệu");
            Set("about_software", "HOTEL MANAGEMENT SOFTWARE", "PHẦN MỀM QUẢN LÝ KHÁCH SẠN");
        }

        private static void Set(string key, string en, string vi)
        {
            _en[key] = en;
            _vi[key] = vi;
        }

        public static Language Current
        {
            get { return _current; }
            set
            {
                if (_current != value)
                {
                    _current = value;
                    LanguageChanged?.Invoke(null, EventArgs.Empty);
                }
            }
        }

        public static void Toggle()
        {
            Current = _current == Language.English ? Language.Vietnamese : Language.English;
        }

        public static string Get(string key)
        {
            var dict = _current == Language.English ? _en : _vi;
            string val;
            if (dict.TryGetValue(key, out val)) return val;
            if (_en.TryGetValue(key, out val)) return val;
            return key;
        }

        public static string Get(string key, params object[] args)
        {
            return string.Format(Get(key), args);
        }
    }
}
