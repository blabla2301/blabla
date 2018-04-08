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
    public partial class frmVatTu : Form
    {
        bool kt;
        public frmVatTu()
        {
            InitializeComponent();
        }

        private void frmVatTu_Load(object sender, EventArgs e)
        {
            lockControl();
            loadCombobox();
            showLsvVatTu();
            DAL.NguoiDung_Model nd = new DAL.NguoiDung_Model();
            nd.checkPermission(btnThem, btnSua, btnXoa);
        }

        public void lockControl()
        {
            txtID_VatTu.Enabled = false;
            txtTenVatTu.Enabled = false;
            txtTheLoai.Enabled = false;
            txtSoTien.Enabled = false;
            cmbTenNCC.Enabled = false;
            cmbID_NCC.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            lsvVatTu.Enabled = true;
        }

        public void openControl()
        {
            txtID_VatTu.Enabled = true;
            txtTenVatTu.Enabled = true;
            txtTheLoai.Enabled = true;
            txtSoTien.Enabled = true;
            cmbTenNCC.Enabled = true;
            cmbID_NCC.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            lsvVatTu.Enabled = false;
        }

        public void clearControl()
        {
            string query = "select count(ID_VatTu) from VATTU";
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            int count = int.Parse(sqlConn.execScanler(query));
            txtID_VatTu.Text = "VT" + (count + 1).ToString();
            txtTenVatTu.ResetText();
            txtTheLoai.ResetText();
            txtSoTien.ResetText();
            cmbTenNCC.ResetText();
            cmbID_NCC.ResetText();
        }

        public void addList(SqlDataReader dr)
        {
            ListViewItem item = new ListViewItem();
            item.Text = dr["ID_VatTu"].ToString();
            item.SubItems.Add(dr["TenVatTu"].ToString());
            item.SubItems.Add(dr["TheLoai"].ToString());
            item.SubItems.Add(dr["SoTien"].ToString());
            item.SubItems.Add(dr["TenNCC"].ToString());
            lsvVatTu.Items.Add(item);
        }

        public void clearLsvVatTu()
        {
            lsvVatTu.Items.Clear();
        }

        public void showLsvVatTu()
        {
            clearLsvVatTu();
            string query = "select vt.ID_VatTu, vt.TenVatTu, vt.TheLoai, vt.SoTien, c.TenNCC from VATTU vt, NHACUNGCAP c where vt.ID_NhaCungCap = c.ID_NhaCungCap";
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.execCommand(query);
            while (dr.Read())
            {
                addList(dr);
            }
        }

        public void loadCombobox()
        {
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("NHACUNGCAP");
            while (dr.Read())
            {
                cmbID_NCC.Items.Add(dr["ID_NhaCungCap"].ToString());
                cmbTenNCC.Items.Add(dr["TenNCC"].ToString());
            }
            //cmbTimKiem.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            kt = true;
            openControl();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            clearControl();
            txtID_VatTu.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            kt = false;
            openControl();
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            txtID_VatTu.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                ENTITY.VatTu vt = new ENTITY.VatTu();
                vt.ID_VatTu = txtID_VatTu.Text.Trim();
                DAL.VatTu_Model k = new DAL.VatTu_Model();
                k.deleteVatTu(vt);
            }
            showLsvVatTu();
            clearControl();
            lockControl();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ENTITY.VatTu vt = new ENTITY.VatTu();
            vt.ID_VatTu = txtID_VatTu.Text.Trim();
            vt.TenVatTu = txtTenVatTu.Text.Trim();
            vt.TheLoai = txtTheLoai.Text.Trim();
            vt.SoTien = txtSoTien.Text.Trim();
            vt.ID_NhaCungCap = cmbID_NCC.Text.Trim();
            DAL.VatTu_Model v = new DAL.VatTu_Model();
            if (kt == true)
            {
                v.insertVatTu(vt);
            }
            else
            {
                v.editVatTu(vt);
            }
            showLsvVatTu();
            lockControl();
            clearControl();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            lockControl();
            clearControl();
        }

        private void lsvVatTu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvVatTu.SelectedItems.Count > 0)
            {
                txtID_VatTu.Text = lsvVatTu.SelectedItems[0].SubItems[0].Text;
                txtTenVatTu.Text = lsvVatTu.SelectedItems[0].SubItems[1].Text;
                txtTheLoai.Text = lsvVatTu.SelectedItems[0].SubItems[2].Text;
                txtSoTien.Text = lsvVatTu.SelectedItems[0].SubItems[3].Text;
                cmbTenNCC.Text = lsvVatTu.SelectedItems[0].SubItems[4].Text;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                clearLsvVatTu();
                DAL.VatTu_Model vt = new DAL.VatTu_Model();
                SqlDataReader dr = vt.searchVatTu(cmbTimKiem.Text.Trim(), cmbValue.Text.Trim());
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
            showLsvVatTu();
        }

        private void loadNhaCungCap()
        {
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("NHACUNGCAP");
            while (dr.Read())
            {
                cmbValue.Items.Add(dr["TenNCC"].ToString());
            }
        }

        private void cmbTimKiem_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbValue.Items.Clear();
            cmbValue.ResetText();
            int key = cmbTimKiem.SelectedIndex;
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("VATTU");
            if (key==0)
            {
                while (dr.Read())
                {
                    cmbValue.Items.Add(dr["ID_VatTu"].ToString());
                }
            }
            else if (key == 1)
            {
                while (dr.Read())
                {
                    cmbValue.Items.Add(dr["TenVatTu"].ToString());
                }
            }
            else if (key == 2)
            {
                while (dr.Read())
                {
                    cmbValue.Items.Add(dr["TheLoai"].ToString());
                }
            }
            else
            {
                loadNhaCungCap();
            }
        }

        private void cmbTenNCC_TextChanged(object sender, EventArgs e)
        {
            string key = cmbTenNCC.Text;
            string query = "select ID_NhaCungCap from NHACUNGCAP where TenNCC like '" + key + "%'";
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            string value = sqlConn.execScanler(query);
            cmbID_NCC.Text = value;
        }

        private void cmbID_NCC_TextChanged(object sender, EventArgs e)
        {
            string key = cmbID_NCC.Text;
            string query = "select TenNCC from NHACUNGCAP where ID_NhaCungCap like '" + key + "%'";
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            string value = sqlConn.execScanler(query);
            cmbTenNCC.Text = value;
        }
    }
}
