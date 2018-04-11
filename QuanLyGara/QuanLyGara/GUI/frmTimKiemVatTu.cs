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
    public partial class frmTimKiemVatTu : Form
    {
        public frmTimKiemVatTu()
        {
            InitializeComponent();
        }

        private void frmTimKiemVatTu_Load(object sender, EventArgs e)
        {
            cmbTimKiem.SelectedIndex = 0;
            showLstVT();
        }

        public void showLstVT()
        {
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("VATTU");
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr["ID_VatTu"].ToString();
                item.SubItems.Add(dr["TenVatTu"].ToString());
                item.SubItems.Add(dr["TheLoai"].ToString());
                item.SubItems.Add(dr["SoTien"].ToString());
                item.SubItems.Add(dr["ID_NhaCungCap"].ToString());
                lsvVatTu.Items.Add(item);
            }
        }

        public void clearLsvVatTu()
        {
            foreach (ListViewItem item in lsvVatTu.Items)
                item.Remove();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                clearLsvVatTu();
                DATA.TimKiemVatTu vt = new DATA.TimKiemVatTu();
                SqlDataReader dr = vt.tk_VatTu(cmbTimKiem.Text, txtTimKiem.Text);
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dr["ID_VatTu"].ToString();
                    item.SubItems.Add(dr["TenVatTu"].ToString());
                    item.SubItems.Add(dr["TheLoai"].ToString());
                    item.SubItems.Add(dr["SoTien"].ToString());
                    item.SubItems.Add(dr["ID_NhaCungCap"].ToString());
                    lsvVatTu.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearLsvVatTu();
            showLstVT();
        }
    }
}
