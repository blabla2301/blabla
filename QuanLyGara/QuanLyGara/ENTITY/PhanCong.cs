using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.ENTITY
{
    class PhanCong
    {
        private string id_phancong;

        public string ID_PhanCong
        {
            get { return id_phancong; }
            set { id_phancong = value; }
        }
        private string id_Lenhsuachua;

        public string ID_LenhSuaChua
        {
            get { return id_Lenhsuachua; }
            set { id_Lenhsuachua = value; }
        }
        private string id_nhanvien;

        public string ID_NhanVien
        {
            get { return id_nhanvien; }
            set { id_nhanvien = value; }
        }
        private string ngaybd;

        public string NgayBD
        {
            get { return ngaybd; }
            set { ngaybd = value; }
        }
    }
}
