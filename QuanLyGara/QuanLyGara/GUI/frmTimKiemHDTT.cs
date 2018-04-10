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
    public partial class frmTimKiemHDTT : Form
    {
        public frmTimKiemHDTT()
        {
            InitializeComponent();
        }

        private void frmTimKiemHDTT_Load(object sender, EventArgs e)
        {
            cmbTimKiem.SelectedIndex = 0;
            showLsvHDTT();
        }

        public void showLsvHDTT()
        {
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("HOADON_THANHTOAN");
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr["ID_HoaDonThanhToan"].ToString();
                item.SubItems.Add(dr["ID_LenhSuaChua"].ToString());
                item.SubItems.Add(dr["TenHoaDon"].ToString());
                item.SubItems.Add(dr["MaNguoiPhuTrach"].ToString());
                item.SubItems.Add(dr["TienDichVu"].ToString());
                item.SubItems.Add(dr["TongTienThanhToan"].ToString());
                lsvHD_TT.Items.Add(item);
            }
        }

        public void clearLsvHDTT()
        {
            foreach (ListViewItem item in lsvHD_TT.Items)
                item.Remove();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                clearLsvHDTT();
                DATA.TimKiemHoaDonThanhToan hdtt = new DATA.TimKiemHoaDonThanhToan();
                SqlDataReader dr = hdtt.tk_HDTT(cmbTimKiem.Text, txtTimKiem.Text);
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dr["ID_HoaDonThanhToan"].ToString();
                    item.SubItems.Add(dr["ID_LenhSuaChua"].ToString());
                    item.SubItems.Add(dr["TenHoaDon"].ToString());
                    item.SubItems.Add(dr["MaNguoiPhuTrach"].ToString());
                    item.SubItems.Add(dr["TienDichVu"].ToString());
                    item.SubItems.Add(dr["TongTienThanhToan"].ToString());
                    lsvHD_TT.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearLsvHDTT();
            showLsvHDTT();
        }

        
    }
}
