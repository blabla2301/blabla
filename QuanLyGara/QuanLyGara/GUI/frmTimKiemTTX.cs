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
    public partial class frmTimKiemTTX : Form
    {
        public frmTimKiemTTX()
        {
            InitializeComponent();
        }

        private void frmTimKiemTTX_Load(object sender, EventArgs e)
        {
            cmbTimKiem.SelectedIndex = 0;
            showLsvTTX();
        }

        public void clearLsvTTX()
        {
            foreach (ListViewItem item in lsvThongTinXe.Items)
                item.Remove();
        }

        public void showLsvTTX()
        {
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("THONGTINXE");
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr["ID_Xe"].ToString();
                item.SubItems.Add(dr["ID_HangXe"].ToString());
                item.SubItems.Add(dr["BienSoXe"].ToString());
                item.SubItems.Add(dr["DoiXe"].ToString());
                item.SubItems.Add(dr["SoKhung"].ToString());
                item.SubItems.Add(dr["SoMay"].ToString());
                item.SubItems.Add(dr["SoKM"].ToString());
                lsvThongTinXe.Items.Add(item);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                clearLsvTTX();
                DATA.TimKiemThongTinXe ttx = new DATA.TimKiemThongTinXe();
                SqlDataReader dr = ttx.tk_TTX(cmbTimKiem.Text, txtTimKiem.Text);
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dr["ID_Xe"].ToString();
                    item.SubItems.Add(dr["ID_HangXe"].ToString());
                    item.SubItems.Add(dr["BienSoXe"].ToString());
                    item.SubItems.Add(dr["DoiXe"].ToString());
                    item.SubItems.Add(dr["SoKhung"].ToString());
                    item.SubItems.Add(dr["SoMay"].ToString());
                    item.SubItems.Add(dr["SoKM"].ToString());
                    lsvThongTinXe.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearLsvTTX();
            showLsvTTX();
        }
    }
}
