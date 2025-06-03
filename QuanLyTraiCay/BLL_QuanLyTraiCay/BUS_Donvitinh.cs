using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLyTraiCay;
using DTO_QuanLyTraiCay;

namespace BLL_QuanLyTraiCay
{
    public class BUS_Donvitinh
    {
        DAL_Donvitinh DAL_Donvitinh = new DAL_Donvitinh();

        public List<Donvitinh> laydanhsachdonvitinh()
        {
            return DAL_Donvitinh.Getalldonvitinh();
        }
    }
}
