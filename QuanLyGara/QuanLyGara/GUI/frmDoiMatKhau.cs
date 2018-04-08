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
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (DAL.NguoiDung_Model.matkhau.Equals(txtMKCu.Text.Trim()))
            {
                if (txtXacNhan.Text.Trim().Equals(txtMKMoi.Text.Trim()))
                {
                    string TaiKhoan = DAL.NguoiDung_Model.taikhoan;
                    string MatKhau = txtMKMoi.Text.Trim();
                    string query = "update NGUOIDUNG set MatKhau = '" + MatKhau + "' where TaiKhoan = '" + TaiKhoan + "'";
                    DAL.sqlConnect sqlConn = new DAL.sqlConnect();
                    try
                    {
                        sqlConn.openConnection();
                        SqlCommand cmd = new SqlCommand(query, sqlConn.Conn);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        DAL.NguoiDung_Model.matkhau = MatKhau;
                        sqlConn.closeConnection();
                    }
                    MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mật khâu không khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMKCu.Focus();
            }
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {

        }

    }
}
