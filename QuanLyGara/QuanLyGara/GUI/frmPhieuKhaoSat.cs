using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyGara.GUI
{
    public partial class frmPhieuKhaoSat : Form
    {
        bool kt;
        public frmPhieuKhaoSat()
        {
            InitializeComponent();
        }

        private void frmPhieuKhaoSat_Load(object sender, EventArgs e)
        {
            lockControl();
            showLsvPhieuKhaoSat();
            loadCombobox();
            DAL.NguoiDung_Model nd = new DAL.NguoiDung_Model();
            nd.checkPermission(btnThem, btnSua, btnXoa);
        }

        private void lockControl()
        {
            txtID_PhieuKhaoSat.Enabled = false;
            txtYeuCau.Enabled = false;
            cmbTenKH.Enabled = false;
            cmbID_KhachHang.Enabled = false;
            cmbBienSoXe.Enabled = false;
            cmbID_Xe.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            lsvPhieuKhaoSat.Enabled = true;
        }

        public void openControl()
        {
            txtID_PhieuKhaoSat.Enabled = true;
            txtYeuCau.Enabled = true;
            cmbTenKH.Enabled = true;
            cmbID_KhachHang.Enabled = true;
            cmbBienSoXe.Enabled = true;
            cmbID_Xe.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            lsvPhieuKhaoSat.Enabled = false;
        }

        public void clearControl()
        {
            string query = "select count(ID_PhieuKhaoSat) from PHIEUKHAOSAT";
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            int count = int.Parse(sqlConn.execScanler(query));
            txtID_PhieuKhaoSat.Text = "PKS" + (count + 1).ToString();
            txtYeuCau.ResetText();
            cmbID_KhachHang.ResetText();
            cmbTenKH.ResetText();
            cmbID_Xe.ResetText();
            cmbBienSoXe.ResetText();
        }

        public void addList(SqlDataReader dr)
        {
            ListViewItem item = new ListViewItem();
            item.Text = dr["ID_PhieuKhaoSat"].ToString();
            item.SubItems.Add(dr["HoTen"].ToString());
            item.SubItems.Add(dr["BienSoXe"].ToString());
            item.SubItems.Add(dr["YeuCau"].ToString());
            lsvPhieuKhaoSat.Items.Add(item);
        }

        public void clearLsvPhieuKhaoSat()
        {
            lsvPhieuKhaoSat.Items.Clear();
        }

        public void showLsvPhieuKhaoSat()
        {
            clearLsvPhieuKhaoSat();
            string query = "select pks.ID_PhieuKhaoSat, kh.HoTen, xe.BienSoXe, pks.YeuCau from PHIEUKHAOSAT pks, KHACHHANG kh, THONGTINXE xe where pks.ID_KhachHang = kh.ID_KhachHang and pks.ID_Xe = xe.ID_Xe";
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
            SqlDataReader kh = sqlConn.getDataTable("KHACHHANG");
            while (kh.Read())
            {
                cmbID_KhachHang.Items.Add(kh["ID_KhachHang"].ToString());
                cmbTenKH.Items.Add(kh["HoTen"].ToString());
            }
            sqlConn.closeConnection();
            SqlDataReader xe = sqlConn.getDataTable("THONGTINXE");
            while (xe.Read())
            {
                cmbID_Xe.Items.Add(xe["ID_Xe"].ToString());
                cmbBienSoXe.Items.Add(xe["BienSoXe"].ToString());
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
            txtID_PhieuKhaoSat.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            kt = false;
            openControl();
            txtID_PhieuKhaoSat.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            //txtMaPKS.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                ENTITY.PhieuKhaoSat p = new ENTITY.PhieuKhaoSat();
                p.ID_PhieuKhaoSat = txtID_PhieuKhaoSat.Text.Trim();
                DAL.PhieuKhaoSat_Model k = new DAL.PhieuKhaoSat_Model();
                k.deletePhieuKhaoSat(p);
            }
            showLsvPhieuKhaoSat();
            clearControl();
            lockControl();
        }

        private void savePKS()
        {
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ENTITY.PhieuKhaoSat pks = new ENTITY.PhieuKhaoSat();
            pks.ID_PhieuKhaoSat = txtID_PhieuKhaoSat.Text.Trim();
            pks.ID_KhachHang = cmbID_KhachHang.Text.Trim();
            pks.ID_Xe = cmbID_Xe.Text.Trim();
            pks.YeuCau = txtYeuCau.Text.Trim();
            DAL.PhieuKhaoSat_Model p = new DAL.PhieuKhaoSat_Model();
            if (kt == true)
            {
                p.insertPhieuKhaoSat(pks);
            }
            else
            {
                p.editPhieuKhaoSat(pks);
            }
            showLsvPhieuKhaoSat();
            clearControl();
            lockControl();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            lockControl();
            clearControl();
        }

        private void lsvPhieuKhaoSat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvPhieuKhaoSat.SelectedItems.Count > 0)
            {
                txtID_PhieuKhaoSat.Text = lsvPhieuKhaoSat.SelectedItems[0].SubItems[0].Text;
                cmbTenKH.Text = lsvPhieuKhaoSat.SelectedItems[0].SubItems[1].Text;
                cmbBienSoXe.Text = lsvPhieuKhaoSat.SelectedItems[0].SubItems[2].Text;
                txtYeuCau.Text = lsvPhieuKhaoSat.SelectedItems[0].SubItems[3].Text;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                clearLsvPhieuKhaoSat();
                DAL.PhieuKhaoSat_Model p = new DAL.PhieuKhaoSat_Model();
                SqlDataReader dr = p.searchPhieuKhaoSat(cmbTimKiem.Text.Trim(), cmbValue.Text.Trim());
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
            showLsvPhieuKhaoSat();
        }

        private void loadTenKH()
        {
            string query = "select HoTen from KHACHHANG";
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.execCommand(query);
            while (dr.Read())
            {
                cmbValue.Items.Add(dr["HoTen"].ToString());
            }
        }

        private void loadBienSoXe()
        {
            string query = "select BienSoXe from THONGTINXE";
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.execCommand(query);
            while (dr.Read())
            {
                cmbValue.Items.Add(dr["BienSoXe"].ToString());
            }
        }

        private void cmbTimKiem_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbValue.Items.Clear();
            int key = cmbTimKiem.SelectedIndex;
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("PHIEUKHAOSAT");
            if (key == 0)
            {
                while (dr.Read())
                {
                    cmbValue.Items.Add(dr["ID_PhieuKhaoSat"].ToString());
                }
            }
            else if (key == 1)
            {
                loadTenKH();
            }
            else if (key == 2)
            {
                loadBienSoXe();
            }
            else
            {
                while (dr.Read())
                {
                    cmbValue.Items.Add(dr["YeuCau"].ToString());
                }
            }
        }

        private void cmbTenKH_TextChanged(object sender, EventArgs e)
        {
            string key = cmbTenKH.Text.Trim();
            cmbID_KhachHang.ResetText();
            string query = "select ID_KhachHang from KHACHHANG where HoTen like '" + key + "%'";
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            string value = sqlConn.execScanler(query);
            cmbID_KhachHang.Text = value;
            //SqlDataReader dr = sqlConn.execCommand(query);
            //while (dr.Read())
            //{
            //    cmbID_KhachHang.Text += dr["ID_KhachHang"].ToString();
            //}
            //sqlConn.closeConnection();
        }

        private void cmbID_KhachHang_TextChanged(object sender, EventArgs e)
        {
            string key = cmbID_KhachHang.Text.Trim();
            string query = "select HoTen from KHACHHANG where ID_KhachHang like '" + key + "%'";
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            string value = sqlConn.execScanler(query);
            cmbTenKH.Text = value;
        }

        private void cmbBienSoXe_TextChanged(object sender, EventArgs e)
        {
            string key = cmbBienSoXe.Text.Trim();
            string query = "select ID_Xe from THONGTINXE where BienSoXe like '" + key + "%'";
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            string value = sqlConn.execScanler(query);
            cmbID_Xe.Text = value;
        }

        private void cmbID_Xe_TextChanged(object sender, EventArgs e)
        {
            string key = cmbID_Xe.Text.Trim();
            string query = "select BienSoXe from THONGTINXE where ID_Xe like '" + key + "%'";
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            string value = sqlConn.execScanler(query);
            cmbBienSoXe.Text = value;
        }
    }
}
