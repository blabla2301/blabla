using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.ENTITY
{
    class NhaCungCap
    {
        private string id_nhacungcap;

        public string ID_NhaCungCap
        {
            get { return id_nhacungcap; }
            set { id_nhacungcap = value; }
        }
        private string tenncc;

        public string TenNCC
        {
            get { return tenncc; }
            set { tenncc = value; }
        }
        private string diachi;

        public string DiaChi
        {
            get { return diachi; }
            set { diachi = value; }
        }
        private string sdt;

        public string SDT
        {
            get { return sdt; }
            set { sdt = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string website;

        public string Website
        {
            get { return website; }
            set { website = value; }
        }
    }
}
