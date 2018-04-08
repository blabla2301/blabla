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
using System.Data;

namespace QuanLyGara.GUI
{
    public partial class frmNhanVien : Form
    {
        bool kt;
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            showLsvNhanVien();
            loadCombobox();
            lockControl();
            DAL.NguoiDung_Model nd = new DAL.NguoiDung_Model();
            nd.checkPermission(btnThem, btnSua, btnXoa);
        }

        public void lockControl()
        {
            txtID_NhanVien.Enabled = false;
            txtHoTen.Enabled = false;
            txtSDT.Enabled = false;
            dtNgaySinh.Enabled = false;
            rdbNam.Enabled = false;
            rdbNu.Enabled = false;
            txtDiaChi.Enabled = false;
            cmbTaiKhoan.Enabled = false;
            rdbNam.Checked = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            lsvNhanVien.Enabled = true;
            
        }

        public void openControl()
        {
            txtID_NhanVien.Enabled = true;
            txtHoTen.Enabled = true;
            txtSDT.Enabled = true;
            dtNgaySinh.Enabled = true;
            rdbNam.Enabled = true;
            rdbNu.Enabled = true;
            txtDiaChi.Enabled = true;
            cmbTaiKhoan.Enabled = true;
            rdbNam.Checked = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            lsvNhanVien.Enabled = false;
        }

        public void loadCombobox()
        {
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("NGUOIDUNG");
            while (dr.Read())
            {
                cmbTaiKhoan.Items.Add(dr["TaiKhoan"].ToString());
            }
            //cmbTimKiem.SelectedIndex = 0;
            cmbTaiKhoan.SelectedItem = "read_only";
        }

        public void clearControl()
        {
            string query = "select count(ID_NhanVien) from NHANVIEN";
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            int count = int.Parse(sqlConn.execScanler(query));
            txtID_NhanVien.Text = "NV" + (count + 1).ToString();
            txtHoTen.ResetText();
            txtSDT.ResetText();
            dtNgaySinh.Value = DateTime.Now;
            rdbNam.Checked = true;
            txtDiaChi.ResetText();
            cmbTaiKhoan.SelectedItem = "read_only";
        }

        public void clearLsvNhanVien()
        {
            lsvNhanVien.Items.Clear();
        }

        public string formatDate(string dt)
        {
            DateTime dateTime = DateTime.Parse(dt);
            string date = dateTime.ToString("yyyy/MM/dd");
            return date;
        }

        public void addList(SqlDataReader dr)
        {
            ListViewItem item = new ListViewItem();
            item.Text = dr["ID_NhanVien"].ToString();
            item.SubItems.Add(dr["HoTen"].ToString());
            item.SubItems.Add(dr["SDT"].ToString());
            item.SubItems.Add(formatDate(dr["NgaySinh"].ToString()));
            item.SubItems.Add(dr["GioiTinh"].ToString());
            item.SubItems.Add(dr["DiaChi"].ToString());
            item.SubItems.Add(dr["TaiKhoan"].ToString());
            lsvNhanVien.Items.Add(item);
        }

        public void showLsvNhanVien()
        {
            clearLsvNhanVien();
            DAL.sqlConnect conn = new DAL.sqlConnect();
            SqlDataReader dr = conn.getDataTable("NHANVIEN");
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
            txtID_NhanVien.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            kt = false;
            openControl();
            txtID_NhanVien.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            txtHoTen.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                ENTITY.NhanVien n = new ENTITY.NhanVien();
                n.ID_NhanVien = txtID_NhanVien.Text.Trim();
                DAL.NhanVien_Model nv = new DAL.NhanVien_Model();
                nv.deleteNhanVien(n);
            }
            showLsvNhanVien();
            lockControl();
            clearControl();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ENTITY.NhanVien nv = new ENTITY.NhanVien();
            nv.ID_NhanVien = txtID_NhanVien.Text.Trim();
            nv.HoTen = txtHoTen.Text.Trim();
            nv.SDT = txtSDT.Text.Trim();
            nv.NgaySinh = dtNgaySinh.Value.ToShortDateString();
            if (rdbNam.Checked == true)
            {
                nv.GioiTinh = rdbNam.Text;
            }
            else
            {
                nv.GioiTinh = rdbNu.Text;
            }
            nv.DiaChi = txtDiaChi.Text.Trim();
            nv.TaiKhoan = cmbTaiKhoan.Text.Trim();
            DAL.NhanVien_Model n = new DAL.NhanVien_Model();
            if (kt == true)
            {
                n.insertNhanVien(nv);
            }
            else
            {
                n.editNhanVien(nv);
            }
            showLsvNhanVien();
            lockControl();
            clearControl();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            lockControl();
            clearControl();
        }

        private void lsvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvNhanVien.SelectedItems.Count > 0)
            {
                txtID_NhanVien.Text = lsvNhanVien.SelectedItems[0].SubItems[0].Text;
                txtHoTen.Text = lsvNhanVien.SelectedItems[0].SubItems[1].Text;
                txtSDT.Text = lsvNhanVien.SelectedItems[0].SubItems[2].Text;
                dtNgaySinh.Value = DateTime.Parse(lsvNhanVien.SelectedItems[0].SubItems[3].Text);
                rdbNam.Checked = lsvNhanVien.SelectedItems[0].SubItems[4].Text.Equals("Nam") ? true : false;
                rdbNu.Checked = lsvNhanVien.SelectedItems[0].SubItems[4].Text.Equals("Nam") ? false : true;
                txtDiaChi.Text = lsvNhanVien.SelectedItems[0].SubItems[5].Text;
                cmbTaiKhoan.Text = lsvNhanVien.SelectedItems[0].SubItems[6].Text;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            clearLsvNhanVien();
            DAL.NhanVien_Model nv = new DAL.NhanVien_Model();
            SqlDataReader dr = nv.searchNhanVien(cmbTimKiem.Text.Trim(), cmbValue.Text.Trim());
            while (dr.Read())
            {
                addList(dr);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showLsvNhanVien();
        }

        private void cmbTimKiem_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbValue.Items.Clear();
            int key = cmbTimKiem.SelectedIndex;
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("NHANVIEN");
            while (dr.Read())
            {
                if (key == 0)
                {
                    cmbValue.Items.Add(dr["ID_NhanVien"].ToString());
                }
                else if (key == 1)
                {
                    cmbValue.Items.Add(dr["HoTen"].ToString());
                }
                else if (key == 2)
                {
                    cmbValue.Items.Add(dr["SDT"].ToString());
                }
                else if (key == 3)
                {
                    cmbValue.Items.Add(dr["GioiTinh"].ToString());
                }
                else
                {
                    cmbValue.Items.Add(dr["DiaChi"].ToString());
                }
            }
        }


    }
}
