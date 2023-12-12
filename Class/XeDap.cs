using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyXeDap
{
    public class XeDap
    {
        private string ma;
        private string ten;
        private string hang;
        private string xuatxu;
        private int sl;
        private decimal gia;
        private decimal tien;
        private byte[] hinhanh;
        private int ton;
        public string Ma
        {
            get
            {
                return ma;
            }
            set
            {
                ma = value;
            }
        }
        public string Ten
        {
            get
            {
                return ten;
            }
            set
            {
                ten = value;
            }
        }
        public string Hang
        {
            get
            {
                return hang;
            }
            set
            {
                hang = value;
            }
        }
        public string XuatXu
        {
            get
            {
                return xuatxu;
            }
            set
            {
                xuatxu = value;
            }
        }
        public int Ton
        {
            get
            {
                return ton;
            }
            set
            {
                ton = value;
            }
        }
        public int SoLuong
        {
            get
            {
                return sl;
            }
            set
            {
                sl = value;
            }
        }
        public decimal Gia
        {
            get
            {
                return gia;
            }
            set
            {
                gia = value;
            }
        }
        public decimal Tien
        {
            get
            {
                return tien;
            }
            set
            {
                tien = value;
            }
        }

        public byte[] HinhAnh
        {
            get
            {
                return hinhanh;
            }
            set
            {
                hinhanh = value;
            }
        }
        /*=====Constructor=====*/
        public XeDap()
        {

        }
        public XeDap(string _ma, string _ten, string _hang, string _xuatxu, int _sl, decimal _gia, decimal _tien, byte[] _hinhanh)
        {
            this.Ma = _ma;
            this.Ten = _ten;
            this.Hang = _hang;
            this.xuatxu = _xuatxu;
            this.SoLuong = _sl;
            this.Gia = _gia;
            this.Tien = _tien;
            this.HinhAnh = _hinhanh;
        }
    }
}
