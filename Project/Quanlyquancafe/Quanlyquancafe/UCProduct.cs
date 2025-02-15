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
    public partial class UCProduct : UserControl
    {
        public UCProduct()
        {
            InitializeComponent();
        }

        private void btnBanh_Click(object sender, EventArgs e)
        {

        }

        private void btnTra_Click(object sender, EventArgs e)
        {

        }

        private void btnSoda_Click(object sender, EventArgs e)
        {

        }

        private void btnMatcha_Click(object sender, EventArgs e)
        {

        }

        private void btnCafe_Click(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.StartPosition = FormStartPosition.CenterScreen; // Hiện giữa màn hình
            addProduct.ShowDialog();
        }
    }
}
