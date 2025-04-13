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

        //lay danh sach bill theo ngay
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

        private DataTable LoadListBillByDateAndPage(DateTime checkIn, DateTime checkOut, int pageNumber)
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

            return dt;
        }

        //xdinh tổng số trang
        private int GetNumBillByDate(DateTime checkIn, DateTime checkOut)
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
                return Convert.ToInt32(dt.Rows[0][0]);  // giả sử cột đầu tiên là tổng số bản ghi
            }
            return 0;

        }

        private void btnThongke_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpBatDau.Value, dtpKetThuc.Value);
          
           
        }

        private void UCBill_Load(object sender, EventArgs e)
        {
            dgvBill.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            txtPageBill.Text = "1";
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            int sumRecord = GetNumBillByDate(dtpBatDau.Value, dtpKetThuc.Value);

            int lastPage = sumRecord / 10;

            if(sumRecord % 10 != 0)
            {
                lastPage++;
            }
            txtPageBill.Text = lastPage.ToString();

        }

        private void btnPreviours_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txtPageBill.Text);

            if(page > 1)
            {
                page--;
            }
            txtPageBill.Text = page.ToString();
                
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txtPageBill.Text);
            int sumRecord = GetNumBillByDate(dtpBatDau.Value, dtpKetThuc.Value);

            if(page < sumRecord)
            {
                page++;
            }
            txtPageBill.Text = page.ToString();
         
        }

        private void txtPageBill_TextChanged(object sender, EventArgs e)
        {
            dgvBill.DataSource = LoadListBillByDateAndPage(dtpBatDau.Value, dtpKetThuc.Value, Convert.ToInt32(txtPageBill.Text)) ;
        }
    }
}
