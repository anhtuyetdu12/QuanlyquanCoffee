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
using System.Xml.Linq;

namespace Quanlyquancafe
{
    public partial class UCProduct : UserControl
    {
        private Database db;
        public UCProduct()
        {
            InitializeComponent();
        }      

       
        private void UCProduct_Load(object sender, EventArgs e)
        {
            db = new Database();
            LoadFood();
            LoadDanhMuc();
            dgvFood.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvFood.Columns[1].HeaderText = "Tên món";
            dgvFood.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvFood.Columns[2].HeaderText = "Giá";
            dgvFood.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvFood.Columns[3].HeaderText = "Mã danh mục";
            dgvFood.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvFood.Columns[4].HeaderText = "Tên danh mục";
            dgvFood.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvFood.Columns[5].HeaderText = "Số lượng";
            dgvFood.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvFood.Columns[6].HeaderText = "Ngày thêm";
            dgvFood.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvFood.DefaultCellStyle.ForeColor = Color.Black;
        }
        public void LoadFood()
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
            var dt = db.SelectData("[LoadFood]", lstPra);
            dgvFood.DataSource = dt;
        }
        public void LoadDanhMuc()
        {
            var dt = db.SelectData("selectDanhMuc"); // Gọi stored procedure hoặc query để lấy danh mục
            cbbDanhMuc.DataSource = dt;
            cbbDanhMuc.DisplayMember = "Tên danh mục"; // Cột chứa tên danh mục
            cbbDanhMuc.ValueMember = "ID"; // Cột chứa ID danh mục
        }

        private void btnTimFood_Click(object sender, EventArgs e)
        {
            LoadFood();
        }

        private void btnthemfood_Click(object sender, EventArgs e)
        {
            if (txtIDMon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã món", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtTenMon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên món", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            if (numGia.Value <= 0)
            {
                MessageBox.Show("Giá tiền phải lớn hơn 0", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbbDanhMuc.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn danh mục", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var lstPara = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    key = "@tenMon",
                    value = txtTenMon.Text
                },
                new CustomParameter()
                {
                    key = "@gia",
                    value = numGia.Value.ToString()
                },
                new CustomParameter()
                {
                    key = "@idDanhMuc",
                    value = cbbDanhMuc.SelectedValue.ToString()
                }
            };
            if (db.ExeCute("[ThemFood]", lstPara) == 1)
            {
                MessageBox.Show("Thêm mới món thành công!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadFood();
                dgvFood.Refresh();
                txtIDMon.Text = null;
                txtTenMon.Text = null;
                numGia.Value = 0;
                cbbDanhMuc.SelectedIndex = 0;
            }
        }
        int id = -1;
        private void btnsuafood_Click(object sender, EventArgs e)
        {

            if (id < 0)
            {
                MessageBox.Show("Vui lòng chọn món cần cập nhật", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtIDMon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã món", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtTenMon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên món", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            if (numGia.Value <= 0)
            {
                MessageBox.Show("Giá tiền phải lớn hơn 0", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            var lstPara = new List<CustomParameter>()
            {
                 new CustomParameter
                {
                    key = "@id",
                    value = id.ToString()
                },
                new CustomParameter()
                {
                    key = "@tenMon",
                    value = txtTenMon.Text
                },
                new CustomParameter()
                {
                    key = "@gia",
                    value = numGia.Value.ToString()
                },
                new CustomParameter()
                {
                    key = "@idDanhMuc",
                    value = cbbDanhMuc.SelectedValue.ToString()
                }
            };
            if (db.ExeCute("[CapNhatFood]", lstPara) == 1)
            {
                MessageBox.Show("Cập nhật món thành công!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadFood();
                dgvFood.Refresh();
                txtIDMon.Text = null;
                txtTenMon.Text = null;
                numGia.Value = 0;
                cbbDanhMuc.SelectedIndex = 0;
                id = -1;

            }
        }

        private void btnxoafood_Click(object sender, EventArgs e)
        {
            if (id < 0)
            {
                MessageBox.Show("Vui lòng chọn món cần xóa", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa món này hay không?", "Xác nhận", MessageBoxButtons.YesNo,
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
                if (db.ExeCute("XoaFood", lstPara) == 1)
                {
                    MessageBox.Show("Xóa món thành công!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadFood();
                    dgvFood.Refresh();
                    txtIDMon.Text = null;
                    txtTenMon.Text = null;
                    numGia.Value = 0;
                    cbbDanhMuc.SelectedIndex = 0;
                    id = -1;
                }

            }
        }

        private void dgvFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = int.Parse(dgvFood.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtIDMon.Text = id.ToString();
                txtTenMon.Text = dgvFood.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (dgvFood.Rows[e.RowIndex].Cells[2].Value != null)
                {
                    string value = dgvFood.Rows[e.RowIndex].Cells[2].Value.ToString();
                    if (int.TryParse(value, out int soLuong))
                    {
                        numGia.Value = soLuong;
                    }
                    else
                    {
                        numGia.Value = 0;
                    }
                }
                cbbDanhMuc.SelectedValue = dgvFood.Rows[e.RowIndex].Cells[3].Value;

            }
        }
    }
}
