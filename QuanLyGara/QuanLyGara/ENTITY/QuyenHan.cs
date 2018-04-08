using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.ENTITY
{
    class QuyenHan
    {
        private string id_quyenhan;

        public string ID_QuyenHan
        {
            get { return id_quyenhan; }
            set { id_quyenhan = value; }
        }
        private bool them;

        public bool Them
        {
            get { return them; }
            set { them = value; }
        }
        private bool sua;

        public bool Sua
        {
            get { return sua; }
            set { sua = value; }
        }
        private bool xoa;

        public bool Xoa
        {
            get { return xoa; }
            set { xoa = value; }
        }
        private bool admin;

        public bool Admin
        {
            get { return admin; }
            set { admin = value; }
        }
    }
}
