using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyGara.GUI
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            //int count = 0;
            //string strConn = "Data Source=DESKTOP-DPEU76K;Initial Catalog=QuanLyGara;Integrated Security=True";
            //SqlConnection conn = new SqlConnection(strConn);
            //string query = "select * from NGUOIDUNG where TaiKhoan = '" + txtTaiKhoan.Text + "' and MatKhau = '" + txtMatKhau.Text + "'";
            //SqlCommand cmd = new SqlCommand(query, conn);
            //conn.Open();
            //SqlDataReader dr = cmd.ExecuteReader();

            //while (dr.Read())
            //{
            //    count += 1;
            //}
            //if (count == 1)
            //{
            //    this.Hide();
            //    GUI.frmMain frm = new frmMain();
            //    frm.Show();
            //}

            DAL.NguoiDung_Model nd = new DAL.NguoiDung_Model();
            int check = nd.ckeckLogin(txtTaiKhoan.Text, txtMatKhau.Text);
            if (check == 1)
            {
                DAL.NguoiDung_Model.taikhoan = txtTaiKhoan.Text;
                DAL.NguoiDung_Model.matkhau = txtMatKhau.Text;
                this.Hide();
                GUI.frmMain frm = new frmMain();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Thông tin tài khoản hoặc mật khẩu không chính xác", "Thông báo");
            }
        }
    }
}
