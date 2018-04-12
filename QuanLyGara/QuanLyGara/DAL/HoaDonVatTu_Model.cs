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
                cmd.Parameters.AddWithValue("@ID_HoaDonVatTu", h.ID_HoaDonVatTu);
                cmd.Parameters.AddWithValue("@ID_PhieuVatTu", h.ID_PhieuVatTu);
                cmd.Parameters.AddWithValue("@ID_VatTu", h.ID_vatTu);
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
                cmd.Parameters.AddWithValue("@ID_HoaDonVatTu", h.ID_HoaDonVatTu);
                cmd.Parameters.AddWithValue("@ID_PhieuVatTu", h.ID_PhieuVatTu);
                cmd.Parameters.AddWithValue("@ID_VatTu", h.ID_vatTu);
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
                cmd.Parameters.AddWithValue("@ID_HoaDonVatTu", h.ID_HoaDonVatTu);
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
            if (name.Equals("ID hóa đơn"))
            {
                query = "select hd.ID_HoaDonVatTu, p.ID_PhieuVatTu, vt.TenVatTu, hd.SoLuong, hd.TongTien from HOADON_PHIEUVATTU hd, PHIEUVATTU p, VATTU vt where hd.ID_VatTu = vt.ID_VatTu and hd.ID_PhieuVatTu = p.ID_PhieuVatTu and ID_HoaDonVatTu like '" + value + "%'";
                dr = execCommand(query);
            }
            else if (name.Equals("ID phiếu vật tư"))
            {
                query = "select hd.ID_HoaDonVatTu, p.ID_PhieuVatTu, vt.TenVatTu, hd.SoLuong, hd.TongTien from HOADON_PHIEUVATTU hd, PHIEUVATTU p, VATTU vt where hd.ID_VatTu = vt.ID_VatTu and hd.ID_PhieuVatTu = p.ID_PhieuVatTu and hd.ID_PhieuVatTu like '" + value + "%'";
                dr = execCommand(query);
            }
            else
            {
                query = "select hd.ID_HoaDonVatTu, p.ID_PhieuVatTu, vt.TenVatTu, hd.SoLuong, hd.TongTien from HOADON_PHIEUVATTU hd, PHIEUVATTU p, VATTU vt where hd.ID_VatTu = vt.ID_VatTu and hd.ID_PhieuVatTu = p.ID_PhieuVatTu and TenVatTu like '" + value + "%'";
                dr = execCommand(query);
            }
            return dr;
        }
    }
}
