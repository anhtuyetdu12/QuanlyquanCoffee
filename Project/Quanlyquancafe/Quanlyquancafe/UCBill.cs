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

        private void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            db = new Database();
            string sql = "USP_GetListBillByDate"; // Gọi stored procedure để cập nhật trạng thái hóa đơn

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

        private void btnThongke_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpBatDau.Value, dtpKetThuc.Value);
        }

        private void UCBill_Load(object sender, EventArgs e)
        {
            dgvBill.DefaultCellStyle.ForeColor = Color.Black;
        }
    }
}
