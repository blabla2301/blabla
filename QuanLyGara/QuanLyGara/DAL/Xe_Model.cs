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
    class Xe_Model : sqlConnect
    {
        public void insertXe(Xe x)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("ThemXe", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Xe", x.ID_Xe);
                cmd.Parameters.AddWithValue("@ID_hangXe", x.ID_HangXe);
                cmd.Parameters.AddWithValue("@BienSo", x.BienSoXe);
                cmd.Parameters.AddWithValue("@DoiXe", x.DoiXe);
                cmd.Parameters.AddWithValue("@SoKhung", x.SoKhung);
                cmd.Parameters.AddWithValue("@SoMay", x.SoMay);
                cmd.Parameters.AddWithValue("@SoKM", x.SoKM);
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

        public void editXe(Xe x)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("SuaXe", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Xe", x.ID_Xe);
                cmd.Parameters.AddWithValue("@ID_HangXe", x.ID_HangXe);
                cmd.Parameters.AddWithValue("@BienSoXe", x.BienSoXe);
                cmd.Parameters.AddWithValue("@DoiXe", x.DoiXe);
                cmd.Parameters.AddWithValue("@SoKhung", x.SoKhung);
                cmd.Parameters.AddWithValue("@SoMay", x.SoMay);
                cmd.Parameters.AddWithValue("@SoKM", x.SoKM);
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

        public void deleteXe(Xe x)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("XoaXe", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Xe", x.ID_Xe);
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

        public SqlDataReader searchXe(string name, string value)
        {
            SqlDataReader dr = null;
            string query;
            if (name.Equals("ID xe"))
            {
                query = "select xe.ID_Xe, h.HangXe, xe.BienSoXe, xe.DoiXe, xe.SoKhung, xe.SoMay, xe.SoKM from THONGTINXE xe, HANGXE h where xe.ID_HangXe = h.ID_HangXe and xe.ID_Xe like '" + value + "%'";
                dr = execCommand(query);
            }
            else if (name.Equals("Hãng xe"))
            {
                query = "select xe.ID_Xe, h.HangXe, xe.BienSoXe, xe.DoiXe, xe.SoKhung, xe.SoMay, xe.SoKM from THONGTINXE xe, HANGXE h where xe.ID_HangXe = h.ID_HangXe and h.HangXe like '" + value + "%'";
                dr = execCommand(query);
            }
            else if (name.Equals("Biển số xe"))
            {
                query = "select xe.ID_Xe, h.HangXe, xe.BienSoXe, xe.DoiXe, xe.SoKhung, xe.SoMay, xe.SoKM from THONGTINXE xe, HANGXE h where xe.ID_HangXe = h.ID_HangXe and xe.BienSoXe like '" + value + "%'";
                dr = execCommand(query);
            }
            else if (name.Equals("Đời xe"))
            {
                query = "select xe.ID_Xe, h.HangXe, xe.BienSoXe, xe.DoiXe, xe.SoKhung, xe.SoMay, xe.SoKM from THONGTINXE xe, HANGXE h where xe.ID_HangXe = h.ID_HangXe and xe.DoiXe like '" + value + "%'";
                dr = execCommand(query);
            }
            else if (name.Equals("Số khung"))
            {
                query = "select xe.ID_Xe, h.HangXe, xe.BienSoXe, xe.DoiXe, xe.SoKhung, xe.SoMay, xe.SoKM from THONGTINXE xe, HANGXE h where xe.ID_HangXe = h.ID_HangXe and xe.SoKhung like '" + value + "%'";
                dr = execCommand(query);
            }
            else if (name.Equals("Số máy"))
            {
                query = "select xe.ID_Xe, h.HangXe, xe.BienSoXe, xe.DoiXe, xe.SoKhung, xe.SoMay, xe.SoKM from THONGTINXE xe, HANGXE h where xe.ID_HangXe = h.ID_HangXe and xe.SoMay like '" + value + "%'";
                dr = execCommand(query);
            }
            else
            {
                query = "select xe.ID_Xe, h.HangXe, xe.BienSoXe, xe.DoiXe, xe.SoKhung, xe.SoMay, xe.SoKM from THONGTINXE xe, HANGXE h where xe.ID_HangXe = h.ID_HangXe and xe.SoKM like '" + value + "%'";
                dr = execCommand(query);
            }
            return dr;
        }
    }
}
