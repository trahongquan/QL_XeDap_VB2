using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyXeDap
{
    public partial class DatHang : Form
    {
        List<XeDap> DanhSachXe;
        ChinhSuaDuLieu con;
        public DatHang()
        {
            InitializeComponent();
            DanhSachXe = new List<XeDap>();
            con = new ChinhSuaDuLieu();
            txtNgay.Format = DateTimePickerFormat.Custom;
            txtNgay.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            GenerateGrid();
        }

        public DatHang(HoaDon hoaDon)
        {
            InitializeComponent();
            con = new ChinhSuaDuLieu();
            List<XeDap> setDSXe = con.getListHoaDonChiTiet(hoaDon.MaHoaDon);
            DanhSachXe = setDSXe;
            GenerateGrid();

            txtMaHoaDon.Text = hoaDon.MaHoaDon;
            txtMaHoaDon.Enabled = false;
            txtKhachHang.Text = hoaDon.KhachHang;
            txtTongTien.Text = hoaDon.TongTien.ToString();
            try
            {
                txtNgay.Value = Convert.ToDateTime(hoaDon.Ngay + " " + hoaDon.Thoigian);
            }
            catch { }
            
            txtNgay.Format = DateTimePickerFormat.Custom;
            txtNgay.CustomFormat = "dd/MM/yyyy hh:mm:ss";
        }

        private void GenerateGrid()
        {
            dgvXe.DataSource = null;
            dgvXe.DataSource = DanhSachXe;
            dgvXe.Columns["Ma"].HeaderText = "Mã xe";
            dgvXe.Columns["Ten"].HeaderText = "Tên xe";
            dgvXe.Columns["Hang"].HeaderText = "Hãng xe";
            dgvXe.Columns["XuatXu"].HeaderText = "Xuất xứ";
            dgvXe.Columns["Gia"].HeaderText = "Giá";
            dgvXe.Columns["Ton"].HeaderText = "Tồn kho";
            dgvXe.Columns["SoLuong"].HeaderText = "Số lượng";
            dgvXe.Columns["Tien"].HeaderText = "Tiền";
            dgvXe.Columns["HinhAnh"].HeaderText = "Hình ảnh";
            foreach (DataGridViewColumn col in dgvXe.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }
        }

        private void btnSeach_Click(object sender, EventArgs e)
        {
            TimKiemXe frmTimkiem = new TimKiemXe();
            DialogResult re = frmTimkiem.ShowDialog();
            if(re == DialogResult.OK)
            {
                XeDap xe = frmTimkiem.xeChon;
                txtMa.Text = xe.Ma;
                txtTen.Text = xe.Ten;
                txtHang.Text = xe.Hang;
                txtXuatXu.Text = xe.XuatXu;
                txtGia.Text = xe.Gia.ToString();
                txtSoLuong.Text = xe.SoLuong.ToString();
                txtTonKho.Text = xe.Ton.ToString();
                txtTien.Text = xe.Tien.ToString();
                var data = (byte[])xe.HinhAnh;
                var stream = new MemoryStream(data);
                try
                {
                    pictureBox2.Image = Image.FromStream(stream);
                }
                catch {}
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMa.Text == string.Empty || Convert.ToInt32(txtSoLuong.Text) == 0)
                return;
            if (Convert.ToInt32(txtSoLuong.Text) > Convert.ToInt32(txtTonKho.Text))
            {
                MessageBox.Show("Số lượng vượt quá tồn kho! Kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            XeDap xe = new XeDap();
            xe.Ma = txtMa.Text;
            xe.Ten = txtTen.Text;
            xe.Hang = txtHang.Text;
            xe.XuatXu = txtXuatXu.Text;
            xe.SoLuong = Convert.ToInt32(txtSoLuong.Text);
            xe.Ton = Convert.ToInt32(txtTonKho.Text);
            xe.Gia = Convert.ToDecimal(txtGia.Text);
            xe.Tien = Convert.ToDecimal(txtTien.Text);

            Image img = pictureBox2.Image;
            MemoryStream tmpStream = new MemoryStream();
            img.Save(tmpStream, ImageFormat.Png); // change to other format
            tmpStream.Seek(0, SeekOrigin.Begin);
            byte[] imgBytes = new byte[100000000];
            tmpStream.Read(imgBytes, 0, 100000000);
            xe.HinhAnh = imgBytes;
            DanhSachXe.Add(xe);
            GenerateGrid();
            txtTongTien.Text = DanhSachXe.Sum(a => a.Tien).ToString();
            ClearForm();
        }

        private void ClearForm()
        {
            txtMa.Text = string.Empty;
            txtTen.Text = string.Empty;
            txtHang.Text = string.Empty;
            txtSoLuong.Text = string.Empty;
            txtTonKho.Text = string.Empty;
            txtXuatXu.Text = string.Empty;
            txtGia.Text = string.Empty;
            txtTien.Text = string.Empty;
            pictureBox2.Image = null;
        }

        private void ClearAll()
        {
            txtMa.Text = string.Empty;
            txtTen.Text = string.Empty;
            txtHang.Text = string.Empty;
            txtSoLuong.Text = string.Empty;
            txtTonKho.Text = string.Empty;
            txtXuatXu.Text = string.Empty;
            txtGia.Text = string.Empty;
            txtTien.Text = string.Empty;
            pictureBox2.Image = null;
            DanhSachXe = new List<XeDap>();
            txtMaHoaDon.Text = string.Empty;
            txtKhachHang.Text = string.Empty;
            txtTongTien.Text = string.Empty;
            txtMaHoaDon.Focus();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMaHoaDon.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập mã hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtKhachHang.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (DanhSachXe.Count == 0)
            {
                MessageBox.Show("Chưa chọn xe!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            HoaDon hoaDon = new HoaDon();
            hoaDon.MaHoaDon = txtMaHoaDon.Text;
            hoaDon.KhachHang = txtKhachHang.Text;
            hoaDon.TongTien = Convert.ToDecimal(txtTongTien.Text);
            hoaDon.Ngay = txtNgay.Value.Date.ToString("dd/MM/yyyy");
            hoaDon.Thoigian = txtNgay.Value.TimeOfDay.ToString();
            hoaDon.DanhSachXe = DanhSachXe;
            if (txtMaHoaDon.Enabled) //Thêm mới
            {
                if (con.insertHoaDon(hoaDon))
                {
                    if (!con.insertHoaDonChiTiet(hoaDon))
                    {
                        MessageBox.Show("Mã hóa đơn đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Mã hóa đơn đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MessageBox.Show("Mua hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else // Sửa
            {
                if (!con.updateHoaDonChiTiet(hoaDon))
                {
                    MessageBox.Show("Cập nhật đơn không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MessageBox.Show("Cập nhật đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
        }

        private void txtSoLuong_Validated(object sender, EventArgs e)
        {
            txtTien.Text = (Convert.ToDecimal(txtSoLuong.Text) * Convert.ToDecimal(txtGia.Text)).ToString();
        }

        private void btnSearchHD_Click(object sender, EventArgs e)
        {

        }

        private void dgvXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMa.Text = dgvXe.Rows[index].Cells[0].Value.ToString();
                txtTen.Text = dgvXe.Rows[index].Cells[1].Value.ToString();
                txtHang.Text = dgvXe.Rows[index].Cells[2].Value.ToString();
                txtXuatXu.Text = dgvXe.Rows[index].Cells[3].Value.ToString();
                txtTonKho.Text = dgvXe.Rows[index].Cells[4].Value.ToString();
                txtSoLuong.Text = dgvXe.Rows[index].Cells[5].Value.ToString();
                txtGia.Text = dgvXe.Rows[index].Cells[6].Value.ToString();
                txtTien.Text = dgvXe.Rows[index].Cells[7].Value.ToString();
                var data = (Byte[])dgvXe.Rows[index].Cells[8].Value;
                var stream = new MemoryStream(data);
                pictureBox2.Image = Image.FromStream(stream);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtNgay_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
