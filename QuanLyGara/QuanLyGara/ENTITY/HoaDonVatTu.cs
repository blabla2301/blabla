using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.ENTITY
{
    class HoaDonVatTu
    {
        private string mahdvt;

        public string MaHDVT
        {
            get { return mahdvt; }
            set { mahdvt = value; }
        }
        private string mapvt;

        public string MaPVT
        {
            get { return mapvt; }
            set { mapvt = value; }
        }
        private string tenvt;

        public string TenVT
        {
            get { return tenvt; }
            set { tenvt = value; }
        }
        private string soluong;

        public string SoLuong
        {
            get { return soluong; }
            set { soluong = value; }
        }
    }
}
