using QuanLyGara.ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.DAL
{
    class PhanCong_Model : sqlConnect
    {
        public void insertPhanCong(PhanCong p)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("ThemPC", Conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_PhanCong", p.ID_PhanCong);
                cmd.Parameters.AddWithValue("@ID_LenhSuaChua", p.ID_LenhSuaChua);
                cmd.Parameters.AddWithValue("@ID_NhanVien", p.ID_NhanVien);
                cmd.Parameters.AddWithValue("@NgayBatDau", p.NgayBD);
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

        public void editPhanCong(PhanCong p)
        { 
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("SuaPC", Conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_PhanCong", p.ID_PhanCong);
                cmd.Parameters.AddWithValue("@ID_LenhSuaChua", p.ID_LenhSuaChua);
                cmd.Parameters.AddWithValue("@ID_NhanVien", p.ID_NhanVien);
                cmd.Parameters.AddWithValue("@NgayBD", p.NgayBD);
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

        public void deletePhanCong(PhanCong p)
        { 
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("XoaPC", Conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_PhanCong", p.ID_PhanCong);
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

        public SqlDataReader searchPhanCong(string name, string value)
        {
            SqlDataReader dr = null;
            string query;
            if (name.Equals("Mã phân công"))
            {
                query = "select * from PHANCONG where ID_PhanCong like '" + value + "%'";
                dr = execCommand(query);
            }
            else if (name.Equals("Mã lệnh sửa chữa"))
            {
                query = "select * from PHANCONG where ID_LenhSuaChua like '" + value + "%'";
                dr = execCommand(query);
            }
            else
            {
                query = "select * from PHANCONG where ID_NhanVien like '" + value + "%'";
                dr = execCommand(query);
            }
            return dr;
        }
    }
}
