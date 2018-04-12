using QuanLyGara.ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.DAL
{
    class HoaDonThanhToan_Model : sqlConnect
    {
        public void insertHoaDonThanhToan(HoaDonThanhToan h)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("ThemHD_TT", Conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_HoaDonThanhToan", h.ID_HoaDonThanhToan);
                cmd.Parameters.AddWithValue("@ID_LenhSuaChua", h.ID_LenhSuaChua);
                cmd.Parameters.AddWithValue("@TenHoaDon", h.TenHD);
                cmd.Parameters.AddWithValue("@MaNguoiPhuTrach", h.MaNPT);
                cmd.Parameters.AddWithValue("@TienDichVu", h.TienDichVu);
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

        public void editHoaDonThanhToan(HoaDonThanhToan h)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("SuaHD_TT", Conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_HoaDonThanhToan", h.ID_HoaDonThanhToan);
                cmd.Parameters.AddWithValue("@ID_LenhSuaChua", h.ID_LenhSuaChua);
                cmd.Parameters.AddWithValue("@TenHD", h.TenHD);
                cmd.Parameters.AddWithValue("@MaNPT", h.MaNPT);
                cmd.Parameters.AddWithValue("@TienDichVu", h.TienDichVu);
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

        public void deleteHoaDonThanhToan(HoaDonThanhToan h)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("XoaHD_TT", Conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_HoaDonThanhToan", h.ID_HoaDonThanhToan);
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

        public SqlDataReader searchHoaDonThanhToan(string name, string value)
        {
            SqlDataReader dr = null;
            string query;
            if (name.Equals("Mã hóa đơn"))
            {
                query = "select * from HOADON_THANHTOAN where ID_hoaDonThanhToan like '" + value + "%'";
                dr = execCommand(query);
            }
            else if (name.Equals("Mã lệnh sửa chữa"))
            {
                query = "select * from HOADON_THANHTOAN where ID_LenhSuaChua like '" + value + "%'";
                dr = execCommand(query);
            }
            else if (name.Equals("Tên hóa đơn"))
            {
                query = "select * from HOADON_THANHTOAN where TenHoaDon like '" + value + "%'";
                dr = execCommand(query);
            }
            else
            {
                query = "select * from HOADON_THANHTOAN where MaNguoiPhuTrach like '" + value + "%'";
                dr = execCommand(query);
            }
            return dr;
        }
    }
}
