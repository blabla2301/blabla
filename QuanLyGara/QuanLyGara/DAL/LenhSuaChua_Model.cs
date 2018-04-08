using QuanLyGara.ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.DAL
{
    class LenhSuaChua_Model : sqlConnect
    {
        public void insertLenhSuaChua(LenhSuaChua l)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("ThemLSC", Conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_LenhSuaChua", l.ID_LenhSuaChua);
                cmd.Parameters.AddWithValue("@ID_PhieuDanhGia", l.ID_PhieuDanhGia);
                cmd.Parameters.AddWithValue("@ID_PhieuVatTu", l.ID_PhieuVatTu);
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

        public void editLenhSuaChua(LenhSuaChua l)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("SuaLSC", Conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_LenhSuaChua", l.ID_LenhSuaChua);
                cmd.Parameters.AddWithValue("@ID_PhieuDanhGia", l.ID_PhieuDanhGia);
                cmd.Parameters.AddWithValue("@ID_PhieuVatTu", l.ID_PhieuVatTu);
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

        public void deleteLenhSuaChua(LenhSuaChua l)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("XoaLSC", Conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_LenhSuaChua", l.ID_LenhSuaChua);
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

        public SqlDataReader searchLenhSuaChua(string name, string value)
        {
            SqlDataReader dr = null;
            string query;
            if (name.Equals("Mã lệnh sửa chữa"))
            {
                query = "select * from LENHSUACHUA where ID_LenhSuaChua like '" + value + "%'";
                dr = execCommand(query);
            }
            else if (name.Equals("Mã phiếu đánh giá"))
            {
                query = "select * from LENHSUACHUA where ID_PhieuDanhGia like '" + value + "%'";
                dr = execCommand(query);
            }
            else
            {
                query = "select * from LENHSUACHUA where ID_PhieuVatTu like '" + value + "%'";
                dr = execCommand(query);
            }
            return dr;
        }
    }
}
