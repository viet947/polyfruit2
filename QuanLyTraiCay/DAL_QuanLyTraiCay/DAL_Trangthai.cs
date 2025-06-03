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
    public class DAL_Trangthai
    {
        public List<Trangthai> SelectBySql (string sql, List<object> args, CommandType cmdtype = CommandType.Text)
        {
            List<Trangthai> list = new List<Trangthai>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    Trangthai trangthai = new Trangthai();

                    trangthai.MaTrangThai = reader["MaTrangThai"].ToString();
                    trangthai. TenTrangThai = reader["TenTrangThai"].ToString();
                    trangthai. MoTa = reader["MoTa"].ToString();
                    
                    list.Add(trangthai);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in DAL_Trangthai.SelectBySql: " + ex.Message);
            }
            return list;
        }
        public List<Trangthai> SelectAll()
        {
            string sql = "SELECT * FROM TrangThai";
            return SelectBySql(sql, new List<object>());
        }


    }
}
