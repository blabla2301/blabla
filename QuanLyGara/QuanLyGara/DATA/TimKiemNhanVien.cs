using QuanLyGara.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.DATA
{
    class TimKiemNhanVien : sqlConnect
    {
        public SqlDataReader tk_NhanVien(string name, string value)
        {
            SqlDataReader dr = null;
            string query = null;
            try
            {
                if (name.Equals("ID Nhân viên"))
                {
                    query = "select * from NHANVIEN where ID_NhanVien like '" + value + "%'";
                    dr = execCommand(query);
                }
                else if (name.Equals("Họ tên"))
                {
                    query = "select * from NHANVIEN where HoTen like '" + value + "%'";
                    dr = execCommand(query);
                }
                else
                {
                    query = "select * from NHANVIEN where SDT like '" + value + "%'";
                    dr = execCommand(query);
                }
            }
            catch (Exception ex)
            {
                new Exception("Error :" + ex.Message);
            }
            return dr;
        }

    }
}
