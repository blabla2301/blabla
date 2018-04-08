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
    public partial class frmLenhSuaChua : Form
    {
        bool kt;
        public frmLenhSuaChua()
        {
            InitializeComponent();
        }

        private void frmLenhSuaChua_Load(object sender, EventArgs e)
        {
            loadConbobox();
            showLsvLenhSuaChua();
            lockControl();
            DAL.NguoiDung_Model nd = new DAL.NguoiDung_Model();
            nd.checkPermission(btnThem, btnSua, btnXoa);
        }

        public void lockControl()
        {
            txtID_LenhSuaChua.Enabled = false;
            txtID_PhieuDanhGia.Enabled = false;
            txtID_PhieuVatTu.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            lsvLenhSuaChua.Enabled = true;
        }

        public void openControl()
        {
            txtID_LenhSuaChua.Enabled = true;
            txtID_PhieuDanhGia.Enabled = true;
            txtID_PhieuVatTu.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            lsvLenhSuaChua.Enabled = false;
        }

        public void clearControl()
        {
            string query = "select count(ID_LenhSuaChua) from LENHSUACHUA";
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            int count = int.Parse(sqlConn.execScanler(query));
            txtID_LenhSuaChua.Text = "LSC" + (count + 1).ToString();
            txtID_PhieuDanhGia.ResetText();
            txtID_PhieuVatTu.ResetText();
        }

        public void addList(SqlDataReader dr)
        {
            ListViewItem item = new ListViewItem();
            item.Text = dr["ID_LenhSuaChua"].ToString();
            item.SubItems.Add(dr["ID_PhieuDanhGia"].ToString());
            item.SubItems.Add(dr["ID_PhieuVatTu"].ToString());
            lsvLenhSuaChua.Items.Add(item);
        }

        public void clearLsvLenhSuaChua()
        {
            lsvLenhSuaChua.Items.Clear();
        }

        public void showLsvLenhSuaChua()
        {
            clearLsvLenhSuaChua();
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("LENHSUACHUA");
            while (dr.Read())
            {
                addList(dr);
            }
        }

        public void loadConbobox()
        {
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader pdg = sqlConn.getDataTable("PHIEUDANHGIA");
            while (pdg.Read())
            {
                txtID_PhieuDanhGia.Items.Add(pdg["ID_PhieuDanhGia"].ToString());
            }
            sqlConn.closeConnection();
            SqlDataReader pvt = sqlConn.getDataTable("PHIEUVATTU");
            while (pvt.Read())
            {
                txtID_PhieuVatTu.Items.Add(pvt["ID_PhieuVatTu"].ToString());
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
            txtID_LenhSuaChua.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            kt = false;
            openControl();
            txtID_LenhSuaChua.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                ENTITY.LenhSuaChua l = new ENTITY.LenhSuaChua();
                l.ID_LenhSuaChua = txtID_LenhSuaChua.Text.Trim();
                DAL.LenhSuaChua_Model lcs = new DAL.LenhSuaChua_Model();
                lcs.deleteLenhSuaChua(l);
            }
            showLsvLenhSuaChua();
            lockControl();
            clearControl();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ENTITY.LenhSuaChua l = new ENTITY.LenhSuaChua();
            l.ID_LenhSuaChua = txtID_LenhSuaChua.Text.Trim();
            l.ID_PhieuDanhGia = txtID_PhieuDanhGia.Text.Trim();
            l.ID_PhieuVatTu = txtID_PhieuVatTu.Text.Trim();
            DAL.LenhSuaChua_Model lsc = new DAL.LenhSuaChua_Model();
            if (kt==true)
            {
                lsc.insertLenhSuaChua(l);
            }
            else
            {
                lsc.editLenhSuaChua(l);
            }
            showLsvLenhSuaChua();
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
                clearLsvLenhSuaChua();
                DAL.LenhSuaChua_Model l = new DAL.LenhSuaChua_Model();
                SqlDataReader dr = l.searchLenhSuaChua(cmbTimKiem.Text.Trim(), cmbValue.Text.Trim());
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
            showLsvLenhSuaChua();
        }

        private void lsvLenhSuaChua_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvLenhSuaChua.SelectedItems.Count > 0)
            {
                txtID_LenhSuaChua.Text = lsvLenhSuaChua.SelectedItems[0].SubItems[0].Text;
                txtID_PhieuDanhGia.Text = lsvLenhSuaChua.SelectedItems[0].SubItems[1].Text;
                txtID_PhieuVatTu.Text = lsvLenhSuaChua.SelectedItems[0].SubItems[2].Text;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void cmbTimKiem_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbValue.Items.Clear();
            int key = cmbTimKiem.SelectedIndex;
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("LENHSUACHUA");
            while (dr.Read())
            {
                if (key == 0)
                {
                    cmbValue.Items.Add(dr["ID_LenhSuaChua"].ToString());
                }
                else if (key == 1)
                {
                    cmbValue.Items.Add(dr["ID_PhieuDanhGia"].ToString());
                }
                else
                {
                    cmbValue.Items.Add(dr["ID_PhieuVatTu"].ToString());
                }
            }
        }


    }
}
