using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara.ENTITY
{
    class PhieuDanhGia
    {
        private string id_phieudanhgia;

        public string ID_PhieuDanhGia
        {
            get { return id_phieudanhgia; }
            set { id_phieudanhgia = value; }
        }
        private string id_phieukhaosat;

        public string ID_PhieuKhaoSat
        {
            get { return id_phieukhaosat; }
            set { id_phieukhaosat = value; }
        }
        private string tinhtrangxe;

        public string TinhTrangXe
        {
            get { return tinhtrangxe; }
            set { tinhtrangxe = value; }
        }
        private string mabaohiem;

        public string MaBaoHiem
        {
            get { return mabaohiem; }
            set { mabaohiem = value; }
        }
        private string baogia;

        public string BaoGia
        {
            get { return baogia; }
            set { baogia = value; }
        }
    }
}
