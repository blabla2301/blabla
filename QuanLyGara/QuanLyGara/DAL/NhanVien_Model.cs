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
    class NhanVien_Model : sqlConnect
    {
        public DateTime formatDate(string str)
        {
            DateTime dt = DateTime.Parse(str);

            return dt;
        }

        public void insertNhanVien(NhanVien nv)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("ThemNV", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_NhanVien", nv.ID_NhanVien);
                cmd.Parameters.AddWithValue("@HoTen", nv.HoTen);
                cmd.Parameters.AddWithValue("@SDT", nv.SDT);
                cmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh);
                cmd.Parameters.AddWithValue("@GT", nv.GioiTinh);
                cmd.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
                cmd.Parameters.AddWithValue("@TaiKhoan", nv.TaiKhoan);
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

        public void editNhanVien(NhanVien nv)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("SuaNV", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_NhanVien", nv.ID_NhanVien);
                cmd.Parameters.AddWithValue("@HoTen", nv.HoTen);
                cmd.Parameters.AddWithValue("@SDT", nv.SDT);
                cmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh);
                cmd.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh);
                cmd.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
                cmd.Parameters.AddWithValue("@TaiKhoan", nv.TaiKhoan);
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

        public void deleteNhanVien(NhanVien nv)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("XoaNV", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_NhanVien", nv.ID_NhanVien);
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

        public SqlDataReader searchNhanVien(string name, string value)
        {
            SqlDataReader dr = null;
            string query;
            try
            {
                if (name.Equals("Mã nhân viên"))
                {
                    query = "select *  from NHANVIEN where ID_NhanVien like '" + value + "%'";
                    dr = execCommand(query);
                }
                else if (name.Equals("Họ tên"))
                {
                    query = "select *  from NHANVIEN where HoTen like N'" + value + "%'";
                    dr = execCommand(query);
                }
                else if (name.Equals("Số điện thoại"))
                {
                    query = "select *  from NHANVIEN where SDT like '" + value + "%'";
                    dr = execCommand(query);
                }
                else if (name.Equals("Giới tính"))
                {
                    query = "select *  from NHANVIEN where GioiTinh like N'" + value + "%'";
                    dr = execCommand(query);
                }
                else
                {
                    query = "select *  from NHANVIEN where DiaChi like N'" + value + "%'";
                    dr = execCommand(query);
                }
            }
            catch (Exception ex)
            {
                new Exception("Error: " + ex.Message);
            }
            return dr;
        }
    }
}
