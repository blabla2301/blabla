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
    public partial class frmHoaDonThanhToan : Form
    {
        bool kt;
        public frmHoaDonThanhToan()
        {
            InitializeComponent();
        }

        private void frmHoaDonThanhToan_Load(object sender, EventArgs e)
        {
            lockControl();
            showLsvHD_TT();
            loadCombobox();
            DAL.NguoiDung_Model nd = new DAL.NguoiDung_Model();
            nd.checkPermission(btnThem, btnSua, btnXoa);
        }

        public void lockControl()
        {
            txtMaHD.Enabled = false;
            cmbMaLSC.Enabled = false;
            txtTenHD.Enabled = false;
            txtMaNPT.Enabled = false;
            txtTienDichVu.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            lsvHD_TT.Enabled = true;
        }

        public void openControl()
        {
            txtMaHD.Enabled = true;
            cmbMaLSC.Enabled = true;
            txtTenHD.Enabled = true;
            txtMaNPT.Enabled = true;
            txtTienDichVu.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            lsvHD_TT.Enabled = false;
        }

        public void clearControl()
        {
            txtMaHD.ResetText();
            cmbMaLSC.ResetText();
            txtTenHD.ResetText();
            txtMaNPT.ResetText();
            txtTienDichVu.ResetText();
        }

        public void loadCombobox()
        {
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("LENHSUACHUA");
            while (dr.Read())
            {
                cmbMaLSC.Items.Add(dr["MaLenhSuaChua"].ToString());
            }
            //cmbTimKiem.SelectedIndex = 0;
        }

        public void addList(SqlDataReader dr)
        {
            ListViewItem item = new ListViewItem();
            item.Text = dr["MaHoaDon"].ToString();
            item.SubItems.Add(dr["MaLenhSuaChua"].ToString());
            item.SubItems.Add(dr["TenHoaDon"].ToString());
            item.SubItems.Add(dr["MaNguoiPhuTrach"].ToString());
            item.SubItems.Add(dr["TienDichVu"].ToString());
            item.SubItems.Add(dr["TongTienThanhToan"].ToString());
            lsvHD_TT.Items.Add(item);
        }

        public void clearLsvHD_TT()
        {
            lsvHD_TT.Items.Clear();
        }

        public void showLsvHD_TT()
        {
            clearLsvHD_TT();
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("HOADON_THANHTOAN");
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
            txtMaHD.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            kt = false;
            openControl();
            txtMaHD.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            cmbMaLSC.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                ENTITY.HoaDonThanhToan hd = new ENTITY.HoaDonThanhToan();
                hd.MaHD = txtMaHD.Text.Trim();
                DAL.HoaDonThanhToan_Model h = new DAL.HoaDonThanhToan_Model();
                h.deleteHoaDonThanhToan(hd);
            }
            showLsvHD_TT();
            lockControl();
            clearControl();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ENTITY.HoaDonThanhToan h = new ENTITY.HoaDonThanhToan();
            h.MaHD = txtMaHD.Text.Trim();
            h.MaLSC = cmbMaLSC.Text.Trim();
            h.TenHD = txtTenHD.Text.Trim();
            h.MaNPT = txtMaNPT.Text.Trim();
            h.TienDichVu = txtTienDichVu.Text.Trim();
            DAL.HoaDonThanhToan_Model hd = new DAL.HoaDonThanhToan_Model();
            if (kt==true)
            {
                hd.insertHoaDonThanhToan(h);
            }
            else
            {
                hd.editHoaDonThanhToan(h);
            }
            showLsvHD_TT();
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
                clearLsvHD_TT();
                DAL.HoaDonThanhToan_Model hd = new DAL.HoaDonThanhToan_Model();
                SqlDataReader dr = hd.searchHoaDonThanhToan(cmbTimKiem.Text.Trim(), cmbValue.Text.Trim());
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
            showLsvHD_TT();
        }

        private void lsvHD_TT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvHD_TT.SelectedItems.Count > 0)
            {
                txtMaHD.Text = lsvHD_TT.SelectedItems[0].SubItems[0].Text;
                cmbMaLSC.Text = lsvHD_TT.SelectedItems[0].SubItems[1].Text;
                txtTenHD.Text = lsvHD_TT.SelectedItems[0].SubItems[2].Text;
                txtMaNPT.Text = lsvHD_TT.SelectedItems[0].SubItems[3].Text;
                txtTienDichVu.Text = lsvHD_TT.SelectedItems[0].SubItems[4].Text;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void cmbTimKiem_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbValue.Items.Clear();
            int key = cmbTimKiem.SelectedIndex;
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("HOADON_THANHTOAN");
            if (key == 0)
            {
                while (dr.Read())
                {
                    cmbValue.Items.Add(dr["MaHoaDon"].ToString());
                }
            }
            else if (key == 1)
            {
                while (dr.Read())
                {
                    cmbValue.Items.Add(dr["MaLenhSuaChua"].ToString());
                }
            }
            else if (key == 2)
            {
                while (dr.Read())
                {
                    cmbValue.Items.Add(dr["TenHoaDon"].ToString());
                }
            }
            else
            {
                while (dr.Read())
                {
                    cmbValue.Items.Add(dr["MaNguoiPhuTrach"].ToString());
                }
            }
        }


    }
}
