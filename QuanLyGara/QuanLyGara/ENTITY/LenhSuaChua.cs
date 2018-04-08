using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.ENTITY
{
    class LenhSuaChua
    {
        private string id_lenhsuachua;

        public string ID_LenhSuaChua
        {
            get { return id_lenhsuachua; }
            set { id_lenhsuachua = value; }
        }
        private string id_phieudanhgia;

        public string ID_PhieuDanhGia
        {
            get { return id_phieudanhgia; }
            set { id_phieudanhgia = value; }
        }
        private string id_phieuvattu;

        public string ID_PhieuVatTu
        {
            get { return id_phieuvattu; }
            set { id_phieuvattu = value; }
        }
    }
}
