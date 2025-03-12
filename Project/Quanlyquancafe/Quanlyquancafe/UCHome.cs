using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public UCHome()
        {
            InitializeComponent();
            LoadTable();
        }

        //Load danh sach ban
        void LoadTable()
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

        //show hóa đơn ra cụ thể
        private void Btn_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            int tableId = (int)clickedButton.Tag; // lấy ID bàn được chọn

            LoadBill(tableId);
        }

        // Load ds bill theo bàn 
        void LoadBill(int tableId)
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
                 
                    lvBill.Items.Add(item);
                    tongTien += Convert.ToDouble(row["ThanhTien"]); // có dấu phẩy động 
                }
            }
            // Hiển thị tổng tiền vào txtTongTien với định dạng tiền tệ
            txtTongTien.Text = tongTien.ToString("N0") + " VND";
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {

        }
    }
}
