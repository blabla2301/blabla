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
    public partial class frmTimKiemHangXe : Form
    {
        public frmTimKiemHangXe()
        {
            InitializeComponent();
        }

        private void frmTimKiemHangXe_Load(object sender, EventArgs e)
        {
            cmbTimKiem.SelectedIndex = 0;
            showLstHangXe();
        }
        public void showLstHangXe()
        {
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("HANGXE");
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr["ID_HangXe"].ToString();
                item.SubItems.Add(dr["HangXe"].ToString());

                lsvHangXe.Items.Add(item);
            }
        }

        public void clearLstHangXe()
        {
            foreach (ListViewItem item in lsvHangXe.Items)
                item.Remove();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearLstHangXe();
            showLstHangXe();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                clearLstHangXe();
                DATA.TimKiemHangXe hx = new DATA.TimKiemHangXe();
                SqlDataReader dr = hx.tk_HangXe(cmbTimKiem.Text, txtTimKiem.Text);
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dr["ID_HangXe"].ToString();
                    item.SubItems.Add(dr["HangXe"].ToString());

                    lsvHangXe.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
