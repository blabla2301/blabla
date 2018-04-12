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
    public partial class frmHangXe : Form
    {
        bool kt;
        public frmHangXe()
        {
            InitializeComponent();
        }

        private void frmHangXe_Load(object sender, EventArgs e)
        {
            showLsvHangXe();
            lockControl();
            DAL.NguoiDung_Model nd = new DAL.NguoiDung_Model();
            nd.checkPermission(btnThem, btnSua, btnXoa);
        }

        public void lockControl()
        {
            txtID_HangXe.Enabled = false;
            txtTenHangXe.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            lsvHangXe.Enabled = true;
        }

        public void openControl()
        {
            txtID_HangXe.Enabled = true;
            txtTenHangXe.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            lsvHangXe.Enabled = false;
        }

        public void clearControl()
        {
            string query = "select count(ID_HangXe) from HANGXE";
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            int count = int.Parse(sqlConn.execScanler(query));
            txtID_HangXe.Text = "H" + (count + 1).ToString();
            txtTenHangXe.ResetText();
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
            item.Text = dr["ID_HangXe"].ToString();
            item.SubItems.Add(dr["HangXe"].ToString());
            lsvHangXe.Items.Add(item);
        }

        public void clearLsvHangXe()
        {
            lsvHangXe.Items.Clear();
        }

        public void showLsvHangXe()
        {
            clearLsvHangXe();
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("HANGXE");
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
            txtID_HangXe.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            kt = false;
            openControl();
            txtID_HangXe.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                ENTITY.HangXe h = new ENTITY.HangXe();
                h.ID = txtID_HangXe.Text.Trim();
                DAL.HangXe_Model hx = new DAL.HangXe_Model();
                hx.deleteHangXe(h);
            }
            showLsvHangXe();
            lockControl();
            clearControl();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ENTITY.HangXe h = new ENTITY.HangXe();
            h.ID = txtID_HangXe.Text.Trim();
            h.TenHangXe = txtTenHangXe.Text.Trim();
            DAL.HangXe_Model hx = new DAL.HangXe_Model();
            if (kt == true)
            {
                hx.insertHangXe(h);
            }
            else
            {
                hx.editHangXe(h);
            }
            showLsvHangXe();
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
                clearLsvHangXe();
                DAL.HangXe_Model h = new DAL.HangXe_Model();
                SqlDataReader dr = h.searchHangXe(cmbTimKiem.Text.Trim(), cmbValue.Text.Trim());
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
            showLsvHangXe();
        }

        private void lsvHangXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvHangXe.SelectedItems.Count > 0)
            {
                txtID_HangXe.Text = lsvHangXe.SelectedItems[0].SubItems[0].Text;
                txtTenHangXe.Text = lsvHangXe.SelectedItems[0].SubItems[1].Text;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void cmbTimKiem_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbValue.Items.Clear();
            int key = cmbTimKiem.SelectedIndex;
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = sqlConn.getDataTable("HANGXE");
            while (dr.Read())
            {
                if (key == 0)
                {
                    cmbValue.Items.Add(dr["ID_HangXe"].ToString());
                }
                else
                {
                    cmbValue.Items.Add(dr["HangXe"].ToString());
                }
            }
        }
    }
}
