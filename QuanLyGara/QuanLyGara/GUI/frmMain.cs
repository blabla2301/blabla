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
    public partial class frmMain : Form
    {
        bool kt;
        public frmMain()
        {
            InitializeComponent();
        }

        private void mnuHT_DX_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI.frmDangNhap dn = new frmDangNhap();
            dn.Show();
        }

        private void mnuHT_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            string query = "select q.Them, q.Sua, q.Xoa, q.Ad from QUYENHAN q, NGUOIDUNG n where q.ID_QuyenHan = n.ID_QuyenHan and n.TaiKhoan = '" + DAL.NguoiDung_Model.taikhoan + "' and n.MatKhau = '" + DAL.NguoiDung_Model.matkhau + "'";
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            sqlConn.openConnection();
            SqlDataReader dr = sqlConn.execCommand(query);
            while (dr.Read())
            {
                if (dr["Ad"].ToString().Equals("True"))
                {
                    mnuHT_QLND.Enabled = true;
                    mnuHT_PQ.Enabled = true;
                }
                else
                {
                    mnuHT_QLND.Enabled = false;
                    mnuHT_PQ.Enabled = false;
                }

                if (dr["Them"].ToString().Equals("False") && dr["Sua"].ToString().Equals("False") && dr["Xoa"].ToString().Equals("False"))
                {
                    mnuDM.Enabled = false;
                }
                else
                {
                    mnuDM.Enabled = true;
                }
            }
            //DAL.NguoiDung_Model nd = new DAL.NguoiDung_Model();
            //nd.checkPermission(btnThemKH, btnSuaKH, btnXoaKH);
            //loadLsvKhachHang();
            //pnlThemKH.Visible = false;
            lockControl();
        }

        
        private void mnuHT_PQ_Click(object sender, EventArgs e)
        {
            GUI.frmChiTietNguoiDung frm = new frmChiTietNguoiDung();
            frm.ShowDialog();
        }

        private void mnuHT_QLND_Click(object sender, EventArgs e)
        {
            GUI.frmQuanLyNguoiDung frm = new frmQuanLyNguoiDung();
            frm.ShowDialog();
        }

        private void mnuHT_DMK_Click(object sender, EventArgs e)
        {
            GUI.frmDoiMatKhau frm = new frmDoiMatKhau();
            frm.ShowDialog();
        }

        private void mnuDM_KH_Click(object sender, EventArgs e)
        {
            GUI.frmKhachHang frm = new frmKhachHang();
            frm.ShowDialog();
        }

        private void mnuDM_TTX_Click(object sender, EventArgs e)
        {
            GUI.frmThongTinXe frm = new frmThongTinXe();
            frm.ShowDialog();
        }

        private void mnuDM_PKS_Click(object sender, EventArgs e)
        {
            GUI.frmPhieuKhaoSat frm = new frmPhieuKhaoSat();
            frm.ShowDialog();
            loadLsvKhachHang();
        }

        private void mnuDM_PDG_Click(object sender, EventArgs e)
        {
            GUI.frmPhieuDanhGia frm = new frmPhieuDanhGia();
            frm.ShowDialog();
        }

        private void mnuDM_VT_Click(object sender, EventArgs e)
        {
            GUI.frmVatTu frm = new frmVatTu();
            frm.ShowDialog();
        }

        private void mnuDM_PVT_Click(object sender, EventArgs e)
        {
            GUI.frmPhieuVatTu frm = new frmPhieuVatTu();
            frm.ShowDialog();
        }

        private void mnuDM_NCC_Click(object sender, EventArgs e)
        {
            GUI.frmNhaCungCap frm = new frmNhaCungCap();
            frm.ShowDialog();
        }

        private void mnuDM_HD_PVT_Click(object sender, EventArgs e)
        {
            GUI.frmHoaDon_PhieuVatTu frm = new frmHoaDon_PhieuVatTu();
            frm.ShowDialog();
        }

        private void mnuDM_LSC_Click(object sender, EventArgs e)
        {
            GUI.frmLenhSuaChua frm = new frmLenhSuaChua();
            frm.ShowDialog();
        }

        private void mnuDM_NV_Click(object sender, EventArgs e)
        {
            GUI.frmNhanVien frm = new frmNhanVien();
            frm.ShowDialog();
        }

        private void mnuDM_PC_Click(object sender, EventArgs e)
        {
            GUI.frmPhanCong frm = new frmPhanCong();
            frm.ShowDialog();
        }

        private void mnuDM_HD_TT_Click(object sender, EventArgs e)
        {
            GUI.frmHoaDonThanhToan frm = new frmHoaDonThanhToan();
            frm.ShowDialog();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //DialogResult check = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //if (check == DialogResult.Yes)
            //{
                //this.Close();
            Application.Exit();
            //}
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)!=DialogResult.OK)
            {
                e.Cancel = true;
            }

        }

        private void lockControl()
        {
            //pnlThemKH.Visible = false;
            //lsvDSKH.Enabled = true;
            //btnThemKH.Enabled = true;
            //btnSuaKH.Enabled = false;
            //btnXoaKH.Enabled = false;
            //txtMaKH.Enabled = false;
            //txtMaKH.Enabled = false;
            //txtHoTen.Enabled = false;
            //txtSDT.Enabled = false;
            //txtEmail.Enabled = false;
            //txtDiaChi.Enabled = false;
            //txtBienSoXe.Enabled = false;
            //txtHangXe.Enabled = false;
            //txtDoiXe.Enabled = false;
            //txtSoKhung.Enabled = false;
            //txtSoMay.Enabled = false;
            //txtSoKM.Enabled = false;
            //txtMaPhieu.Enabled = false;
            //txtYeuCau.Enabled = false;
        }

        private void openControl()
        {
            ////pnlThemKH.Visible = true;
            //lsvDSKH.Enabled = false;
            //txtMaKH.Enabled = true;
            //txtMaKH.Enabled = true;
            //txtHoTen.Enabled = true;
            //txtSDT.Enabled = true;
            //txtEmail.Enabled = true;
            //txtDiaChi.Enabled = true;
            //txtBienSoXe.Enabled = true;
            //txtHangXe.Enabled = true;
            //txtDoiXe.Enabled = true;
            //txtSoKhung.Enabled = true;
            //txtSoMay.Enabled = true;
            //txtSoKM.Enabled = true;
            //txtMaPhieu.Enabled = true;
            //txtYeuCau.Enabled = true;
        }


        private void clearControl()
        {
            //string MaKH = "select count(MaKH) from KHACHHANG";
            //string MaPKS = "select count(MaPhieuKhaoSat) from PHIEUKHAOSAT";
            //DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            //int iMaKH = Convert.ToInt32(sqlConn.execScanler(MaKH));
            //int iMaPKS = Convert.ToInt32(sqlConn.execScanler(MaPKS));
            //txtMaKH.Text = "KH" + (iMaKH + 1).ToString();
            //txtHoTen.ResetText();
            //txtSDT.ResetText();
            //txtEmail.ResetText();
            //txtDiaChi.ResetText();
            //txtBienSoXe.ResetText();
            //txtHangXe.ResetText();
            //txtDoiXe.ResetText();
            //txtSoKhung.ResetText();
            //txtSoMay.ResetText();
            //txtSoKM.ResetText();
            //txtMaPhieu.Text = "MP" + (iMaPKS + 1).ToString();
            //txtYeuCau.ResetText();
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            //kt = true;
            //pnlThemKH.Visible = true;
            //btnSuaKH.Enabled = false;
            //btnXoaKH.Enabled = false;
            //clearControl();
            //openControl();
            //txtMaKH.Focus();
        }
        private void addListKhachHang(SqlDataReader dr)
        {
            //ListViewItem item = new ListViewItem();
            //item.Text = dr["MaKH"].ToString();
            //item.SubItems.Add(dr["HoTen"].ToString());
            //item.SubItems.Add(dr["SDT"].ToString());
            //item.SubItems.Add(dr["Email"].ToString());
            //item.SubItems.Add(dr["DiaChi"].ToString());
            //item.SubItems.Add(dr["BienSoXe"].ToString());
            //item.SubItems.Add(dr["HangXe"].ToString());
            //item.SubItems.Add(dr["DoiXe"].ToString());
            //item.SubItems.Add(dr["SoKhung"].ToString());
            //item.SubItems.Add(dr["SoMay"].ToString());
            //item.SubItems.Add(dr["SoKM"].ToString());
            //item.SubItems.Add(dr["YeuCau"].ToString());
            //item.SubItems.Add(dr["MaPhieuKhaoSat"].ToString());
            //lsvDSKH.Items.Add(item);

        }

        public void loadLsvKhachHang()
        {
            //clearLsvKhachHang();
            //string query = "select kh.MaKH, kh.HoTen, kh.SDT, kh.Email, kh.DiaChi, xe.BienSoXe, xe.HangXe, xe.DoiXe, xe.SoKhung, xe.SoMay, xe.SoKM, pks.YeuCau, pks.MaPhieuKhaoSat from KHACHHANG kh, THONGTINXE xe, PHIEUKHAOSAT pks where kh.MaKH = pks.MaKH and xe.BienSoXe = pks.BienSoXe";
            //DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            //SqlDataReader dr = sqlConn.execCommand(query);
            //while (dr.Read())
            //{
            //    addListKhachHang(dr);
            //}
        }

        private void clearLsvKhachHang()
        {
            //lsvDSKH.Items.Clear();
        }

        private void lsvDSKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (lsvDSKH.SelectedItems.Count > 0)
            //{
            //    txtMaKH.Text = lsvDSKH.SelectedItems[0].SubItems[0].Text;
            //    txtHoTen.Text = lsvDSKH.SelectedItems[0].SubItems[1].Text;
            //    txtSDT.Text = lsvDSKH.SelectedItems[0].SubItems[2].Text;
            //    txtEmail.Text = lsvDSKH.SelectedItems[0].SubItems[3].Text;
            //    txtDiaChi.Text = lsvDSKH.SelectedItems[0].SubItems[4].Text;
            //    txtBienSoXe.Text = lsvDSKH.SelectedItems[0].SubItems[5].Text;
            //    txtHangXe.Text = lsvDSKH.SelectedItems[0].SubItems[6].Text;
            //    txtDoiXe.Text = lsvDSKH.SelectedItems[0].SubItems[7].Text;
            //    txtSoKhung.Text = lsvDSKH.SelectedItems[0].SubItems[8].Text;
            //    txtSoMay.Text = lsvDSKH.SelectedItems[0].SubItems[9].Text;
            //    txtSoKM.Text = lsvDSKH.SelectedItems[0].SubItems[10].Text;
            //    txtYeuCau.Text = lsvDSKH.SelectedItems[0].SubItems[11].Text;
            //    txtMaPhieu.Text = lsvDSKH.SelectedItems[0].SubItems[12].Text;
            //}
            //btnSuaKH.Enabled = true;
            //btnXoaKH.Enabled = true;
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            //ENTITY.PhieuKhaoSat p = new ENTITY.PhieuKhaoSat();
            //p.BienSoXe = txtBienSoXe.Text.Trim();
            //p.MaKH = txtMaKH.Text.Trim();
            //string query = "delete PHIEUKHAOSAT where BienSoXe = '" + p.BienSoXe + "' and MaKH = '" + p.MaKH + "'";
            //DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            //sqlConn.execNonQuery(query);
            //loadLsvKhachHang();
        }

        private void cmbKeyKH_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //cmbValueKH.Items.Clear();
            //cmbValueKH.ResetText();
            //int check = cmbKeyKH.SelectedIndex;
            //string query = null;
            //SqlDataReader dr = null;
            //DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            //if (check==0)
            //{
            //    query = "select MaKH from KHACHHANG";
            //    dr = sqlConn.execCommand(query);
            //    while (dr.Read())
            //    {
            //        if (dr["MaKH"].ToString().Equals(""))
            //        {
            //            continue;
            //        }
            //        cmbValueKH.Items.Add(dr["MaKH"].ToString());
            //    }
            //}
            //else if (check == 1)
            //{
            //    query = "select HoTen from KHACHHANG";
            //    dr = sqlConn.execCommand(query);
            //    while (dr.Read())
            //    {
            //        if (dr["HoTen"].ToString().Equals(""))
            //        {
            //            continue;
            //        }
            //        cmbValueKH.Items.Add(dr["HoTen"].ToString());
            //    }
            //}
            //else if (check == 2)
            //{
            //    query = "select BienSoXe from THONGTINXE";
            //    dr = sqlConn.execCommand(query);
            //    while (dr.Read())
            //    {
            //        if (dr["BienSoXe"].ToString().Equals(""))
            //        {
            //            continue;
            //        }
            //        cmbValueKH.Items.Add(dr["BienSoXe"].ToString());
            //    }
            //}
            //else
            //{
            //    query = "select HangXe from THONGTINXE";
            //    dr = sqlConn.execCommand(query);
            //    while (dr.Read())
            //    {
            //        if (dr["HangXe"].ToString().Equals(""))
            //        {
            //            continue;
            //        }
            //        cmbValueKH.Items.Add(dr["HangXe"].ToString());
            //    }
            //}
        }

        private void btnTimKiemKH_Click(object sender, EventArgs e)
        {
            //clearLsvKhachHang();
            //int index = cmbKeyKH.SelectedIndex;
            //string key = cmbKeyKH.Text.Trim();
            //string value = cmbValueKH.Text.Trim();
            //string query = null;
            //SqlDataReader dr = null;
            //DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            //if (index==0)
            //{
            //    query = "select kh.MaKH, kh.HoTen, kh.SDT, kh.Email, kh.DiaChi, xe.BienSoXe, xe.HangXe, xe.DoiXe, xe.SoKhung, xe.SoMay, xe.SoKM, pks.YeuCau, pks.MaPhieuKhaoSat from KHACHHANG kh, THONGTINXE xe, PHIEUKHAOSAT pks where kh.MaKH = pks.MaKH and xe.BienSoXe = pks.BienSoXe and kh.MaKH like '" + value + "%'";
            //    dr = sqlConn.execCommand(query);
            //    while (dr.Read())
            //    {
            //        addListKhachHang(dr);
            //    }
            //}
            //else if (index == 1)
            //{
            //    query = "select kh.MaKH, kh.HoTen, kh.SDT, kh.Email, kh.DiaChi, xe.BienSoXe, xe.HangXe, xe.DoiXe, xe.SoKhung, xe.SoMay, xe.SoKM, pks.YeuCau, pks.MaPhieuKhaoSat from KHACHHANG kh, THONGTINXE xe, PHIEUKHAOSAT pks where kh.MaKH = pks.MaKH and xe.BienSoXe = pks.BienSoXe and kh.HoTen like '" + value + "%'";
            //    dr = sqlConn.execCommand(query);
            //    while (dr.Read())
            //    {
            //        addListKhachHang(dr);
            //    }
            //}
            //else if (index == 2)
            //{
            //    query = "select kh.MaKH, kh.HoTen, kh.SDT, kh.Email, kh.DiaChi, xe.BienSoXe, xe.HangXe, xe.DoiXe, xe.SoKhung, xe.SoMay, xe.SoKM, pks.YeuCau, pks.MaPhieuKhaoSat from KHACHHANG kh, THONGTINXE xe, PHIEUKHAOSAT pks where kh.MaKH = pks.MaKH and xe.BienSoXe = pks.BienSoXe and xe.BienSoXe like '" + value + "%'";
            //    dr = sqlConn.execCommand(query);
            //    while (dr.Read())
            //    {
            //        addListKhachHang(dr);
            //    }
            //}
            //else
            //{
            //    query = "select kh.MaKH, kh.HoTen, kh.SDT, kh.Email, kh.DiaChi, xe.BienSoXe, xe.HangXe, xe.DoiXe, xe.SoKhung, xe.SoMay, xe.SoKM, pks.YeuCau, pks.MaPhieuKhaoSat from KHACHHANG kh, THONGTINXE xe, PHIEUKHAOSAT pks where kh.MaKH = pks.MaKH and xe.BienSoXe = pks.BienSoXe and xe.HangXe like '" + value + "%'";
            //    dr = sqlConn.execCommand(query);
            //    while (dr.Read())
            //    {
            //        addListKhachHang(dr);
            //    }
            //}
        }

        private void btnRefreshKH_Click(object sender, EventArgs e)
        {
            //loadLsvKhachHang();
        }

        private void btnAnKH_Click(object sender, EventArgs e)
        {
            //lockControl();
            //pnlThemKH.Visible = false;
        }

        private void btnLuuKH_Click_1(object sender, EventArgs e)
        {
            //ENTITY.KhachHang k = new ENTITY.KhachHang();
            //k.MaKH = txtMaKH.Text.Trim();
            //k.HoTen = txtHoTen.Text.Trim();
            //k.SDT = txtSDT.Text.Trim();
            //k.Email = txtEmail.Text.Trim();
            //k.DiaChi = txtDiaChi.Text.Trim();

            //ENTITY.Xe x = new ENTITY.Xe();
            //x.BienSoXe = txtBienSoXe.Text.Trim();
            //x.HangXe = txtHangXe.Text.Trim();
            //x.DoiXe = txtDoiXe.Text.Trim();
            //x.SoKhung = txtSoKhung.Text.Trim();
            //x.SoMay = txtSoMay.Text.Trim();
            //x.SoKM = txtSoKM.Text.Trim();

            //ENTITY.PhieuKhaoSat p = new ENTITY.PhieuKhaoSat();
            //p.MaPKS = txtMaPhieu.Text.Trim();
            //p.BienSoXe = txtBienSoXe.Text.Trim();
            //p.MaKH = txtMaKH.Text.Trim();
            //p.YeuCau = txtYeuCau.Text.Trim();
            //DAL.KhachHang_Model kh = new DAL.KhachHang_Model();
            //DAL.Xe_Model xe = new DAL.Xe_Model();
            //DAL.PhieuKhaoSat_Model pks = new DAL.PhieuKhaoSat_Model();
            //if (kt == true)
            //{
            //    kh.insertKHACHHANG(k);
            //    xe.insertXe(x);
            //    pks.insertPhieuKhaoSat(p);
            //}
            //else
            //{
            //    kh.editKHACHHANG(k);
            //    xe.editXe(x);
            //    pks.editPhieuKhaoSat(p);
            //}
            //lockControl();
            //loadLsvKhachHang();
        }

        private void btnHuyKH_Click_1(object sender, EventArgs e)
        {
            //lockControl();
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            //kt = false;
            //openControl();
            //pnlThemKH.Visible = true;
            //btnThemKH.Enabled = false;
            //btnXoaKH.Enabled = false;
            //txtMaKH.Enabled = false;
            //txtBienSoXe.Enabled = false;
            //txtMaPhieu.Enabled = false;
        }

        private void mnuTK_NV_Click(object sender, EventArgs e)
        {
            GUI.frmThongKe_NV frm = new frmThongKe_NV();
            frm.ShowDialog();
        }

        private void mnuTK_KH_Click(object sender, EventArgs e)
        {
            GUI.frmThongKe_KH frm = new frmThongKe_KH();
            frm.ShowDialog();
        }

        private void mnuTK_NCC_Click(object sender, EventArgs e)
        {
            GUI.frmThongKe_NCC frm = new frmThongKe_NCC();
            frm.ShowDialog();
        }

        private void mnuTK_HD_PVT_Click(object sender, EventArgs e)
        {
            GUI.frmThongKe_HD_PVT frm = new frmThongKe_HD_PVT();
            frm.ShowDialog();
        }

        private void mnuTK_HD_TT_Click(object sender, EventArgs e)
        {
            GUI.frmThongKe_HD_TT frm = new frmThongKe_HD_TT();
            frm.ShowDialog();
        }
    }
}
