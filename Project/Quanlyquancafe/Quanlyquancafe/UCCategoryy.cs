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
    public partial class UCCategoryy : UserControl
    {
        private Database db;
        public UCCategoryy()
        {
            db = new Database();
            InitializeComponent();
        }

        private void UCCategoryy_Load(object sender, EventArgs e)
        {
            LoadCategory();
            dgvCategory.Columns[1].HeaderText = "Tên danh mục";
            dgvCategory.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCategory.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void LoadCategory()
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
            var dt = db.SelectData("[LoadCategory]", lstPra);
            dgvCategory.DataSource = dt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTendanhmuc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên danh mục", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var lstPara = new List<CustomParameter>()
            {
                new CustomParameter
                {
                    key = "@tenDM",
                    value = txtTendanhmuc.Text
                }
            };
            if (db.ExeCute("[ThemCategory]", lstPara) == 1)
            {
                MessageBox.Show("Thêm mới danh mục thành công!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategory();
                dgvCategory.Refresh();
                txtTendanhmuc.Text = null;

            }
        }

        private void btnTimKiemDM_Click(object sender, EventArgs e)
        {
            LoadCategory();
        }

        int id = -1;

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (id < 0)
            {
                MessageBox.Show("Vui lòng chọn danh mục cần cập nhật", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtTendanhmuc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên danh mục", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    key = "@tenDM",
                    value = txtTendanhmuc.Text
                }
            };
            if (db.ExeCute("[CapNhatCategory]", lstPara) == 1)
            {
                MessageBox.Show("Cập nhật danh mục thành công!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategory();
                txtTendanhmuc.Text = null;
                id = -1;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (id < 0)
            {
                MessageBox.Show("Vui lòng chọn danh mục cần xóa", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa danh mục này hay không?", "Xác nhận", MessageBoxButtons.YesNo,
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
                if (db.ExeCute("XoaCategory", lstPara) == 1)
                {
                    MessageBox.Show("Xóa danh mục thành công!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCategory();
                    txtTendanhmuc.Text = null;
                    id = -1;
                }
            }
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = int.Parse(dgvCategory.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtIDdanhmuc.Text = id.ToString();
                txtTendanhmuc.Text = dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }
    }
}
