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
            txtMaHDVT.Enabled = false;
            cmbMaPVT.Enabled = false;
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
            txtMaHDVT.Enabled = true;
            cmbMaPVT.Enabled = true;
            txtSoLuong.Enabled = true;
            cmbTenVT.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            lsvHD_PVT.Enabled = false;
        }

        public void clearControl()
        {
            txtMaHDVT.ResetText();
            cmbMaPVT.ResetText();
            cmbTenVT.ResetText();
            txtSoLuong.ResetText();
        }

        public void addList(SqlDataReader dr)
        {
            ListViewItem item = new ListViewItem();
            item.Text = dr["MaHDVT"].ToString();
            item.SubItems.Add(dr["MaPhieuVatTu"].ToString());
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
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("HOADON_PHIEUVATTU");
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
                cmbMaPVT.Items.Add(pvt["MaPhieuVatTu"].ToString());
            }
            sqlConn.closeConnection();
            SqlDataReader vt = sqlConn.getDataTable("VATTU");
            while (vt.Read())
            {
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
            txtMaHDVT.Focus();
            clearControl();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            kt = false;
            openControl();
            txtMaHDVT.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                ENTITY.HoaDonVatTu h = new ENTITY.HoaDonVatTu();
                h.MaHDVT = txtMaHDVT.Text.Trim();
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
            h.MaHDVT = txtMaHDVT.Text.Trim();
            h.MaHDVT = txtMaHDVT.Text.Trim();
            h.MaPVT = cmbMaPVT.Text.Trim();
            h.TenVT = cmbTenVT.Text.Trim();
            h.SoLuong = txtSoLuong.Text.Trim();
            DAL.HoaDonVatTu_Model hd = new DAL.HoaDonVatTu_Model();
            if (kt==true)
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
                txtMaHDVT.Text = lsvHD_PVT.SelectedItems[0].SubItems[0].Text;
                cmbMaPVT.Text = lsvHD_PVT.SelectedItems[0].SubItems[1].Text;
                cmbTenVT.Text = lsvHD_PVT.SelectedItems[0].SubItems[2].Text;
                txtSoLuong.Text = lsvHD_PVT.SelectedItems[0].SubItems[3].Text;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
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
                    cmbValue.Items.Add(dr["MaHDVT"].ToString());
                }
            }
            else if(key == 1)
            {
                while (dr.Read())
                {
                    cmbValue.Items.Add(dr["MaPhieuVatTu"].ToString());
                }
            }
            else
            {
                while (dr.Read())
                {
                    cmbValue.Items.Add(dr["TenVatTu"].ToString());
                }
            }
        }

    }
}
