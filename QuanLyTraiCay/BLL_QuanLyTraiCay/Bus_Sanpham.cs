using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLyTraiCay;
using DTO_QuanLyTraiCay;

namespace BLL_QuanLyTraiCay
{
   public class Bus_Sanpham
    {
        DAL_Sanpham DAL_Sanpham = new DAL_Sanpham();

        public List<Sanpham> GetSanphams()
        {
            return DAL_Sanpham.selectAllSanpham();
        }

        public string UpdateSanpham(Sanpham sp)
        {
            try
            {
                if (string.IsNullOrEmpty(sp.MaSP))
                {
                    return "Mã sản phẩm không được để trống.";
                }
                DAL_Sanpham.Update(sp);
                return string.Empty; 
            }
            catch (Exception ex)
            {
                return "Cập nhật thất bại: " + ex.Message;
            }
        }
        public string insertSanpham(Sanpham sp)
        {
            try
            {
                sp.MaSP = DAL_Sanpham.autothemmaSp();
                if (string.IsNullOrEmpty(sp.MaSP))
                {
                    return "Mã sản phẩm không được để trống.";
                }
                DAL_Sanpham.Insert(sp);
                return string.Empty; 
            }
            catch (Exception ex)
            {
                return "Thêm mới thất bại: " + ex.Message;
            }
        }

        public string DeleteSanpham(string maSP)
        {
            try
            {
                if (string.IsNullOrEmpty(maSP))
                {
                    return "Mã sản phẩm không được để trống.";
                }
                DAL_Sanpham.Delete(maSP);
                return string.Empty; 
            }
            catch (Exception ex)
            {
                return "Xóa thất bại: " + ex.Message;
            }
        }
    }
}
