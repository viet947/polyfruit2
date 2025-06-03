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
    public class DAL_Sanpham
    {
        public List<Sanpham> SelectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<Sanpham> list = new List<Sanpham>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args, cmdType);
                while (reader.Read())
                {
                    Sanpham sp = new Sanpham();
                    sp.MaSP = reader["MaSP"].ToString();
                    sp.TenSanPham = reader["TenSanPham"].ToString();
                    sp.MaLoaiSP = reader["MaLoaiSP"].ToString();
                    sp.TenLoaiSP = reader["TenLoai"].ToString();
                    sp.MaNCC = reader["MaNCC"].ToString();
                    sp.TenNhaCungCap = reader["TenNhaCungCap"].ToString();
                    sp.MaDVT = reader["MaDVT"].ToString();
                    sp.TenDVT = reader["TenDVT"].ToString();
                    sp.DonGiaNhap = decimal.Parse(reader["DonGiaNhap"].ToString());
                    sp.DonGiaBan = decimal.Parse(reader["DonGiaBan"].ToString());
                    sp.SoLuong = decimal.Parse(reader["SoLuong"].ToString());
                    sp.TrangThai = Convert.ToBoolean(reader["TrangThai"]);
                    sp.HinhAnh = reader["HinhAnh"].ToString();
                    sp.GhiChu = reader["GhiChu"].ToString();
                    list.Add(sp);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public List<Sanpham> selectAllSanpham(int trangthai =  -1 )
        {
            string sql = @"
                    SELECT 
                        sp.MaSP,
                        sp.TenSanPham,
                        sp.MaLoaiSP,
                        sp.MaNCC,
                        sp.MaDVT,
                        sp.DonGiaNhap,
                        sp.DonGiaBan,
                        sp.SoLuong,
                        sp.HinhAnh,
                        sp.GhiChu,
                        sp.TrangThai,
                        lsp.TenLoai,
                        ncc.TenNhaCungCap,
                        dvt.TenDVT
                    FROM 
                        SanPham sp
                    INNER JOIN 
                        LoaiSanPham lsp ON sp.MaLoaiSP = lsp.MaLoaiSP
                    INNER JOIN 
                        NhaCungCap ncc ON sp.MaNCC = ncc.MaNCC
                    INNER JOIN 
                        DonViTinh dvt ON sp.MaDVT = dvt.MaDVT
                    ";
            List<object> thamso = new List<object>();
            if (trangthai != -1)
            {
                sql += "WHERE SanPham.TrangThai = @0 ";
            }
            thamso.Add(trangthai);
            return SelectBySql(sql, thamso);
        }

   

        public Sanpham selectByid(string id)
        {
            String sql = "SELECT * FROM SanPham WHERE MaSP = @0";
            List<object> thamso = new List<object>();
            thamso.Add(id);
            List<Sanpham> list = SelectBySql(sql, thamso);
            return list.Count > 0 ? list[0] : null;
        }
        public void Insert(Sanpham sp)
        {
            try
            {
                string sql = "INSERT INTO SanPham (MaSP, TenSanPham, MaLoaiSP, MaNCC, MaDVT, DonGiaNhap, DonGiaBan, SoLuong, HinhAnh, GhiChu, TrangThai) " +
                             "VALUES (@MaSP, @TenSanPham, @MaLoaiSP, @MaNCC, @MaDVT, @DonGiaNhap, @DonGiaBan, @SoLuong, @HinhAnh, @GhiChu, @TrangThai)";
                List<object> thamso = new List<object>
                {
                    Tuple.Create("@MaSP", (object)sp.MaSP),
                    Tuple.Create("@TenSanPham", (object)sp.TenSanPham),
                    Tuple.Create("@MaLoaiSP", (object)sp.MaLoaiSP),
                    Tuple.Create("@MaNCC", (object)sp.MaNCC),
                    Tuple.Create("@MaDVT", (object)sp.MaDVT),
                    Tuple.Create("@DonGiaNhap", (object)sp.DonGiaNhap),
                    Tuple.Create("@DonGiaBan", (object)sp.DonGiaBan),
                    Tuple.Create("@SoLuong", (object)sp.SoLuong),
                    Tuple.Create("@HinhAnh", (object)sp.HinhAnh),
                    Tuple.Create("@GhiChu", (object)sp.GhiChu),
                    Tuple.Create("@TrangThai", (object)sp.TrangThai)
                };
                DBUtil.Update(sql, thamso);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Update(Sanpham sp)
        {
            try
            {
                string sql = "UPDATE SanPham SET TenSanPham = @TenSanPham, MaLoaiSP = @MaLoaiSP, MaNCC = @MaNCC, MaDVT = @MaDVT, " +
                             "DonGiaNhap = @DonGiaNhap, DonGiaBan = @DonGiaBan, SoLuong = @SoLuong, HinhAnh = @HinhAnh, " +
                             "GhiChu = @GhiChu, TrangThai = @TrangThai WHERE MaSP = @MaSP";
                List<object> thamso = new List<object>
                {
                    Tuple.Create("@MaSP", (object)sp.MaSP),
                    Tuple.Create("@TenSanPham", (object)sp.TenSanPham),
                    Tuple.Create("@MaLoaiSP", (object)sp.MaLoaiSP),
                    Tuple.Create("@MaNCC", (object)sp.MaNCC),
                    Tuple.Create("@MaDVT", (object)sp.MaDVT),
                    Tuple.Create("@DonGiaNhap", (object)sp.DonGiaNhap),
                    Tuple.Create("@DonGiaBan", (object)sp.DonGiaBan),
                    Tuple.Create("@SoLuong", (object)sp.SoLuong),
                    Tuple.Create("@HinhAnh", (object)sp.HinhAnh),
                    Tuple.Create("@GhiChu", (object)sp.GhiChu),
                    Tuple.Create("@TrangThai", (object)sp.TrangThai)
                };
                DBUtil.Update(sql, thamso);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Delete(string maSP)
        {
            try
            {
                string sql = "DELETE FROM SanPham WHERE MaSP = @MaSP";
                List<object> thamso = new List<object>
                {
                    Tuple.Create("@MaSP", (object)maSP)
                };
                DBUtil.Update(sql, thamso);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string autothemmaSp()
        {
            string prefix = "SP";
            string sql = "SELECT MAX(MaSP) FROM SanPham";
            List<object> thamSo = new List<object>();
            object result = DBUtil.ScalarQuery(sql, thamSo);
            if (result != null && result.ToString().StartsWith(prefix))
            {
                string maxCode = result.ToString().Substring(2);
                int newNumber = int.Parse(maxCode) + 1;
                return $"{prefix}{newNumber:D3}";
            }

            return $"{prefix}001";
        }
    }
    }


