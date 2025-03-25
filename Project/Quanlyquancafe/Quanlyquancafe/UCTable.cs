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
    public partial class UCTable : UserControl
    {
        private Database db;
        public event EventHandler TableUpdated; // Sự kiện cập nhật danh sách bàn
        public UCTable()
        {

            db = new Database();
            InitializeComponent();
        }
       

        public void LoadDSTable()
        {

            var timkiem = txtTimKiem.Text.Trim();
            var lstPra = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    key = "@timkiem",
                    value = timkiem
                }
            };
            var dt = db.SelectData("[LoadTable]", lstPra);
            dgvTable.DataSource = dt;
        }

        private void UCTable_Load(object sender, EventArgs e)
        {
            LoadDSTable();

            dgvTable.Columns[1].HeaderText = "Tên bàn";
            dgvTable.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvTable.Columns[2].HeaderText = "Trạng thái bàn";
            dgvTable.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
         
            dgvTable.DefaultCellStyle.ForeColor = Color.Black;
            txtTrangThai.Text = "Trống";
        }

        private void btnthemban_Click(object sender, EventArgs e)
        {
            if (txtTenBan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên bàn", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra trạng thái không được là "Có người"
            if (txtTrangThai.Text.Trim().ToLower() == "có người")
            {
                MessageBox.Show("Thêm mới trạng thái phải để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var lstPara = new List<CustomParameter>()
            {
                new CustomParameter
                {
                    key = "@tenBan",
                    value = txtTenBan.Text
                },
                new CustomParameter
                {
                    key = "@trangThai",
                    value = "Trống" // Đảm bảo trạng thái luôn là "Trống"
                }
            };
            if (db.ExeCute("[ThemTable]", lstPara) == 1)
            {
                MessageBox.Show("Thêm mới bàn thành công!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDSTable();
                dgvTable.Refresh();
                txtTenBan.Text = null;
                txtTrangThai.Text = "Trống"; // Đặt lại trạng thái sau khi thêm

            }
            // Gọi sự kiện để thông báo cập nhật
            TableUpdated?.Invoke(this, EventArgs.Empty);
        }
        int id = -1;
        private void btnsuaban_Click(object sender, EventArgs e)
        {
            if (id < 0)
            {
                MessageBox.Show("Vui lòng chọn bàn cần cập nhật", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtTenBan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên bàn", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var lstPara = new List<CustomParameter>()
            {
                 new CustomParameter
                {
                    key = "@id",
                    value = id.ToString()
                },
                new CustomParameter
                {
                    key = "@tenBan",
                    value = txtTenBan.Text
                },
                new CustomParameter
                {
                    key = "@trangThai",
                    value = txtTrangThai.Text
                }
            };
            if (db.ExeCute("[CapNhatTable]", lstPara) == 1)
            {
                MessageBox.Show("Cập nhật bàn thành công!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDSTable();
                txtTenBan.Text = null;
                txtTrangThai.Text = "Trống"; // Đặt lại trạng thái sau khi thêm
                id = -1;
               
            }
            // Gọi sự kiện thông báo cập nhật
            TableUpdated?.Invoke(this, EventArgs.Empty);
        }

        private void btnxoaban_Click(object sender, EventArgs e)
        {
            if (id < 0)
            {
                MessageBox.Show("Vui lòng chọn bàn cần xóa", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa bàn này hay không?", "Xác nhận", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var lstPara = new List<CustomParameter>()
                {
                     new CustomParameter
                    {
                        key = "@id",
                        value = id.ToString()
                    }

                };
                if (db.ExeCute("XoaTable", lstPara) == 1)
                {
                    MessageBox.Show("Xóa bàn thành công!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDSTable();
                    txtTenBan.Text = null;
                    txtTrangThai.Text = "Trống"; // Đặt lại trạng thái sau khi thêm
                    id = -1;
                }
                // Gọi sự kiện thông báo cập nhật
                TableUpdated?.Invoke(this, EventArgs.Empty);
            }
        }

        private void btnTimban_Click(object sender, EventArgs e)
        {
            LoadDSTable();
        }
        

        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = int.Parse(dgvTable.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtIDBan.Text = id.ToString();
                txtTenBan.Text = dgvTable.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtTrangThai.Text = dgvTable.Rows[e.RowIndex].Cells[2].Value.ToString();
                
            }
        }
    }
}
