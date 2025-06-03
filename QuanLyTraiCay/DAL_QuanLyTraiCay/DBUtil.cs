using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using DTO_QuanLyTraiCay;

namespace DAL_QuanLyTraiCay
{
    public class DBUtil
    {
        public static string connString = @"Data Source=VITCON222\SQLEXPRESS02;Initial Catalog=Xuong_QuanLyTraiCay;Integrated Security=True;Trust Server Certificate=True";

        public static SqlCommand GetCommand(string sql, List<Object> args, CommandType cmdType)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = cmdType;

            // Nếu args không phải Tuple, tự động tạo tham số @0, @1, ...
            for (int i = 0; i < args.Count; i++)
            {
                var param = args[i] as Tuple<string, object>;
                if (param != null)
                {
                    cmd.Parameters.AddWithValue(param.Item1, param.Item2 ?? DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue($"@{i}", args[i] ?? DBNull.Value);
                }
            }

            return cmd;
        }

        public static void Update(string sql, List<Object> args, CommandType cmdType = CommandType.Text)
        {
            SqlCommand cmd = GetCommand(sql, args, cmdType);
            cmd.Connection.Open();

            // Bắt đầu transaction
            SqlTransaction transaction = cmd.Connection.BeginTransaction();
            cmd.Transaction = transaction;

            try
            {
                cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        public static SqlDataReader Query(string sql, List<Object> args, CommandType cmdType = CommandType.Text)
        {
            try
            {
                SqlCommand cmd = GetCommand(sql, args, cmdType);
                cmd.Connection.Open();
                return cmd.ExecuteReader();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static T Value<T>(string sql, List<object> args, CommandType cmdType = CommandType.Text) where T : new()
        {
            try
            {
                SqlCommand cmd = GetCommand(sql, args, cmdType);
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    T result = new T();
                    Type type = typeof(T);

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string columnName = reader.GetName(i);
                        PropertyInfo propertyInfo = type.GetProperty(columnName);
                        if (propertyInfo != null && propertyInfo.CanWrite)
                        {
                            object value = reader.IsDBNull(i) ? null : reader.GetValue(i);
                            if (value != null)
                                propertyInfo.SetValue(result, Convert.ChangeType(value, propertyInfo.PropertyType));
                        }
                        return result;
                    }
                    return default;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return default;
        }
        public static object ScalarQuery(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            try
            {
                SqlCommand cmd = GetCommand(sql, args, cmdType);
                cmd.Connection.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
