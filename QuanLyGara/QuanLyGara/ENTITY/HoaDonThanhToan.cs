using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.ENTITY
{
    class HoaDonThanhToan
    {
        private string id_hoadonthanhtoan;

        public string ID_HoaDonThanhToan
        {
            get { return id_hoadonthanhtoan; }
            set { id_hoadonthanhtoan = value; }
        }
        private string id_lenhsuachua;

        public string ID_LenhSuaChua
        {
            get { return id_lenhsuachua; }
            set { id_lenhsuachua = value; }
        }
        private string tenhd;

        public string TenHD
        {
            get { return tenhd; }
            set { tenhd = value; }
        }
        private string manpt;

        public string MaNPT
        {
            get { return manpt; }
            set { manpt = value; }
        }
        private string tiendichvu;

        public string TienDichVu
        {
            get { return tiendichvu; }
            set { tiendichvu = value; }
        }
    }
}
