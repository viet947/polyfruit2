using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLyTraiCay;
using DTO_QuanLyTraiCay;

namespace BLL_QuanLyTraiCay
{
    public class BUSNhacungcap
    {
        DAL_NhaCungCap DAL_NhaCungCap = new DAL_NhaCungCap();

        public List<nhacungcap> GetAllNhaCungCap()
        {
            return DAL_NhaCungCap.GetAll();
        }

        public void ThemNhaCungCap(nhacungcap ncc)
        {
            DAL_NhaCungCap.insertNhaCungCap(ncc);
        }

        public void SuaNhaCungCap(nhacungcap ncc)
        {
            DAL_NhaCungCap.updateNhaCungCap(ncc);
        }

        public void XoaNhaCungCap(string maNCC)
        {
            DAL_NhaCungCap.deleteNhaCungCap(maNCC);
        }
    }
}
