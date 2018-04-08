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
    public partial class frmChiTietNguoiDung : Form
    {
        public frmChiTietNguoiDung()
        {
            InitializeComponent();
        }

        private void frmChiTietNguoiDung_Load(object sender, EventArgs e)
        {
            loadCombobox();
            showList();
        }

        public void loadCombobox()
        {
            //cmbTimKiem.SelectedIndex = 0;
        }

        public void showList()
        {
            clearList();
            string query = "select nv.MaNV, nv.HoTen, nd.TaiKhoan, nd.MatKhau, q.MaQuyen, Them, Sua, Xoa, Ad from NHANVIEN nv, NGUOIDUNG nd, QUYENHAN q where nv.TaiKhoan = nd.TaiKhoan and nd.MaQuyen = q.MaQuyen ";
            SqlDataReader dr = null;
            try
            {
                DAL.sqlConnect sqlConn = new DAL.sqlConnect();
                dr = sqlConn.execCommand(query);
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void addList(SqlDataReader dr)
        {
            ListViewItem item = new ListViewItem();
            item.Text = dr["MaNV"].ToString();
            item.SubItems.Add(dr["HoTen"].ToString());
            item.SubItems.Add(dr["TaiKhoan"].ToString());
            item.SubItems.Add(dr["MatKhau"].ToString());
            item.SubItems.Add(dr["MaQuyen"].ToString());
            item.SubItems.Add(dr["Them"].ToString());
            item.SubItems.Add(dr["Sua"].ToString());
            item.SubItems.Add(dr["Xoa"].ToString());
            item.SubItems.Add(dr["Ad"].ToString());
            lsvDanhSach.Items.Add(item);   
        }

        public void clearList()
        {
            foreach (ListViewItem item in lsvDanhSach.Items)
            {
                item.Remove();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showList();
        }

        //private void btnTimKiem_Click(object sender, EventArgs e)
        //{
        //    clearList();
        //    string key = cmbValue.Text.Trim();
        //    DAL.sqlConnect sqlConn = new DAL.sqlConnect();
        //    string query;
        //    SqlDataReader dr = null;
        //    if (cmbTimKiem.Text.Equals("Mã nhân viên"))
        //    {
        //        query = "select nv.MaNV, nv.HoTen, nd.TaiKhoan, nd.MatKhau, q.MaQuyen, Them, Sua, Xoa, Ad from NHANVIEN nv, NGUOIDUNG nd, QUYENHAN q where nv.TaiKhoan = nd.TaiKhoan and nd.MaQuyen = q.MaQuyen and nv.MaNV like '" + key + "%'";
        //        dr = sqlConn.execCommand(query);
        //        while (dr.Read())
        //        {
        //            addList(dr);
        //        }
        //    }
        //    else if (cmbTimKiem.Text.Equals("Họ tên"))
        //    {
        //        query = "select nv.MaNV, nv.HoTen, nd.TaiKhoan, nd.MatKhau, q.MaQuyen, Them, Sua, Xoa, Ad from NHANVIEN nv, NGUOIDUNG nd, QUYENHAN q where nv.TaiKhoan = nd.TaiKhoan and nd.MaQuyen = q.MaQuyen and nv.HoTen like '" + key + "%'";
        //        dr = sqlConn.execCommand(query);
        //        while (dr.Read())
        //        {
        //            addList(dr);
        //        }
        //    }
        //    else if (cmbTimKiem.Text.Equals("Tài khoản"))
        //    {
        //        query = "select nv.MaNV, nv.HoTen, nd.TaiKhoan, nd.MatKhau, q.MaQuyen, Them, Sua, Xoa, Ad from NHANVIEN nv, NGUOIDUNG nd, QUYENHAN q where nv.TaiKhoan = nd.TaiKhoan and nd.MaQuyen = q.MaQuyen and nd.TaiKhoan like '" + key + "%'";
        //        dr = sqlConn.execCommand(query);
        //        while (dr.Read())
        //        {
        //            addList(dr);
        //        }
        //    }
        //    else
        //    {
        //        query = "select nv.MaNV, nv.HoTen, nd.TaiKhoan, nd.MatKhau, q.MaQuyen, Them, Sua, Xoa, Ad from NHANVIEN nv, NGUOIDUNG nd, QUYENHAN q where nv.TaiKhoan = nd.TaiKhoan and nd.MaQuyen = q.MaQuyen and q.MaQuyen like '" + key + "%'";
        //        dr = sqlConn.execCommand(query);
        //        while (dr.Read())
        //        {
        //            addList(dr);
        //        }
        //    }
        //}

        public void addCmbValue(SqlDataReader dr)
        { 
            
        }

        public void clearCmbValue()
        {
            cmbValue.Items.Clear();
        }

        private void cmbTimKiem_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbValue.Items.Clear();
            int key = cmbTimKiem.SelectedIndex;
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            SqlDataReader dr = null;
            if (key == 0)
            {
                dr = sqlConn.getDataTable("NHANVIEN");
                while (dr.Read())
                {
                    cmbValue.Items.Add(dr["HoTen"].ToString());
                }
            }
            else if (key == 1)
            {
                dr = sqlConn.getDataTable("NHANVIEN");
                while (dr.Read())
                {
                    cmbValue.Items.Add(dr["MaNV"].ToString());
                }
            }
            else if (key == 2)
            {
                dr = sqlConn.getDataTable("QUYENHAN");
                while (dr.Read())
                {
                    cmbValue.Items.Add(dr["MaQuyen"].ToString());
                }
            }
            else
            {
                dr = sqlConn.getDataTable("NGUOIDUNG");
                while (dr.Read())
                {
                    cmbValue.Items.Add(dr["TaiKhoan"].ToString());
                }
            }
        }

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            clearList();
            string key = cmbValue.Text.Trim();
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            string query;
            SqlDataReader dr = null;
            if (cmbTimKiem.Text.Equals("Mã nhân viên"))
            {
                query = "select nv.MaNV, nv.HoTen, nd.TaiKhoan, nd.MatKhau, q.MaQuyen, Them, Sua, Xoa, Ad from NHANVIEN nv, NGUOIDUNG nd, QUYENHAN q where nv.TaiKhoan = nd.TaiKhoan and nd.MaQuyen = q.MaQuyen and nv.MaNV like '" + key + "%'";
                dr = sqlConn.execCommand(query);
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else if (cmbTimKiem.Text.Equals("Họ tên"))
            {
                query = "select nv.MaNV, nv.HoTen, nd.TaiKhoan, nd.MatKhau, q.MaQuyen, Them, Sua, Xoa, Ad from NHANVIEN nv, NGUOIDUNG nd, QUYENHAN q where nv.TaiKhoan = nd.TaiKhoan and nd.MaQuyen = q.MaQuyen and nv.HoTen like '" + key + "%'";
                dr = sqlConn.execCommand(query);
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else if (cmbTimKiem.Text.Equals("Tài khoản"))
            {
                query = "select nv.MaNV, nv.HoTen, nd.TaiKhoan, nd.MatKhau, q.MaQuyen, Them, Sua, Xoa, Ad from NHANVIEN nv, NGUOIDUNG nd, QUYENHAN q where nv.TaiKhoan = nd.TaiKhoan and nd.MaQuyen = q.MaQuyen and nd.TaiKhoan like '" + key + "%'";
                dr = sqlConn.execCommand(query);
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else
            {
                query = "select nv.MaNV, nv.HoTen, nd.TaiKhoan, nd.MatKhau, q.MaQuyen, Them, Sua, Xoa, Ad from NHANVIEN nv, NGUOIDUNG nd, QUYENHAN q where nv.TaiKhoan = nd.TaiKhoan and nd.MaQuyen = q.MaQuyen and q.MaQuyen like '" + key + "%'";
                dr = sqlConn.execCommand(query);
                while (dr.Read())
                {
                    addList(dr);
                }
            }
        }

        
    }
}
