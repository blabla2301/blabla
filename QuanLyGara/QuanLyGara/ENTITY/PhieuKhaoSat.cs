using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.ENTITY
{
    class PhieuKhaoSat
    {
        private string id_phieukhaosat;

        public string ID_PhieuKhaoSat
        {
            get { return id_phieukhaosat; }
            set { id_phieukhaosat = value; }
        }
        private string id_khachhang;

        public string ID_KhachHang
        {
            get { return id_khachhang; }
            set { id_khachhang = value; }
        }
        private string id_xe;

        public string ID_Xe
        {
            get { return id_xe; }
            set { id_xe = value; }
        }
        private string yeucau;

        public string YeuCau
        {
            get { return yeucau; }
            set { yeucau = value; }
        }
    }
}
