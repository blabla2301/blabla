using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.ENTITY
{
    class PhieuVatTu
    {
        private string id_phieuvattu;

        public string ID_PhieuVatTu
        {
            get { return id_phieuvattu; }
            set { id_phieuvattu = value; }
        }
        private string manpt;

        public string MaNPT
        {
            get { return manpt; }
            set { manpt = value; }
        }
        private string thoigian;

        public string ThoiGian
        {
            get { return thoigian; }
            set { thoigian = value; }
        }
    }
}
