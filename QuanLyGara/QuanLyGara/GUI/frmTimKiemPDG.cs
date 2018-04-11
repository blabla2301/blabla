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
    public partial class frmTimKiemPDG : Form
    {
        public frmTimKiemPDG()
        {
            InitializeComponent();
        }


        private void frmTimKiemPDG_Load(object sender, EventArgs e)
        {
            cmbTimKiem.SelectedIndex = 0;
            showLsvPDG();

        }

        public void clearLsvPDG()
        {
            foreach (ListViewItem item in lsvPhieuDanhGia.Items)
                item.Remove();
        }
        public void showLsvPDG()
        {
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("PHIEUDANHGIA");
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr["ID_PhieuDanhGia"].ToString();
                item.SubItems.Add(dr["ID_PhieuKhaoSat"].ToString());
                item.SubItems.Add(dr["TinhTrangXe"].ToString());
                item.SubItems.Add(dr["MaBaoHiem"].ToString());
                item.SubItems.Add(dr["ThongBaoGiaSua"].ToString());
                lsvPhieuDanhGia.Items.Add(item);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearLsvPDG();
            showLsvPDG();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                clearLsvPDG();
                DATA.TimKiemPhieuDanhGia pdg = new DATA.TimKiemPhieuDanhGia();
                SqlDataReader dr = pdg.tk_PDG(cmbTimKiem.Text, txtTimKiem.Text);
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dr["ID_PhieuDanhGia"].ToString();
                    item.SubItems.Add(dr["ID_PhieuKhaoSat"].ToString());
                    item.SubItems.Add(dr["TinhTrangXe"].ToString());
                    item.SubItems.Add(dr["MaBaoHiem"].ToString());
                    item.SubItems.Add(dr["ThongBaoGiaSua"].ToString());
                    lsvPhieuDanhGia.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

    }
}
