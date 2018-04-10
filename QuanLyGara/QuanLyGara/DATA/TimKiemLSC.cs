using QuanLyGara.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.DATA
{
    class TimKiemLSC : sqlConnect
    {
        public SqlDataReader tk_LSC(string name, string value)
        {
            SqlDataReader dr = null;
            string query = null;

            try
            {
                if (name.Equals("ID Lệnh sửa chữa"))
                {
                    query = "select * from LENHSUACHUA where ID_LenhSuaChua like '" + value + "%'";
                    dr = execCommand(query);
                }
                else
                {
                    query = "select * from LENHSUACHUA where ID_PhieuDanhGia like '" + value + "%'";
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
