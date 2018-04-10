using QuanLyGara.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.DATA
{
    class TimKiemPhanCong : sqlConnect
    {
        public SqlDataReader tk_PhanCong(string name, string value)
        {
            SqlDataReader dr = null;
            string query = null;
            try
            {
                if (name.Equals("ID Phân công"))
                {
                    query = "select * from PHANCONG where ID_PhanCong like '" + value + "%'";
                    dr = execCommand(query);
                }
                else if(name.Equals("ID Lệnh sửa chữa"))
                {
                    query = "select * from PHANCONG where ID_LenhSuaChua like '" + value + "%'";
                    dr = execCommand(query);
                }
                else
                {
                    query = "select * from PHANCONG where ID_NhanVien like '" + value + "%'";
                    dr = execCommand(query);
                }
            }
            catch (Exception e)
            {
                new Exception("Error :" + e.Message);
            }
            return dr;
        }
    }
}
