using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Models
{
    [Serializable]
    internal class ChiTietHoaDon
    {
        private string maHD;
        private int soLuong;
        private Sach sach;

        public ChiTietHoaDon()
        {
            this.maHD = null;
            this.soLuong = 0;
            this.sach = new Sach();
        }
        public ChiTietHoaDon(string maHD, int soLuong, Sach sach)
        {
            this.maHD = maHD;
            this.soLuong = soLuong;
            this.sach = sach;
        }
        public string MaHD
        {
            get { return this.maHD; }
            set { this.maHD = value; }
        }
        public string MaSach
        {
            get { return this.sach.MaSach; }
            set { this.sach.MaSach = value; }
        }
        public string TenSach
        {
            get { return this.sach.TenSach; }
            set { this.sach.TenSach = value; }
        }
        public decimal GiaBan
        {
            get { return this.sach.GiaBan; }
            set { this.sach.GiaBan = value; }
        }

        public Sach Sach
        {
            get { return this.sach; }
            set { this.sach = value; }
        }

        public int SoLuong
        {
            get { return this.soLuong; }
            set { this.soLuong = value; }
        }

        private decimal TinhThanhTien()
        {
            return this.soLuong* this.sach.GiaBan;
        }
        public decimal ThanhTien
        {
            get { return TinhThanhTien(); }
        }
    }
}
