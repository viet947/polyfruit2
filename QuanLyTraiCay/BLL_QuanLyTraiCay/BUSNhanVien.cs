using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLyTraiCay;
using DTO_QuanLyTraiCay;

namespace BLL_QuanLyTraiCay
{
    public class BUSNhanVien
    {
        DAL_NhanVien dalNhanVien = new DAL_NhanVien();
        public NhanVien? DangNhap(string username, string matkhau)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(matkhau))
                return null;

            return dalNhanVien.getNhanVien1(username, matkhau);

        }

        public List<NhanVien> GetNhanVienList()
        {
            return dalNhanVien.selectAll();
        }

        public string UpdateNhanVien(NhanVien nv)
        {
            try
            {
                if (string.IsNullOrEmpty(nv.MaNV))
                {
                    return "Mã nhân viên không hợp lệ.";
                }
                dalNhanVien.updateNhanVien(nv);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Cập nhật không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }
        public string DeleteNhanVien(string maNV)
        {
            try
            {
                if (string.IsNullOrEmpty(maNV))
                {
                    return "Mã nhân viên không hợp lệ.";
                }
                dalNhanVien.deleteNhanVien(maNV);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Xóa không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }
        public string AddNhanVien(NhanVien nv)
        {
            try
            {
                nv.MaNV = dalNhanVien.autothemnhanvien(); // Tự động tạo mã nhân viên mới
                if (string.IsNullOrEmpty(nv.MaNV) || string.IsNullOrEmpty(nv.Email) || string.IsNullOrEmpty(nv.MatKhau))
                {
                    return "Thông tin nhân viên không hợp lệ.";
                }
                dalNhanVien.insertNhanVien(nv);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Thêm mới không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }
    }
}
