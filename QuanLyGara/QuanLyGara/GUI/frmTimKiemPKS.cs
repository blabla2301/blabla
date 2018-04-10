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
    public partial class frmTimKiemPKS : Form
    {
        public frmTimKiemPKS()
        {
            InitializeComponent();
        }

        private void frmTimKiemPKS_Load(object sender, EventArgs e)
        {
            cmbTimKiem.SelectedIndex = 0;
            showLsvPKS();
        }

        public void clearLsvPKS()
        {
            foreach (ListViewItem item in lsvPhieuKhaoSat.Items)
                item.Remove();
        }
        public void showLsvPKS()
        {
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("PHIEUKHAOSAT");
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr["ID_PhieuKhaoSat"].ToString();
                item.SubItems.Add(dr["ID_KhachHang"].ToString());
                item.SubItems.Add(dr["ID_Xe"].ToString());
                item.SubItems.Add(dr["YeuCau"].ToString());
                lsvPhieuKhaoSat.Items.Add(item);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                clearLsvPKS();
                DATA.TimKiemPhieuKhaoSat pks = new DATA.TimKiemPhieuKhaoSat();
                SqlDataReader dr = pks.tk_PhieuKhaoSat(cmbTimKiem.Text, txtTimKiem.Text);
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dr["ID_PhieuKhaoSat"].ToString();
                    item.SubItems.Add(dr["ID_KhachHang"].ToString());
                    item.SubItems.Add(dr["ID_Xe"].ToString());
                    item.SubItems.Add(dr["YeuCau"].ToString());
                    lsvPhieuKhaoSat.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearLsvPKS();
            showLsvPKS();
        }
    }
}
