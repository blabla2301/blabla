using QuanLyGara.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.DATA
{
    class TimKiemPhieuKhaoSat : sqlConnect
    {
        public SqlDataReader tk_PhieuKhaoSat(string name, string value)
        {
            SqlDataReader dr = null;
            string query = null;
            try
            {
                if (name.Equals("ID Phiếu khảo sát"))
                {
                    query = "select* from PHIEUKHAOSAT where ID_PhieuKhaoSat like '" + value + "%'";
                    dr = execCommand(query);
                }
                else if(name.Equals("ID Khách hàng"))
                {
                    query = "select* from PHIEUKHAOSAT where ID_KhachHang like '" + value + "%'";
                    dr = execCommand(query);
                }
                else
                {
                    query = "select* from PHIEUKHAOSAT where ID_Xe like '" + value + "%'";
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
