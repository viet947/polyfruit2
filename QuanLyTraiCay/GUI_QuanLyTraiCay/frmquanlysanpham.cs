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
    public partial class frmquanlysanpham : Form
    {
        public frmquanlysanpham()
        {
            InitializeComponent();
        }

        private void clearform()
        {
            cbdvt.SelectedIndex = -1; // Đặt lại ComboBox Đơn Vị Tính
            txttensanpham.Clear();
            txtsoluong.Clear();
            txtdongianhap.Clear();
            txtghichu.Clear();
            cbloaisp.SelectedIndex = -1; // Đặt lại ComboBox Loại Sản Phẩm
            txtmasanpham.Clear();
            cbncc.SelectedIndex = -1; // Đặt lại ComboBox Nhà Cung Cấp
            rbhoatdong.Checked = true; // Trạng thái Đang hoạt động
            rbtamngung.Checked = false; // Trạng thái Tạm ngưng

        }

        private void loaddanhsachsanpham()
        {
            Bus_Sanpham bus = new Bus_Sanpham();
            dgvsanpham.DataSource = null;
            dgvsanpham.DataSource = bus.GetSanphams();
            dgvsanpham.DefaultCellStyle.ForeColor = Color.Black;
            dgvsanpham.DefaultCellStyle.BackColor = Color.White;
            dgvsanpham.ColumnHeadersDefaultCellStyle.BackColor = Color.Green;
            dgvsanpham.DefaultCellStyle.SelectionBackColor = Color.Green;
            dgvsanpham.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvsanpham.Columns["MaSP"].HeaderText = "Mã Sản Phẩm";
            dgvsanpham.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";
            dgvsanpham.Columns["MaLoaiSP"].HeaderText = "Mã Loại Sản Phẩm";
            dgvsanpham.Columns["TenLoaiSP"].HeaderText = "Tên Loại Sản Phẩm"; // Hiển thị tên loại sản phẩm
            dgvsanpham.Columns["MaNCC"].HeaderText = "Mã Nhà Cung Cấp";
            dgvsanpham.Columns["TenNhaCungCap"].HeaderText = "Tên Nhà Cung Cấp"; // Hiển thị tên nhà cung cấp
            dgvsanpham.Columns["MaDVT"].HeaderText = "Mã Đơn Vị Tính";
            dgvsanpham.Columns["TenDVT"].HeaderText = "Tên Đơn Vị Tính"; // Hiển thị tên đơn vị tính

            dgvsanpham.Columns["DonGiaNhap"].HeaderText = "Đơn Giá Nhập";
            dgvsanpham.Columns["DonGiaBan"].HeaderText = "Đơn Giá Bán";
            dgvsanpham.Columns["SoLuong"].HeaderText = "Số Lượng";
            dgvsanpham.Columns["TrangthaiText"].HeaderText = "Trạng Thái"; // Hiển thị trạng thái dưới dạng văn bản
            dgvsanpham.Columns["HinhAnh"].HeaderText = "Hình Ảnh";
            dgvsanpham.Columns["GhiChu"].HeaderText = "Ghi Chú";
            dgvsanpham.Columns["TrangThai"].Visible = false; // Ẩn cột Trang Thái thực tế
            dgvsanpham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void LoadLoaiSanPham()
        {
            try
            {
                Bus_LoaiSanpham bUSLoaiSanPham = new Bus_LoaiSanpham();
                List<LoaiSanpham> dsLoai = bUSLoaiSanPham.GetAllLoaiSanpham();
                cbloaisp.DataSource = dsLoai;
                cbloaisp.ValueMember = "MaLoaiSP";
                cbloaisp.DisplayMember = "TenLoai";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách loại sản phẩm" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadNhaCungCap()
        {
            try
            {
                BUSNhacungcap busNCC = new BUSNhacungcap();
                List<nhacungcap> dsNCC = busNCC.GetAllNhaCungCap();
                cbncc.DataSource = dsNCC;
                cbncc.ValueMember = "MaNCC";
                cbncc.DisplayMember = "TenNCC";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDonViTinh()
        {
            try
            {
                BUS_Donvitinh busDVT = new BUS_Donvitinh();
                List<Donvitinh> dsDVT = busDVT.laydanhsachdonvitinh();
                cbdvt.DataSource = dsDVT;
                cbdvt.ValueMember = "MaDVT";
                cbdvt.DisplayMember = "TenDVT";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách đơn vị tính: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmquanlysanpham_Load(object sender, EventArgs e)
        {
            clearform();
            loaddanhsachsanpham();
            LoadLoaiSanPham();
            LoadNhaCungCap();
            LoadDonViTinh();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string maSP = txtmasanpham.Text.Trim();
            string tenSP = txttensanpham.Text.Trim();
            string maLoaiSP = cbloaisp.SelectedValue?.ToString().Trim() ?? string.Empty;
            string maNCC = cbncc.SelectedValue?.ToString().Trim() ?? string.Empty;
            string maDVT = cbdvt.SelectedValue?.ToString().Trim() ?? string.Empty;

            if (!decimal.TryParse(txtdongianhap.Text, out decimal donGiaNhap))
            {
                MessageBox.Show("Đơn giá nhập phải là số!");
                return;
            }
            if (!decimal.TryParse(dongiaban.Text, out decimal donGiaBan))
            {
                MessageBox.Show("Đơn giá bán phải là số!");
                return;
            }
            if (!decimal.TryParse(txtsoluong.Text, out decimal soLuong))
            {
                MessageBox.Show("Số lượng phải là số!");
                return;
            }

            string hinhanh = txthinhanh.Text.Trim();
            string ghiChu = txtghichu.Text.Trim();
            bool trangThai = rbhoatdong.Checked;

            if (string.IsNullOrEmpty(tenSP) || string.IsNullOrEmpty(maLoaiSP) ||
                string.IsNullOrEmpty(maNCC) || string.IsNullOrEmpty(maDVT) || donGiaNhap <= 0 || donGiaBan <= 0 || soLuong < 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và hợp lệ thông tin sản phẩm.");
                return;
            }

            Sanpham sanpham = new Sanpham
            {
                MaSP = maSP,
                TenSanPham = tenSP,
                MaLoaiSP = maLoaiSP,
                MaNCC = maNCC,
                MaDVT = maDVT,
                DonGiaNhap = donGiaNhap,
                DonGiaBan = donGiaBan,
                SoLuong = soLuong,
                HinhAnh = hinhanh,
                GhiChu = ghiChu,
                TrangThai = trangThai
            };

            Bus_Sanpham bus = new Bus_Sanpham();
            string result = bus.insertSanpham(sanpham);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Thêm sản phẩm thành công!");
                clearform();
                loaddanhsachsanpham();
            }
            else
            {
                MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string maSP = txtmasanpham.Text.Trim();
            string tenSP = txttensanpham.Text.Trim();
            string maLoaiSP = cbloaisp.SelectedValue?.ToString().Trim() ?? string.Empty;
            string maNCC = cbncc.SelectedValue?.ToString().Trim() ?? string.Empty;
            string maDVT = cbdvt.SelectedValue?.ToString().Trim() ?? string.Empty;
            if (!decimal.TryParse(txtdongianhap.Text, out decimal donGiaNhap))
            {
                MessageBox.Show("Đơn giá nhập phải là số!");
                return;
            }
            if (!decimal.TryParse(dongiaban.Text, out decimal donGiaBan))
            {
                MessageBox.Show("Đơn giá bán phải là số!");
                return;
            }
            if (!decimal.TryParse(txtsoluong.Text, out decimal soLuong))
            {
                MessageBox.Show("Số lượng phải là số!");
                return;
            }
            string hinhanh = txthinhanh.Text.Trim();
            string ghiChu = txtghichu.Text.Trim();
            bool trangThai = rbhoatdong.Checked;
            if (string.IsNullOrEmpty(tenSP) || string.IsNullOrEmpty(maLoaiSP) ||
                string.IsNullOrEmpty(maNCC) || string.IsNullOrEmpty(maDVT) || donGiaNhap <= 0 || donGiaBan <= 0 || soLuong < 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và hợp lệ thông tin sản phẩm.");
                return;
            }
            Sanpham sanpham = new Sanpham
            {
                MaSP = maSP,
                TenSanPham = tenSP,
                MaLoaiSP = maLoaiSP,
                MaNCC = maNCC,
                MaDVT = maDVT,
                DonGiaNhap = donGiaNhap,
                DonGiaBan = donGiaBan,
                SoLuong = soLuong,
                HinhAnh = hinhanh,
                GhiChu = ghiChu,
                TrangThai = trangThai
            };
            Bus_Sanpham bus = new Bus_Sanpham();
            string result = bus.UpdateSanpham(sanpham);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật sản phẩm thành công!");
                clearform();
                loaddanhsachsanpham();
            }
            else
            {
                MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string maSP = txtmasanpham.Text.Trim();
            if (string.IsNullOrEmpty(maSP))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xóa.");
                return;
            }
            Bus_Sanpham bus = new Bus_Sanpham();
            string result = bus.DeleteSanpham(maSP);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Xóa sản phẩm thành công!");
                clearform();
                loaddanhsachsanpham();
            }
            else
            {
                MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void dgvsanpham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvsanpham.Rows.Count)
            {
                DataGridViewRow row = dgvsanpham.Rows[e.RowIndex];
                txtmasanpham.Text = row.Cells["MaSP"].Value.ToString();
                txttensanpham.Text = row.Cells["TenSanPham"].Value.ToString();
                cbloaisp.SelectedValue = row.Cells["MaLoaiSP"].Value;
                cbncc.SelectedValue = row.Cells["MaNCC"].Value;
                cbdvt.SelectedValue = row.Cells["MaDVT"].Value;
                txtdongianhap.Text = row.Cells["DonGiaNhap"].Value.ToString();
                dongiaban.Text = row.Cells["DonGiaBan"].Value.ToString();
                txtsoluong.Text = row.Cells["SoLuong"].Value.ToString();
                txthinhanh.Text = row.Cells["HinhAnh"].Value.ToString();
                txtghichu.Text = row.Cells["GhiChu"].Value.ToString();
                rbhoatdong.Checked = (bool)row.Cells["TrangThai"].Value;
                rbtamngung.Checked = !rbhoatdong.Checked;
            }
        }

        private void btnmoi_Click(object sender, EventArgs e)
        {
            clearform();
            loaddanhsachsanpham();
            LoadDonViTinh();
            LoadLoaiSanPham();
            LoadNhaCungCap();

        }
    }
}
