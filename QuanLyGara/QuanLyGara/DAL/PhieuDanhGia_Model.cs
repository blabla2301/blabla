using QuanLyGara.ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.DAL
{
    class PhieuDanhGia_Model : sqlConnect
    {
        public void insertPhieuDanhGia(PhieuDanhGia p)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("ThemPDG", Conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_PhieuDanhGia", p.ID_PhieuDanhGia);
                cmd.Parameters.AddWithValue("@ID_PhieuKhaoSat", p.ID_PhieuKhaoSat);
                cmd.Parameters.AddWithValue("@TinhTrangXe", p.TinhTrangXe);
                cmd.Parameters.AddWithValue("@MaBaoHiem", p.MaBaoHiem);
                cmd.Parameters.AddWithValue("@ThongBaoGiaSua", p.BaoGia);
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

        public void editPhieuDanhGia(PhieuDanhGia p)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("SuaPDG", Conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_PhieuDanhGia", p.ID_PhieuDanhGia);
                cmd.Parameters.AddWithValue("@ID_PhieuKhaoSat", p.ID_PhieuKhaoSat);
                cmd.Parameters.AddWithValue("@TinhTrangXe", p.TinhTrangXe);
                cmd.Parameters.AddWithValue("@MaBaoHiem", p.MaBaoHiem);
                cmd.Parameters.AddWithValue("@ThongBaoGia", p.BaoGia);
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

        public void deletePhieuDanhGia(PhieuDanhGia p)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("XoaPDG", Conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_PhieuDanhGia", p.ID_PhieuDanhGia);
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

        public SqlDataReader searchPhieuDanhGia(string name, string value)
        {
            SqlDataReader dr = null;
            string query;
            if (name.Equals("Mã phiếu đánh giá"))
            {
                query = "select * from PHIEUDANHGIA where ID_PhieuDanhGia like '" + value + "%'";
                dr = execCommand(query);
            }
            else if (name.Equals("Mã phiếu khảo sát"))
            {
                query = "select * from PHIEUDANHGIA where ID_PhieuKhaoSat like '" + value + "%'";
                dr = execCommand(query);
            }
            else if (name.Equals("Tình trạng xe"))
            {
                query = "select * from PHIEUDANHGIA where TinhTrangXe like '" + value + "%'";
                dr = execCommand(query);
            }
            else
            {
                query = "select * from PHIEUDANHGIA where MaBaoHiem like '" + value + "%'";
                dr = execCommand(query);
            }
            //else
            //{
            //    query = "select * from PHIEUDANHGIA where ThongBaoGiaSua like '" + value + "%'";
            //    dr = execCommand(query);
            //}
            return dr;
        }
    }
}
