﻿using Microsoft.Office.Interop.Excel;
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
    public partial class frmThongKe_KH : Form
    {
        public frmThongKe_KH()
        {
            InitializeComponent();
        }
        private void frmThongKe_KH_Load(object sender, EventArgs e)
        {
            loadCombobox();
            showList();
        }
        public void loadCombobox()
        {
            cmbTK.SelectedIndex = 0;
        }

        public void showList()
        {
            clearList();
            string query = "select kh.ID_KhachHang, kh.HoTen, tt.BienSoXe, hx.HangXe, tt.DoiXe,tt.SoKhung, tt.SoMay, kh.SDT, kh.Email, kh.DiaChi from KHACHHANG kh, PHIEUKHAOSAT ks, THONGTINXE tt, HANGXE hx where kh.ID_KhachHang = ks.ID_KhachHang and ks.ID_Xe = tt.ID_Xe and tt.ID_HangXe = hx.ID_HangXe";
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void addList(SqlDataReader dr)
        {
            ListViewItem item = new ListViewItem();
            item.Text = dr["ID_KhachHang"].ToString();
            item.SubItems.Add(dr["HoTen"].ToString());
            item.SubItems.Add(dr["BienSoXe"].ToString());
            item.SubItems.Add(dr["HangXe"].ToString());
            item.SubItems.Add(dr["DoiXe"].ToString());
            item.SubItems.Add(dr["SoKhung"].ToString());
            item.SubItems.Add(dr["SoMay"].ToString());
            item.SubItems.Add(dr["SDT"].ToString());
            item.SubItems.Add(dr["Email"].ToString());
            item.SubItems.Add(dr["DiaChi"].ToString());
            lsvDanhSach.Items.Add(item);
        }

        public void clearList()
        {
            foreach (ListViewItem item in lsvDanhSach.Items)
            {
                item.Remove();
            }
        }
        private void btnXong_Click(object sender, EventArgs e)
        {
            clearList();
            string key = txtTK.Text.Trim();
            DAL.sqlConnect sqlConn = new DAL.sqlConnect();
            string query;
            SqlDataReader dr = null;
            if (cmbTK.Text.Equals("Mã khách hàng"))
            {
                query = "select kh.ID_KhachHang, kh.HoTen, tt.BienSoXe, hx.HangXe, tt.DoiXe, tt.SoKhung, tt.SoMay, kh.SDT, kh.Email, kh.DiaChi from KHACHHANG kh, PHIEUKHAOSAT ks, THONGTINXE tt, HANGXE hx where kh.ID_KhachHang = ks.ID_KhachHang and ks.ID_Xe = tt.ID_Xe and tt.ID_HangXe = hx.ID_HangXe and kh.ID_KhachHang like '" + key + "%'";
                dr = sqlConn.execCommand(query);
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else if (cmbTK.Text.Equals("Họ tên"))
            {
                query = "select kh.ID_KhachHang, kh.HoTen, tt.BienSoXe, hx.HangXe, tt.DoiXe, tt.SoKhung, tt.SoMay, kh.SDT, kh.Email, kh.DiaChi from KHACHHANG kh, PHIEUKHAOSAT ks, THONGTINXE tt, HANGXE hx where kh.ID_KhachHang = ks.ID_KhachHang and ks.ID_Xe = tt.ID_Xe and tt.ID_HangXe = hx.ID_HangXe and kh.HoTen like '" + key + "%'";
                dr = sqlConn.execCommand(query);
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else
            {
                query = "select kh.ID_KhachHang, kh.HoTen, tt.BienSoXe, hx.HangXe, tt.DoiXe, tt.SoKhung, tt.SoMay, kh.SDT, kh.Email, kh.DiaChi from KHACHHANG kh, PHIEUKHAOSAT ks, THONGTINXE tt, HANGXE hx where kh.ID_KhachHang = ks.ID_KhachHang and ks.ID_Xe = tt.ID_Xe and tt.ID_HangXe = hx.ID_HangXe and tt.BienSoXe like '" + key + "%'";
                dr = sqlConn.execCommand(query);
                while (dr.Read())
                {
                    addList(dr);
                }
            }
        }

        private void btnInDanhSach_Click(object sender, EventArgs e)
        {
            // tạo đối tượng lưu tệp tin
            SaveFileDialog fsave = new SaveFileDialog();
            //chỉ ra đuôi 
            fsave.Filter = "(Tất cả các tệp)|*.*|(các tệp excel)|*.xlsx";
            fsave.ShowDialog();
            //xử lý
            if (fsave.FileName != "")
            {
                //tạo excel app
                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                // tao 1 worlbook
                Workbook wb = app.Workbooks.Add(Type.Missing);
                //tạo sheet
                Worksheet sheet = null;
                try
                {
                    // đọc dữ liệu từ listview inds ra file excel có định dạng
                    sheet = wb.ActiveSheet;
                    sheet.Name = "Dữ liệu xuất ra";
                    sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, lsvDanhSach.Columns.Count]].Merge();
                    sheet.Cells[1, 1].Value = "Danh sách khách hàng";
                    sheet.Cells[1, 1].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    sheet.Cells[1, 1].Font.Size = 20;
                    sheet.Cells[1, 1].Borders.Weight = XlBorderWeight.xlThin;
                    //sinh tiêu đề
                    for (int i = 1; i <= lsvDanhSach.Columns.Count; i++)
                    {
                        sheet.Cells[2, i] = lsvDanhSach.Columns[i - 1].Text;
                        sheet.Cells[2, 1].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        sheet.Cells[2, 1].Font.Bold = true;
                        sheet.Cells[2, 1].Borders.Weight = XlBorderWeight.xlThin;
                    }
                    //sinh dữ liệu
                    for (int i = 1; i <= lsvDanhSach.Items.Count; i++)
                    {
                        ListViewItem item = lsvDanhSach.Items[i - 1];
                        sheet.Cells[i + 2, 1] = item.Text;
                        sheet.Cells[i + 2, 1].Borders.Weight = XlBorderWeight.xlThin;
                        for (int j = 2; j <= lsvDanhSach.Columns.Count; j++)
                        {
                            sheet.Cells[i + 2, j] = item.SubItems[j - 1].Text;
                            sheet.Cells[i + 2, j].Borders.Weight = XlBorderWeight.xlThin;
                        }
                    }
                    //ghi lại
                    wb.SaveAs(fsave.FileName);
                    MessageBox.Show("Ghi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    app.Quit();
                    wb = null;
                }

            }
            else
            {
                MessageBox.Show("Bạn không chọn tệp tin nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
    }
}
