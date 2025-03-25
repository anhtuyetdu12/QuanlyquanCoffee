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
    public partial class UCMenu : UserControl
    {
        private Database db;

        public UCMenu()
        {
            db = new Database();

            InitializeComponent();
        }

        private void UCMenu_Load(object sender, EventArgs e)
        {
            LoadMenu();

            dgvMenu.Columns[1].HeaderText = "Ngày thêm";
            dgvMenu.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvMenu.Columns[2].HeaderText = "Số lượng";
            dgvMenu.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvMenu.Columns[3].HeaderText = "Tên món";
            dgvMenu.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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

        private void btnTimMenu_Click(object sender, EventArgs e)
        {
            LoadMenu();
        }

        private void btnthemmenu_Click(object sender, EventArgs e)
        {
            if (txtTenMon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên món", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numSoLuong.Value <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           

            var lstPara = new List<CustomParameter>()
            {
                new CustomParameter
                {
                    key = "@ngayThem",
                    value = dtpNgay.Value == null ? DateTime.Now.ToString("yyyy-MM-dd") : dtpNgay.Value.ToString("yyyy-MM-dd")
                },               
                new CustomParameter
                {
                    key = "@tenMon",
                    value = txtTenMon.Text
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
                txtTenMon.Text = null;
                numSoLuong.Value = 0;
            }
        }
        int id = -1;

        private void btnsuamenu_Click(object sender, EventArgs e)
        {
            if (id < 0)
            {
                MessageBox.Show("Vui lòng chọn menu cần cập nhật", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtTenMon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên món", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numSoLuong.Value <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    value = dtpNgay.Value == null ? DateTime.Now.ToString("yyyy-MM-dd") : dtpNgay.Value.ToString("yyyy-MM-dd")
                },               
                new CustomParameter
                {
                    key = "@tenMon",
                    value = txtTenMon.Text
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
                txtTenMon.Text = null;
                numSoLuong.Value = 0;
                id = -1;

            }
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
                    txtTenMon.Text = null;
                    numSoLuong.Value = 0;
                    id = -1;
                }
               
            }
        }

        private void dgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvMenu.Rows.Count)
            {
                DataGridViewRow row = dgvMenu.Rows[e.RowIndex];

                id = int.Parse(dgvMenu.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtIDThucDon.Text = id.ToString();
                // dtpNgay.Value = DateTime.Parse(dgvMenu.Rows[e.RowIndex].Cells[1].Value.ToString());
                // Kiểm tra và lấy ngày
                if (row.Cells[1].Value != null && DateTime.TryParse(row.Cells[1].Value.ToString(), out DateTime dateValue))
                {
                    dtpNgay.Value = dateValue;
                }
                else
                {
                    dtpNgay.Value = DateTime.Now; // Ngày mặc định
                }

                numSoLuong.Value = int.Parse(dgvMenu.Rows[e.RowIndex].Cells[2].Value.ToString());
                txtTenMon.Text = dgvMenu.Rows[e.RowIndex].Cells[3].Value.ToString();


            }
        }
    }
}
