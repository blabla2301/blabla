using QuanLyGara.ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.DAL
{
    class HoaDonVatTu_Model : sqlConnect
    {
        public void insertHoaDonVatTu(HoaDonVatTu h)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("ThemHD_PVT", Conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaHDVT", h.MaHDVT);
                cmd.Parameters.AddWithValue("@MaPVT", h.MaPVT);
                cmd.Parameters.AddWithValue("@TenVT", h.TenVT);
                cmd.Parameters.AddWithValue("@SoLuong", h.SoLuong);
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

        public void editHoaDonVatTu(HoaDonVatTu h)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("SuaHD_PVT", Conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaHDVT", h.MaHDVT);
                cmd.Parameters.AddWithValue("@MaPVT", h.MaPVT);
                cmd.Parameters.AddWithValue("@TenVT", h.TenVT);
                cmd.Parameters.AddWithValue("@SoLuong", h.SoLuong);
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

        public void deleteHoaDonVatTu(HoaDonVatTu h)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("XoaHD_PVT", Conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaHDVT", h.MaHDVT);
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

        public SqlDataReader searchHoaDonVatTu(string name, string value)
        {
            SqlDataReader dr = null;
            string query;
            if (name.Equals("Mã hóa đơn"))
            {
                query = "select * from HOADON_PHIEUVATTU where MaHDVT like '" + value + "%'";
                dr = execCommand(query);
            }
            else if (name.Equals("Mã phiếu vật tư"))
            {
                query = "select * from HOADON_PHIEUVATTU where MaPhieuVatTu like '" + value + "%'";
                dr = execCommand(query);
            }
            else
            {
                query = "select * from HOADON_PHIEUVATTU where TenVatTu like '" + value + "%'";
                dr = execCommand(query);
            }
            return dr;
        }
    }
}
