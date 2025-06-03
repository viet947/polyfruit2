using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLyTraiCay;
using DTO_QuanLyTraiCay;

namespace BLL_QuanLyTraiCay
{
    public class Bus_ChiTietDonHang
    {
        DAL_Chitietdonhang dal = new DAL_Chitietdonhang();

        public List<Chitietloaisanpham> GetAllChiTietDonHang(string maDonHang)
        {
            return dal.SelectAllChitietdonhang(maDonHang);
        }

        public string AddChiTietDonHang(Chitietloaisanpham ct)
        {
            try
            {
                ct.MaDonhang = dal.generateChiTietID();
                if(string.IsNullOrEmpty (ct.MaChiTiet)){
                    return "MaChiTiet không được để trống!";

                }
                dal. Insert(ct);
                return string.Empty;

            }
            catch (Exception ex)
            {
                return $"Lỗi khi thêm chi tiết đơn hàng: {ex.Message}";
            }
        }

        public string UpdateChiTietDonHang(Chitietloaisanpham ct)
        {
            try
            {
                if (string.IsNullOrEmpty(ct.MaChiTiet))
                {
                    return "MaChiTiet không được để trống!";
                }
                dal.Update(ct);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return $"Lỗi khi cập nhật chi tiết đơn hàng: {ex.Message}";
            }
        }


        public string DeleteChiTietDonHang(string maChiTiet)
        {
            try
            {
                if (string.IsNullOrEmpty(maChiTiet))
                {
                    return "MaChiTiet không được để trống!";
                }
                dal.Delete(maChiTiet);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return $"Lỗi khi xóa chi tiết đơn hàng: {ex.Message}";
            }
        }
    }
}
