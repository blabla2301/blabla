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
    public partial class frmHoaDon_PhieuVatTu : Form
    {
        bool kt;
        public frmHoaDon_PhieuVatTu()
        {
            InitializeComponent();
        }

        private void frmHoaDon_PhieuVatTu_Load(object sender, EventArgs e)
        {
            lockControl();
            showLsvHD_PVT();
            loadCombobox();
            DAL.NguoiDung_Model nd = new DAL.NguoiDung_Model();
            nd.checkPermission(btnThem, btnSua, btnXoa);
        }

        public void lockControl()
        {
            txtID_HoaDonVatTu.Enabled = false;
            cmbID_PhieuVatTu.Enabled = false;
            cmbID_VatTu.Enabled = false;
            txtSoLuong.Enabled = false;
            cmbTenVT.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            lsvHD_PVT.Enabled = true;
        }

        public void openControl()
        {
            txtID_HoaDonVatTu.Enabled = true;
            cmbID_PhieuVatTu.Enabled = true;
            cmbID_VatTu.Enabled = true;
            txtSoLuong.Enabled = true;
            cmbTenVT.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            lsvHD_PVT.Enabled = false;
        }

        public void clearControl()
        {
            string query = "select count(ID_HoaDonVatTu) from HOADON_PHIEUVATTU";
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            int count = int.Parse(sqlConn.execScanler(query));
            txtID_HoaDonVatTu.Text = "HDVT" + (count + 1).ToString();
            cmbID_PhieuVatTu.ResetText();
            cmbTenVT.ResetText();
            txtSoLuong.ResetText();
        }

        public void addList(SqlDataReader dr)
        {
            ListViewItem item = new ListViewItem();
            item.Text = dr["ID_HoaDonVatTu"].ToString();
            item.SubItems.Add(dr["ID_PhieuVatTu"].ToString());
            item.SubItems.Add(dr["TenVatTu"].ToString());
            item.SubItems.Add(dr["SoLuong"].ToString());
            item.SubItems.Add(dr["TongTien"].ToString());
            lsvHD_PVT.Items.Add(item);
        }

        public void clearLsvHD_PVT()
        {
            lsvHD_PVT.Items.Clear();
        }

        public void showLsvHD_PVT()
        {
            clearLsvHD_PVT();
            string query = "select hd.ID_HoaDonVatTu, p.ID_PhieuVatTu, vt.TenVatTu, hd.SoLuong, hd.TongTien from HOADON_PHIEUVATTU hd, PHIEUVATTU p, VATTU vt where hd.ID_VatTu = vt.ID_VatTu and hd.ID_PhieuVatTu = p.ID_PhieuVatTu";
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.execCommand(query);
            while (dr.Read())
            {
                addList(dr);
            }
        }

        private void loadCombobox()
        {
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader pvt = sqlConn.getDataTable("PHIEUVATTU");
            while (pvt.Read())
            {
                cmbID_PhieuVatTu.Items.Add(pvt["ID_PhieuVatTu"].ToString());
            }
            sqlConn.closeConnection();
            SqlDataReader vt = sqlConn.getDataTable("VATTU");
            while (vt.Read())
            {
                cmbID_VatTu.Items.Add(vt["ID_VatTu"].ToString());
                cmbTenVT.Items.Add(vt["TenVatTu"].ToString());
            }

            //cmbTimKiem.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            kt = true;
            openControl();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtID_HoaDonVatTu.Focus();
            clearControl();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            kt = false;
            openControl();
            txtID_HoaDonVatTu.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                ENTITY.HoaDonVatTu h = new ENTITY.HoaDonVatTu();
                h.ID_HoaDonVatTu = txtID_HoaDonVatTu.Text.Trim();
                DAL.HoaDonVatTu_Model k = new DAL.HoaDonVatTu_Model();
                k.deleteHoaDonVatTu(h);
            }
            showLsvHD_PVT();
            lockControl();
            clearControl();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ENTITY.HoaDonVatTu h = new ENTITY.HoaDonVatTu();
            h.ID_HoaDonVatTu = txtID_HoaDonVatTu.Text.Trim();
            h.ID_PhieuVatTu = cmbID_PhieuVatTu.Text.Trim();
            h.ID_vatTu = cmbID_VatTu.Text.Trim();
            h.SoLuong = txtSoLuong.Text.Trim();
            DAL.HoaDonVatTu_Model hd = new DAL.HoaDonVatTu_Model();
            if (kt == true)
            {
                hd.insertHoaDonVatTu(h);
            }
            else
            {
                hd.editHoaDonVatTu(h);
            }
            showLsvHD_PVT();
            clearControl();
            lockControl();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            clearControl();
            lockControl();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                clearLsvHD_PVT();
                DAL.HoaDonVatTu_Model h = new DAL.HoaDonVatTu_Model();
                SqlDataReader dr = h.searchHoaDonVatTu(cmbTimKiem.Text.Trim(), cmbValue.Text.Trim());
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showLsvHD_PVT();
        }

        private void lsvHD_PVT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvHD_PVT.SelectedItems.Count > 0)
            {
                txtID_HoaDonVatTu.Text = lsvHD_PVT.SelectedItems[0].SubItems[0].Text;
                cmbID_PhieuVatTu.Text = lsvHD_PVT.SelectedItems[0].SubItems[1].Text;
                cmbTenVT.Text = lsvHD_PVT.SelectedItems[0].SubItems[2].Text;
                txtSoLuong.Text = lsvHD_PVT.SelectedItems[0].SubItems[3].Text;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void loadTenVT()
        {
            string query = "select TenVatTu from VATTU";
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.execCommand(query);
            while (dr.Read())
            {
                cmbValue.Items.Add(dr["TenVatTu"].ToString());
            }
        }

        private void cmbTimKiem_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbValue.Items.Clear();
            int key = cmbTimKiem.SelectedIndex;
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("HOADON_PHIEUVATTU");
            if (key == 0)
            {
                while (dr.Read())
                {
                    cmbValue.Items.Add(dr["ID_HoaDonVatTu"].ToString());
                }
            }
            else if (key == 1)
            {
                while (dr.Read())
                {
                    cmbValue.Items.Add(dr["ID_PhieuVatTu"].ToString());
                }
            }
            else
            {
                loadTenVT();
            }
        }

        private void cmbTenVT_TextChanged(object sender, EventArgs e)
        {
            string key = cmbTenVT.Text.Trim();
            string query = "select ID_VatTu from VATTU where TenVatTu like '" + key + "%'";
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            string value = sqlConn.execScanler(query);
            cmbID_VatTu.Text = value;
        }

        private void cmbID_VatTu_TextChanged(object sender, EventArgs e)
        {
            string key = cmbID_VatTu.Text.Trim();
            string query = "select TenVatTu from VATTU where ID_VatTu like '" + key + "%'";
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            string value = sqlConn.execScanler(query);
            cmbTenVT.Text = value;
        }
    }
}
