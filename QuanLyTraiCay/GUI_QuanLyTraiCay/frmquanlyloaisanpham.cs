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
using Guna.UI2.WinForms;

namespace GUI_QuanLyTraiCay
{
    public partial class frmquanlyloaisanpham : Form
    {

        public frmquanlyloaisanpham()
        {
            InitializeComponent();
        }
        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            string maloai = txtmaloai.Text.Trim();
            string tenloai = txttenloai.Text.Trim();
            string ghichu = txtghichu.Text.Trim();
            DateTime ngaytao = dtpngaytao.Value;
            if (string.IsNullOrEmpty(tenloai) || string.IsNullOrEmpty(ghichu))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoaiSanpham sp = new LoaiSanpham
            {
                MaLoaiSP = maloai,
                TenLoai = tenloai,
                GhiChu = ghichu,
                NgayTao = ngaytao
            };
            Bus_LoaiSanpham bus = new Bus_LoaiSanpham();
            string result = bus.InsertLoaiSanpham(sp);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Thêm mới loại sản phẩm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearform();
                LoadDanhSachLoaiSanPham();
            }
            else
            {
                MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//them
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void frmquanlyloaisanpham_Load(object sender, EventArgs e)
        {
            clearform();
            LoadDanhSachLoaiSanPham();
        }

        public void clearform()
        {
            txtmaloai.Clear();
            txttenloai.Clear();
            txtghichu.Clear();
            dtpngaytao.Value = DateTime.Now;
        }

        public void LoadDanhSachLoaiSanPham()
        {
            Bus_LoaiSanpham bus = new Bus_LoaiSanpham();
            dgvloaisanpham.DataSource = null;
            dgvloaisanpham.DataSource = bus.GetAllLoaiSanpham();
            dgvloaisanpham.DefaultCellStyle.ForeColor = Color.Black;
            dgvloaisanpham.DefaultCellStyle.BackColor = Color.White;
            dgvloaisanpham.ColumnHeadersDefaultCellStyle.BackColor = Color.Green;
            dgvloaisanpham.DefaultCellStyle.SelectionBackColor = Color.Green;
            dgvloaisanpham.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvloaisanpham.Columns["MaLoaiSP"].HeaderText = "Mã Loại Sản Phẩm";
            dgvloaisanpham.Columns["TenLoai"].HeaderText = "Tên Loại Sản Phẩm";
            dgvloaisanpham.Columns["GhiChu"].HeaderText = "Ghi Chú";
            dgvloaisanpham.Columns["NgayTao"].HeaderText = "Ngày Tạo";
            dgvloaisanpham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string maloai = txtmaloai.Text.Trim();
            string tenloai = txttenloai.Text.Trim();
            string ghichu = txtghichu.Text.Trim();
            DateTime ngaytao = dtpngaytao.Value;
            if (string.IsNullOrEmpty(maloai) || string.IsNullOrEmpty(tenloai) || string.IsNullOrEmpty(ghichu))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoaiSanpham sp = new LoaiSanpham
            {
                MaLoaiSP = maloai,
                TenLoai = tenloai,
                GhiChu = ghichu,
                NgayTao = ngaytao
            };
            Bus_LoaiSanpham bus = new Bus_LoaiSanpham();
            string result = bus.UpdateLoaiSanpham(sp);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật loại sản phẩm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearform();
                LoadDanhSachLoaiSanPham();
            }
            else
            {
                MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvloaisanpham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvloaisanpham.Rows.Count)
            {
                DataGridViewRow row = dgvloaisanpham.Rows[e.RowIndex];
                txtmaloai.Text = row.Cells["MaLoaiSP"].Value.ToString();
                txttenloai.Text = row.Cells["TenLoai"].Value.ToString();
                txtghichu.Text = row.Cells["GhiChu"].Value.ToString();
                dtpngaytao.Value = Convert.ToDateTime(row.Cells["NgayTao"].Value);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một loại sản phẩm để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string maloai = txtmaloai.Text.Trim();
            if (string.IsNullOrEmpty(maloai))
            {
                MessageBox.Show("Vui lòng chọn loại sản phẩm cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa loại sản phẩm này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Bus_LoaiSanpham bus = new Bus_LoaiSanpham();
                string deleteResult = bus.DeleteLoaiSanpham(maloai);
                if (string.IsNullOrEmpty(deleteResult))
                {
                    MessageBox.Show("Xóa loại sản phẩm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearform();
                    LoadDanhSachLoaiSanPham();
                }
                else
                {
                    MessageBox.Show(deleteResult, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnmoi_Click(object sender, EventArgs e)
        {
            clearform();
            LoadDanhSachLoaiSanPham();
        }
    }
}