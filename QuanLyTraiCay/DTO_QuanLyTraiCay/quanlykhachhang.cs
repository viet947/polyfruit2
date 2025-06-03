using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyTraiCay
{
    public class quanlykhachhang
    {
        public string MaKhach { get; set; }
        public string TenKhach { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string GhiChu { get; set; }
        public DateTime NgayTao { get; set; }
        public string GioiTinh { get; set; }
        public string KhachHangThanThiet { get; set; }
        public bool TrangThai { get; set; }
     
        public string TrangThaiText => TrangThai ? "Đang Hoạt Động" : "Tạm Ngưng";
    }
}
