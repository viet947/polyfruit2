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
    public class DAL_NhanVien
    {
        public NhanVien? getNhanVien1(string email, string matkhau)
        {
            string sql = "SELECT Top 1 * FROM NhanVien WHERE Email=@0 AND MatKhau=@1";
            List<object> thamSo = new List<object>();
            thamSo.Add(email);
            thamSo.Add(matkhau);
            SqlDataReader reader = DBUtil.Query(sql, thamSo);
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    NhanVien nhanVien = new NhanVien();
                    nhanVien.MaNV = reader["MaNV"].ToString() ?? string.Empty;
                    nhanVien.HoTen = reader["HoTen"].ToString() ?? string.Empty;
                    nhanVien.GioiTinh = reader["GioiTinh"].ToString() ?? string.Empty;
                    nhanVien.Email = reader["Email"].ToString() ?? string.Empty;
                    nhanVien.MatKhau = reader["MatKhau"].ToString() ?? string.Empty;
                    nhanVien.DiaChi = reader["DiaChi"].ToString() ?? string.Empty;
                    nhanVien.VaiTro = (bool)reader["VaiTro"];
                    nhanVien.TrangThai = (bool)reader["TrangThai"];
                    return nhanVien;
                }
            }
            return null;
        }
        public string autothemnhanvien()
        {
            string manv = "NV";
            string sql = "SELECT MAX(MaNV) FROM NhanVien"; 
            List<object> thamSo = new List<object>();
            object ketqua = DBUtil.ScalarQuery(sql, thamSo);
            if (ketqua != null && ketqua.ToString().StartsWith(manv))
            {
                string soHienTaitrongmanv = ketqua.ToString().Substring(manv.Length); // Lấy phần số phía sau "PHB"
                int soMoi = int.Parse(soHienTaitrongmanv) + 1; // Tăng số lên 1
                return $"{manv}{soMoi:D3}"; // ghep thanh so moi
            }
            else
            {
                // Trường hợp chưa có phiếu nào trong hệ thống => bắt đầu từ "PHB001"
                return $"{manv}001";
            }
        }

        public List<NhanVien> SelectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<NhanVien> list = new List<NhanVien>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    NhanVien entity = new NhanVien();
                    entity.MaNV = reader.GetString("MaNV");
                    entity.HoTen = reader.GetString("HoTen");
                    entity.Email = reader.GetString("Email");
                    entity.GioiTinh = reader.GetString("GioiTinh");
                    entity.DiaChi = reader.GetString("DiaChi");
                    entity.MatKhau = reader.GetString("MatKhau");
                    entity.VaiTro = reader.GetBoolean("VaiTro");
                    entity.TrangThai = reader.GetBoolean("TrangThai");
                    list.Add(entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }
        public List<NhanVien> selectAll()
        {
            String sql = "SELECT * FROM NhanVien";
            return SelectBySql(sql, new List<object>());
        }
        public void updateNhanVien(NhanVien nv)
        {
            try
            {
                string sql = @"UPDATE NhanVien SET HoTen = @1, Email = @2, GioiTinh =@3 , MatKhau = @4, DiaChi = @5, VaiTro = @6, TrangThai = @7
                            WHERE MaNV = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(nv.MaNV);
                thamSo.Add(nv.HoTen);
                thamSo.Add(nv.Email);
                thamSo.Add(nv.GioiTinh); 
                thamSo.Add(nv.MatKhau);
                thamSo.Add(nv.DiaChi);
                thamSo.Add(nv.VaiTro);
                thamSo.Add(nv.TrangThai);
                DBUtil.Update(sql, thamSo);

            }
            catch (Exception )
            {
                throw;
            }
        }
        public void insertNhanVien(NhanVien nv)
        {
            try
            {
                string sql = @"INSERT INTO NhanVien (MaNV, HoTen, Email, MatKhau, GioiTinh, DiaChi, VaiTro, TrangThai)
                            VALUES (@0, @1, @2, @3, @4, @5, @6, @7)";
                List<object> thamSo = new List<object>();
                thamSo.Add(nv.MaNV);
                thamSo.Add(nv.HoTen);
                thamSo.Add(nv.Email);
                thamSo.Add(nv.MatKhau);
                thamSo.Add(nv.GioiTinh);
                thamSo.Add(nv.DiaChi);
                thamSo.Add(nv.VaiTro);
                thamSo.Add(nv.TrangThai);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception )
            {
                throw;
            }
        }
        public void deleteNhanVien(string maNV)
        {
            try
            {
                string sql = "DELETE FROM NhanVien WHERE MaNV = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(maNV);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception )
            {
                throw;
            }
        }
    }
}

    

