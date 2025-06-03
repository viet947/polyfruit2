using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLyTraiCay;
using DTO_QuanLyTraiCay;

namespace BLL_QuanLyTraiCay
{
    public class Bus_TrangThai
    {
        DAL_Trangthai dalTrangThai = new DAL_Trangthai();
        public List<Trangthai> GetTrangthais()
        {
            return dalTrangThai.SelectAll();
        }

    }
}
