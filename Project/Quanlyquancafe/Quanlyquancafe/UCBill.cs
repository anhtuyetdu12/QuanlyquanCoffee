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
    public partial class UCBill : UserControl
    {
        private Database db;
        private DataTable dt;

        private int currentPage = 1;
        private int totalPages = 1;
        private const int rowsPerPage = 10;

        public UCBill()
        {
            InitializeComponent();
     
            LoadDateTimePickerBill();
            LoadListBillByDate(dtpBatDau.Value, dtpKetThuc.Value);
        }

       
        private void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpBatDau.Value = new DateTime(today.Year, today.Month, 1);
            dtpKetThuc.Value = dtpBatDau.Value.AddMonths(1).AddDays(-1);
        }

        private void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            db = new Database();
            string sql = "USP_GetListBillByDate"; 

            var lstPra = new List<CustomParameter>()
            {
                 new CustomParameter()
                 {
                    key = "@checkIn",
                    value = checkIn.ToString("yyyy-MM-dd")
                 },
                 new CustomParameter()
                 {
                    key = "@checkOut",
                    value = checkOut.ToString("yyyy-MM-dd")
                 }
            };

            var dt = db.SelectData(sql, lstPra);

            dgvBill.DataSource = dt;
           
            
        }

        private void LoadListBillByDateAndPage(DateTime checkIn, DateTime checkOut, int pageNumber)
        {
            db = new Database();
            string sql = "USP_GetListBillByDateAndPage";

            var lstPra = new List<CustomParameter>()
            {
                 new CustomParameter()
                 {
                    key = "@checkIn",
                    value = checkIn.ToString("yyyy-MM-dd")
                 },
                 new CustomParameter()
                 {
                    key = "@checkOut",
                    value = checkOut.ToString("yyyy-MM-dd")
                 },
                 new CustomParameter()
                 {
                    key = "@page",
                    value = pageNumber.ToString()
                 }
            };

            var dt = db.SelectData(sql, lstPra);
            txtPageBill.Text = $"{pageNumber}";

        }

        //xdinh tổng số trang
        private void GetNumBillByDate(DateTime checkIn, DateTime checkOut)
        {
            db = new Database();
            string sql = "USP_GetNumBillByDate";

            var lstPra = new List<CustomParameter>()
            {
                 new CustomParameter()
                 {
                    key = "@checkIn",
                    value = checkIn.ToString("yyyy-MM-dd")
                 },
                 new CustomParameter()
                 {
                    key = "@checkOut",
                    value = checkOut.ToString("yyyy-MM-dd")
                 }
            };

            var dt = db.SelectData(sql, lstPra);

            if (dt.Rows.Count > 0)
            {
                int numBill = Convert.ToInt32(dt.Rows[0][0]);
                totalPages = (int)Math.Ceiling((double)numBill / rowsPerPage);
            }

        }

        private void btnThongke_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpBatDau.Value, dtpKetThuc.Value);
            currentPage = 1;
            GetNumBillByDate(dtpBatDau.Value, dtpKetThuc.Value);
            LoadListBillByDateAndPage(dtpBatDau.Value, dtpKetThuc.Value, currentPage);
        }

        private void UCBill_Load(object sender, EventArgs e)
        {
            dgvBill.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            txtPageBill.Text = "1";
            LoadListBillByDateAndPage(dtpBatDau.Value, dtpKetThuc.Value, currentPage);

        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentPage = totalPages;
            LoadListBillByDateAndPage(dtpBatDau.Value, dtpKetThuc.Value, currentPage);
        }

        private void btnPreviours_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadListBillByDateAndPage(dtpBatDau.Value, dtpKetThuc.Value, currentPage);
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadListBillByDateAndPage(dtpBatDau.Value, dtpKetThuc.Value, currentPage);
            }
        }
    }
}
