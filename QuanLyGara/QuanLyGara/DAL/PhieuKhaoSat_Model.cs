using QuanLyGara.ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.DAL
{
    class PhieuKhaoSat_Model : sqlConnect
    {
        public void insertPhieuKhaoSat(PhieuKhaoSat p)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("ThemPKS", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_PhieuKhaoSat", p.ID_PhieuKhaoSat);
                cmd.Parameters.AddWithValue("@ID_KhachHang", p.ID_KhachHang);
                cmd.Parameters.AddWithValue("@ID_Xe", p.ID_Xe);
                cmd.Parameters.AddWithValue("@YeuCau", p.YeuCau);
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

        public void editPhieuKhaoSat(PhieuKhaoSat p)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("SuaPKS", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_PhieuKhaoSat", p.ID_PhieuKhaoSat);
                cmd.Parameters.AddWithValue("@ID_KhachHang", p.ID_KhachHang);
                cmd.Parameters.AddWithValue("@ID_Xe", p.ID_Xe);
                cmd.Parameters.AddWithValue("@YeuCau", p.YeuCau);
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

        public void deletePhieuKhaoSat(PhieuKhaoSat p)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("XoaPKS", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_PhieuKhaoSat", p.ID_PhieuKhaoSat);
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

        public SqlDataReader searchPhieuKhaoSat(string name, string value)
        {
            SqlDataReader dr = null;
            string query;
            if (name.Equals("Mã phiếu khảo sát"))
            {
                query = "select pks.ID_PhieuKhaoSat, kh.HoTen, xe.BienSoXe, pks.YeuCau from PHIEUKHAOSAT pks, KHACHHANG kh, THONGTINXE xe where pks.ID_KhachHang = kh.ID_KhachHang and pks.ID_Xe = xe.ID_Xe and pks.ID_PhieuKhaoSat like '" + value + "%'";
                dr = execCommand(query);
            }
            else if (name.Equals("Tên khách hàng"))
            {
                query = "select pks.ID_PhieuKhaoSat, kh.HoTen, xe.BienSoXe, pks.YeuCau from PHIEUKHAOSAT pks, KHACHHANG kh, THONGTINXE xe where pks.ID_KhachHang = kh.ID_KhachHang and pks.ID_Xe = xe.ID_Xe and kh.HoTen like '" + value + "%'";
                dr = execCommand(query);
            }
            else if (name.Equals("Biển số xe"))
            {
                query = "select pks.ID_PhieuKhaoSat, kh.HoTen, xe.BienSoXe, pks.YeuCau from PHIEUKHAOSAT pks, KHACHHANG kh, THONGTINXE xe where pks.ID_KhachHang = kh.ID_KhachHang and pks.ID_Xe = xe.ID_Xe and xe.BienSoXe like '" + value + "%'";
                dr = execCommand(query);
            }
            else
            {
                query = "select pks.ID_PhieuKhaoSat, kh.HoTen, xe.BienSoXe, pks.YeuCau from PHIEUKHAOSAT pks, KHACHHANG kh, THONGTINXE xe where pks.ID_KhachHang = kh.ID_KhachHang and pks.ID_Xe = xe.ID_Xe and pks.YeuCau like '" + value + "%'";
                dr = execCommand(query);
            }
            return dr;
        }
    }
}
