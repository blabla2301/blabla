﻿using QuanLyGara.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.DATA
{
    class TimKiemPhieuDanhGia : sqlConnect
    {
        public SqlDataReader tk_PDG(string name, string value)
        {
            SqlDataReader dr = null;
            string query = null;
            try
            {
                if(name.Equals("ID Phiếu đánh giá"))
                {
                    query = "select * from PHIEUDANHGIA where ID_PhieuDanhGia like '" + value + "%'";
                    dr=execCommand(query);
                }
                else
                {
                    query = "select * from PHIEUDANHGIA where ID_PhieuKhaoSat like '" + value + "%'";
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
