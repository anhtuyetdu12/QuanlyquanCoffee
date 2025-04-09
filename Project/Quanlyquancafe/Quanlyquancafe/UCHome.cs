using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Quanlyquancafe
{
    public partial class UCHome : UserControl
    {
        private Database db;
        private DataTable dt;
        // Biến toàn cục lưu ID bàn đang được chọn
        private int currentTableId = -1;


        public UCHome()
        {
            InitializeComponent();
            LoadTable();
            LoadCategory();
            loadCbbTable(cbbChuyenBan);


        }

        //Load danh sach ban
        public void LoadTable()
        {
            flpTable.Controls.Clear();

            db = new Database();
            string sql = "USP_GetTableList"; // Tên Stored Procedure

            dt = db.SelectData(sql);

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Button btn = new Button();
                    btn.Width = 100;
                    btn.Height = 100;
                    // btn.Text = row["name"].ToString() + Environment.NewLine + row["status"].ToString();
                    btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    btn.TextAlign = ContentAlignment.BottomCenter;
                    btn.ImageAlign = ContentAlignment.TopCenter;
                    btn.FlatStyle = FlatStyle.Flat;

                    Image statusImage;

                    if (row["status"].ToString() == "Trống")
                    {
                        btn.BackColor = Color.LightGreen;
                        statusImage = Properties.Resources.checked__1_;
                    }
                    else
                    {
                        btn.BackColor = Color.LightPink;
                        statusImage = Properties.Resources.check;
                    }
                    btn.Image = statusImage;
                    btn.Text = row["name"].ToString();
                    btn.Tag = row["id"]; //gắn table id vào
                    btn.Click += Btn_Click;

                    flpTable.Controls.Add(btn);
                }
            }
        }

        public void loadCbbTable(ComboBox cb)
        {
            db = new Database();
            string sql = "USP_GetTableList"; // Gọi Stored Procedure lấy danh sách bàn
            dt = db.SelectData(sql);

            if (dt != null)
            {
                cb.DataSource = dt;
                cb.DisplayMember = "name";  // Hiển thị tên bàn
                cb.ValueMember = "id";      // Lưu ID bàn
            }

        }


        // Load danh muc sp
        public void LoadCategory()
        {
            db = new Database();
            string sql = "USP_GetCategory"; // Stored Procedure lấy danh mục món ăn
            dt = db.SelectData(sql);

            if (dt != null)
            {
                cbbDanhMuc.DataSource = dt;
                cbbDanhMuc.DisplayMember = "name";  // Cột hiển thị
                cbbDanhMuc.ValueMember = "id";      // Cột giá trị
            }
        }

        //Load danh sách food theo ID danh mục
        public void LoadFoodListByCategoryID()
        {
            if (cbbDanhMuc.SelectedValue != null)
            {
                int idCategory = Convert.ToInt32(cbbDanhMuc.SelectedValue);
                db = new Database();
                string sql = "USP_GetFoodListByCategoryId"; // Stored Procedure lấy món ăn theo danh mục

                var lstPra = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    key = "@idCategory",
                    value = idCategory.ToString()
                }
            };

                dt = db.SelectData(sql, lstPra);

                if (dt != null)
                {
                    cbbMonAn.DataSource = dt;
                    cbbMonAn.DisplayMember = "TenMonAn"; // Tên cột hiển thị
                    cbbMonAn.ValueMember = "IDMonAn";   // ID món ăn
                }
            }
        }


        //show hóa đơn ra cụ thể
        private void Btn_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            int tableId = (int)clickedButton.Tag; // lấy ID bàn được chọn

            currentTableId = (int)clickedButton.Tag; // Lưu lại ID bàn được chọn

            // Reset viền của tất cả các button trong flpTable
            foreach (Control control in flpTable.Controls)
            {
                if (control is Button btn)
                {
                    btn.FlatAppearance.BorderSize = 1; // Viền bình thường
                    btn.FlatAppearance.BorderColor = Color.White;
                }
            }

            // Đổi viền đỏ cho button được chọn
            clickedButton.FlatAppearance.BorderSize = 3;
            clickedButton.FlatAppearance.BorderColor = Color.Yellow;

            LoadBill(tableId);
     
        }

        // Load ds bill theo bàn 
        public void LoadBill(int tableId)
        {
            lvBill.Items.Clear(); // Xóa dữ liệu cũ trước khi hiển thị mới
            txtTongTien.Text = "0"; // Reset tổng tiền trước khi tính lại

            db = new Database();
            string sql = "USP_GetBillTable"; // Tên Stored Procedure

            var lstPra = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    key = "@tableId",
                    value = tableId.ToString() // Chuyển số sang chuỗi nếu cần
                }
            };

            dt = db.SelectData(sql, lstPra);
            double tongTien = 0;

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["TenMon"].ToString());
                    item.SubItems.Add(row["SoLuong"].ToString());
                    item.SubItems.Add(row["DonGia"].ToString());
                    item.SubItems.Add(row["ThanhTien"].ToString());
                    string note = row["GhiChu"]?.ToString();
                    item.SubItems.Add(string.IsNullOrWhiteSpace(note) ? "Trống" : note);   //sẽ kiểm tra cả null, "", và " " (chuỗi toàn khoảng trắng).

                    lvBill.Items.Add(item);
                    tongTien += Convert.ToDouble(row["ThanhTien"]); // có dấu phẩy động 
                }
            }
            // Hiển thị tổng tiền vào txtTongTien với định dạng tiền tệ
            txtTongTien.Text = tongTien.ToString("N0") + " VND";
           
        }

        //hàm insert bill
        public void InsertBill(int idTable)
        {
            db = new Database();
            string sql = "USP_InsertBill"; // Gọi Stored Procedure để tạo hóa đơn mới

            var lstPra = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    key = "@idTable",
                    value = idTable.ToString()
                }
            };

            db.ExeCute(sql, lstPra); // Thực thi Stored Procedure
        }
        //hàm insert Bill info
        public void InsertBillInfo(int idBill, int idFood, int count, string note)
        {
            db = new Database();
            string sql = "USP_InsertBillInfo"; // Gọi Stored Procedure để thêm món vào bill info

            var lstPra = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    key = "@idBill",
                    value = idBill.ToString()
                },
                new CustomParameter()
                {
                    key = "@idFood",
                    value = idFood.ToString()
                },
                new CustomParameter()
                {
                    key = "@count",
                    value = count.ToString()
                },
                new CustomParameter() 
                { 
                    key = "@note", 
                    value = note ?? "Trống" 
                }
            };

            db.ExeCute(sql, lstPra); // Thực thi Stored Procedure
        }

        // hàm checkout bill
        public void CheckOut (int id, int? discount)
        {
            db = new Database();
            string sql = "USP_CheckOut"; // Gọi stored procedure để cập nhật trạng thái hóa đơn

            // Nếu discount là null, gán mặc định là 0
            int finalDiscount = discount ?? 0;

            var lstPra = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    key = "@id",
                    value = id.ToString()
                },
                 new CustomParameter()
                {
                    key = "@discount",
                    value = finalDiscount.ToString() // Đảm bảo không truyền null
                }
            };

            db.ExeCute(sql, lstPra); // Thực thi stored procedure
        }
        //load table lên

     

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem bàn hiện tại có hóa đơn chưa thanh toán không
            if (currentTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn cần thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            db = new Database();
            string checkBillSql = "USP_GetUncheckBillIDByTableID"; // Kiểm tra hóa đơn chưa thanh toán

            var lstPra = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    key = "@idTable",
                    value = currentTableId.ToString()
                }
            };

            dt = db.SelectData(checkBillSql, lstPra);

            if (dt != null && dt.Rows.Count > 0)
            {
                int idBill = Convert.ToInt32(dt.Rows[0]["id"]);

                // Xác nhận trước khi thanh toán
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn thanh toán hóa đơn cho bàn " + currentTableId + "?",
                    "Xác nhận thanh toán",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question
                );


                if (result == DialogResult.OK)
                {
                    // Lấy tổng tiền từ txtTongTien và loại bỏ " VND" và dấu phẩy
                    decimal totalAmount = Convert.ToDecimal(txtTongTien.Text.Replace(" VND", "").Replace(",", ""));

                    // Lấy giá trị giảm giá từ một TextBox hoặc NumericUpDown (ví dụ: numDiscount)
                    int discountValue = (int)nmGiamGia.Value; // Giảm giá

                    // Tính lại tổng tiền sau khi áp dụng giảm giá
                    decimal finalAmount = totalAmount - (totalAmount * (discountValue / 100m));

                    DateTime dateCheckIn = DateTime.Now;
                    DateTime dateCheckOut = DateTime.Now;

                    // Mở form nhập thông tin thanh toán
                    using (FormPayment formPayment = new FormPayment(totalAmount, currentTableId, dateCheckIn, dateCheckOut, discountValue))
                    {
                        if (formPayment.ShowDialog() == DialogResult.OK)
                        {
                            // Cập nhật totalPrice và discount trước khi xử lý thanh toán
                            string updateTotalPriceSql = "USP_UpdateBillTotalPrice";
                            var lstUpdatePrice = new List<CustomParameter>()
                            {
                                new CustomParameter() { key = "@idBill", value = idBill.ToString() },
                                new CustomParameter() { key = "@totalPrice", value = totalAmount.ToString() },
                                new CustomParameter() { key = "@discount", value = ((int) discountValue).ToString()}
                            };
                            db.ExeCute(updateTotalPriceSql, lstUpdatePrice);

                            // Cập nhật phương thức thanh toán
                            string updateBillSql = "USP_GetReceiptByBillID";
                            var lstUpdate = new List<CustomParameter>()
                            {
                                new CustomParameter() { key = "@idBill", value = idBill.ToString() },
                                new CustomParameter() { key = "@paymentMethod", value = formPayment.PaymentMethod },
                                new CustomParameter() { key = "@customerMoney", value = formPayment.CustomerMoney.ToString() },
                                new CustomParameter() { key = "@changeMoney", value = formPayment.ChangeMoney.ToString() }
                            };
                            db.ExeCute(updateBillSql, lstUpdate);

                            CheckOut(idBill, (int)discountValue); // Cập nhật ngày checkout và giảm giá
                            MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Cập nhật giao diện
                            LoadBill(currentTableId);
                            LoadTable();
                        }
                    }
                }
               
            }
            else
            {
                MessageBox.Show("Không có hóa đơn nào cần thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID();  // load danh sách theo danh mục id (phân loại )
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn bàn hay chưa
            if (currentTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra xem đã chọn danh mục chưa
            if (cbbDanhMuc.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục món ăn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra xem đã chọn món ăn chưa
            if (cbbMonAn.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn món ăn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idFood = Convert.ToInt32(cbbMonAn.SelectedValue); // Lấy ID món ăn
            int count = (int)numDemMon.Value; // Lấy số lượng món
            string note = txtNote.Text;

            db = new Database();
            string checkBillSql = "USP_GetUncheckBillIDByTableID"; // SP kiểm tra hóa đơn chưa thanh toán

            var lstPra = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    key = "@idTable",
                    value = currentTableId.ToString()
                }
            };

            dt = db.SelectData(checkBillSql, lstPra);
            int idBill = -1;

            if (dt != null && dt.Rows.Count > 0)
            {
                // Lưu ý: cột trả về có thể là "id" thay vì "IDBill". Hãy kiểm tra SP của bạn.
                idBill = Convert.ToInt32(dt.Rows[0]["id"]);
            }
            else
            {
                InsertBill(currentTableId); // Tạo hóa đơn mới nếu chưa có
                dt = db.SelectData(checkBillSql, lstPra);
                if (dt != null && dt.Rows.Count > 0)
                {
                    idBill = Convert.ToInt32(dt.Rows[0]["id"]);
                }
            }

            if (idBill != -1)
            {
                InsertBillInfo(idBill, idFood, count, txtNote.Text); // Thêm món vào hóa đơn
                txtNote.Clear();
                LoadBill(currentTableId); // Cập nhật lại danh sách món trên hóa đơn
            }
            LoadTable();
        }

        private void btnGiamGia_Click(object sender, EventArgs e)
        {
            
        }

        //chuyển bàn
        private void SwitchTable(int tableA, int tableB)
        {           
            try
            {
                var lstPara = new List<CustomParameter>
                {
                    new CustomParameter 
                    { 
                        key = "@idTable1", 
                        value = tableA.ToString() 
                    },
                    new CustomParameter 
                    {
                        key = "@idTable2", 
                        value = tableB.ToString() 
                    }
                };

                int rowsAffected = db.ExeCute("USP_SwitchTable", lstPara);
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Chuyển bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadCbbTable(cbbChuyenBan); // Cập nhật lại danh sách bàn sau khi chuyển
                }
                else
                {
                    MessageBox.Show("Chuyển bàn thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chuyển bàn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private void btnChuyenBan_Click(object sender, EventArgs e)
        {


            // Kiểm tra xem flpTable.Tag có chứa ID bàn không
            if (currentTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn cần chuyển!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy tên bàn hiện tại từ danh sách bàn
            string currentTableName = GetTableNameById(currentTableId);

            // Kiểm tra xem ComboBox có bàn đích hợp lệ không
            if (cbbChuyenBan.SelectedItem == null || !int.TryParse(cbbChuyenBan.SelectedValue?.ToString(), out int targetTableId))
            {
                MessageBox.Show("Vui lòng chọn bàn đích để chuyển!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy tên bàn đích từ ComboBox
            string targetTableName = cbbChuyenBan.Text; // Hoặc dùng GetTableNameById(targetTableId)

            // Kiểm tra xem bàn đích có trùng bàn hiện tại không
            if (currentTableId == targetTableId)
            {
                MessageBox.Show("Bàn đích không thể trùng với bàn hiện tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn chuyển từ bàn '{currentTableName}' sang bàn '{targetTableName}' không?",
                                                  "Xác nhận chuyển bàn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SwitchTable(currentTableId, targetTableId);
                LoadTable();
            }


        }
        //lấy tên bàn
        private string GetTableNameById(int tableId)
        {
            string sql = "USP_GetTableList";
            DataTable dt = db.SelectData(sql);

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy danh sách bàn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

            // Kiểm tra nếu DataTable có cột "id"
            if (!dt.Columns.Contains("id"))
            {
                MessageBox.Show("Lỗi: Dữ liệu bàn không chứa cột 'id'. Kiểm tra lại stored procedure!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

            DataRow[] rows = dt.Select($"id = {tableId}");
            if (rows.Length > 0)
            {
                return rows[0]["name"].ToString();
            }

            return "Không tìm thấy bàn";
        }
        public static decimal DiscountValue = 0;
        private void nmGiamGia_ValueChanged(object sender, EventArgs e)
        {
            DiscountValue = (int)nmGiamGia.Value;  // Cập nhật giá trị khi người dùng thay đổi
        }
    }
}
