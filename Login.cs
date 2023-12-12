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
    public partial class Login : Form
    {
        ChinhSuaDuLieu con;
        public Login()
        {
            InitializeComponent();
            btnLogin.Focus();
            con = new ChinhSuaDuLieu();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            EnterLogin();
        }
        private void btnSignup_Click(object sender, EventArgs e)
        {
            EnterSignUp();
        }

        private void txtTenDangNhap_Click(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = "";
        }

        private void txtMatKhau_Click(object sender, EventArgs e)
        {
            txtMatKhau.Text = "";
        }

        private void btnLogin_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                EnterLogin();
            }
        }

        private void EnterLogin()
        {
            if (con.DangNhap(txtTenDangNhap.Text, txtMatKhau.Text))
            {
                this.Hide();
                Menu frmMain = new Menu();
                frmMain.Show();
                if(txtTenDangNhap.Text != "admin")
                    frmMain.DisableMenuNhanVien();
            }
            else
            {
                MessageBox.Show("Bạn nhập sai tên đăng nhập hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnterSignUp()
        {
            if (con.DangKy(txtTenDangNhap.Text, txtMatKhau.Text))
            {
                MessageBox.Show("Đăng ký tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Tài khoản đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenDangNhap.Focus();
            }
        }

        private void lblChaoMung_Click(object sender, EventArgs e)
        {

        }
    }


}
