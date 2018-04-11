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
    public partial class frmTimKiemPVT : Form
    {
        public frmTimKiemPVT()
        {
            InitializeComponent();
        }

        private void frmTimKiemPVT_Load(object sender, EventArgs e)
        {
            cmbTimKiem.SelectedIndex = 0;
            showLsvPVT();
        }

        public void clearLsvPVT()
        {
            foreach (ListViewItem item in lsvPhieuVatTu.Items)
                item.Remove();
        }

        public void showLsvPVT()
        {
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("PHIEUVATTU");
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr["ID_PhieuVatTu"].ToString();
                item.SubItems.Add(dr["MaNguoiPhuTrach"].ToString());
                item.SubItems.Add(dr["ThoiGian"].ToString());
                lsvPhieuVatTu.Items.Add(item);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                clearLsvPVT();
                DATA.TimKiemPhieuVatTu pvt = new DATA.TimKiemPhieuVatTu();
                SqlDataReader dr = pvt.tk_PVT(cmbTimKiem.Text, txtTimKiem.Text);
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dr["ID_PhieuVatTu"].ToString();
                    item.SubItems.Add(dr["MaNguoiPhuTrach"].ToString());
                    item.SubItems.Add(dr["ThoiGian"].ToString());
                    lsvPhieuVatTu.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearLsvPVT();
            showLsvPVT();
        }
    }
}
