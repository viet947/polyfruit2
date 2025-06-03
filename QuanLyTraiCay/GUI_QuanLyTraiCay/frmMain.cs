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

namespace GUI_QuanLyTraiCay
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private Form currentFormChild;


        private void openChildFrom(Form formChild)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = formChild;
            formChild.TopLevel = false;
            formChild.FormBorderStyle = FormBorderStyle.None;
            formChild.Dock = DockStyle.Fill;
            pnmain.Controls.Add(formChild);
            pnmain.Tag = formChild;
            formChild.BringToFront();
            formChild.Show();
        }

        private void gnbTrangChu_Click(object sender, EventArgs e)
        {


        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            openChildFrom(new frmNhanVien());
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            openChildFrom(new frmquanlysanpham());
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            openChildFrom(new frmquanlyloaisanpham());
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            openChildFrom(new frmdonhang());
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            openChildFrom(new frmchitiedonhang());
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            openChildFrom(new frmnhacungcap());
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            openChildFrom(new frmquanlykhachhang());
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            openChildFrom(new frmdonvitinh());
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            openChildFrom(new frmquanlytrangthai());
        }
    }
}
