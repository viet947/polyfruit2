using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyTraiCay
{
    public class LoaiSanpham
    {
        public string MaLoaiSP { get; set; }
        public string TenLoai { get; set; }
        public DateTime NgayTao { get; set; } = DateTime.Now;
        public string GhiChu { get; set; }
    }
}
