using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLyTraiCay;
using DTO_QuanLyTraiCay;
using Microsoft.Identity.Client;

namespace BLL_QuanLyTraiCay
{
    public class BUS_Donhang
    {
        
            DAL_donhang donhang = new DAL_donhang();

        public List<Donhang> GetAllDonhangs(string MaDonhang)
        {
            return donhang.SelectAllDonhang(MaDonhang);
        }
        public string  InsertDonhang(Donhang dh)
        {
            try
            {
                dh.MaDonHang = donhang.AutoMaDonHang();
                if (string.IsNullOrEmpty(dh.MaDonHang))
                {
                    return "Mã đơn hàng không được để trống.";
                }
                donhang.Insert(dh);
                return string.Empty; 
            }
            catch (Exception ex)
            {
                return "Thêm mới thất bại: " + ex.Message;
            }
        }
        public string UpdateDonhang(Donhang dh)
        {
            try
            {
                if (string.IsNullOrEmpty(dh.MaDonHang))
                {
                    return "Mã đơn hàng không được để trống.";
                }
                donhang.Update(dh);
                return string.Empty; 
            }
            catch (Exception ex)
            {
                return "Cập nhật thất bại: " + ex.Message;
            }
        }
        public string DeleteDonhang(string maDonHang)
        {
            try
            {
                if (string.IsNullOrEmpty(maDonHang))
                {
                    return "Mã đơn hàng không được để trống.";
                }
                donhang.Delete(maDonHang);
                return string.Empty; 
            }
            catch (Exception ex)
            {
                return "Xóa thất bại: " + ex.Message;
            }
        }
    }

}
   

