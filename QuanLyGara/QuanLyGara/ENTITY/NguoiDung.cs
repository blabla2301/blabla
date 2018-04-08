using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.ENTITY
{
    class NguoiDung
    {
        private string taiKhoan;
        private string matKhau;
        private string id_quyenhan;

        public string TaiKhoan
        {
            get { return taiKhoan; }
            set { taiKhoan = value; }
        }

        public string MatKhau
        {
            get { return matKhau; }
            set { matKhau = value; }
        }

        public string ID_QuyenHan
        {
            get { return id_quyenhan; }
            set { id_quyenhan = value; }
        }


    }
}
