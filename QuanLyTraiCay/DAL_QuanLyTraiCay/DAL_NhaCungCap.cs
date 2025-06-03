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
    public class DAL_NhaCungCap
    {
        public List<nhacungcap> GetAll()
        {
            List<nhacungcap> list = new List<nhacungcap>();
            string sql = "SELECT * FROM NhaCungCap";
            List<object> args = new List<object>();

            using (SqlDataReader reader = DBUtil.Query(sql, args))
            {
                while (reader.Read())
                {
                    nhacungcap ncc = new nhacungcap
                    {
                        MaNCC = reader["MaNCC"].ToString(),
                        TenNCC = reader["TenNhaCungCap"].ToString(),
                        DiaChi = reader["DiaChi"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        NgayTao = Convert.ToDateTime(reader["NgayTao"]),
                        ghichu = reader["GhiChu"].ToString()
                    };
                    list.Add(ncc);
                }
            }
            return list;
        }


        public List<nhacungcap> SelectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<nhacungcap> list = new List<nhacungcap>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                            nhacungcap entity = new nhacungcap();
                    entity.MaNCC = reader["MaNCC"].ToString();
                    entity.TenNCC = reader["TenNhaCungCap"].ToString();
                    entity.DiaChi = reader["DiaChi"].ToString();
                    entity.SoDienThoai = reader["SoDienThoai"].ToString();
                    entity.NgayTao = Convert.ToDateTime(reader["NgayTao"]);
                    entity.ghichu = reader["GhiChu"].ToString();
                    list.Add(entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public List<nhacungcap> selectAll()
        {
            string sql = "SELECT * FROM NhaCungCap";
            return SelectBySql(sql, new List<object>());
        }
            
        public void insertNhaCungCap(nhacungcap ncc)
        {
            try
            {
                string sql = @"INSERT INTO NhaCungCap (MaNCC, TenNhaCungCap, DiaChi, SoDienThoai, NgayTao, GhiChu) 
                               VALUES (@0, @1, @2, @3, @4, @5)";
                List<object> thamSo = new List<object>
                {
                    ncc.MaNCC, ncc.TenNCC, ncc.DiaChi, ncc.SoDienThoai, ncc.NgayTao, ncc.ghichu
                };
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void updateNhaCungCap(nhacungcap ncc)
        {
            try
            {
                string sql = @"UPDATE NhaCungCap 
                               SET TenNhaCungCap = @1, DiaChi = @2, SoDienThoai = @3, NgayTao = @4, GhiChu = @5 
                               WHERE MaNCC = @0";
                List<object> thamSo = new List<object>
                {
                    ncc.MaNCC, ncc.TenNCC, ncc.DiaChi, ncc.SoDienThoai, ncc.NgayTao, ncc.ghichu
                };
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void deleteNhaCungCap(string maNCC)
        {
            try
            {
                string sql = "DELETE FROM NhaCungCap WHERE MaNCC = @0";
                List<object> thamSo = new List<object> { maNCC };
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string generateMaNCC()
        {
            string manhacungcap = "NCC";
            string sql = "SELECT MAX(MaNCC) FROM NhaCungCap";
            List<object> thamSo = new List<object>();
            object result = DBUtil.ScalarQuery(sql, thamSo);
            if (result != null && result.ToString().StartsWith(manhacungcap))
            {
                string maxCode = result.ToString().Substring(3);
                int newNumber = int.Parse(maxCode) + 1;
                return $"{manhacungcap}{newNumber:D3}";
            }

            return $"{manhacungcap}001";
        }
    }
}
    