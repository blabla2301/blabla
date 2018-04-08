using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.ENTITY
{
    class KhachHang
    {
        private string makh;

        public string MaKH
        {
            get { return makh; }
            set { makh = value; }
        }
        private string hoten;

        public string HoTen
        {
            get { return hoten; }
            set { hoten = value; }
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
        private string diachi;

        public string DiaChi
        {
            get { return diachi; }
            set { diachi = value; }
        }
    }
}
