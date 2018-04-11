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
    public partial class frmTimKiemLSC : Form
    {
        public frmTimKiemLSC()
        {
            InitializeComponent();
        }

        private void lsvLenhSuaChua_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmTimKiemLSC_Load(object sender, EventArgs e)
        {
            cmbTimKiem.SelectedIndex = 0;
            showLsvLSC();
        }

        public void showLsvLSC()
        {
            
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("LENHSUACHUA");
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr["ID_LenhSuaChua"].ToString();
                item.SubItems.Add(dr["ID_PhieuDanhGia"].ToString());
                item.SubItems.Add(dr["ID_PhieuVatTu"].ToString());
                lsvLenhSuaChua.Items.Add(item);
            }
        }

        public void clearLsvLSC()
        {
            foreach (ListViewItem item in lsvLenhSuaChua.Items)
                item.Remove();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                clearLsvLSC();
                DATA.TimKiemLSC lsc = new DATA.TimKiemLSC();
                SqlDataReader dr = lsc.tk_LSC(cmbTimKiem.Text, txtTimKiem.Text);
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dr["ID_LenhSuaChua"].ToString();
                    item.SubItems.Add(dr["ID_PhieuDanhGia"].ToString());
                    item.SubItems.Add(dr["ID_PhieuVatTu"].ToString());
                    lsvLenhSuaChua.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearLsvLSC();
            showLsvLSC();
        }
    }
}
