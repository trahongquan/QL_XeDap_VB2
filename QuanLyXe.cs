using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace QuanLyXeDap
{
    public partial class QuanLyXe : Form
    {
        ChinhSuaDuLieu mXe;
        public QuanLyXe()
        {
            InitializeComponent();
            mXe = new ChinhSuaDuLieu();
            foreach (DataGridViewColumn col in dgvXe.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }
        }
        public void LoadXe()
        {
            DataTable dt = mXe.getAllXe();
            dgvXe.DataSource = dt;
        }
        public void lockControl()
        {
            btnDel.Enabled = false;
            btnEditorSave.Enabled = false;
            btnCancel.Enabled = false;
            txtMa.ReadOnly = true;
            txtTen.ReadOnly = true;
            txtHang.ReadOnly = true;
            txtSL.ReadOnly = true;
            txtGia.ReadOnly = true;
            txtXuatXu.ReadOnly = true;
            btnUpload.Enabled = false;
        }
        public void unlockControl()
        {
            btnDel.Enabled = true;
            btnEditorSave.Enabled = true;
            btnCancel.Enabled = true;
            txtMa.ReadOnly = true;
            txtTen.ReadOnly = false;
            txtHang.ReadOnly = false;
            txtSL.ReadOnly = false;
            txtGia.ReadOnly = false;
            txtXuatXu.ReadOnly = false;
            btnUpload.Enabled = true;
        }
        public void resetForm()
        {
            txtMa.ResetText();
            txtTen.ResetText();
            txtHang.ResetText();
            txtSL.ResetText();
            txtGia.ResetText();
            txtTuKhoa.ResetText();
            txtXuatXu.ResetText();
            pictureBox2.Image = null;
            btnEditorSave.Text = "LƯU";
            btnEditorSave.Enabled = true;
        }
        public bool checkData()
        {
            if (string.IsNullOrEmpty(txtMa.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã xe.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMa.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTen.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên xe.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTen.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtHang.Text))
            {
                MessageBox.Show("Bạn chưa nhập hãng SX xe.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHang.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSL.Text))
            {
                MessageBox.Show("Bạn chưa nhập số lượng xe.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSL.Focus();
                return false;
            }
            int a;
            if (!int.TryParse(txtSL.Text, out a))
            {
                MessageBox.Show("Số lượng không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSL.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtGia.Text) || !int.TryParse(txtGia.Text, out a))
            {
                MessageBox.Show("Bạn chưa nhập giá xe.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGia.Focus();
                return false;
            }
            if (!int.TryParse(txtGia.Text, out a))
            {
                MessageBox.Show("Giá không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGia.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtXuatXu.Text))
            {
                MessageBox.Show("Bạn chưa nhập xuất xứ xe.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGia.Focus();
                return false;
            }
            if (pictureBox2.Image == null)
            {
                MessageBox.Show("Bạn chưa nhập hình ảnh xe.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGia.Focus();
                return false;
            }
            return true;
        }
        private void FormXe_Load(object sender, EventArgs e)
        {
            lockControl();
            LoadXe();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            resetForm();
            unlockControl();
            txtMa.ReadOnly = false;
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xoá hay không?", "Cảnh báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                XeDap d = new XeDap();
                d.Ma = txtMa.Text;
                if (mXe.delXe(d))
                {
                    LoadXe();
                    MessageBox.Show("Đã xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetForm();
                }
                else
                    MessageBox.Show("Đã có lỗi xảy ra, vui lòng thử lại.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void btnEditorSave_Click(object sender, EventArgs e)
        {
            if (checkData())
                if (btnEditorSave.Text == "LƯU")
                {
                    XeDap d = new XeDap();
                    d.Ma = txtMa.Text;
                    d.Ten = txtTen.Text;
                    d.Hang = txtHang.Text;
                    d.XuatXu = txtXuatXu.Text;
                    d.SoLuong = int.Parse(txtSL.Text);
                    d.Gia = decimal.Parse(txtGia.Text);
                    d.Tien = d.SoLuong * d.Gia;
                    Image img = pictureBox2.Image;
                    MemoryStream tmpStream = new MemoryStream();
                    img.Save(tmpStream, ImageFormat.Png); // change to other format
                    tmpStream.Seek(0, SeekOrigin.Begin);
                    byte[] imgBytes = new byte[100000000];
                    tmpStream.Read(imgBytes, 0, 100000000);

                    d.HinhAnh = imgBytes;
                    if (mXe.insertXe(d))
                    {
                        LoadXe();
                        MessageBox.Show("Đã thêm xe thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Đã có lỗi xảy ra, vui lòng thử lại.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    XeDap d = new XeDap();
                    d.Ma = txtMa.Text;
                    d.Ten = txtTen.Text;
                    d.Hang = txtHang.Text;
                    d.XuatXu = txtXuatXu.Text;
                    d.SoLuong = int.Parse(txtSL.Text);
                    d.Gia = decimal.Parse(txtGia.Text);
                    d.Tien = d.SoLuong * d.Gia;
                    Image img = pictureBox2.Image;
                    MemoryStream tmpStream = new MemoryStream();
                    img.Save(tmpStream, ImageFormat.Png); // change to other format
                    tmpStream.Seek(0, SeekOrigin.Begin);
                    byte[] imgBytes = new byte[100000000];
                    tmpStream.Read(imgBytes, 0, 100000000);

                    d.HinhAnh = imgBytes;
                    if (mXe.updateXe(d))
                    {
                        LoadXe();
                        MessageBox.Show("Đã sửa thông tin xe thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        resetForm();
                    }
                    else
                        MessageBox.Show("Đã có lỗi xảy ra, vui lòng thử lại.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string key = txtTuKhoa.Text.Trim();
            if (!string.IsNullOrEmpty(key))
            {
                DataTable dt = mXe.findXe(key);
                dgvXe.DataSource = dt;
            }
            else
                LoadXe();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            resetForm();
            lockControl();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
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
                txtSL.Text = dgvXe.Rows[index].Cells[4].Value.ToString();
                txtGia.Text = dgvXe.Rows[index].Cells[5].Value.ToString();
                var data = (Byte[])dgvXe.Rows[index].Cells[7].Value;
                var stream = new MemoryStream(data);
                try
                {
                    pictureBox2.Image = Image.FromStream(stream);
                }
                catch { }
                btnEditorSave.Text = "SỬA";
                txtTuKhoa.Clear();
                unlockControl();
            }
        }

        private void dgvXe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvXe.CurrentRow.Index;
            txtMa.Text = dgvXe.Rows[index].Cells[0].Value.ToString();
            txtTen.Text = dgvXe.Rows[index].Cells[1].Value.ToString();
            txtHang.Text = dgvXe.Rows[index].Cells[2].Value.ToString();
            txtXuatXu.Text = dgvXe.Rows[index].Cells[3].Value.ToString();
            txtSL.Text = dgvXe.Rows[index].Cells[4].Value.ToString();
            txtGia.Text = dgvXe.Rows[index].Cells[5].Value.ToString();
            var data = (byte[])dgvXe.Rows[index].Cells[7].Value;
            var stream = new MemoryStream(data);
            pictureBox2.Image = Image.FromStream(stream);
            btnEditorSave.Text = "SỬA";
            txtTuKhoa.Clear();
            unlockControl();
        }


        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files|*.jpg;*.jpeg;.*.gif;.png";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = new Bitmap(opnfd.FileName);
            }
        }
    }
}