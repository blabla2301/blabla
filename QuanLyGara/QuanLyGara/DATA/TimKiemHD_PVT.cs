using QuanLyGara.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.DATA
{
    class TimKiemHD_PVT:sqlConnect
    {
        public SqlDataReader tk_HD_PVT(string name, string value)
        {
            SqlDataReader dr = null;
            string query = null;
            try
            {
                if (name.Equals("ID Hóa đơn vật tư"))
                {
                    query = "select * from HOADON_PHIEUVATTU where ID_HoaDonVatTu like '" + value + "%'";
                    dr = execCommand(query);
                }
                else if (name.Equals("ID Phiếu vật tư"))
                {
                    query = "select * from HOADON_PHIEUVATTU where ID_PhieuVatTu like'" + value + "%'";
                    dr = execCommand(query);
                }
                else
                {
                    query = " select* from HOADON_PHIEUVATTU where ID_VatTu like'" + value + "%'";
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
