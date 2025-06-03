using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyTraiCay
{
    public class NhanVien
    {
       public string MaNV {  get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public string GioiTinh { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string MatKhau { get; set; } = string.Empty;
        public string DiaChi { get; set; } = string.Empty;
        public bool VaiTro { get; set; }
        public bool TrangThai { get; set; }
        public string VaiTroText => VaiTro ? "Quản lý" : "Nhân Viên";
        public string TrangThaiText => TrangThai ? "Đang Hoạt Động" : "Tạm Ngưng";
    }
    
}
