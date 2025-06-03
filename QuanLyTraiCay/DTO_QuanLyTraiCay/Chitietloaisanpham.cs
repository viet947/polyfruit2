using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyTraiCay
{
    public class Chitietloaisanpham
    {
        public string MaChiTiet { get; set; }
        public string MaDonhang { get; set; }
        public string MaSp { get; set; }
        public string MaDVT { get; set; }
        public int SoLuong { get; set; }

        public decimal DonGiaBan { get; set; }
        public decimal ThanhTien =>  DonGiaBan * SoLuong;

    }
}
