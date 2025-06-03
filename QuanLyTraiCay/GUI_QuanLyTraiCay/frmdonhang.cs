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
using DTO_QuanLyTraiCay;

namespace GUI_QuanLyTraiCay
{
    public partial class frmdonhang : Form
    {
        public frmdonhang()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel9_Click(object sender, EventArgs e)
        {

        }

        private void frmdonhang_Load(object sender, EventArgs e)
        {
            loaddanhdonhang("");
        }

        private void loaddanhdonhang(string MaDonHang)
        {
            BUS_Donhang busDonHang = new BUS_Donhang();
            List<Donhang> donhangs = busDonHang.GetAllDonhangs(MaDonHang);
            if (donhangs.Count > 0)
            {
                dgvdonhang.DataSource = donhangs;
                dgvdonhang.Columns["MaDonHang"].HeaderText = "Mã Đơn Hàng";
                dgvdonhang.Columns["MaKhach"].HeaderText = "Mã Khách Hàng";
                dgvdonhang.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
                dgvdonhang.Columns["TenNV"].HeaderText = "Tên Nhân Viên";
                dgvdonhang.Columns["TenKhach"].HeaderText = "Tên Khách Hàng";
                dgvdonhang.Columns["NgayDatHang"].HeaderText = "Ngày Đặt Hàng";
                dgvdonhang.Columns["DiaChiGiaoHang"].HeaderText = "Địa Chỉ Giao Hàng";
                dgvdonhang.Columns["MaTrangThai"].HeaderText = "Mã Trạng Thái";
                dgvdonhang.Columns["TenTrangThai"].HeaderText = "Tên Trạng Thái";
                dgvdonhang.Columns["GhiChu"].HeaderText = "Ghi Chú";
                dgvdonhang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                dgvdonhang.DataSource = null;
                MessageBox.Show("Không có đơn hàng nào được tìm thấy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void loadnhanvien()
        {
            BUSNhanVien busNhanVien = new BUSNhanVien();
            List<NhanVien> nhanViens = busNhanVien.GetNhanVienList();
            if (nhanViens.Count > 0)
            {
                cb.DataSource = nhanViens;
                cbomanv.DisplayMember = "HoTen";
                cbomanv.ValueMember = "MaNV";
            }
            else
            {
                cbomanv.DataSource = null;
                MessageBox.Show("Không có nhân viên nào được tìm thấy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
