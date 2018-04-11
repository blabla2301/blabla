using QuanLyGara.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.DATA
{
    class TimKiemNhaCungCap :sqlConnect
    {
        public SqlDataReader tk_NCC(string name, string value)
        {
            SqlDataReader dr = null;
            string query = null;
            try
            {
                if (name.Equals("ID Nhà cung cấp"))
                {
                    query = "select*from NHACUNGCAP where ID_NhaCungCap like '" + value + "%'";
                    dr = execCommand(query);
                }
                else
                {
                    query = "select*from NHACUNGCAP where TenNCC like '" + value + "%'";
                    dr = execCommand(query);
                }
            }
            catch (Exception ex)
            {
                new Exception("Error : " + ex.Message);
            }
            return dr;
        }
    }
}
