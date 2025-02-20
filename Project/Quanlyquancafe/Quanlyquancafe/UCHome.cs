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
        public UCHome()
        {
            InitializeComponent();
            LoadTable();
        }

        //Load danh sach ban
        void LoadTable()
        {
            flpTable.Controls.Clear();

            Database db = new Database();
            string sql = "USP_GetTableList"; // Tên Stored Procedure

            DataTable dt = db.SelectData(sql);

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
                    btn.Tag = row["id"];
                    btn.Click += Btn_Click;

                    flpTable.Controls.Add(btn);
                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            int tableId = (int)clickedButton.Tag;
            MessageBox.Show("Bạn đã chọn bàn có ID: " + tableId);
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {

        }
    }
}
