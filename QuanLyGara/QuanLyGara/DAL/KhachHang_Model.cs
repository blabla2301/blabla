using QuanLyGara.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyGara.DAL
{
    class KhachHang_Model : sqlConnect
    {
        public void insertKHACHHANG(KhachHang kh)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("ThemKH", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaKH", kh.MaKH);
                cmd.Parameters.AddWithValue("@HoTen", kh.HoTen);
                cmd.Parameters.AddWithValue("@SDT", kh.SDT);
                cmd.Parameters.AddWithValue("@Email", kh.Email);
                cmd.Parameters.AddWithValue("@DiaChi", kh.DiaChi);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                new Exception("Error: " + ex.Message);
            }
            finally
            {
                closeConnection();
            }
        }

        public void editKHACHHANG(KhachHang kh)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("SuaKH", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaKH", kh.MaKH);
                cmd.Parameters.AddWithValue("@HoTen", kh.HoTen);
                cmd.Parameters.AddWithValue("@SDT", kh.SDT);
                cmd.Parameters.AddWithValue("@Email", kh.Email);
                cmd.Parameters.AddWithValue("@DiaChi", kh.DiaChi);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                new Exception("Error: " + ex.Message);
            }
            finally
            {
                closeConnection();
            }
        }

        public void deleteKHACHHANG(KhachHang kh)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("XoaKH", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaKH", kh.MaKH);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                new Exception("Error: " + ex.Message);
            }
            finally
            {
                closeConnection();
            }
        }

        public SqlDataReader searchKHACHHANG(string name, string value)
        {
            SqlDataReader dr = null;
            string query;
            if (name.Equals("Mã khách hàng"))
            {
                query = "select * from KHACHHANG where MaKH like '" + value + "%'";
                dr = execCommand(query);
            }
            else if (name.Equals("Họ tên"))
            {
                query = "select * from KHACHHANG where HoTen like N'" + value + "%'";
                dr = execCommand(query);
            }
            else if (name.Equals("Số điện thoại"))
            {
                query = "select * from KHACHHANG where SDT like '" + value + "%'";
                dr = execCommand(query);
            }
            else if (name.Equals("Email"))
            {
                query = "select * from KHACHHANG where Email like '" + value + "%'";
                dr = execCommand(query);
            }
            else
            {
                query = "select * from KHACHHANG where DiaChi like N'" + value + "%'";
                dr = execCommand(query);
            }

            return dr;
        }
    }
}
