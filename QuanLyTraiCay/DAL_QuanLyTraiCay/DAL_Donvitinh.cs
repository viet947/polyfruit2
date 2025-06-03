using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLyTraiCay;
using Microsoft.Data.SqlClient;

namespace DAL_QuanLyTraiCay
{
    public class DAL_Donvitinh
    {
        public List<Donvitinh> Getalldonvitinh()
        {
            List<Donvitinh> list = new List<Donvitinh>();
            string sql = "SELECT * FROM Donvitinh";
            List<object> agrs = new List<object>();
            using (SqlDataReader reader = DBUtil.Query(sql, agrs))
            {
                while (reader.Read())
                {
                    Donvitinh donvitinh = new Donvitinh
                    {
                        MaDVT = reader["MaDVT"].ToString() ?? string.Empty,
                        TenDVT = reader["TenDVT"].ToString() ?? string.Empty,
                        MoTa = reader["MoTa"].ToString() ?? string.Empty
                    };
                    list.Add(donvitinh);
                }
            }
            return list;
        }


    }
}
