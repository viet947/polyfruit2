using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_QuanLyTraiCay;

namespace GUI_QuanLyTraiCay
{
    public partial class frmdonvitinh : Form
    {
        public frmdonvitinh()
        {
            InitializeComponent();
        }

        private void txtmadvt_TextChanged(object sender, EventArgs e)
        {

        }

        private void loadDonViTinh()
        {
            BUS_Donvitinh bll = new BUS_Donvitinh();
            dgvdonvitinh.DataSource = null;
            dgvdonvitinh.DataSource = bll.laydanhsachdonvitinh();
            dgvdonvitinh.DefaultCellStyle.ForeColor = Color.Black;
            dgvdonvitinh.DefaultCellStyle.BackColor = Color.White;
            dgvdonvitinh.DefaultCellStyle.SelectionBackColor = Color.Blue;
            dgvdonvitinh.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvdonvitinh.Columns["MaDVT"].HeaderText = "Mã Đơn Vị Tính";
            dgvdonvitinh.Columns["TenDVT"].HeaderText = "Tên Đơn Vị Tính";
            dgvdonvitinh.Columns["MoTa"].HeaderText = "Mô Tả";

            dgvdonvitinh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void frmdonvitinh_Load(object sender, EventArgs e)
        {
            loadDonViTinh();
        }
    }
}
