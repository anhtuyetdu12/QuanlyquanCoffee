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
        public UCCategoryy()
        {
            InitializeComponent();
        }

        private void btnThemDM_Click(object sender, EventArgs e)
        {
            AddCategory addCategory = new AddCategory();
            addCategory.StartPosition = FormStartPosition.CenterScreen; // Hiện giữa màn hình
            addCategory.ShowDialog();
        }
    }
}
