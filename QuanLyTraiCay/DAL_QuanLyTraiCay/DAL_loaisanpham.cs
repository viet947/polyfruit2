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
    public class DAL_loaisanpham
    {
        public List<LoaiSanpham> SelectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<LoaiSanpham> list = new List<LoaiSanpham>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args, cmdType);
                while (reader.Read())
                {
                    LoaiSanpham sp = new LoaiSanpham();

                    sp.MaLoaiSP = reader["MaLoaiSP"].ToString();
                    sp.TenLoai = reader["TenLoai"].ToString();
                    sp.NgayTao = Convert.ToDateTime(reader["NgayTao"]);
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
        public List<LoaiSanpham> selectAllLoaiSanpham()
        {
            String sql = "SELECT * FROM LoaiSanPham";
            return SelectBySql(sql, new List<object>(), CommandType.Text);
        }

        public void Insert(LoaiSanpham sp)
        {
            try
            {
                string sql = "INSERT INTO LoaiSanPham (MaLoaiSP, TenLoai, NgayTao, GhiChu) " +
                             "VALUES (@MaLoaiSP, @TenLoai, @NgayTao, @GhiChu)";
                List<object> thamso = new List<object>
                {
                    Tuple.Create("@MaLoaiSP", (object)sp.MaLoaiSP),
                    Tuple.Create("@TenLoai", (object)sp.TenLoai),
                    Tuple.Create("@NgayTao", (object)sp.NgayTao),
                    Tuple.Create("@GhiChu", (object)sp.GhiChu)
                };
                DBUtil.Update(sql, thamso);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Update(LoaiSanpham sp)
        {
            try
            {
                string sql = "UPDATE LoaiSanPham SET TenLoai = @TenLoai, NgayTao = @NgayTao, GhiChu = @GhiChu WHERE MaLoaiSP = @MaLoaiSP";
                List<object> thamso = new List<object>
                {
                    Tuple.Create("@MaLoaiSP", (object)sp.MaLoaiSP),
                    Tuple.Create("@TenLoai", (object)sp.TenLoai),
                    Tuple.Create("@NgayTao", (object)sp.NgayTao),
                    Tuple.Create("@GhiChu", (object)sp.GhiChu)
                };
                DBUtil.Update(sql, thamso);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Delete(string maLoaiSP)
        {
            try
            {
                string sql = "DELETE FROM LoaiSanPham WHERE MaLoaiSP = @MaLoaiSP";
                List<object> thamso = new List<object>
                {
                    Tuple.Create("@MaLoaiSP", (object)maLoaiSP)
                };
                DBUtil.Update(sql, thamso);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string automaloaisp()
        {
            string maphieuchitiet = "LSP";
            string sql = "SELECT MAX(MaLoaiSP) FROM LoaiSanPham"; // Lấy mã phiếu lớn nhất hiện có
            List<object> thamSo = new List<object>();
            object ketqua = DBUtil.ScalarQuery(sql, thamSo);
            if (ketqua != null && ketqua.ToString().StartsWith(maphieuchitiet))
            {
                string soHienTaitrongphieubanhang = ketqua.ToString().Substring(maphieuchitiet.Length); // Lấy phần số phía sau "PHB"
                int soMoi = int.Parse(soHienTaitrongphieubanhang) + 1; // Tăng số lên 1
                return $"{maphieuchitiet}{soMoi:D3}"; // ghep thanh so moi
            }
            else
            {
                // Trường hợp chưa có phiếu nào trong hệ thống => bắt đầu từ "PHB001"
                return $"{maphieuchitiet}001";
            }
        }
    }
}
