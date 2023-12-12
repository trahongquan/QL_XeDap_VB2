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
    public partial class TimKiemXe : Form
    {
        ChinhSuaDuLieu mXe;
        public XeDap xeChon;
        public TimKiemXe()
        {
            InitializeComponent();
            mXe = new ChinhSuaDuLieu();
        }

        private void TimKiemXe_Load(object sender, EventArgs e)
        {
            LoadXe();
            xeChon = new XeDap();
        }
        public void LoadXe()
        {
            DataTable dt = mXe.getAllXe();
            dgvXe.DataSource = dt;
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

        private void dgvXe_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            xeChon.Ma = dgvXe.Rows[e.RowIndex].Cells[0].Value.ToString();
            xeChon.Ten = dgvXe.Rows[e.RowIndex].Cells[1].Value.ToString();
            xeChon.Hang = dgvXe.Rows[e.RowIndex].Cells[2].Value.ToString();
            xeChon.XuatXu = dgvXe.Rows[e.RowIndex].Cells[3].Value.ToString();
            xeChon.Ton = Convert.ToInt32(dgvXe.Rows[e.RowIndex].Cells[4].Value);
            xeChon.SoLuong = Convert.ToInt32(dgvXe.Rows[e.RowIndex].Cells[4].Value);
            xeChon.Gia = Convert.ToDecimal(dgvXe.Rows[e.RowIndex].Cells[5].Value);
            xeChon.Tien = Convert.ToDecimal(dgvXe.Rows[e.RowIndex].Cells[6].Value);
            xeChon.HinhAnh = (byte[])dgvXe.Rows[e.RowIndex].Cells[7].Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
