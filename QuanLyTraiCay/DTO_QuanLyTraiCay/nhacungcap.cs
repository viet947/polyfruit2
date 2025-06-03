using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyTraiCay
{
   public class nhacungcap
    {
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime NgayTao { get; set; } = new DateTime();
        public string ghichu { get; set; }

    }
}
