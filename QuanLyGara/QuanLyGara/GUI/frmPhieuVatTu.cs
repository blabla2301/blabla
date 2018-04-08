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
    public partial class frmPhieuVatTu : Form
    {
        bool kt;
        public frmPhieuVatTu()
        {
            InitializeComponent();
        }

        private void frmPhieuVatTu_Load(object sender, EventArgs e)
        {
            showLsvPhieuVatTu();
            lockControl();
            loadCombobox();
            DAL.NguoiDung_Model nd = new DAL.NguoiDung_Model();
            nd.checkPermission(btnThem, btnSua, btnXoa);
        }

        public void lockControl()
        {
            txtID_PhieuVatTu.Enabled = false;
            txtMaNPT.Enabled = false;
            dtThoiGian.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            lsvPhieuVatTu.Enabled = true;
        }

        public void openControl()
        {
            txtID_PhieuVatTu.Enabled = true;
            txtMaNPT.Enabled = true;
            dtThoiGian.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            lsvPhieuVatTu.Enabled = false;
        }

        public void clearControl()
        {
            string query = "select count(ID_PhieuVatTu) from PHIEUVATTU";
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            int count = int.Parse(sqlConn.execScanler(query));
            txtID_PhieuVatTu.Text = "PVT" + (count + 1).ToString();
            txtMaNPT.ResetText();
            dtThoiGian.Value = DateTime.Now;
        }

        public void loadCombobox()
        {
            //cmbTimKiem.SelectedIndex = 0;
        }

        public string formatDate(string dt)
        {
            DateTime datetime = DateTime.Parse(dt);
            string date = datetime.ToString("yyyy/MM/dd");
            return date;
        }

        public void addList(SqlDataReader dr)
        {
            ListViewItem item = new ListViewItem();
            item.Text = dr["ID_PhieuVatTu"].ToString();
            item.SubItems.Add(dr["MaNguoiPhuTrach"].ToString());
            item.SubItems.Add(formatDate(dr["ThoiGian"].ToString()));
            lsvPhieuVatTu.Items.Add(item);
        }

        public void clearLsvPhieuVatTu()
        {
            lsvPhieuVatTu.Items.Clear();
        }

        public void showLsvPhieuVatTu()
        {
            clearLsvPhieuVatTu();
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("PHIEUVATTU");
            while (dr.Read())
            {
                addList(dr);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            kt = true;
            openControl();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            clearControl();
            txtID_PhieuVatTu.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            kt = false;
            openControl();
            txtID_PhieuVatTu.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            //txtMaNPT.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                ENTITY.PhieuVatTu p = new ENTITY.PhieuVatTu();
                p.ID_PhieuVatTu = txtID_PhieuVatTu.Text.Trim();
                DAL.PhieuVatTu_Model pvt = new DAL.PhieuVatTu_Model();
                pvt.deletePhieuVatTu(p);
            }
            showLsvPhieuVatTu();
            lockControl();
            clearControl();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ENTITY.PhieuVatTu p = new ENTITY.PhieuVatTu();
            p.ID_PhieuVatTu = txtID_PhieuVatTu.Text.Trim();
            p.MaNPT = txtMaNPT.Text.Trim();
            p.ThoiGian = dtThoiGian.Value.ToShortDateString();
            DAL.PhieuVatTu_Model pvt = new DAL.PhieuVatTu_Model();
            if (kt == true)
            {
                pvt.insertPhieuVatTu(p);
            }
            else
            {
                pvt.editPhieuVatTu(p);
            }
            showLsvPhieuVatTu();
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
                clearLsvPhieuVatTu();
                DAL.PhieuVatTu_Model p = new DAL.PhieuVatTu_Model();
                SqlDataReader dr = p.searchPhieuVatTu(cmbTimKiem.Text.Trim(), cmbValue.Text.Trim());
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
            showLsvPhieuVatTu();
        }

        private void lsvPhieuVatTu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvPhieuVatTu.SelectedItems.Count > 0)
            {
                txtID_PhieuVatTu.Text = lsvPhieuVatTu.SelectedItems[0].SubItems[0].Text;
                txtMaNPT.Text = lsvPhieuVatTu.SelectedItems[0].SubItems[1].Text;
                dtThoiGian.Text = lsvPhieuVatTu.SelectedItems[0].SubItems[2].Text;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void cmbTimKiem_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbValue.Items.Clear();
            int key = cmbTimKiem.SelectedIndex;
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("PHIEUVATTU");
            while (dr.Read())
            {
                if (key == 0)
                {
                    cmbValue.Items.Add(dr["MaPhieuVatTu"].ToString());
                }
                else
                {
                    cmbValue.Items.Add(dr["MaNguoiPhuTrach"].ToString());
                }
            }
        }


    }
}
