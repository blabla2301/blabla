using QuanLyGara.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.DATA
{
    class TimKiemHoaDonThanhToan : sqlConnect
    {
        public SqlDataReader tk_HDTT(string name, string value)
        {
            SqlDataReader dr = null;
            string query = null;
            try
            {
                if (name.Equals("ID Hóa đơn thanh toán"))
                {
                    query = "select*from HOADON_THANHTOAN where ID_HoaDonThanhToan like '" + value + "%'";
                    dr = execCommand(query);
                }
                else
                {
                    query = "select * from HOADON_THANHTOAN where ID_LenhSuaChua like '" + value + "%'";
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
