using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLyTraiCay;
using Microsoft.Data.SqlClient;

namespace DAL_QuanLyTraiCay
{
    public class DAL_quanlykhachhang
    {
        public List<quanlykhachhang> SelectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<quanlykhachhang> list = new List<quanlykhachhang>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args, cmdType);
                while (reader.Read())
                {
                    quanlykhachhang kh = new quanlykhachhang();
                    kh.MaKhach = reader["MaKhach"].ToString();
                    kh.TenKhach = reader["TenKhach"].ToString();
                    kh.DiaChi = reader["DiaChi"].ToString();
                    kh.DienThoai = reader["DienThoai"].ToString();
                    kh.GhiChu = reader["GhiChu"].ToString();
                    kh.KhachHangThanThiet = reader["KhachHangThanThiet"].ToString();
                    kh.NgayTao = Convert.ToDateTime(reader["NgayTao"]);
                    kh.TrangThai = Convert.ToBoolean(reader["TrangThai"]);
                    kh.GioiTinh = reader["GioiTinh"].ToString();
                    list.Add(kh);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public List<quanlykhachhang> selectAllquanlikhachhang()
        {
            String sql = "SELECT * FROM KhachHang";
            return SelectBySql(sql, new List<object>(), CommandType.Text);
        }

        public void Insert(quanlykhachhang kh)
        {
            try
            {
                string sql = "INSERT INTO KhachHang (MaKhach, TenKhach, DiaChi, DienThoai, GhiChu, NgayTao, TrangThai, GioiTinh, KhachHangThanThiet) " +
                             "VALUES (@MaKhach, @TenKhach, @DiaChi, @DienThoai, @GhiChu, @NgayTao, @TrangThai, @GioiTinh, @KhachHangThanThiet)";
                List<object> thamso = new List<object>
                {
                    Tuple.Create("@MaKhach", (object)kh.MaKhach),
                    Tuple.Create("@TenKhach", (object)kh.TenKhach),
                    Tuple.Create("@DiaChi", (object)kh.DiaChi),
                    Tuple.Create("@DienThoai", (object)kh.DienThoai),
                    Tuple.Create("@GhiChu", (object)kh.GhiChu),
                    Tuple.Create("@NgayTao", (object)kh.NgayTao),
                    Tuple.Create("@TrangThai", (object)kh.TrangThai),
                    Tuple.Create("@GioiTinh", (object)kh.GioiTinh),
                    Tuple.Create("@KhachHangThanThiet", (object)kh.KhachHangThanThiet)
                };
                DBUtil.Update(sql, thamso);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(quanlykhachhang kh)
        {
            try
            {
                string sql = "UPDATE KhachHang SET TenKhach = @TenKhach, DiaChi = @DiaChi, DienThoai = @DienThoai, GhiChu = @GhiChu, NgayTao = @NgayTao, TrangThai = @TrangThai, GioiTinh = @GioiTinh, KhachHangThanThiet = @KhachHangThanThiet WHERE MaKhach = @MaKhach";
                List<object> thamso = new List<object>
                {
                    Tuple.Create("@TenKhach", (object)kh.TenKhach),
                    Tuple.Create("@DiaChi", (object)kh.DiaChi),
                    Tuple.Create("@DienThoai", (object)kh.DienThoai),
                    Tuple.Create("@GhiChu", (object)kh.GhiChu),
                    Tuple.Create("@NgayTao", (object)kh.NgayTao),
                    Tuple.Create("@TrangThai", (object)kh.TrangThai),
                    Tuple.Create("@GioiTinh", (object)kh.GioiTinh),
                    Tuple.Create("@KhachHangThanThiet", (object)kh.KhachHangThanThiet),
                    Tuple.Create("@MaKhach", (object)kh.MaKhach)
                };
                DBUtil.Update(sql, thamso);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(string makhach)
        {
            try
            {
                string sql = "DELETE FROM KhachHang WHERE MaKhach = @MaKhach";
                List<object> thamso = new List<object>
                {
                    Tuple.Create("@MaKhach", (object)makhach)
                };
                DBUtil.Update(sql, thamso);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string autoMakhach()
        {
            string makhach = "KH";
            string sql = "SELECT MAX(MaKhach) FROM KhachHang";
            List<object> thamSo = new List<object>();
            object result = DBUtil.ScalarQuery(sql, thamSo);
            if (result != null && result.ToString().StartsWith(makhach))
            {
                string maxCode = result.ToString().Substring(3);
                int newNumber = int.Parse(maxCode) + 1;
                return $"{makhach}{newNumber:D3}";
            }

            return $"{makhach}001";
        }
    }
}
