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
    public partial class frmTimKiemPC : Form
    {
        public frmTimKiemPC()
        {
            InitializeComponent();
        }

        private void frmTimKiemPC_Load(object sender, EventArgs e)
        {
            cmbTimKiem.SelectedIndex = 0;
            showLsvPhanCong();
        }

        public void showLsvPhanCong()
        {
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("PHANCONG");
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr["ID_PhanCong"].ToString();
                item.SubItems.Add(dr["ID_LenhSuaChua"].ToString());
                item.SubItems.Add(dr["ID_NhanVien"].ToString());
                item.SubItems.Add(dr["NgayBatDau"].ToString());
                lsvPhanCong.Items.Add(item);
            }
        }

        public void clearLsvPC()
        {
            foreach (ListViewItem item in lsvPhanCong.Items)
                item.Remove();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                clearLsvPC();
                DATA.TimKiemPhanCong pc = new DATA.TimKiemPhanCong();
                SqlDataReader dr = pc.tk_PhanCong(cmbTimKiem.Text, txtTimKiem.Text);
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dr["ID_PhanCong"].ToString();
                    item.SubItems.Add(dr["ID_LenhSuaChua"].ToString());
                    item.SubItems.Add(dr["ID_NhanVien"].ToString());
                    item.SubItems.Add(dr["NgayBatDau"].ToString());
                    lsvPhanCong.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearLsvPC();
            showLsvPhanCong();
        }
    }
}
