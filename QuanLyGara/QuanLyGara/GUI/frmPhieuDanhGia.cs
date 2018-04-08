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
    public partial class frmPhieuDanhGia : Form
    {
        bool kt;
        public frmPhieuDanhGia()
        {
            InitializeComponent();
        }

        private void frmPhieuDanhGia_Load(object sender, EventArgs e)
        {
            showLsvPhieuDanhGia();
            loadCombobox();
            lockControl();
            DAL.NguoiDung_Model nd = new DAL.NguoiDung_Model();
            nd.checkPermission(btnThem, btnSua, btnXoa);
        }

        public void lockControl()
        {
            txtID_PhieuDanhGia.Enabled = false;
            cmbID_PhieuKhaoSat.Enabled = false;
            txtMaBH.Enabled = false;
            txtTinhTrangXe.Enabled = false;
            txtBaoGia.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            lsvPhieuDanhGia.Enabled = true;
        }

        public void openControl()
        {
            txtID_PhieuDanhGia.Enabled = true;
            cmbID_PhieuKhaoSat.Enabled = true;
            txtMaBH.Enabled = true;
            txtTinhTrangXe.Enabled = true;
            txtBaoGia.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            lsvPhieuDanhGia.Enabled = false;
        }

        public void clearControl()
        {
            string query = "select count(ID_PhieuDanhGia) from PHIEUDANHGIA";
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            int count = int.Parse(sqlConn.execScanler(query));
            txtID_PhieuDanhGia.Text = "PDG" + (count + 1).ToString();
            cmbID_PhieuKhaoSat.ResetText();
            txtMaBH.ResetText();
            txtTinhTrangXe.ResetText();
            txtBaoGia.ResetText();
        }

        public void addList(SqlDataReader dr)
        {
            ListViewItem item = new ListViewItem();
            item.Text = dr["ID_PhieuDanhGia"].ToString();
            item.SubItems.Add(dr["ID_PhieuKhaoSat"].ToString());
            item.SubItems.Add(dr["TinhTrangXe"].ToString());
            item.SubItems.Add(dr["MaBaoHiem"].ToString());
            item.SubItems.Add(dr["ThongBaoGiaSua"].ToString());
            lsvPhieuDanhGia.Items.Add(item);
        }

        public void clearLsvPhieuDanhGia()
        {
            lsvPhieuDanhGia.Items.Clear();
        }

        public void showLsvPhieuDanhGia()
        {
            clearLsvPhieuDanhGia();
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("PHIEUDANHGIA");
            while (dr.Read())
            {
                addList(dr);
            }
        }

        public void loadCombobox()
        {
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("PHIEUKHAOSAT");
            while (dr.Read())
            {
                cmbID_PhieuKhaoSat.Items.Add(dr["ID_PhieuKhaoSat"].ToString());
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
            txtID_PhieuDanhGia.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            kt = false;
            openControl();
            txtID_PhieuDanhGia.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            //txtMaPDG.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                ENTITY.PhieuDanhGia p = new ENTITY.PhieuDanhGia();
                p.ID_PhieuDanhGia = txtID_PhieuDanhGia.Text.Trim();
                DAL.PhieuDanhGia_Model pdg = new DAL.PhieuDanhGia_Model();
                pdg.deletePhieuDanhGia(p);
            }
            showLsvPhieuDanhGia ();
            lockControl();
            clearControl();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ENTITY.PhieuDanhGia p = new ENTITY.PhieuDanhGia();
            p.ID_PhieuDanhGia = txtID_PhieuDanhGia.Text.Trim();
            p.ID_PhieuKhaoSat = cmbID_PhieuKhaoSat.Text.Trim();
            p.MaBaoHiem = txtMaBH.Text.Trim();
            p.TinhTrangXe = txtTinhTrangXe.Text.Trim();
            p.BaoGia = txtBaoGia.Text.Trim();
            DAL.PhieuDanhGia_Model pdg = new DAL.PhieuDanhGia_Model();
            if (kt == true)
            {
                pdg.insertPhieuDanhGia(p);
            }
            else
            {
                pdg.editPhieuDanhGia(p);
            }
            showLsvPhieuDanhGia();
            lockControl();
            clearControl();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            lockControl();
            //clearControl();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                clearLsvPhieuDanhGia();
                DAL.PhieuDanhGia_Model p = new DAL.PhieuDanhGia_Model();
                SqlDataReader dr = p.searchPhieuDanhGia(cmbTimKiem.Text.Trim(), cmbValue.Text.Trim());
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
            showLsvPhieuDanhGia();
        }

        private void lsvPhieuDanhGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvPhieuDanhGia.SelectedItems.Count > 0)
            {
                txtID_PhieuDanhGia.Text = lsvPhieuDanhGia.SelectedItems[0].SubItems[0].Text;
                cmbID_PhieuKhaoSat.Text = lsvPhieuDanhGia.SelectedItems[0].SubItems[1].Text;
                txtTinhTrangXe.Text = lsvPhieuDanhGia.SelectedItems[0].SubItems[2].Text;
                txtMaBH.Text = lsvPhieuDanhGia.SelectedItems[0].SubItems[3].Text;
                txtBaoGia.Text = lsvPhieuDanhGia.SelectedItems[0].SubItems[4].Text;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void cmbTimKiem_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbValue.Items.Clear();
            cmbValue.ResetText();
            int key = cmbTimKiem.SelectedIndex;
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("PHIEUDANHGIA");
            while (dr.Read())
            {
                if (key == 0)
                {
                    cmbValue.Items.Add(dr["ID_PhieuDanhGia"].ToString());
                }
                else if (key == 1)
                {
                    cmbValue.Items.Add(dr["ID_PhieuKhaoSat"].ToString());
                }
                else if (key == 2)
                {
                    cmbValue.Items.Add(dr["TinhTrangXe"].ToString());
                }
                else
                {
                    cmbValue.Items.Add(dr["MaBaoHiem"].ToString());
                }
            }
        }


    }
}
