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
        public UCMenu()
        {
            InitializeComponent();
        }

        private void btnThemTD_Click(object sender, EventArgs e)
        {
            AddMenu addMenu = new AddMenu();
            addMenu.StartPosition = FormStartPosition.CenterScreen; // Hiện giữa màn hình
            addMenu.ShowDialog();
        }
    }
}
