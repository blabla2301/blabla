using QuanLyGara.ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.DAL
{
    class VatTu_Model : sqlConnect
    {
        public void insertVatTu(VatTu vt)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("ThemVT", Conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_VatTu", vt.ID_VatTu);
                cmd.Parameters.AddWithValue("@TenVT", vt.TenVatTu);
                cmd.Parameters.AddWithValue("@TheLoai", vt.TheLoai);
                cmd.Parameters.AddWithValue("@SoTien", vt.SoTien);
                cmd.Parameters.AddWithValue("@ID_NhaCungCap", vt.ID_NhaCungCap);
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

        public void editVatTu(VatTu vt)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("SuaVT", Conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_VatTu", vt.ID_VatTu);
                cmd.Parameters.AddWithValue("@TenVT", vt.TenVatTu);
                cmd.Parameters.AddWithValue("@TheLoai", vt.TheLoai);
                cmd.Parameters.AddWithValue("@SoTien", vt.SoTien);
                cmd.Parameters.AddWithValue("@ID_NhaCungCap", vt.ID_NhaCungCap);
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

        public void deleteVatTu(VatTu vt)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("XoaVT", Conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_VatTu", vt.ID_VatTu);
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

        public SqlDataReader searchVatTu(string name, string value)
        {
            SqlDataReader dr = null;
            string query;
            if (name.Equals("ID"))
            {
                query = "select vt.ID_VatTu, vt.TenVatTu, vt.TheLoai, vt.SoTien, c.TenNCC from VATTU vt, NHACUNGCAP c where vt.ID_NhaCungCap = c.ID_NhaCungCap and vt.ID_VatTu like '" + value + "%'";
                dr = execCommand(query);
            }
            else if (name.Equals("Tên vật tư"))
            {
                query = "select vt.ID_VatTu, vt.TenVatTu, vt.TheLoai, vt.SoTien, c.TenNCC from VATTU vt, NHACUNGCAP c where vt.ID_NhaCungCap = c.ID_NhaCungCap and TenVatTu like '" + value + "%'";
                dr = execCommand(query);
            }
            else if (name.Equals("Thể loại"))
            {
                query = "select vt.ID_VatTu, vt.TenVatTu, vt.TheLoai, vt.SoTien, c.TenNCC from VATTU vt, NHACUNGCAP c where vt.ID_NhaCungCap = c.ID_NhaCungCap and vt.TheLoai like '" + value + "%'";
                dr = execCommand(query);
            }
            else
            {
                query = "select vt.ID_VatTu, vt.TenVatTu, vt.TheLoai, vt.SoTien, c.TenNCC from VATTU vt, NHACUNGCAP c where vt.ID_NhaCungCap = c.ID_NhaCungCap and c.TenNCC like '" + value + "%'";
                dr = execCommand(query);
            }
            return dr;
        }
    }
}
