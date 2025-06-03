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
    public class DAL_donhang
    {
        public List<Donhang> SelectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<Donhang> list = new List<Donhang>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args, cmdType);
                while (reader.Read())
                {
                    Donhang dh = new Donhang
                    {
                        MaDonHang = reader["MaDonHang"].ToString(),

                        MaKhach = reader["MaKhach"].ToString(),
                        TenKhach = reader["TenKhach"].ToString(),
                        MaNV = reader["MaNV"].ToString(),
                        TenNV = reader["HoTen"].ToString(),
                        NgayDatHang = Convert.ToDateTime(reader["NgayDatHang"]),
                        DiaChiGiaoHang = reader["DiaChiGiaoHang"].ToString(),
                        MaTrangThai = reader["MaTrangThai"].ToString(),
                        TenTrangThai = reader["TenTrangThai"].ToString(),
                        GhiChu = reader["GhiChu"].ToString()
                    };
                    list.Add(dh);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public List<Donhang> SelectAllDonhang(string MaDonHang)
        {
            List<object> param = new List<object>();
            string sql = @"
                    SELECT 
                        dh.MaDonHang, 
                        dh.MaNV, 
                        dh.MaKhach, 
                        kh.TenKhach, 
                        nv.HoTen,
                        dh.NgayDatHang, 
                        dh.DiaChiGiaoHang, 
                        dh.MaTrangThai, 
                        tt.TenTrangThai,    
                        dh.GhiChu 
                    FROM Donhang dh
                    INNER JOIN NhanVien nv ON dh.MaNV = nv.MaNV
                    INNER JOIN KhachHang kh ON dh.MaKhach = kh.MaKhach
                    INNER JOIN TrangThai tt ON dh.MaTrangThai = tt.MaTrangThai
";

            if (!string.IsNullOrEmpty(MaDonHang)) // Giả sử bạn dùng biến 'maThe' để tìm theo MaNhanVien
            {
                sql += " WHERE dh.MaNV = @0";
                param.Add(MaDonHang);
            }

            return SelectBySql(sql, param);

        }


        public void Insert(Donhang dh)
        {
            try
            {
                string sql = "INSERT INTO DonHang (MaDonHang, MaKhach, MaNV, TenKhach, NgayDatHang, DiaChiGiaoHang, MaTrangThai, GhiChu) " +
                             "VALUES (@MaDonHang, @MaKhach, @MaNV, @TenKhach, @NgayDatHang, @DiaChiGiaoHang, @MaTrangThai, @GhiChu)";
                List<object> thamso = new List<object>
                {
                    Tuple.Create("@MaDonHang", (object)dh.MaDonHang),
                    Tuple.Create("@MaKhach", (object)dh.MaKhach),
                    Tuple.Create("@MaNV", (object)dh.MaNV),
                  
                    Tuple.Create("@NgayDatHang", (object)dh.NgayDatHang),
                    Tuple.Create("@DiaChiGiaoHang", (object)dh.DiaChiGiaoHang),
                    Tuple.Create("@MaTrangThai", (object)dh.MaTrangThai),
                    Tuple.Create("@GhiChu", (object)dh.GhiChu)
                };
                DBUtil.Update(sql, thamso);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Donhang dh)
        {
            try
            {
                string sql = "UPDATE DonHang SET MaKhach = @MaKhach, MaNV = @MaNV, TenKhach=@TenKhach, NgayDatHang = @NgayDatHang, " +
                             "DiaChiGiaoHang = @DiaChiGiaoHang, MaTrangThai = @MaTrangThai, GhiChu = @GhiChu " +
                             "WHERE MaDonHang = @MaDonHang";
                List<object> thamso = new List<object>
                {
                    Tuple.Create("@MaDonHang", (object)dh.MaDonHang),
                    Tuple.Create("@MaKhach", (object)dh.MaKhach),
                    Tuple.Create("@MaNV", (object)dh.MaNV),
                 
                    Tuple.Create("@NgayDatHang", (object)dh.NgayDatHang),
                    Tuple.Create("@DiaChiGiaoHang", (object)dh.DiaChiGiaoHang),
                    Tuple.Create("@MaTrangThai", (object)dh.MaTrangThai),
                    Tuple.Create("@GhiChu", (object)dh.GhiChu)
                };
                DBUtil.Update(sql, thamso);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(string maDonHang)
        {
            try
            {
                string sql = "DELETE FROM DonHang WHERE MaDonHang = @MaDonHang";
                List<object> thamso = new List<object>
                {
                    Tuple.Create("@MaDonHang", (object)maDonHang)
                };
                DBUtil.Update(sql, thamso);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string AutoMaDonHang()
        {
            string madonhang = "DH";
            string sql = "SELECT MAX(MaDonHang) FROM DonHang";
            List<object> thamso = new List<object>();
            object result = DBUtil.ScalarQuery(sql, thamso);
            if (result != null && result.ToString().StartsWith(madonhang))
            {
                string maxCode = result.ToString().Substring(3);
                int newNumber = int.Parse(maxCode) + 1;
                return $"{madonhang}{newNumber:D3}";
            }
            return $"{madonhang}001";
        }
    }
}
