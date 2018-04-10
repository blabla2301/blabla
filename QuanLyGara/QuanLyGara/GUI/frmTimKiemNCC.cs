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
    public partial class frmTimKiemNCC : Form
    {
        public frmTimKiemNCC()
        {
            InitializeComponent();
        }

        private void frmTimKiemNCC_Load(object sender, EventArgs e)
        {
            cmbTimKiem.SelectedIndex = 0;
            showLsvNCC();
        }
        public void showLsvNCC()
        {
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("NHACUNGCAP");
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr["ID_NhaCungCap"].ToString();
                item.SubItems.Add(dr["TenNCC"].ToString());
                item.SubItems.Add(dr["DiaChi"].ToString());
                item.SubItems.Add(dr["SDT"].ToString());
                item.SubItems.Add(dr["Email"].ToString());
                item.SubItems.Add(dr["Website"].ToString());
                lsvNhaCungCap.Items.Add(item);
            }
        }
        public void clearLsvNCC()
        {
            foreach (ListViewItem item in lsvNhaCungCap.Items)
                item.Remove();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                clearLsvNCC();
                DATA.TimKiemNhaCungCap ncc = new DATA.TimKiemNhaCungCap();
                SqlDataReader dr = ncc.tk_NCC(cmbTimKiem.Text, txtTimKiem.Text);
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dr["ID_NhaCungCap"].ToString();
                    item.SubItems.Add(dr["TenNCC"].ToString());
                    item.SubItems.Add(dr["DiaChi"].ToString());
                    item.SubItems.Add(dr["SDT"].ToString());
                    item.SubItems.Add(dr["Email"].ToString());
                    item.SubItems.Add(dr["Website"].ToString());
                    lsvNhaCungCap.Items.Add(item);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearLsvNCC();
            showLsvNCC();
        }
    }
}
