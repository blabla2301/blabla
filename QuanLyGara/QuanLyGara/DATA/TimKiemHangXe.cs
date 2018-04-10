using QuanLyGara.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.DATA
{
    class TimKiemHangXe:sqlConnect
    {
        public SqlDataReader tk_HangXe(string name, string value)
        {
            SqlDataReader dr = null;
            string query = null;
            try
            {
                if (name.Equals("ID Hãng xe"))
                {
                    query = "select* from HANGXE where ID_HangXe like '" + value + "%'";
                    dr = execCommand(query);
                }
                else
                {
                    query = "select* from HANGXE where HangXe like '" + value + "%'";
                    dr = execCommand(query);
                }
            }
            catch (Exception ex)
            {
                new Exception("Error : "+ex.Message);
            }
            return dr;
        }
    }
}
