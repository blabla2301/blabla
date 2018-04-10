using QuanLyGara.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.DATA
{
    class TimKiemPhieuVatTu : sqlConnect
    {
        public SqlDataReader tk_PVT(string name, string value)
        {
            SqlDataReader dr = null;
            string query = null;
            try
            {
                if (name.Equals("ID Phiếu vật tư"))
                {
                    query = "select * from PHIEUVATTU where ID_PhieuVatTu like '" + value + "%'";
                    dr = execCommand(query);
                }
                else
                {
                    query = "select * from PHIEUVATTU where MaNguoiPhuTrach like '" + value + "%'";
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
