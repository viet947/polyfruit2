using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLyTraiCay;
using DTO_QuanLyTraiCay;

namespace BLL_QuanLyTraiCay
{
    public class BUS_KhachHang
    {
        DAL_quanlykhachhang DAL_KhachHang = new DAL_quanlykhachhang();

        public List<quanlykhachhang> GetQuanlykhachhangs()
        {
            return DAL_KhachHang.selectAllquanlikhachhang();
        }

        public string UpdateKhachHang(quanlykhachhang kh)
        {
            try
            {
                if (string.IsNullOrEmpty(kh.MaKhach))
                {
                    return "Mã khách hàng không được để trống.";
                }
                DAL_KhachHang.Update(kh);
                return string.Empty; 
            }
            catch (Exception ex)
            {
                return "Cập nhật thất bại: " + ex.Message;
            }
        }

        public string InsertKhachHang(quanlykhachhang kh)
        {
            try
            {
                kh.MaKhach = DAL_KhachHang.autoMakhach();
                if (string.IsNullOrEmpty(kh.MaKhach))
                {
                    return "Mã khách hàng không được để trống.";
                }
                DAL_KhachHang.Insert(kh);
                return string.Empty; 
            }
            catch (Exception ex)
            {
                return "Thêm mới thất bại: " + ex.Message;
            }
        }

        public string DeleteKhachHang(string maKhach)
        {
            try
            {
                if (string.IsNullOrEmpty(maKhach))
                {
                    return "Mã khách hàng không được để trống.";
                }
                DAL_KhachHang.Delete(maKhach);
                return string.Empty; 
            }
            catch (Exception ex)
            {
                return "Xóa thất bại: " + ex.Message;
            }
        }
    }
}
