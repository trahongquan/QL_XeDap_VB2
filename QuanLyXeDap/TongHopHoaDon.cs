using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyXeDap
{
    public partial class TongHopHoaDon : Form
    {
        ChinhSuaDuLieu con;
        string selectedHoaDon;
        int selectedIndex;
        public TongHopHoaDon()
        {
            InitializeComponent();
            con = new ChinhSuaDuLieu();
            selectedIndex = -1;
        }

        private void TongHopHoaDon_Load(object sender, EventArgs e)
        {
            LoadHoaDon();
        }

        private void dgvPH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex = e.RowIndex;
            if (selectedIndex >= 0)
            {
                string maHoaDon = dgvPH.Rows[selectedIndex].Cells[0].Value.ToString();
                DataTable dt = con.getAllHoaDonChiTiet(maHoaDon);
                dgvCT.DataSource = dt;
                selectedHoaDon = maHoaDon;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DatHang frmDatHang = new DatHang();
            frmDatHang.ShowDialog();
            
            DataTable dt = con.getAllHoaDon();
            dgvPH.DataSource = dt;
            dgvPH.Refresh();
            selectedHoaDon = "";
            DataTable dt2 = con.getAllHoaDonChiTiet(selectedHoaDon);
            dgvCT.DataSource = dt2;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedIndex < 0)
                return;
            HoaDon hoaDon = new HoaDon();
            hoaDon.MaHoaDon = dgvPH.Rows[selectedIndex].Cells[0].Value.ToString();
            hoaDon.KhachHang = dgvPH.Rows[selectedIndex].Cells[1].Value.ToString();
            hoaDon.TongTien = Convert.ToDecimal(dgvPH.Rows[selectedIndex].Cells[2].Value);
            hoaDon.Ngay = dgvPH.Rows[selectedIndex].Cells[3].Value.ToString();
            hoaDon.Thoigian = dgvPH.Rows[selectedIndex].Cells[4].Value.ToString();
            DatHang frmDatHang = new DatHang(hoaDon);
            frmDatHang.ShowDialog();

            DataTable dt = con.getAllHoaDon();
            dgvPH.DataSource = dt;
            dgvPH.Refresh();
            selectedHoaDon = "";
            DataTable dt2 = con.getAllHoaDonChiTiet(selectedHoaDon);
            dgvCT.DataSource = dt2;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if(selectedHoaDon == string.Empty)
            {
                MessageBox.Show("Chưa chọn đơn hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá hay không?", "Cảnh báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (con.delHoaDon(selectedHoaDon))
                {
                    LoadHoaDon();
                    MessageBox.Show("Đã xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Đã có lỗi xảy ra, vui lòng thử lại.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void LoadHoaDon()
        {
            DataTable dt = con.getAllHoaDon();
            dgvPH.DataSource = dt;
            dgvPH.Refresh();
            selectedHoaDon = ""; 
            DataTable dt2 = con.getAllHoaDonChiTiet(selectedHoaDon);
            dgvCT.DataSource = dt2;
            dgvCT.Columns["colTon"].Visible = false;
            foreach (DataGridViewColumn col in dgvPH.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }
            foreach (DataGridViewColumn col in dgvCT.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvCT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvPH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
