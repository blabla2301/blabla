using QuanLyGara.ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.DAL
{
    class HangXe_Model : sqlConnect
    {
        public void insertHangXe(HangXe hx)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("ThemHangXe", Conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_HangXe", hx.ID);
                cmd.Parameters.AddWithValue("@HangXe", hx.TenHangXe);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                closeConnection();
            }
        }

        public void editHangXe(HangXe hx)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("SuaHangXe", Conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_HangXe", hx.ID);
                cmd.Parameters.AddWithValue("@HangXe", hx.TenHangXe);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                closeConnection();
            }
        }

        public void deleteHangXe(HangXe hx)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("XoaHangXe", Conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_HangXe", hx.ID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                closeConnection();
            }
        }

        public SqlDataReader searchHangXe(string key, string value)
        {
            string query;
            SqlDataReader dr = null;
            if (key.Equals("ID hãng xe"))
            {
                query = "select * from HANGXE where ID_HangXe like '" + value + "%'";
                dr = execCommand(query);
            }
            else
            {
                query = "select * from HANGXE where HangXe like '" + value + "%'";
                dr = execCommand(query);
            }
            return dr;
        }
    }
}
