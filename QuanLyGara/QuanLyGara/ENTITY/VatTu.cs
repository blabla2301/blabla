using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.ENTITY
{
    class VatTu
    {
        private string id_vattu;

        public string ID_VatTu
        {
            get { return id_vattu; }
            set { id_vattu = value; }
        }
        private string tenvattu;

        public string TenVatTu
        {
            get { return tenvattu; }
            set { tenvattu = value; }
        }
        private string theloai;

        public string TheLoai
        {
            get { return theloai; }
            set { theloai = value; }
        }
        private string sotien;

        public string SoTien
        {
            get { return sotien; }
            set { sotien = value; }
        }
        private string id_nhacungcap;

        public string ID_NhaCungCap
        {
            get { return id_nhacungcap; }
            set { id_nhacungcap = value; }
        }
    }
}
