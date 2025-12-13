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
        private int soLuong;
        private Sach sach;

        public ChiTietHoaDon()
        {
            this.soLuong = 0;
            this.sach = null;
        }
        public ChiTietHoaDon(int soLuong, Sach sach)
        {
            this.soLuong = soLuong;
            this.sach = sach;
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

        public decimal TinhThanhTien()
        {
            return this.soLuong * this.sach.GiaBan;
        }
        public decimal ThanhTien
        {
            get { return TinhThanhTien(); }
        }
    }
}
