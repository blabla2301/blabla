using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyGara.GUI
{
    public partial class frmTimKiemHD_PVT : Form
    {
        public frmTimKiemHD_PVT()
        {
            InitializeComponent();
        }
        private void frmTimKiemHD_PVT_Load(object sender, EventArgs e)
        {
            cmbTimKiem.SelectedIndex = 0;
            showLsvHD_PVT();
        }

        public void showLsvHD_PVT()
        {
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("HOADON_PHIEUVATTU");
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr["ID_HoaDonVatTu"].ToString();
                item.SubItems.Add(dr["ID_PhieuVatTu"].ToString());
                item.SubItems.Add(dr["ID_VatTu"].ToString());
                item.SubItems.Add(dr["SoLuong"].ToString());
                item.SubItems.Add(dr["TongTien"].ToString());
                lsvHD_PVT.Items.Add(item);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                clearLsvHD_PVT();
                DATA.TimKiemHD_PVT hd_pvt = new DATA.TimKiemHD_PVT();
                SqlDataReader dr = hd_pvt.tk_HD_PVT(cmbTimKiem.Text, txtTimKiem.Text);
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dr["ID_HoaDonVatTu"].ToString();
                    item.SubItems.Add(dr["ID_PhieuVatTu"].ToString());
                    item.SubItems.Add(dr["ID_VatTu"].ToString());
                    item.SubItems.Add(dr["SoLuong"].ToString());
                    item.SubItems.Add(dr["TongTien"].ToString());
                    lsvHD_PVT.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void clearLsvHD_PVT()
        {
            foreach (ListViewItem item in lsvHD_PVT.Items)
                item.Remove();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearLsvHD_PVT();
            showLsvHD_PVT();
        }


    }
}
