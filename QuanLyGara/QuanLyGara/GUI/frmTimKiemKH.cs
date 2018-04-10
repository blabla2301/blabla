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
    public partial class frmTimKiemKH : Form
    {
        public frmTimKiemKH()
        {
            InitializeComponent();
        }

        private void frmTimKiemKH_Load(object sender, EventArgs e)
        {
            cmbTimKiem.SelectedIndex = 0;
            showLsvKhachHang();
        }

        public void showLsvKhachHang()
        {
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("KHACHHANG");
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr["ID_KhachHang"].ToString();
                item.SubItems.Add(dr["HoTen"].ToString());
                item.SubItems.Add(dr["SDT"].ToString());
                item.SubItems.Add(dr["Email"].ToString());
                item.SubItems.Add(dr["DiaChi"].ToString());
                lsvKhachHang.Items.Add(item);
            }
        }

        public void clearLsvKhachHang()
        {
            foreach (ListViewItem item in lsvKhachHang.Items)
                item.Remove();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                clearLsvKhachHang();
                DATA.TimKiemKhachHang kh = new DATA.TimKiemKhachHang();
                SqlDataReader dr = kh.tk_KhachHang(cmbTimKiem.Text, txtTimKiem.Text);
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dr["ID_KhachHang"].ToString();
                    item.SubItems.Add(dr["HoTen"].ToString());
                    item.SubItems.Add(dr["SDT"].ToString());
                    item.SubItems.Add(dr["Email"].ToString());
                    item.SubItems.Add(dr["DiaChi"].ToString());
                    lsvKhachHang.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearLsvKhachHang();
            showLsvKhachHang();
        }
    }
}
