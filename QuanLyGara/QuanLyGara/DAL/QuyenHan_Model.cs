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
    class QuyenHan_Model : sqlConnect
    {
        public void insertQuyen(QuyenHan qh)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("ThemQH", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID_QuyenHan", qh.ID_QuyenHan);
                cmd.Parameters.AddWithValue("Them", qh.Them);
                cmd.Parameters.AddWithValue("Sua", qh.Sua);
                cmd.Parameters.AddWithValue("Xoa", qh.Xoa);
                cmd.Parameters.AddWithValue("Ad", qh.Admin);
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

        public void editQuyen(QuyenHan q)
        {
            try
            {
                //string query = "update QUYENHAN set Them = @Them, Sua = @Sua, Xoa = @Xoa, Ad = @Ad where MaQuyen = @MaQuyen";
                openConnection();
                SqlCommand cmd = new SqlCommand("SuaQH", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_QuyenHan", q.ID_QuyenHan);
                cmd.Parameters.AddWithValue("@Them", q.Them);
                cmd.Parameters.AddWithValue("@Sua", q.Sua);
                cmd.Parameters.AddWithValue("@Xoa", q.Xoa);
                cmd.Parameters.AddWithValue("@Ad", q.Admin);
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

        public void deleteQuyen(QuyenHan q)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("XoaQH", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_QuyenHan", q.ID_QuyenHan);
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

        public SqlDataReader searchQuyen(string value)
        {
            SqlDataReader dr = null;
            try
            {
                string query = "select * from QUYENHAN where ID_QuyenHan like '" + value + "%'";
                dr = execCommand(query);
            }
            catch (Exception ex)
            {
                new Exception("Error: " + ex.Message);
            }
            return dr;
        }
    }
}
