using QuanLyGara.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.DATA
{
    class TimKiemKhachHang:sqlConnect
    {
        public SqlDataReader tk_KhachHang(string name,string value)
        {
            SqlDataReader dr = null;
            string query = null;
            try
            {
                if(name.Equals("ID Khách hàng"))
                {
                    query="select * from KHACHHANG where ID_KhachHang like'"+value+"%'";
                    dr=execCommand(query);
                }
                else if(name.Equals("Họ tên"))
                {
                    query="select * from KHACHHANG where HoTen like'"+value+"%'";
                    dr=execCommand(query);
                }
                else
                {
                    query="select * from KHACHHANG where SDT like'"+value+"%'";
                    dr=execCommand(query);
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
