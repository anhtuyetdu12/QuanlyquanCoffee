using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlyquancafe
{
    public partial class UCMenu : UserControl
    {
        private Database db;

        public UCMenu()
        {          
            InitializeComponent();
        }

        private void UCMenu_Load(object sender, EventArgs e)
        {
            db = new Database();

            LoadMenu();
            LoadFoodcbb();
            dgvMenu.Columns[1].HeaderText = "Ngày thêm";
            dgvMenu.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvMenu.Columns[2].HeaderText = "Số lượng";
            dgvMenu.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvMenu.Columns[3].HeaderText = "Mã món";
            dgvMenu.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvMenu.Columns[4].HeaderText = "Tên món";
            dgvMenu.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvMenu.DefaultCellStyle.ForeColor = Color.Black;
        }
        public void LoadMenu()
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
            var dt = db.SelectData("[LoadMenu]", lstPra);
            dgvMenu.DataSource = dt;
        }
        public void LoadFoodcbb()
        {
            var dt = db.SelectData("selectMonAn"); // Gọi stored procedure hoặc query để lấy danh mục
            cbbMon.DataSource = dt;
            cbbMon.DisplayMember = "name"; // Cột chứa tên danh mục
            cbbMon.ValueMember = "id"; // Cột chứa ID danh mục
        }

        private void btnTimMenu_Click(object sender, EventArgs e)
        {
            LoadMenu();
        }

        private void btnthemmenu_Click(object sender, EventArgs e)
        {
            
            if (cbbMon.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn tên món", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numSoLuong.Value <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra ngày nhập có đúng không
            DateTime ngayThem;
            if (!DateTime.TryParseExact(mtbNgayThem.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngayThem))
            {
                MessageBox.Show("Ngày nhập không hợp lệ. Vui lòng nhập theo định dạng dd/MM/yyyy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            var lstPara = new List<CustomParameter>()
            {
                new CustomParameter
                {
                    key = "@ngayThem",
                    value = ngayThem.ToString("yyyy-MM-dd")
                },               
                new CustomParameter
                {
                    key = "@maMon",
                    value = cbbMon.SelectedValue.ToString()
                },
                new CustomParameter
                {
                    key = "@soLuong",
                    value = numSoLuong.Value.ToString()
                }

            };
            if (db.ExeCute("[ThemMenu]", lstPara) == 1)
            {
                MessageBox.Show("Thêm mới menu thành công!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMenu();
                dgvMenu.Refresh();
                cbbMon.SelectedIndex = 0;
                numSoLuong.Value = 0;
               
            }
            mtbNgayThem.Text = DateTime.Now.ToString("dd/MM/yyyy ");
        }
        int id = -1;

        private void btnsuamenu_Click(object sender, EventArgs e)
        {
            if (id < 0)
            {
                MessageBox.Show("Vui lòng chọn menu cần cập nhật", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbbMon.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn tên món", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numSoLuong.Value <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Thêm kiểm tra ngày nhập
            DateTime ngayThem;
            if (!DateTime.TryParseExact(mtbNgayThem.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out ngayThem))
            {
                MessageBox.Show("Ngày nhập không hợp lệ. Vui lòng nhập theo định dạng dd/MM/yyyy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    key = "@ngayThem",
                    value = ngayThem.ToString("yyyy-MM-dd")
                },               
                new CustomParameter
                {
                    key = "@maMon",
                    value = cbbMon.SelectedValue.ToString()
                },
                new CustomParameter
                {
                    key = "@soLuong",
                    value = numSoLuong.Value.ToString()
                }
            };
            if (db.ExeCute("[CapNhatMenu]", lstPara) == 1)
            {
                MessageBox.Show("Cập nhật menu thành công!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMenu();
                dgvMenu.Refresh();
                cbbMon.SelectedIndex = 0;
                numSoLuong.Value = 0;
                id = -1;

            }
            mtbNgayThem.Text = DateTime.Now.ToString("dd/MM/yyyy ");
        }

        private void btnxoamenu_Click(object sender, EventArgs e)
        {
            if (id < 0)
            {
                MessageBox.Show("Vui lòng chọn menu cần xóa", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa menu này hay không?", "Xác nhận", MessageBoxButtons.YesNo,
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
                if (db.ExeCute("XoaMenu", lstPara) == 1)
                {
                    MessageBox.Show("Xóa menu thành công!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMenu();
                    dgvMenu.Refresh();
                    cbbMon.SelectedIndex = 0;
                    numSoLuong.Value = 0;
                    id = -1;
                }
                mtbNgayThem.Text = DateTime.Now.ToString("dd/MM/yyyy ");
            }
        }

        private void dgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvMenu.Rows.Count)
            {
                DataGridViewRow row = dgvMenu.Rows[e.RowIndex];

                id = int.Parse(dgvMenu.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtIDThucDon.Text = id.ToString();

                // Định dạng ngày chỉ hiển thị dd/MM/yyyy
                if (row.Cells[1].Value != null && DateTime.TryParse(row.Cells[1].Value.ToString(), out DateTime ngayThem))
                {
                    mtbNgayThem.Text = ngayThem.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtbNgayThem.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }

                if (dgvMenu.Rows[e.RowIndex].Cells[2].Value != null)
                {
                    string value = dgvMenu.Rows[e.RowIndex].Cells[2].Value.ToString();
                    if (int.TryParse(value, out int soLuong))
                    {
                        numSoLuong.Value = soLuong;
                    }
                    else
                    {
                        numSoLuong.Value = 0; 
                    }
                }
               
                cbbMon.Text = dgvMenu.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }
    }
}
