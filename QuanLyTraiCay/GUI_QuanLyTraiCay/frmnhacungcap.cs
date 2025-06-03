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
    public partial class frmnhacungcap : Form
    {
        public frmnhacungcap()
        {
            InitializeComponent();
        }

        private void frmnhacungcap_Load(object sender, EventArgs e)
        {
            loadNCC();
            clearform();
        }

        private void loadNCC()
        {
            BUSNhacungcap bll = new BUSNhacungcap();
            dgvncc.DataSource = null;
            dgvncc.DataSource = bll.GetAllNhaCungCap();
            dgvncc.DefaultCellStyle.ForeColor = Color.Black;
            dgvncc.DefaultCellStyle.BackColor = Color.White;
            dgvncc.ColumnHeadersDefaultCellStyle.BackColor = Color.Green;

            dgvncc.DefaultCellStyle.SelectionBackColor = Color.Green;
            dgvncc.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvncc.Columns["MaNCC"].HeaderText = "Mã Nhà Cung Cấp";
            dgvncc.Columns["TenNCC"].HeaderText = "Tên Nhà Cung Cấp";
            dgvncc.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dgvncc.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
            dgvncc.Columns["NgayTao"].HeaderText = "Ngày Tạo";
            dgvncc.Columns["GhiChu"].HeaderText = "Ghi Chú";

            dgvncc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void clearform()
        {
            txtmancc.Clear();
            txttenncc.Clear();
            txtdiachincc.Clear();
            txtsdt.Clear();
            txtghichu.Clear();
            dtpncc.Value = DateTime.Now;
        }

        private void btnthemncc_Click(object sender, EventArgs e)
        {

            DAL_NhaCungCap dal = new DAL_NhaCungCap();

            // Tự động tạo mã mới
            string maNCC = dal.generateMaNCC();
            txtmancc.Text = maNCC;
            string tenNCC = txttenncc.Text.Trim();
            string diaChi = txtdiachincc.Text.Trim();
            string soDienThoai = txtsdt.Text.Trim();
            string ghiChu = txtghichu.Text.Trim();
            DateTime ngayTao = DateTime.Now;

            // Kiểm tra xem có dữ liệu bị thiếu hay không
            if (string.IsNullOrEmpty(tenNCC) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(soDienThoai))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo đối tượng Nhà Cung Cấp
            nhacungcap ncc = new nhacungcap
            {
                MaNCC = maNCC,
                TenNCC = tenNCC,
                DiaChi = diaChi,
                SoDienThoai = soDienThoai,
                NgayTao = ngayTao,
                ghichu = ghiChu
            };

            // Thêm dữ liệu vào database
            BUSNhacungcap bll = new BUSNhacungcap();
            bll.ThemNhaCungCap(ncc);

            MessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Làm mới form và tải lại danh sách
            clearform();
            loadNCC();
        }

        private void dgvncc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvncc.Rows[e.RowIndex];

                txtmancc.Text = row.Cells["MaNCC"].Value.ToString();
                txttenncc.Text = row.Cells["TenNhaCungCap"].Value.ToString();
                txtdiachincc.Text = row.Cells["DiaChi"].Value.ToString();
                txtsdt.Text = row.Cells["SoDienThoai"].Value.ToString();
                txtghichu.Text = row.Cells["GhiChu"].Value.ToString();
                dtpncc.Value = Convert.ToDateTime(row.Cells["NgayTao"].Value);
                btnthemncc.Enabled = false;
                btnsuancc.Enabled = true;
                btnxoancc.Enabled = true;
            }
        }

        private void btnxoancc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtmancc.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhà cung cấp {txtmancc.Text}?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                BUSNhacungcap bll = new BUSNhacungcap();
                bll.XoaNhaCungCap(txtmancc.Text);
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearform();
                loadNCC();
            }
        }

        private void btnlammoincc_Click(object sender, EventArgs e)
        {
            clearform();
            loadNCC();
        }

        private void btnsuancc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtmancc.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            nhacungcap ncc = new nhacungcap
            {
                MaNCC = txtmancc.Text.Trim(),
                TenNCC = txttenncc.Text.Trim(),
                DiaChi = txtdiachincc.Text.Trim(),
                SoDienThoai = txtsdt.Text.Trim(),
                NgayTao = dtpncc.Value,
                ghichu = txtghichu.Text.Trim()
            };

            BUSNhacungcap bll = new BUSNhacungcap();
            bll.SuaNhaCungCap(ncc);
            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clearform();
            loadNCC();
        }
    }
}
