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
    public partial class frmNhaCungCap : Form
    {
        bool kt;
        public frmNhaCungCap()
        {
            InitializeComponent();
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            loadCombobx();
            showLsvNhaCungCap();
            lockControl();
            DAL.NguoiDung_Model nd = new DAL.NguoiDung_Model();
            nd.checkPermission(btnThem, btnSua, btnXoa);
        }

        public void lockControl()
        {
            txtID_NhaCungCap.Enabled = false;
            txtTenNCC.Enabled = false;
            txtDiaChi.Enabled = false;
            txtSDT.Enabled = false;
            txtEmail.Enabled = false;
            txtWebsite.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            lsvNhaCungCap.Enabled = true;
        }

        public void openControl()
        {
            txtID_NhaCungCap.Enabled = true;
            txtTenNCC.Enabled = true;
            txtDiaChi.Enabled = true;
            txtSDT.Enabled = true;
            txtEmail.Enabled = true;
            txtWebsite.Enabled = true;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            lsvNhaCungCap.Enabled = false;
        }

        public void clearControl()
        {
            string query = "select count(ID_NhaCungCap) from NHACUNGCAP";
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            int count = int.Parse(sqlConn.execScanler(query));
            txtID_NhaCungCap.Text = "NCC" + (count + 1).ToString();
            txtTenNCC.ResetText();
            txtDiaChi.ResetText();
            txtSDT.ResetText();
            txtEmail.ResetText();
            txtWebsite.ResetText();
        }

        public void addList(SqlDataReader dr)
        {
            ListViewItem item = new ListViewItem();
            item.Text = dr["ID_NhaCungCap"].ToString();
            item.SubItems.Add(dr["TenNCC"].ToString());
            item.SubItems.Add(dr["DiaChi"].ToString());
            item.SubItems.Add(dr["SDT"].ToString());
            item.SubItems.Add(dr["Email"].ToString());
            item.SubItems.Add(dr["Website"].ToString());
            lsvNhaCungCap.Items.Add(item);
        }

        public void clearLsvNhaCungCap()
        {
            lsvNhaCungCap.Items.Clear();
        }

        public void showLsvNhaCungCap()
        {
            clearLsvNhaCungCap();
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("NHACUNGCAP");
            while (dr.Read())
            {
                addList(dr);
            }
        }

        public void loadCombobx()
        {
            //cmbTimKiem.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            kt = true;
            openControl();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtID_NhaCungCap.Focus();
            clearControl();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            kt = false;
            openControl();
            txtID_NhaCungCap.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                ENTITY.NhaCungCap n = new ENTITY.NhaCungCap();
                n.ID_NhaCungCap = txtID_NhaCungCap.Text.Trim();
                DAL.NhaCungCap_Model ncc = new DAL.NhaCungCap_Model();
                ncc.deleteNhaCungCap(n);
            }
            showLsvNhaCungCap();
            lockControl();
            clearControl();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ENTITY.NhaCungCap n = new ENTITY.NhaCungCap();
            n.ID_NhaCungCap = txtID_NhaCungCap.Text.Trim();
            n.TenNCC = txtTenNCC.Text.Trim();
            n.DiaChi = txtDiaChi.Text.Trim();
            n.SDT = txtSDT.Text.Trim();
            n.Email = txtEmail.Text.Trim();
            n.Website = txtWebsite.Text.Trim();
            DAL.NhaCungCap_Model ncc = new DAL.NhaCungCap_Model();
            if (kt==true)
            {
                ncc.insertNhaCungCap(n);
            }
            else
            {
                ncc.editNhaCungCap(n);
            }
            showLsvNhaCungCap();
            lockControl();
            clearControl();
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
                clearLsvNhaCungCap();
                DAL.NhaCungCap_Model n = new DAL.NhaCungCap_Model();
                SqlDataReader dr = n.searchNhaCungCap(cmbTimKiem.Text.Trim(), cmbValue.Text.Trim());
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
            showLsvNhaCungCap();
        }

        private void lsvNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvNhaCungCap.SelectedItems.Count > 0)
            {
                txtID_NhaCungCap.Text = lsvNhaCungCap.SelectedItems[0].SubItems[0].Text;
                txtTenNCC.Text = lsvNhaCungCap.SelectedItems[0].SubItems[1].Text;
                txtDiaChi.Text = lsvNhaCungCap.SelectedItems[0].SubItems[2].Text;
                txtSDT.Text = lsvNhaCungCap.SelectedItems[0].SubItems[3].Text;
                txtEmail.Text = lsvNhaCungCap.SelectedItems[0].SubItems[4].Text;
                txtWebsite.Text = lsvNhaCungCap.SelectedItems[0].SubItems[5].Text;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void cmbTimKiem_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbValue.Items.Clear();
            int key = cmbTimKiem.SelectedIndex;
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("NHACUNGCAP");
            while (dr.Read())
            {
                if (key == 0)
                {
                    cmbValue.Items.Add(dr["ID_nhaCungCap"].ToString());
                }
                else if (key == 1)
                {
                    cmbValue.Items.Add(dr["TenNCC"].ToString());
                }
                else if (key == 2)
                {
                    cmbValue.Items.Add(dr["DiaChi"].ToString());
                }
                else if (key == 3)
                {
                    cmbValue.Items.Add(dr["SDT"].ToString());
                }
                else if (key == 4)
                {
                    cmbValue.Items.Add(dr["Email"].ToString());
                }
                else
                {
                    cmbValue.Items.Add(dr["Website"].ToString());
                }
            }
        }
    }
}
