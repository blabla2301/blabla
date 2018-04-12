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
    public partial class frmKhachHang : Form
    {
        bool kt;
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            lockControl();
            loadCombobox();
            showLsvKhachHang();
            DAL.NguoiDung_Model nd = new DAL.NguoiDung_Model();
            nd.checkPermission(btnThem, btnSua, btnXoa);
        }

        public void lockControl()
        {
            txtID_KhachHang.Enabled = false;
            txtHoTen.Enabled = false;
            txtSDT.Enabled = false;
            txtEmail.Enabled = false;
            txtDiaChi.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            lsvKhachHang.Enabled = true;
        }

        public void openControl()
        {
            txtID_KhachHang.Enabled = true;
            txtHoTen.Enabled = true;
            txtSDT.Enabled = true;
            txtEmail.Enabled = true;
            txtDiaChi.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            lsvKhachHang.Enabled = false;
        }

        public void loadCombobox()
        {
            //cmbTimKiem.SelectedIndex = 0;
        }

        public void showLsvKhachHang()
        {
            clearLsvKhachHang();
            DAL.sqlConnect conn = new DAL.sqlConnect();
            SqlDataReader dr = conn.getDataTable("KHACHHANG");
            while (dr.Read())
            {
                addList(dr);
            }
        }

        public void addList(SqlDataReader dr)
        {
            ListViewItem item = new ListViewItem();
            item.Text = dr["ID_KhachHang"].ToString();
            item.SubItems.Add(dr["HoTen"].ToString());
            item.SubItems.Add(dr["SDT"].ToString());
            item.SubItems.Add(dr["Email"].ToString());
            item.SubItems.Add(dr["DiaChi"].ToString());
            lsvKhachHang.Items.Add(item);
        }

        public void clearLsvKhachHang()
        {
            lsvKhachHang.Items.Clear();
        }

        public void clearControl()
        {
            string query = "select count(ID_KhachHang) from KHACHHANG";
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            int count = int.Parse(sqlConn.execScanler(query));
            txtID_KhachHang.Text = "KH" + (count + 1).ToString();
            txtHoTen.ResetText();
            txtSDT.ResetText();
            txtEmail.ResetText();
            txtDiaChi.ResetText();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            kt = true;
            openControl();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            clearControl();
            txtID_KhachHang.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            kt = false;
            openControl();
            txtID_KhachHang.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            txtHoTen.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                ENTITY.KhachHang kh = new ENTITY.KhachHang();
                kh.ID_KhachHang = txtID_KhachHang.Text.Trim();
                DAL.KhachHang_Model k = new DAL.KhachHang_Model();
                k.deleteKHACHHANG(kh);
            }
            showLsvKhachHang();
            lockControl();
            clearControl();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ENTITY.KhachHang kh = new ENTITY.KhachHang();
            kh.ID_KhachHang = txtID_KhachHang.Text.Trim();
            kh.HoTen = txtHoTen.Text.Trim();
            kh.SDT = txtSDT.Text.Trim();
            kh.Email = txtEmail.Text.Trim();
            kh.DiaChi = txtDiaChi.Text.Trim();
            DAL.KhachHang_Model k = new DAL.KhachHang_Model();
            if (kt == true)
            {
                k.insertKHACHHANG(kh);
            }
            else
            {
                k.editKHACHHANG(kh);
            }
            showLsvKhachHang();
            lockControl();
            clearControl();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            lockControl();
            clearControl();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string name = cmbTimKiem.Text.Trim();
            string value = cmbValue.Text.Trim();
            try
            {
                clearLsvKhachHang();
                DAL.KhachHang_Model kh = new DAL.KhachHang_Model();
                SqlDataReader dr = kh.searchKHACHHANG(name, value);
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
            showLsvKhachHang();
        }

        private void lsvKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvKhachHang.SelectedItems.Count > 0)
            {
                txtID_KhachHang.Text = lsvKhachHang.SelectedItems[0].SubItems[0].Text;
                txtHoTen.Text = lsvKhachHang.SelectedItems[0].SubItems[1].Text;
                txtSDT.Text = lsvKhachHang.SelectedItems[0].SubItems[2].Text;
                txtEmail.Text = lsvKhachHang.SelectedItems[0].SubItems[3].Text;
                txtDiaChi.Text = lsvKhachHang.SelectedItems[0].SubItems[4].Text;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void cmbTimKiem_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbValue.Items.Clear();
            int key = cmbTimKiem.SelectedIndex;
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("KHACHHANG");
            while (dr.Read())
            {
                if (key == 0)
                {
                    cmbValue.Items.Add(dr["ID_KhachHang"].ToString());
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
                    cmbValue.Items.Add(dr["Email"].ToString());
                }
                else
                {
                    cmbValue.Items.Add(dr["DiaChi"].ToString());
                }
            }
        }


    }
}
