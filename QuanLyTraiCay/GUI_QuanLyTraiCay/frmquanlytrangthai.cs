using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QuanLyTraiCay
{
    public partial class frmquanlytrangthai : Form
    {
        public frmquanlytrangthai()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void loadTrangThai()
        {
            BLL_QuanLyTraiCay.Bus_TrangThai busTrangThai = new BLL_QuanLyTraiCay.Bus_TrangThai();
            List<DTO_QuanLyTraiCay.Trangthai> trangThais = busTrangThai.GetTrangthais();
            dgvtrangthai.DataSource = trangThais;
            dgvtrangthai.Columns["MaTrangThai"].HeaderText = "Mã Trạng Thái";
            dgvtrangthai.Columns["TenTrangThai"].HeaderText = "Tên Trạng Thái";
            dgvtrangthai.Columns["MoTa"].HeaderText = "Mô Tả";
            dgvtrangthai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void frmquanlytrangthai_Load(object sender, EventArgs e)
        {
            loadTrangThai();
        }
    }
}
