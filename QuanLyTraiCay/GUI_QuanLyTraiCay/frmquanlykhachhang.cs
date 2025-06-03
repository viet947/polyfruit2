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
using DAL_QuanLyTraiCay;
using DTO_QuanLyTraiCay;

namespace GUI_QuanLyTraiCay
{
    public partial class frmquanlykhachhang : Form
    {
        public frmquanlykhachhang()
        {
            InitializeComponent();
        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmquanlykhachhang_Load(object sender, EventArgs e)
        {
            clearform();
            loaddanhsachkhachhang();

        }

        public void clearform()
        {
            txtmakhachhang.Clear();
            txttenkhachhang.Clear();
            txtdiachi.Clear();
            txtsdt.Clear();
            txtghichu.Clear();
            dtpngaytao.Value = DateTime.Now;
            rbco.Checked = true; // Giới tính Nam
            rbco.Checked = true; // Khách hàng thân thiết Có
            rbhoatdong.Checked = true; // Trạng thái Đang hoạt động



        }

        private void loaddanhsachkhachhang()
        {
            BUS_KhachHang bus = new BUS_KhachHang();
            dgvdanhsach.DataSource = null;
            dgvdanhsach.DataSource = bus.GetQuanlykhachhangs();
            dgvdanhsach.DefaultCellStyle.ForeColor = Color.Black;
            dgvdanhsach.DefaultCellStyle.BackColor = Color.White;
            dgvdanhsach.ColumnHeadersDefaultCellStyle.BackColor = Color.Green;
            dgvdanhsach.DefaultCellStyle.SelectionBackColor = Color.Green;
            dgvdanhsach.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvdanhsach.Columns["MaKhach"].HeaderText = "Mã Khách Hàng";
            dgvdanhsach.Columns["TenKhach"].HeaderText = "Tên Khách Hàng";
            dgvdanhsach.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dgvdanhsach.Columns["DienThoai"].HeaderText = "Điện Thoại";
            dgvdanhsach.Columns["GhiChu"].HeaderText = "Ghi Chú";
            dgvdanhsach.Columns["NgayTao"].HeaderText = "Ngày Tạo";

            dgvdanhsach.Columns["GioiTinh"].HeaderText = "Giới Tính";
            dgvdanhsach.Columns["KhachHangThanThiet"].HeaderText = "Khách Hàng Thân Thiết";
            dgvdanhsach.Columns["trangThaitext"].HeaderText = "Trạng Thái"; // Ẩn cột Trang Thái
            dgvdanhsach.Columns["TrangThai"].Visible = false; // Ẩn cột Trang Thái thực tế



            dgvdanhsach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string maKhach = txtmakhachhang.Text.Trim();
            string tenKhach = txttenkhachhang.Text.Trim();
            string diaChi = txtdiachi.Text.Trim();
            string dienThoai = txtsdt.Text.Trim();
            string ghiChu = txtghichu.Text.Trim();
            DateTime ngayTao = dtpngaytao.Value;
            string gioiTinh = rbnam.Checked ? "Nam" : "Nữ";
            string khachHangThanThiet = rbco.Checked ? "Có" : "Không";
            bool trangThai = rbhoatdong.Checked;

            quanlykhachhang kh = new quanlykhachhang
            {
                MaKhach = maKhach,
                TenKhach = tenKhach,
                DiaChi = diaChi,
                DienThoai = dienThoai,
                GhiChu = ghiChu,
                NgayTao = ngayTao,
                GioiTinh = gioiTinh,
                KhachHangThanThiet = khachHangThanThiet,
                TrangThai = trangThai
            };
            BUS_KhachHang bus = new BUS_KhachHang();
            string result = bus.InsertKhachHang(kh);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Thêm mới khách hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearform();
                loaddanhsachkhachhang();
            }
            else
            {
                MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string maKhach = txtmakhachhang.Text.Trim();
            if (string.IsNullOrEmpty(maKhach))
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                BUS_KhachHang bus = new BUS_KhachHang();
                string deleteResult = bus.DeleteKhachHang(maKhach);
                if (string.IsNullOrEmpty(deleteResult))
                {
                    MessageBox.Show("Xóa khách hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearform();
                    loaddanhsachkhachhang();
                }
                else
                {
                    MessageBox.Show(deleteResult, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string maKhach = txtmakhachhang.Text.Trim();
            string tenKhach = txttenkhachhang.Text.Trim();
            string diaChi = txtdiachi.Text.Trim();
            string dienThoai = txtsdt.Text.Trim();
            string ghiChu = txtghichu.Text.Trim();
            DateTime ngayTao = dtpngaytao.Value;
            string gioiTinh = rbnam.Checked ? "Nam" : "Nữ";
            string khachHangThanThiet = rbco.Checked ? "Có" : "Không";
            bool trangThai = rbhoatdong.Checked;
            quanlykhachhang kh = new quanlykhachhang
            {
                MaKhach = maKhach,
                TenKhach = tenKhach,
                DiaChi = diaChi,
                DienThoai = dienThoai,
                GhiChu = ghiChu,
                NgayTao = ngayTao,
                GioiTinh = gioiTinh,
                KhachHangThanThiet = khachHangThanThiet,
                TrangThai = trangThai
            };
            BUS_KhachHang bus = new BUS_KhachHang();
            string result = bus.UpdateKhachHang(kh);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật khách hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearform();
                loaddanhsachkhachhang();
            }
            else
            {
                MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvdanhsach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvdanhsach.Rows[e.RowIndex];
            txtmakhachhang.Text = row.Cells["MaKhach"].Value.ToString();
            txttenkhachhang.Text = row.Cells["TenKhach"].Value.ToString();
            txtdiachi.Text = row.Cells["DiaChi"].Value.ToString();
            txtsdt.Text = row.Cells["DienThoai"].Value.ToString();
            txtghichu.Text = row.Cells["GhiChu"].Value.ToString();
            dtpngaytao.Value = Convert.ToDateTime(row.Cells["NgayTao"].Value);
            rbnam.Checked = row.Cells["GioiTinh"].Value.ToString() == "Nam";
            if (rbnu != null)
                rbnu.Checked = !rbnam.Checked;
            rbco.Checked = row.Cells["KhachHangThanThiet"].Value.ToString() == "Có";
            rbkhong.Checked = !rbco.Checked;
            rbhoatdong.Checked = Convert.ToBoolean(row.Cells["TrangThai"].Value);
            rbngunghoatdong.Checked = !rbhoatdong.Checked;
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            clearform();
            loaddanhsachkhachhang();
        }
    }
}
