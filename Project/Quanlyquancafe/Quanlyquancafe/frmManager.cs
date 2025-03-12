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
    public partial class frmManager : Form
    {
        //dùng chuột di chuyển form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public frmManager()
        {
            InitializeComponent();
        }

        private void ptbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ptbMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ptbState_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Normal)
            {
                this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.WindowState = FormWindowState.Maximized;
                ptbState.Image = Properties.Resources.max;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                ptbState.Image = Properties.Resources.images;
            }
        }

        private void frmManager_Load(object sender, EventArgs e)
        {
            ucHome3.BringToFront(); // Hiển thị ucHome đầu tiên khi load form
        }

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ucHome3.BringToFront();
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            ucTable3.BringToFront();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            ucProduct2.BringToFront();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            ucCategoryy2.BringToFront();
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            ucBill2.BringToFront();
        }

        private void btnStatistic_Click(object sender, EventArgs e)
        {
            ucStatistic4.BringToFront();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            ucMenu1.BringToFront();
        }
    }
}
