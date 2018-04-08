using QuanLyGara.ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.DAL
{
    class NhaCungCap_Model : sqlConnect
    {
        public void insertNhaCungCap(NhaCungCap n)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("ThemNCC", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_NhaCungCap", n.ID_NhaCungCap);
                cmd.Parameters.AddWithValue("@TenNCC", n.TenNCC);
                cmd.Parameters.AddWithValue("@DC", n.DiaChi);
                cmd.Parameters.AddWithValue("@SDT", n.SDT);
                cmd.Parameters.AddWithValue("@Email", n.Email);
                cmd.Parameters.AddWithValue("@Web", n.Website);
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

        public void editNhaCungCap(NhaCungCap n)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("SuaNCC", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_NhaCungCap", n.ID_NhaCungCap);
                cmd.Parameters.AddWithValue("@TenNCC", n.TenNCC);
                cmd.Parameters.AddWithValue("@DiaChi", n.DiaChi);
                cmd.Parameters.AddWithValue("@SDT", n.SDT);
                cmd.Parameters.AddWithValue("@Email", n.Email);
                cmd.Parameters.AddWithValue("@Website", n.Website);
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

        public void deleteNhaCungCap(NhaCungCap n)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("XoaNCC", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_NhaCungCap", n.ID_NhaCungCap);
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

        public SqlDataReader searchNhaCungCap(string name, string value)
        {
            SqlDataReader dr = null;
            string query;
            if (name.Equals("Mã nhà cung cấp"))
            {
                query = "select * from NHACUNGCAP where ID_NhaCungCap like '" + value + "%'";
                dr = execCommand(query);
            }
            else if (name.Equals("Tên nhà cung cấp"))
            {
                query = "select * from NHACUNGCAP where TenNCC like '" + value + "%'";
                dr = execCommand(query);
            }
            else if (name.Equals("Địa chỉ"))
            {
                query = "select * from NHACUNGCAP where DiaChi like '" + value + "%'";
                dr = execCommand(query);
            }
            else if (name.Equals("Số điện thoại"))
            {
                query = "select * from NHACUNGCAP where SDT like '" + value + "%'";
                dr = execCommand(query);
            }
            else if (name.Equals("Email"))
            {
                query = "select * from NHACUNGCAP where Email like '" + value + "%'";
                dr = execCommand(query);
            }
            else
            {
                query = "select * from NHACUNGCAP where Website like '" + value + "%'";
                dr = execCommand(query);
            }
            return dr;
        }
    }
}
