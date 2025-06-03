using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_QuanLyTraiCay;
using DTO_QuanLyTraiCay;
using UTIL_QuanLyTraiCay;

namespace GUI_QuanLyTraiCay
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        BUSNhanVien busNhanVien = new BUSNhanVien();

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = txtemail.Text;
            string password = txtpassword.Text;
            NhanVien? nhanVien = busNhanVien.DangNhap(username, password);

            if (nhanVien == null)
            {
                MessageBox.Show("Tài khoản mật khẩu không chính xác");
                return;
            }

            if (nhanVien.TrangThai == false)
            {
                MessageBox.Show("Tài khoản đã bị khóa");
                return;
            }

            AuthUtil.user = nhanVien;

            frmMain main = new frmMain();
            main.Show();
            this.Hide();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            txtpassword.UseSystemPasswordChar = !guna2ToggleSwitch1.Checked;
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {
            txtpassword.UseSystemPasswordChar = true;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtemail.Text = "Email";
            txtemail.ForeColor = Color.Gray;

            txtpassword.Text = "Password";
            txtpassword.ForeColor = Color.Gray;
            txtpassword.UseSystemPasswordChar = false; // Tắt dấu ● khi hiển thị placeholder
        }

        private void txtemail_Enter(object sender, EventArgs e)
        {
            if (txtemail.Text == "Email")
            {
                txtemail.Text = "";
                txtemail.ForeColor = Color.Black;
            }
        }

        private void txtpassword_Enter(object sender, EventArgs e)
        {
            if (txtpassword.Text == "Password")
            {
                txtpassword.Text = "";
                txtpassword.ForeColor = Color.Black;
                txtpassword.UseSystemPasswordChar = true; // Bật dấu ● khi nhập
            }
        }

        private void txtemail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtemail.Text))
            {
                txtemail.Text = "Email";
                txtemail.ForeColor = Color.Gray;
            }
        }

        private void txtpassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtpassword.Text))
            {
                txtpassword.Text = "Password";
                txtpassword.ForeColor = Color.Gray;
                txtpassword.UseSystemPasswordChar = false; // Tắt dấu ● nếu không có gì nhập
            }
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {
          //  openChildFrom(new frmWdoimk());
        }
       
    }
}
