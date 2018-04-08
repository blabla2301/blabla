using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyGara.GUI
{
    public partial class frmQuanLyNguoiDung : Form
    {
        bool kt;
        public frmQuanLyNguoiDung()
        {
            InitializeComponent();
        }

        private void frmQuanLyNguoiDung_Load(object sender, EventArgs e)
        {
            lockControlNguoiDung();
            lockControlQuyen();
            loadCombobox();
            showLsvNguoiDung();
            showLsvQuyenHan();
            DAL.NguoiDung_Model nd = new DAL.NguoiDung_Model();
            nd.checkPermission(btnThem, btnSua, btnXoa);
        }

        public void lockControlNguoiDung()
        {
            txtTaiKhoan.Enabled = false;
            txtMatKhau.Enabled = false;
            cmbID_QuyenHan.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            lsvNguoiDung.Enabled = true;
        }

        public void lockControlQuyen()
        {
            txtID_QuyenHan.Enabled = false;
            ckbAdmin.Enabled = false;
            ckbSua.Enabled = false;
            ckbThem.Enabled = false;
            ckbXoa.Enabled = false;
            btThem.Enabled = true;
            btSua.Enabled = false;
            btXoa.Enabled = false;
            btLuu.Enabled = false;
            btHuy.Enabled = false;
            lsvQuyenHan.Enabled = true;
        }

        public void openControlNguoiDung()
        {
            txtTaiKhoan.Enabled = true;
            txtMatKhau.Enabled = true;
            cmbID_QuyenHan.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            lsvNguoiDung.Enabled = false;
        }

        public void openControlQuyen()
        {
            txtID_QuyenHan.Enabled = true;
            ckbAdmin.Enabled = true;
            ckbSua.Enabled = true;
            ckbThem.Enabled = true;
            ckbXoa.Enabled = true;
            btSua.Enabled = true;
            btXoa.Enabled = true;
            btLuu.Enabled = true;
            btHuy.Enabled = true;
            lsvQuyenHan.Enabled = false;
        }

        public void clearControl()
        {
            txtTaiKhoan.ResetText();
            txtMatKhau.ResetText();
            txtID_QuyenHan.ResetText();
            ckbAdmin.Checked = false;
            ckbSua.Checked = false;
            ckbThem.Checked = false;
            ckbXoa.Checked = false;
        }

        public void showLsvNguoiDung()
        {
            clearLsvNguoiDung();
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("NGUOIDUNG");
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr["TaiKhoan"].ToString();
                item.SubItems.Add(dr["MatKhau"].ToString());
                item.SubItems.Add(dr["ID_QuyenHan"].ToString());
                lsvNguoiDung.Items.Add(item);
            }
        }

        public void clearLsvNguoiDung()
        {
            foreach (ListViewItem item in lsvNguoiDung.Items)
            {
                item.Remove();
            }
        }

        public void showLsvQuyenHan()
        {
            clearLsvQuyen();
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("QUYENHAN");
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr["ID_QuyenHan"].ToString();
                item.SubItems.Add(dr["Them"].ToString());
                item.SubItems.Add(dr["Sua"].ToString());
                item.SubItems.Add(dr["Xoa"].ToString());
                item.SubItems.Add(dr["Ad"].ToString());
                lsvQuyenHan.Items.Add(item);
            }
        }
        public void clearLsvQuyen()
        {
            foreach (ListViewItem item in lsvQuyenHan.Items)
            {
                item.Remove();
            }
        }

        public void removeCombobox()
        {
            cmbID_QuyenHan.Items.Clear();
        }

        public void loadCombobox()
        {
            removeCombobox();
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("QUYENHAN");
            while (dr.Read())
            {
                cmbID_QuyenHan.Items.Add(dr["ID_QuyenHan"].ToString());
            }
            cmbID_QuyenHan.SelectedIndex = 1;
            //cbbTimKiem.SelectedIndex = 0;
            //cmbTimKiem.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            kt = true;
            openControlNguoiDung();
            clearControl();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtTaiKhoan.Focus();
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            kt = false;
            openControlNguoiDung();
            txtTaiKhoan.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            //txtTaiKhoan.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                ENTITY.NguoiDung nd = new ENTITY.NguoiDung();
                nd.TaiKhoan = txtTaiKhoan.Text;
                DAL.NguoiDung_Model user = new DAL.NguoiDung_Model();
                user.deleteNguoiDung(nd);
                showLsvNguoiDung();
            }
            lockControlNguoiDung();
            clearControl();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ENTITY.NguoiDung nd = new ENTITY.NguoiDung();
            nd.TaiKhoan = txtTaiKhoan.Text;
            nd.MatKhau = txtMatKhau.Text;
            nd.ID_QuyenHan = cmbID_QuyenHan.Text;
            if (kt == true)
            {
                DAL.NguoiDung_Model user = new DAL.NguoiDung_Model();
                user.insertNguoiDung(nd);
                showLsvNguoiDung();
            }
            else
            {
                DAL.NguoiDung_Model user = new DAL.NguoiDung_Model();
                user.editNguoiDung(nd);
                showLsvNguoiDung();
            }
            lockControlNguoiDung();
            clearControl();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            lockControlNguoiDung();
            clearControl();
        }

        private void lsvNguoiDung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvNguoiDung.SelectedItems.Count > 0)
            {
                txtTaiKhoan.Text = lsvNguoiDung.SelectedItems[0].SubItems[0].Text;
                txtMatKhau.Text = lsvNguoiDung.SelectedItems[0].SubItems[1].Text;
                cmbID_QuyenHan.Text = lsvNguoiDung.SelectedItems[0].SubItems[2].Text;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            kt = true;
            openControlQuyen();
            clearControl();
            btSua.Enabled = false;
            btXoa.Enabled = false;
            txtID_QuyenHan.Focus();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            kt = false;
            openControlQuyen();
            txtID_QuyenHan.Enabled = false;
            btThem.Enabled = false;
            btXoa.Enabled = false;
            //txtMaQuyen.Focus();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                ENTITY.QuyenHan qh = new ENTITY.QuyenHan();
                qh.ID_QuyenHan = txtID_QuyenHan.Text;
                DAL.QuyenHan_Model q = new DAL.QuyenHan_Model();
                q.deleteQuyen(qh);
            }
            showLsvQuyenHan();
            loadCombobox();
            lockControlQuyen();
            clearControl();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            ENTITY.QuyenHan qh = new ENTITY.QuyenHan();
            qh.ID_QuyenHan = txtID_QuyenHan.Text;
            qh.Them = ckbThem.Checked ? true : false;
            qh.Sua = ckbSua.Checked ? true : false;
            qh.Xoa = ckbXoa.Checked ? true : false;
            qh.Admin = ckbAdmin.Checked ? true : false;
            if (kt == true)
            {
                DAL.QuyenHan_Model q = new DAL.QuyenHan_Model();
                q.insertQuyen(qh);
                showLsvQuyenHan();
            }
            else
            {
                DAL.QuyenHan_Model q = new DAL.QuyenHan_Model();
                q.editQuyen(qh);
                showLsvQuyenHan();
            }
            loadCombobox();
            lockControlQuyen();
            clearControl();
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            lockControlQuyen();
            clearControl();
        }

        private void lsvQuyenHan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvQuyenHan.SelectedItems.Count > 0)
            {
                txtID_QuyenHan.Text = lsvQuyenHan.SelectedItems[0].SubItems[0].Text;
                ckbThem.Checked = lsvQuyenHan.SelectedItems[0].SubItems[1].Text.Equals("True") ? true : false;
                ckbSua.Checked = lsvQuyenHan.SelectedItems[0].SubItems[2].Text.Equals("True") ? true : false;
                ckbXoa.Checked = lsvQuyenHan.SelectedItems[0].SubItems[3].Text.Equals("True") ? true : false;
                ckbAdmin.Checked = lsvQuyenHan.SelectedItems[0].SubItems[4].Text.Equals("True") ? true : false;

                btSua.Enabled = true;
                btXoa.Enabled = true;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                clearLsvNguoiDung();
                DAL.NguoiDung_Model nd = new DAL.NguoiDung_Model();
                SqlDataReader dr = nd.searchNguoiDung(cmbTimKiem.Text.Trim(), cmbValue.Text.Trim());
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dr["TaiKhoan"].ToString();
                    item.SubItems.Add(dr["MatKhau"].ToString());
                    item.SubItems.Add(dr["ID_QuyenHan"].ToString());
                    lsvNguoiDung.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            showLsvNguoiDung();
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                clearLsvQuyen();
                DAL.QuyenHan_Model q = new DAL.QuyenHan_Model();
                SqlDataReader dr = q.searchQuyen(cbbValue.Text.Trim());
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dr["ID_QuyenHan"].ToString();
                    item.SubItems.Add(dr["Them"].ToString());
                    item.SubItems.Add(dr["Sua"].ToString());
                    item.SubItems.Add(dr["Xoa"].ToString());
                    item.SubItems.Add(dr["Ad"].ToString());
                    lsvQuyenHan.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showLsvQuyenHan();
        }

        private void cmbTimKiem_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbValue.Items.Clear();
            int key = cmbTimKiem.SelectedIndex;
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("NGUOIDUNG");
            while (dr.Read())
            {
                if (key == 0)
                {
                    cmbValue.Items.Add(dr["ID_QuyenHan"].ToString());
                }
                else
                {
                    cmbValue.Items.Add(dr["TaiKhoan"].ToString());
                }
            }
        }

        private void cbbTimKiem_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbbValue.Items.Clear();
            int key = cbbTimKiem.SelectedIndex;
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("QUYENHAN");
            while (dr.Read())
            {
                if (key == 0)
                {
                    cbbValue.Items.Add(dr["ID_QuyenHan"].ToString());
                }
            }
        }
    }
}
