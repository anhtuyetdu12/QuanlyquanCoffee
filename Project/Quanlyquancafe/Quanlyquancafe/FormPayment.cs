using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlyquancafe
{
    public partial class FormPayment : Form
    {      
        private int tableId;
        private DateTime dateCheckOut;
        private DateTime dateCheckIn;

        private DataTable billItemsTable;
        public decimal TotalAmount; // Tổng tiền cần thanh toán
        public decimal CustomerMoney; // Số tiền khách đưa
        public decimal ChangeMoney; // Tiền thối lại
        public string PaymentMethod; // Phương thức thanh toán

        private bool isPrinted = false; // Biến kiểm tra đã in hay chưa
        public decimal DiscountAmount = 0; // Biến lưu số tiền giảm giá

        private PrintDocument printDocument = new PrintDocument();
        public FormPayment(decimal totalAmount, int tableId, DateTime dateCheckIn, DateTime dateCheckOut, decimal discountAmount)
        {
            InitializeComponent();
            TotalAmount = totalAmount;
            txtTotal.Text = TotalAmount.ToString("N0") + " VND";
            this.tableId = tableId;
            this.dateCheckIn = dateCheckIn;
            this.dateCheckOut = dateCheckOut;
            lblGiamGia.Text = DiscountAmount.ToString("N0") + " %";

            printDocument.PrintPage += PrintDocument_PrintPage;

            lblNgayCheckIn.Text = dateCheckIn.ToString("dd/MM/yyyy HH:mm:ss");
            lblNgayXuat.Text = dateCheckOut.ToString("dd/MM/yyyy HH:mm:ss"); // Hiển thị ngày xuất hóa đơn

            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            LoadBill(tableId); // Gọi phương thức tải hóa đơn
        }
        private void Payment_Load(object sender, EventArgs e)
        {
            // Thêm phương thức thanh toán vào ComboBox khi Form được load
            cbbPhuongThuc.Items.Add("Thanh toán tiền mặt");
            cbbPhuongThuc.Items.Add("Chuyển khoản");
        }

        private void LoadBill(int tableId)
        {
            try
            {
                Database db = new Database();
                string query = "USP_LoadBill"; // Stored Procedure lấy hóa đơn

                List<CustomParameter> parameters = new List<CustomParameter>
                {
                    new CustomParameter { key = "@idTable", value = tableId.ToString() }
                };

                DataSet ds = db.SelectDataSet(query, parameters);  // Gọi truy vấn

                if (ds != null && ds.Tables.Count > 1) // Kiểm tra nếu có 2 bảng
                {

                     billItemsTable = ds.Tables[0]; // Bảng danh sách món ăn
                    DataTable billTable = ds.Tables[1]; // Bảng thông tin hóa đơn

                    if (billTable.Rows.Count > 0)
                    {
                        lblBan.Text = "Bàn " + tableId.ToString();

                        object dateCheckInValue = billTable.Rows[0]["NgayTao"];
                        object dateCheckOutValue = billTable.Rows[0]["NgayXuat"];
                        object discountValue = billTable.Rows[0]["GiamGia"];
                        object totalBeforeDiscountValue = billTable.Rows[0]["TongTienTruocGiam"];
                        object totalAfterDiscountValue = billTable.Rows[0]["TongTienSauGiam"];

                        lblNgayCheckIn.Text = dateCheckInValue != DBNull.Value
                            ? Convert.ToDateTime(dateCheckInValue).ToString("dd/MM/yyyy HH:mm:ss")
                            : "Không có dữ liệu";

                        lblNgayXuat.Text = dateCheckOutValue != DBNull.Value
                            ? Convert.ToDateTime(dateCheckOutValue).ToString("dd/MM/yyyy HH:mm:ss")
                            : DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                        // Nếu có giảm giá thì lấy giá trị giảm giá
                        DiscountAmount = discountValue != DBNull.Value ? Convert.ToDecimal(discountValue) : 0;

                        // Hiển thị giảm giá trên giao diện
                        lblGiamGia.Text = DiscountAmount.ToString("N0") + " %";


                        // Tính tổng tiền từ bảng danh sách món ăn
                        decimal total = 0;
                        foreach (DataRow row in billItemsTable.Rows)
                        {
                            total += Convert.ToDecimal(row["ThanhTien"]);
                        }

                        // Áp dụng giảm giá
                        TotalAmount = total - DiscountAmount;
                        txtTotal.Text = TotalAmount.ToString("N0") + " VND";
                    }
                    else
                    {
                        MessageBox.Show("Không có hóa đơn cho bàn này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi dữ liệu hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        //in hóa đơn 
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (billItemsTable != null && billItemsTable.Rows.Count > 0)
            {
                Graphics g = e.Graphics;
                Font font = new Font("Arial", 12);
                Font boldFont = new Font("Arial", 12, FontStyle.Bold);
                float yPos = 20;
                float leftMargin = e.MarginBounds.Left;


                // In tiêu đề căn giữa
                string title = "HÓA ĐƠN THANH TOÁN";
                Font titleFont = new Font("Arial", 14, FontStyle.Bold);
                // Lấy kích thước chiều rộng của tiêu đề
                SizeF titleSize = g.MeasureString(title, titleFont);
                // Tính vị trí x để căn giữa
                float centerX = e.MarginBounds.Left + (e.MarginBounds.Width - titleSize.Width) / 2;
                // Vẽ tiêu đề ở vị trí căn giữa
                g.DrawString(title, titleFont, Brushes.Black, centerX, yPos);
                yPos += 30;

                // In thông tin bàn và ngày xuất hóa đơn
                g.DrawString($"Bàn: {lblBan.Text}", font, Brushes.Black, leftMargin, yPos);
                yPos += 25;
                g.DrawString($"Ngày Check-in: {lblNgayCheckIn.Text}", font, Brushes.Black, leftMargin, yPos);
                yPos += 25;
                g.DrawString($"Ngày Check-out: {lblNgayXuat.Text}", font, Brushes.Black, leftMargin, yPos);
                yPos += 30;

                // Xác định vị trí của các cột
                float col1 = leftMargin;         // Cột "Tên món"
                float col2 = col1 + 200;         // Cột "Số lượng"
                float col3 = col2 + 80;          // Cột "Đơn giá"
                float col4 = col3 + 100;         // Cột "Thành tiền"

                // In tiêu đề cột
                g.DrawString("Tên món", boldFont, Brushes.Black, col1, yPos);
                g.DrawString("SL", boldFont, Brushes.Black, col2, yPos);
                g.DrawString("Đơn giá", boldFont, Brushes.Black, col3, yPos);
                g.DrawString("Thành tiền", boldFont, Brushes.Black, col4, yPos);
                yPos += 20;

                g.DrawLine(Pens.Black, leftMargin, yPos, e.MarginBounds.Right, yPos);
                yPos += 10;

                // In danh sách món ăn
                foreach (DataRow row in billItemsTable.Rows)
                {
                    g.DrawString(row["TenMon"].ToString(), font, Brushes.Black, col1, yPos);
                    g.DrawString(row["SoLuong"].ToString(), font, Brushes.Black, col2, yPos);
                    g.DrawString(row["DonGia"].ToString(), font, Brushes.Black, col3, yPos);
                    g.DrawString(row["ThanhTien"].ToString(), font, Brushes.Black, col4, yPos);
                    yPos += 20;
                }

                g.DrawLine(Pens.Black, leftMargin, yPos, e.MarginBounds.Right, yPos);
                yPos += 10;

                // In tổng tiền
                g.DrawString($"Giảm giá: {DiscountAmount.ToString("N0")} VND", font, Brushes.Black, leftMargin, yPos);
                yPos += 25;
                g.DrawString($"Tổng tiền: {TotalAmount.ToString("N0")} VND", boldFont, Brushes.Black, leftMargin, yPos);
                yPos += 30;

                // In phương thức thanh toán, tiền khách đưa & tiền thối lại
                g.DrawString($"Phương thức thanh toán: {cbbPhuongThuc.Text}", font, Brushes.Black, leftMargin, yPos);
                yPos += 30;
                g.DrawString($"Tiền khách đưa: {txtTienKhachDua.Text} VND", font, Brushes.Black, leftMargin, yPos);
                yPos += 30;
                g.DrawString($"Tiền thối lại: {txtTienThoi.Text} VND", font, Brushes.Black, leftMargin, yPos);
               
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtTienKhachDua.Text.Replace(",", "").Replace(" VND", ""), out decimal customerMoney) || customerMoney < TotalAmount)
            {
                MessageBox.Show("Số tiền khách đưa không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra nếu chưa in hóa đơn
            if (!isPrinted)
            {
                MessageBox.Show("Vui lòng in hóa đơn trước khi xác nhận!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            CustomerMoney = customerMoney;
            ChangeMoney = CustomerMoney - TotalAmount;
            PaymentMethod = cbbPhuongThuc.SelectedItem.ToString();


            DialogResult = DialogResult.OK; // Xác nhận thông tin hợp lệ
            Close();
        }

        private void ptbExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng form  thanh toán hóa đơn này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close(); // Đóng form nhỏ
            }
        }

        private void cbbPhuongThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedMethod = cbbPhuongThuc.SelectedItem.ToString();          
        }

        private void txtKhachDua_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtTienKhachDua.Text.Replace(",", "").Replace(" VND", ""), out decimal tienKhachDua))
            {
                decimal tienPhaiTra = TotalAmount; // Lấy tổng tiền từ biến TotalAmount
                decimal tienThoi = tienKhachDua - tienPhaiTra;

                if (tienThoi >= 0)
                {
                    txtTienThoi.Text =  tienThoi.ToString("N0") + " VND";
                    txtTienThoi.ForeColor = Color.Green; // Màu xanh nếu đủ tiền
                }
                else
                {
                    txtTienThoi.Text =  Math.Abs(tienThoi).ToString("N0") + " VND";
                    txtTienThoi.ForeColor = Color.Red; // Màu đỏ nếu thiếu tiền
                }
            }
            else
            {
                txtTienThoi.Text = ""; // Xóa nội dung nếu nhập sai định dạng
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (TotalAmount <= 0)
            {
                MessageBox.Show("Không có hóa đơn để in!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hiển thị hộp thoại xem trước trước khi in
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();

            // Đánh dấu đã in hóa đơn
            isPrinted = true;


            // Nếu muốn in ngay, thay bằng: printDocument.Print();

            MessageBox.Show("In hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
