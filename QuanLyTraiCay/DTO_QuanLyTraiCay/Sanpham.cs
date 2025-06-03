using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyTraiCay
{
    public class Sanpham
    {
        public string MaSP { get; set; }
        public string TenSanPham { get; set; }
        public string MaLoaiSP { get; set; }
        public string TenLoaiSP { get; set; } // Thêm thuộc tính này để lưu tên loại sản phẩm
        public string MaNCC { get; set; }
        public string TenNhaCungCap { get; set; } // Thêm thuộc tính này để lưu tên nhà cung cấp
        public string MaDVT { get; set; }
        public string TenDVT { get; set; } // Thêm thuộc tính này để lưu tên đơn vị tính

        public decimal DonGiaNhap { get; set; }
        public decimal DonGiaBan { get; set; }
        public decimal SoLuong { get; set; }

        
        public string HinhAnh { get; set; }
        public string GhiChu { get; set; }

        public bool TrangThai { get; set; }
        public string TrangThaiText => TrangThai ? "Hoạt Động" : "Ngừng Hoạt Động";
    }
}
