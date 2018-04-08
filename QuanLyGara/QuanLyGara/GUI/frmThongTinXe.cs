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
    public partial class frmThongTinXe : Form
    {
        bool kt;
        public frmThongTinXe()
        {
            InitializeComponent();
        }

        private void frmThongTinXe_Load(object sender, EventArgs e)
        {
            showLsvThongTinXe();
            loadCombobox();
            lockControl();
            DAL.NguoiDung_Model nd = new DAL.NguoiDung_Model();
            nd.checkPermission(btnThem, btnSua, btnXoa);
        }

        public void lockControl()
        {
            txtID_Xe.Enabled = false;
            cmbID_HangXe.Enabled = false;
            cmbHangXe.Enabled = false;
            txtBienSoXe.Enabled = false;
            txtDoiXe.Enabled = false;
            txtSoKhung.Enabled = false;
            txtSoMay.Enabled = false;
            txtSoKM.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            lsvThongTinXe.Enabled = true;
        }

        public void openControl()
        {
            txtID_Xe.Enabled = true;
            cmbID_HangXe.Enabled = true;
            cmbHangXe.Enabled = true;
            txtBienSoXe.Enabled = true;
            txtDoiXe.Enabled = true;
            txtSoKhung.Enabled = true;
            txtSoMay.Enabled = true;
            txtSoKM.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            lsvThongTinXe.Enabled = false;
        }

        public void loadCombobox()
        {
            //cmbTimKiem.SelectedIndex = 0;
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("HangXe");
            while (dr.Read())
            {
                cmbID_HangXe.Items.Add(dr["ID_HangXe"].ToString());
                cmbHangXe.Items.Add(dr["HangXe"].ToString());
            }
            //cmbHangXe.SelectedItem = "Audi";
            
        }

        public void clearControl()
        {
            string query = "select count(ID_Xe) from THONGTINXE";
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            int count = int.Parse(sqlConn.execScanler(query));
            txtID_Xe.Text = "X" + (count + 1).ToString();
            cmbID_HangXe.ResetText();
            cmbHangXe.ResetText();
            txtBienSoXe.ResetText();
            txtDoiXe.ResetText();
            txtSoKhung.ResetText();
            txtSoMay.ResetText();
            txtSoKM.ResetText();
        }

        public void addList(SqlDataReader dr)
        {
            ListViewItem item = new ListViewItem();
            item.Text = dr["ID_Xe"].ToString();
            item.SubItems.Add(dr["HangXe"].ToString());
            item.SubItems.Add(dr["BienSoXe"].ToString());
            item.SubItems.Add(dr["DoiXe"].ToString());
            item.SubItems.Add(dr["SoKhung"].ToString());
            item.SubItems.Add(dr["SoMay"].ToString());
            item.SubItems.Add(dr["SoKM"].ToString());
            lsvThongTinXe.Items.Add(item);

        }

        public void showLsvThongTinXe()
        {
            clearLsvThongTinXe();
            string query = "select xe.ID_Xe, h.HangXe, xe.BienSoXe, xe.DoiXe, xe.SoKhung, xe.SoMay, xe.SoKM from THONGTINXE xe, HANGXE h where xe.ID_HangXe = h.ID_HangXe";
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.execCommand(query);
            while (dr.Read())
            {
                addList(dr);
            }
        }

        public void clearLsvThongTinXe()
        {
            lsvThongTinXe.Items.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            kt = true;
            openControl();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            clearControl();
            txtID_Xe.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            kt = false;
            openControl();
            txtID_Xe.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                ENTITY.Xe xe = new ENTITY.Xe();
                xe.ID_Xe = txtID_Xe.Text.Trim();
                DAL.Xe_Model x = new DAL.Xe_Model();
                x.deleteXe(xe);
            }
            showLsvThongTinXe();
            lockControl();
            clearControl();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ENTITY.Xe xe = new ENTITY.Xe();
            xe.ID_Xe = txtID_Xe.Text.Trim();
            xe.ID_HangXe = cmbID_HangXe.Text.Trim();
            xe.BienSoXe = txtBienSoXe.Text.Trim();
            xe.DoiXe = txtDoiXe.Text.Trim();
            xe.SoKhung = txtSoKhung.Text.Trim();
            xe.SoMay = txtSoMay.Text.Trim();
            xe.SoKM = txtSoKM.Text.Trim();
            DAL.Xe_Model x = new DAL.Xe_Model();
            if(kt == true)
            {
                x.insertXe(xe);
            }
            else
            {
                x.editXe(xe);
            }
            showLsvThongTinXe();
            clearControl();
            lockControl();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            lockControl();
            clearControl();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                clearLsvThongTinXe();
                DAL.Xe_Model x = new DAL.Xe_Model();
                SqlDataReader dr = x.searchXe(cmbTimKiem.Text.Trim(), cmbValue.Text.Trim());
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
            showLsvThongTinXe();
        }

        private void lsvThongTinXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvThongTinXe.SelectedItems.Count > 0)
            {
                txtID_Xe.Text = lsvThongTinXe.SelectedItems[0].SubItems[0].Text;
                cmbHangXe.Text = lsvThongTinXe.SelectedItems[0].SubItems[1].Text;
                txtBienSoXe.Text = lsvThongTinXe.SelectedItems[0].SubItems[2].Text;
                txtDoiXe.Text = lsvThongTinXe.SelectedItems[0].SubItems[3].Text;
                txtSoKhung.Text = lsvThongTinXe.SelectedItems[0].SubItems[4].Text;
                txtSoMay.Text = lsvThongTinXe.SelectedItems[0].SubItems[5].Text;
                txtSoKM.Text = lsvThongTinXe.SelectedItems[0].SubItems[6].Text;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void loadHangXe()
        {
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("HANGXE");
            while (dr.Read())
            {
                cmbValue.Items.Add(dr["HangXe"].ToString());
            }  
        }

        private void cmbTimKiem_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbValue.Items.Clear();
            cmbValue.ResetText();
            int key = cmbTimKiem.SelectedIndex;
            string query = "select xe.ID_Xe, h.HangXe, xe.BienSoXe, xe.DoiXe, xe.SoKhung, xe.SoMay, xe.SoKM from THONGTINXE xe, HANGXE h where xe.ID_HangXe = h.ID_HangXe";
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.execCommand(query);
            if (key == 0)
            {
                while (dr.Read())
                {
                    cmbValue.Items.Add(dr["ID_Xe"].ToString());
                }
            }
            else if (key == 1)
            {
                //cmbValue.Items.Add(dr["HangXe"].ToString());
                loadHangXe();
            }
            else if (key == 2)
            {
                while (dr.Read())
                {
                    cmbValue.Items.Add(dr["BienSoXe"].ToString());
                }
            }
            else if (key == 3)
            {
                while (dr.Read())
                {
                    cmbValue.Items.Add(dr["DoiXe"].ToString());
                }
            }
            else if(key == 4)
            {
                while (dr.Read())
                {
                    cmbValue.Items.Add(dr["SoKhung"].ToString());
                }
            }
            else if(key == 5)
            {
                while (dr.Read())
                {
                    cmbValue.Items.Add(dr["SoMay"].ToString());
                }
            }
            else
            {
                while (dr.Read())
                {
                    cmbValue.Items.Add(dr["SoKM"].ToString());
                }
            }
        }

        private void cmbHangXe_TextChanged(object sender, EventArgs e)
        {
            string key = cmbHangXe.Text;
            string query = "select ID_HangXe from HANGXE where HangXe like '" + key + "%'";
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            string value = sqlConn.execScanler(query);
            cmbID_HangXe.Text = value;
        }

        private void cmbID_HangXe_TextChanged(object sender, EventArgs e)
        {
            string key = cmbID_HangXe.Text;
            string query = "select HangXe from HANGXE where ID_hangXe like '" + key + "%'";
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            string value = sqlConn.execScanler(query);
            cmbHangXe.Text = value;
        }

    }
}
