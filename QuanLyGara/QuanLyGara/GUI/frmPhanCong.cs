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
    public partial class frmPhanCong : Form
    {
        bool kt;
        public frmPhanCong()
        {
            InitializeComponent();
        }

        private void frmPhanCong_Load(object sender, EventArgs e)
        {
            lockControl();
            loadCombobox();
            showLsvPhanCong();
            DAL.NguoiDung_Model nd = new DAL.NguoiDung_Model();
            nd.checkPermission(btnThem, btnSua, btnXoa);
        }

        public void lockControl()
        {
            txtID_PhanCong.Enabled = false;
            cmbID_LenhSuaChua.Enabled = false;
            cmbID_NhanVien.Enabled = false;
            dtNgayBD.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            lsvPhanCong.Enabled = true;
        }

        public void openControl()
        {
            txtID_PhanCong.Enabled = true;
            cmbID_LenhSuaChua.Enabled = true;
            cmbID_NhanVien.Enabled = true;
            dtNgayBD.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            lsvPhanCong.Enabled = false;
        }

        public void clearControl()
        {
            string query = "select count(ID_PhanCong) from PHANCONG";
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            int count = int.Parse(sqlConn.execScanler(query));
            txtID_PhanCong.Text = "PC" + (count + 1).ToString();
            cmbID_LenhSuaChua.ResetText();
            cmbID_NhanVien.ResetText();
            dtNgayBD.Value = DateTime.Now;
        }

        public void loadCombobox()
        {
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader lsc = sqlConn.getDataTable("LENHSUACHUA");
            while (lsc.Read())
            {
                cmbID_LenhSuaChua.Items.Add(lsc["ID_LenhSuaChua"].ToString());
            }
            sqlConn.closeConnection();
            SqlDataReader nv = sqlConn.getDataTable("NHANVIEN");
            while (nv.Read())
            {
                cmbID_NhanVien.Items.Add(nv["ID_NhanVien"].ToString());
                cmbTenNV.Items.Add(nv["HoTen"].ToString());
            }
            //cmbTimKiem.SelectedIndex = 0;
        }

        public void addList(SqlDataReader dr)
        {
            ListViewItem item = new ListViewItem();
            item.Text = dr["ID_PhanCong"].ToString();
            item.SubItems.Add(dr["ID_LenhSuaChua"].ToString());
            item.SubItems.Add(dr["ID_NhanVien"].ToString());
            item.SubItems.Add(formatDate(dr["NgayBatDau"].ToString()));
            lsvPhanCong.Items.Add(item);
        }

        private string formatDate(string dt)
        {
            DateTime datetime = DateTime.Parse(dt);
            string date = datetime.ToString("yyyy/MM/dd");
            return date;
        }

        public void clearLsvPhanCong()
        {
            lsvPhanCong.Items.Clear();
        }

        public void showLsvPhanCong()
        {
            clearLsvPhanCong();
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("PHANCONG");
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
            txtID_PhanCong.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            kt = false;
            openControl();
            txtID_PhanCong.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            cmbID_LenhSuaChua.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                ENTITY.PhanCong pc = new ENTITY.PhanCong();
                pc.ID_PhanCong = txtID_PhanCong.Text.Trim();
                DAL.PhanCong_Model p = new DAL.PhanCong_Model();
                p.deletePhanCong(pc);
            }
            showLsvPhanCong();
            lockControl();
            clearControl();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ENTITY.PhanCong p = new ENTITY.PhanCong();
            p.ID_PhanCong = txtID_PhanCong.Text.Trim();
            p.ID_LenhSuaChua = cmbID_LenhSuaChua.Text.Trim();
            p.ID_NhanVien = cmbID_NhanVien.Text.Trim();
            p.NgayBD = dtNgayBD.Value.ToShortDateString();
            DAL.PhanCong_Model pc = new DAL.PhanCong_Model();
            if (kt == true)
            {
                pc.insertPhanCong(p);
            }
            else
            {
                pc.editPhanCong(p);
            }
            showLsvPhanCong();
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
                clearLsvPhanCong();
                DAL.PhanCong_Model p = new DAL.PhanCong_Model();
                SqlDataReader dr = p.searchPhanCong(cmbTimKiem.Text.Trim(), cmbValue.Text.Trim());
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
            showLsvPhanCong();
        }

        private void lsvPhanCong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvPhanCong.SelectedItems.Count > 0)
            {
                txtID_PhanCong.Text = lsvPhanCong.SelectedItems[0].SubItems[0].Text;
                cmbID_LenhSuaChua.Text = lsvPhanCong.SelectedItems[0].SubItems[1].Text;
                cmbID_NhanVien.Text = lsvPhanCong.SelectedItems[0].SubItems[2].Text;
                dtNgayBD.Text = lsvPhanCong.SelectedItems[0].SubItems[3].Text;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }



        private void cmbTimKiem_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbValue.Items.Clear();
            int key = cmbTimKiem.SelectedIndex;
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("PHANCONG");
            while (dr.Read())
            {
                if (key == 0)
                {
                    cmbValue.Items.Add(dr["ID_PhanCong"].ToString());
                }
                else if (key == 1)
                {
                    cmbValue.Items.Add(dr["ID_LenhSuaChua"].ToString());
                }
                else
                {
                    cmbValue.Items.Add(dr["ID_NhanVien"].ToString());
                }
            }
        }

        private void cmbID_NhanVien_TextChanged(object sender, EventArgs e)
        {
            string key = cmbID_NhanVien.Text.Trim();
            string query = "select HoTen from NHANVIEN where ID_NhanVien like '" + key + "%'";
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            string value = sqlConn.execScanler(query);
            cmbTenNV.Text = value;
        }

    }
}
