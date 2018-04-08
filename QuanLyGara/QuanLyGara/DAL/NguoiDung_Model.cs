using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyGara.ENTITY;

namespace QuanLyGara.DAL
{
    class NguoiDung_Model : sqlConnect
    {
        public static string taikhoan;
        public static string matkhau;

        public int ckeckLogin(string name, string pass)
        {
            
            try
            {
                string query = "select * from NGUOIDUNG where TaiKhoan = '" + name + "' and MatKhau = '" + pass + "'";
                SqlDataReader dr = execCommand(query);
                if (dr.HasRows == true)
                    return 1;

                //while (dr.Read())
                //{
                //    check += 1;
                //}
               
                //if (check == 1)
                //{

                //}
                
            }
            catch (Exception e)
            {
                new Exception("Error: " + e.Message);
            }
            return 0;
        }

        public void checkPermission(Button btnThem, Button btnSua, Button btnXoa)
        {
            btnThem.Visible = false;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            string query = "select q.Them, q.Sua, q.Xoa from QUYENHAN q, NGUOIDUNG n where q.ID_QuyenHan = n.ID_QuyenHan and n.TaiKhoan = '" + taikhoan + "' and n.MatKhau = '" + matkhau + "'";
            SqlDataReader dr = execCommand(query);
            while (dr.Read())
            {
                if (dr["Them"].ToString().Equals("True"))
                {
                    btnThem.Visible = true;
                }
                if (dr["Sua"].ToString().Equals("True"))
                {
                    btnSua.Visible = true;
                }
                if (dr["Xoa"].ToString().Equals("True"))
                {
                    btnXoa.Visible = true;
                }
            }
        }

        public void insertNguoiDung(NguoiDung nd)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("ThemTaiKhoan", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TaiKhoan", nd.TaiKhoan);
                cmd.Parameters.AddWithValue("@MatKhau", nd.MatKhau);
                cmd.Parameters.AddWithValue("@ID_quyenHan", nd.ID_QuyenHan);
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

        public void editNguoiDung(NguoiDung nd)
        {
            try
            {
                //string query = "update NGUOIDUNG set MatKhau = @MatKhau, MaQuyen = @MaQuyen where TaiKhoan = @TaiKhoan";
                openConnection();
                SqlCommand cmd = new SqlCommand("SuaND", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TaiKhoan", nd.TaiKhoan);
                cmd.Parameters.AddWithValue("@MatKhau", nd.MatKhau);
                cmd.Parameters.AddWithValue("@ID_QuyenHan", nd.ID_QuyenHan);
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

        public void deleteNguoiDung(NguoiDung nd)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("XoaTK", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TenTK", nd.TaiKhoan);
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

        public SqlDataReader searchNguoiDung(string name, string value)
        {
            SqlDataReader dr = null;
            string query = null;
            try
            {
                if (name.Equals("Tài khoản"))
                {
                    query = "select * from NGUOIDUNG where TaiKhoan like '" + value + "%'";
                    dr = execCommand(query);
                }
                else
                {
                    query = "select * from NGUOIDUNG where ID_quyenHan like '" + value + "%'";
                    dr = execCommand(query);
                }
            }
            catch(Exception ex)
            {
                new Exception("Error: " + ex.Message);
            }
            return dr;
        }
    }
}
