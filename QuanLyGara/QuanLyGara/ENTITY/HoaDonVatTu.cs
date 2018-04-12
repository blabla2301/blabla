using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.ENTITY
{
    class HoaDonVatTu
    {
        private string id_hoadonvattu;

        public string ID_HoaDonVatTu
        {
            get { return id_hoadonvattu; }
            set { id_hoadonvattu = value; }
        }
        private string id_phieuvattu;

        public string ID_PhieuVatTu
        {
            get { return id_phieuvattu; }
            set { id_phieuvattu = value; }
        }
        private string id_vattu;

        public string ID_vatTu
        {
            get { return id_vattu; }
            set { id_vattu = value; }
        }
        private string soluong;

        public string SoLuong
        {
            get { return soluong; }
            set { soluong = value; }
        }
    }
}
