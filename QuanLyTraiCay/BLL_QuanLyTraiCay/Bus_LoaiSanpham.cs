using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLyTraiCay;
using DTO_QuanLyTraiCay;

namespace BLL_QuanLyTraiCay
{
    public class Bus_LoaiSanpham
    {
        DAL_loaisanpham dAL_Loaisanpham = new DAL_loaisanpham();

        public List<LoaiSanpham> GetAllLoaiSanpham()
        {
            return dAL_Loaisanpham.selectAllLoaiSanpham();
        }
        public string InsertLoaiSanpham(LoaiSanpham sp)
        {
            try
            {   sp.MaLoaiSP = dAL_Loaisanpham.automaloaisp();
                if (string.IsNullOrEmpty(sp.MaLoaiSP))
                {
                    return "Mã loại sản phẩm không được để trống.";
                }
                dAL_Loaisanpham.Insert(sp);
                return string.Empty; 
            }
            catch (Exception ex)
            {
                return "Thêm mới thất bại: " + ex.Message;
            }
        }

        public string UpdateLoaiSanpham(LoaiSanpham sp)
        {
            try
            {
                if (string.IsNullOrEmpty(sp.MaLoaiSP))
                {
                    return "Mã loại sản phẩm không được để trống.";
                }
                dAL_Loaisanpham.Update(sp);
                return string.Empty; 
            }
            catch (Exception ex)
            {
                return "Cập nhật thất bại: " + ex.Message;
            }
        }
        public string DeleteLoaiSanpham(string maLoaiSP)
        {
            try
            {
                if (string.IsNullOrEmpty(maLoaiSP))
                {
                    return "Mã loại sản phẩm không được để trống.";
                }
                dAL_Loaisanpham.Delete(maLoaiSP);
                return string.Empty; 
            }
            catch (Exception ex)
            {
                return "Xóa thất bại: " + ex.Message;
            }
        }
    }
}
