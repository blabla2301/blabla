using QuanLyGara.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.DATA
{
    class TimKiemVatTu : sqlConnect
    {
        public SqlDataReader tk_VatTu(string name, string value)
        {
            SqlDataReader dr = null;
            string query = null;
            try
            {
                if (name.Equals("ID Vật tư"))
                {
                    query = "select*from VATTU where ID_VatTu like '" + value + "%'";
                    dr = execCommand(query);
                }
                else
                {
                    query = "select*from VATTU where TenVatTu like '" + value + "%'";
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
