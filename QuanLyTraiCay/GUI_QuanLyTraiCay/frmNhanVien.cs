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
using Microsoft.VisualBasic.Devices;

namespace GUI_QuanLyTraiCay
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            loadnnVien();

        }

        private void loadnnVien()
        {
            BUSNhanVien bus_NhanVien = new BUSNhanVien();
            dgvnhanvien.DataSource = null;
            dgvnhanvien.DataSource = bus_NhanVien.GetNhanVienList();
            dgvnhanvien.DefaultCellStyle.ForeColor = Color.Black;
            dgvnhanvien.DefaultCellStyle.BackColor = Color.White;
            dgvnhanvien.DefaultCellStyle.SelectionBackColor = Color.Purple; // màu khi chọn
            dgvnhanvien.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvnhanvien.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
            dgvnhanvien.Columns["HoTen"].HeaderText = "Họ Tên";
            dgvnhanvien.Columns["GioiTinh"].HeaderText = "Giới Tính";
            dgvnhanvien.Columns["Email"].HeaderText = "Email";
            dgvnhanvien.Columns["MatKhau"].HeaderText = "Mật Khẩu";
            dgvnhanvien.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dgvnhanvien.Columns["VaiTroText"].HeaderText = "Vai Trò";
            dgvnhanvien.Columns["TrangThaiText"].HeaderText = "Trạng Thái";
            dgvnhanvien.Columns["VaiTro"].Visible = false; // Ẩn cột Vai Trò
            dgvnhanvien.Columns["TrangThai"].Visible = false; // Ẩn cột Trạng Thái

            dgvnhanvien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void clearform()
        {
            txtemail.Clear();
            txttimkiem.Clear();
            txthoten.Clear();
            txtmatkhau.Clear();
            txtmanhanvien.Clear();
            txtxacnhanmatkhau.Clear();
            txtdiachi.Clear();
            rbtnam.Checked = false;
            rbtnu.Checked = false;
            rbtdhd.Checked = false;
            rbtql.Checked = false;
            rbtnv.Checked = false;
            rbtn.Checked = false;

        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)// lam moi
        {
            clearform();
            loadnnVien();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string maNV = txtmanhanvien.Text.Trim();
            string hoTen = txthoten.Text.Trim();
            string gioiTinh = rbtnam.Checked ? "Nam" : (rbtnu.Checked ? "Nữ" : string.Empty);
            string email = txtemail.Text.Trim();
            string matKhau = txtmatkhau.Text.Trim();
            string xacNhanMatKhau = txtxacnhanmatkhau.Text.Trim();
            string diaChi = txtdiachi.Text.Trim();
            bool vaiTro;
            if (rbtql.Checked)
            {
                vaiTro = true; // Quản lý
            }
            else if (rbtnv.Checked)
            {
                vaiTro = false; // Nhân viên
            }
            else
            {
                MessageBox.Show("Vui lòng chọn vai trò cho nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool trangThai; // Trạng thái làm việc (Đang hoạt động hay không)
            if (rbtdhd.Checked)
            {
                trangThai = true; // Đang hoạt động
            }
            else if (rbtn.Checked)
            {
                trangThai = false; // Không hoạt động
            }
            else
            {
                MessageBox.Show("Vui lòng chọn trạng thái làm việc cho nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(matKhau) || string.IsNullOrEmpty(xacNhanMatKhau) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(gioiTinh))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (matKhau != xacNhanMatKhau)
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            BUSNhanVien busNhanVien = new BUSNhanVien();
            NhanVien nv = new NhanVien
            {
                MaNV = maNV,
                HoTen = hoTen,
                GioiTinh = gioiTinh,
                Email = email,
                MatKhau = matKhau,
                DiaChi = diaChi,
                VaiTro = vaiTro,
                TrangThai = trangThai
            };
            string result = busNhanVien.AddNhanVien(nv);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Thêm nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearform();
                loadnnVien();
            }
            else
            {
                MessageBox.Show("Thêm nhân viên không thành công: " + result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnxoa_Click(object sender, EventArgs e)
        {
            string maNV = txtmanhanvien.Text.Trim();
            if (string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?", "Xóa nhân viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                BUSNhanVien busNhanVien = new BUSNhanVien();
                string messge = busNhanVien.DeleteNhanVien(maNV);
                if (string.IsNullOrEmpty(messge))
                {
                    MessageBox.Show("Xóa nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearform();
                    loadnnVien();
                }
                else
                {
                    MessageBox.Show("Xóa nhân viên không thành công: " + messge, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnsua_Click_1(object sender, EventArgs e)
        {
            string maNV = txtmanhanvien.Text.Trim();
            string hoTen = txthoten.Text.Trim();
            string gioiTinh = rbtnam.Checked ? "Nam" : (rbtnu.Checked ? "Nữ" : string.Empty);
            string email = txtemail.Text.Trim();
            string matKhau = txtmatkhau.Text.Trim();
            string diaChi = txtdiachi.Text.Trim();
            bool vaiTro;
            if (rbtql.Checked)
            {
                vaiTro = true; // Quản lý
            }
            else if (rbtnv.Checked)
            {
                vaiTro = false; // Nhân viên
            }
            else
            {
                MessageBox.Show("Vui lòng chọn vai trò cho nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool trangThai; // Trạng thái làm việc (Đang hoạt động hay không)
            if (rbtdhd.Checked)
            {
                trangThai = true; // Đang hoạt động
            }
            else if (rbtn.Checked)
            {
                trangThai = false; // Không hoạt động
            }
            else
            {
                MessageBox.Show("Vui lòng chọn trạng thái làm việc cho nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(matKhau) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(gioiTinh))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            BUSNhanVien busNhanVien = new BUSNhanVien();
            NhanVien nv = new NhanVien
            {
                MaNV = maNV,
                HoTen = hoTen,
                GioiTinh = gioiTinh,
                Email = email,
                MatKhau = matKhau,
                DiaChi = diaChi,
                VaiTro = vaiTro,
                TrangThai = trangThai
            };
            string result = busNhanVien.UpdateNhanVien(nv);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearform();
                loadnnVien();
            }
            else
            {
                MessageBox.Show("Cập nhật nhân viên không thành công: " + result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvnhanvien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvnhanvien.Rows[e.RowIndex];
            txtmanhanvien.Text = row.Cells["MaNV"].Value.ToString();
            txthoten.Text = row.Cells["HoTen"].Value.ToString();
            string gioiTinh = row.Cells["GioiTinh"].Value.ToString();
            if (gioiTinh == "Nam")
            {
                rbtnam.Checked = true;
            }
            else if (gioiTinh == "Nữ")
            {
                rbtnu.Checked = true;
            }
            else
            {
                rbtnam.Checked = false;
                rbtnu.Checked = false;
            }

            txtemail.Text = row.Cells["Email"].Value.ToString();
            txtmatkhau.Text = row.Cells["MatKhau"].Value.ToString();
            txtxacnhanmatkhau.Text = row.Cells["MatKhau"].Value.ToString();
            txtdiachi.Text = row.Cells["DiaChi"].Value.ToString();

            bool vaiTro = Convert.ToBoolean(row.Cells["VaiTro"].Value);
            if (vaiTro)
            {
                rbtql.Checked = true;
            }
            else
            {
                rbtnv.Checked = true;
            }
            bool trangThai = Convert.ToBoolean(row.Cells["TrangThai"].Value);
            if (trangThai)
            {
                rbtdhd.Checked = true;
            }
            else
            {
                rbtn.Checked = true;
            }

            btnthem.Enabled = false;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            //tat chinh sua ma nhan vien
            txtmanhanvien.Enabled = false;
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string KeyWord = txttimkiem.Text;
            if (!string.IsNullOrWhiteSpace(KeyWord))
            {
                SearchInAllCells11(KeyWord);
            }

        }
        private void SearchInAllCells11(string Keyword)
        {
            foreach (DataGridViewRow row in dgvnhanvien.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(Keyword.ToLower()))
                    {
                        row.Selected = true;
                        break;
                    }
                    else
                    {
                        row.Selected = false;
                    }
                }
            }
        }
    }


}
