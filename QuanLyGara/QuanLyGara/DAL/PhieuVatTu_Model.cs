using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using QuanLyGara.ENTITY;

namespace QuanLyGara.DAL
{
    class PhieuVatTu_Model : sqlConnect
    {
        public void insertPhieuVatTu(PhieuVatTu p)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("ThemPVT", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_PhieuVatTu", p.ID_PhieuVatTu);
                cmd.Parameters.AddWithValue("@MaNguoiPhuTrach", p.MaNPT);
                cmd.Parameters.AddWithValue("@ThoiGian", p.ThoiGian);
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

        public void editPhieuVatTu(PhieuVatTu p)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("SuaPVT", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_PhieuVatTu", p.ID_PhieuVatTu);
                cmd.Parameters.AddWithValue("@MaNPT", p.MaNPT);
                cmd.Parameters.AddWithValue("@ThoiGian", p.ThoiGian);
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

        public void deletePhieuVatTu(PhieuVatTu p)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("XoaPVT", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_PhieuVatTu", p.ID_PhieuVatTu);
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

        public SqlDataReader searchPhieuVatTu(string name, string value)
        {
            SqlDataReader dr = null;
            string query;
            if (name.Equals("Mã phiếu vật tư"))
            {
                query = "select * from PHIEUVATTU where ID_PhieuVatTu like '" + value + "%'";
                dr = execCommand(query);
            }
            else
            {
                query = "select * from PHIEUVATTU where MaNguoiPhuTrach like '" + value + "%'";
                dr = execCommand(query);
            }
            //else
            //{
            //    query = "select * from PHIEUVATTU where ThoiGian like '" + value + "%'";
            //    dr = execCommand(query);
            //}
            return dr;
        }
    }
}
