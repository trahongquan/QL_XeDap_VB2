using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyXeDap
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        public void DisableMenuNhanVien()
        {
            btnQuanLyDonHang.Visible = false;
            btnQuanLyXe.Visible = false;
        }

        private void btnQuanLyXe_Click(object sender, EventArgs e)
        {
            QuanLyXe frmQlyXe = new QuanLyXe();
            frmQlyXe.ShowDialog();
        }

        private void btnDatHang_Click(object sender, EventArgs e)
        {
            DatHang frmDatHang = new DatHang();
            frmDatHang.ShowDialog();
        }

        private void btnQuanLyDonHang_Click(object sender, EventArgs e)
        {
            TongHopHoaDon frmTH = new TongHopHoaDon();
            frmTH.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            Login frmLogin = new Login();
            frmLogin.Show();
        }
    }
}
