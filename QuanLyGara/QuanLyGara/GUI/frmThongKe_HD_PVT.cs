using Microsoft.Office.Interop.Excel;
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
    public partial class frmThongKe_HD_PVT : Form
    {
        public frmThongKe_HD_PVT()
        {
            InitializeComponent();
        }

        private void frmThongKe_HD_PVT_Load(object sender, EventArgs e)
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
            string query = "select a.ID_HoaDonVatTu, b.ID_PhieuVatTu, c.ID_VatTu, c.TenVatTu, b.MaNguoiPhuTrach, a.SoLuong, c.TheLoai, b.ThoiGian, c.SoTien, a.TongTien from HOADON_PHIEUVATTU a, PHIEUVATTU b, VATTU c where a.ID_VatTu = c.ID_VatTu and a.ID_PhieuVatTu = b.ID_PhieuVatTu ";
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
            item.Text = dr["ID_HoaDonVatTu"].ToString();
            item.SubItems.Add(dr["ID_PhieuVatTu"].ToString());
            item.SubItems.Add(dr["ID_VatTu"].ToString());
            item.SubItems.Add(dr["TenVatTu"].ToString());
            item.SubItems.Add(dr["MaNguoiPhuTrach"].ToString());
            item.SubItems.Add(dr["SoLuong"].ToString());
            item.SubItems.Add(dr["TheLoai"].ToString());
            item.SubItems.Add(dr["ThoiGian"].ToString());
            item.SubItems.Add(dr["SoTien"].ToString());
            item.SubItems.Add(dr["TongTien"].ToString());
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
            string query = null;
            SqlDataReader dr = null;
            if (cmbTK.Text.Equals("Mã hóa đơn vật tư"))
            {
                query = "select a.ID_HoaDonVatTu, b.ID_PhieuVatTu, c.ID_VatTu, c.TenVatTu, b.MaNguoiPhuTrach, a.SoLuong, c.TheLoai, b.ThoiGian, c.SoTien, a.TongTien from HOADON_PHIEUVATTU a, PHIEUVATTU b, VATTU c where a.ID_VatTu = c.ID_VatTu and a.ID_PhieuVatTu = b.ID_PhieuVatTu and a.ID_HoaDonVatTu like'" + key + "%'";
                dr = sqlConn.execCommand(query);
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else if (cmbTK.Text.Equals("Mã phiếu vật tư"))
            {
                query = "select a.ID_HoaDonVatTu, b.ID_PhieuVatTu, c.ID_VatTu, c.TenVatTu, b.MaNguoiPhuTrach, a.SoLuong, c.TheLoai, b.ThoiGian, c.SoTien, a.TongTien from HOADON_PHIEUVATTU a, PHIEUVATTU b, VATTU c where a.ID_VatTu = c.ID_VatTu and a.ID_PhieuVatTu = b.ID_PhieuVatTu and b.ID_PhieuVatTu like '" + key + "%'";
                dr = sqlConn.execCommand(query);
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else
            {
                query = "select a.ID_HoaDonVatTu, b.ID_PhieuVatTu, c.ID_VatTu, c.TenVatTu, b.MaNguoiPhuTrach, a.SoLuong, c.TheLoai, b.ThoiGian, c.SoTien, a.TongTien from HOADON_PHIEUVATTU a, PHIEUVATTU b, VATTU c where a.ID_VatTu = c.ID_VatTu and a.ID_PhieuVatTu = b.ID_PhieuVatTu and c.TenVatTu like '" + key + "%'";
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
                    sheet.Cells[1, 1].Value = "Hóa đơn phiếu vật tư";
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
