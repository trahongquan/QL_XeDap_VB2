using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyXeDap
{
    public class HoaDon
    {
        private string maHoaDon;
        private string khachHang;
        private List<XeDap> danhSachXe;
        private decimal tongTien;
        private string ngay;
        private string thoigian;
        public HoaDon()
        {
        }

        public string MaHoaDon { 
            get {
                return maHoaDon;
            }
            set
            {
                maHoaDon = value;
            }
        }

        public string KhachHang
        {
            get
            {
                return khachHang;
            }
            set
            {
                khachHang = value;
            }
        }

        public List<XeDap> DanhSachXe
        {
            get
            {
                return danhSachXe;
            }
            set
            {
                danhSachXe = value;
            }
        }

        public decimal TongTien
        {
            get
            {
                return tongTien;
            }
            set
            {
                tongTien = value;
            }
        }

        public string Ngay
        {
            get
            {
                return ngay;
            }
            set
            {
                ngay = value;
            }
        }
        public string Thoigian
        {
            get
            {
                return thoigian;
            }
            set
            {
                thoigian = value;
            }
        }

        public HoaDon(string maHoaDon, string khachHang, List<XeDap> danhSachXe, decimal tongTien)
        {
            this.MaHoaDon = maHoaDon;
            this.KhachHang = khachHang;
            this.DanhSachXe = danhSachXe;
            this.TongTien = tongTien;
        }
    }
}
