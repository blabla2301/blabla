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
    public partial class frmTimKiemNV : Form
    {
        public frmTimKiemNV()
        {
            InitializeComponent();
        }

        private void frmTimKiemNV_Load(object sender, EventArgs e)
        {
            cmbTimKiem.SelectedIndex = 0;
            showLsvNhanVien();

        }
        public void showLsvNhanVien()
        {
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("NHANVIEN");
            while(dr.Read())
            {
                ListViewItem item =new ListViewItem();
                item.Text = dr["ID_NhanVien"].ToString();
                item.SubItems.Add(dr["HoTen"].ToString());
                item.SubItems.Add(dr["SDT"].ToString());
                item.SubItems.Add(dr["Ngaysinh"].ToString());
                item.SubItems.Add(dr["GioiTinh"].ToString());
                item.SubItems.Add(dr["DiaChi"].ToString());
                item.SubItems.Add(dr["TaiKhoan"].ToString());
                lsvNhanVien.Items.Add(item);
            }
        }

        public void clearLsvNhanVien()
        {
            foreach (ListViewItem item in lsvNhanVien.Items)
                item.Remove();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                clearLsvNhanVien();
                DATA.TimKiemNhanVien nv = new DATA.TimKiemNhanVien();
                SqlDataReader dr = nv.tk_NhanVien(cmbTimKiem.Text, txtTimKiem.Text);
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dr["ID_NhanVien"].ToString();
                    item.SubItems.Add(dr["HoTen"].ToString());
                    item.SubItems.Add(dr["SDT"].ToString());
                    item.SubItems.Add(dr["Ngaysinh"].ToString());
                    item.SubItems.Add(dr["GioiTinh"].ToString());
                    item.SubItems.Add(dr["DiaChi"].ToString());
                    item.SubItems.Add(dr["TaiKhoan"].ToString());
                    lsvNhanVien.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRfresh_Click(object sender, EventArgs e)
        {
            clearLsvNhanVien();
            showLsvNhanVien();
        }

    }
}
