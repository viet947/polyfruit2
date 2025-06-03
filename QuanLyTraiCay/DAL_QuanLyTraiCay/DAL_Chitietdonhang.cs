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
    public class DAL_Chitietdonhang
    {
        public List<Chitietloaisanpham> SelectSql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<Chitietloaisanpham> list = new List<Chitietloaisanpham>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args, cmdType);
                while (reader.Read())
                {
                    Chitietloaisanpham ct = new Chitietloaisanpham();

                    ct.MaChiTiet = reader["MaChiTiet"].ToString();
                    ct.MaDonhang = reader["MaDonHang"].ToString();
                    ct.MaSp = reader["MaSP"].ToString();
                    ct.SoLuong = Convert.ToInt32(reader["SoLuong"]);
                    ct.DonGiaBan = Convert.ToDecimal(reader["DonGia"]);


                    list.Add(ct);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }


        public List<Chitietloaisanpham> SelectAllChitietdonhang(string maDonHang)
        {
            string sql = "SELECT ct.MaChiTiet, ct.MaPhieu, ct.MaSp,  ct.SoLuong,  ct.DonGiaBan ,  sp.TenSP  " +
                         "FROM Chitietdonhang ct " +
                         "INNER JOIN Sanpham sp ON ct.MaSp = sp.MaSP" +
                          "WHERE ct.MaDonHang = @0";
            List<object> thamSo = new List<object>();
            thamSo.Add(maDonHang);
            return SelectSql(sql, thamSo);
        }

        public void Insert(Chitietloaisanpham ct)
        {
            try
            {
                string sql = "INSERT INTO Chitietdonhang (MaChiTiet, MaDonHang, MaSP, SoLuong, DonGiaBan) " +
                             "VALUES (@MaChiTiet, @MaDonHang, @MaSP, @SoLuong, @DonGiaBan)";
                List<object> thamso = new List<object>
                {
                    Tuple.Create("@MaChiTiet", (object)ct.MaChiTiet),
                    Tuple.Create("@MaDonHang", (object)ct.MaDonhang),
                    Tuple.Create("@MaSP", (object)ct.MaSp),
                    Tuple.Create("@SoLuong", (object)ct.SoLuong),
                    Tuple.Create("@DonGiaBan", (object)ct.DonGiaBan)
                };
                DBUtil.Update(sql, thamso);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void insertListChiTiet(List<Chitietloaisanpham> lstChiTiet)
        {
            try
            {
                foreach (Chitietloaisanpham item in lstChiTiet)
                {
                    Insert(item);
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public void Update(Chitietloaisanpham ct)
        {
            try
            {
                string sql = "UPDATE Chitietdonhang SET MaDonHang = @MaDonHang, MaSP = @MaSP, SoLuong = @SoLuong, DonGiaBan = @DonGiaBan WHERE MaChiTiet = @MaChiTiet";
                List<object> thamso = new List<object>
                {
                    Tuple.Create("@MaChiTiet", (object)ct.MaChiTiet),
                    Tuple.Create("@MaDonHang", (object)ct.MaDonhang),
                    Tuple.Create("@MaSP", (object)ct.MaSp),
                    Tuple.Create("@SoLuong", (object)ct.SoLuong),
                    Tuple.Create("@DonGiaBan", (object)ct.DonGiaBan)
                };
                DBUtil.Update(sql, thamso);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void Delete(string maChiTiet)
        {
            try
            {
                string sql = "DELETE FROM Chitietdonhang WHERE MaChiTiet = @MaChiTiet";
                List<object> thamso = new List<object>
                {
                    Tuple.Create("@MaChiTiet", (object)maChiTiet)
                };
                DBUtil.Update(sql, thamso);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public string generateChiTietID()
        {
            string prefix = "CTDH";
            string sql = "SELECT MAX(MaChiTiet) FROM ChiTietDonHang";
            List<object> thamSo = new List<object>();
            object result = DBUtil.ScalarQuery(sql, thamSo);
            if (result != null && result.ToString().StartsWith(prefix))
            {
                string maxCode = result.ToString().Substring(3);
                int newNumber = int.Parse(maxCode) + 1;
                return $"{prefix}{newNumber:D3}";
            }

            return $"{prefix}001";
        }
    }
}
