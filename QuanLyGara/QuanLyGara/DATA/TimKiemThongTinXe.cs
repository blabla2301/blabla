using QuanLyGara.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.DATA
{
    class TimKiemThongTinXe:sqlConnect
    {
        public SqlDataReader tk_TTX(string name, string value)
        {
            SqlDataReader dr = null;
            string query = null;
            try
            {
                if (name.Equals("ID Xe"))
                {
                    query = "select * from THONGTINXE where ID_Xe like '" + value + "%'";
                    dr = execCommand(query);
                }
                else if (name.Equals("ID Hãng xe"))
                {
                    query = "select * from THONGTINXE where ID_HangXe like '" + value + "%'";
                    dr = execCommand(query);
                }
                else
                {
                    query = "select * from THONGTINXE where BienSoXe like '" + value + "%'";
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
