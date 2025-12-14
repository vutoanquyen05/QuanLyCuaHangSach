using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Models
{
    [Serializable]
   public class Sach
    {
        private string maSach;
        private string tenSach;
        private string tenTG;
        private string maNXB;
        private decimal giaBan;
        private int soLuong;
        public Sach()
        {
            this.maSach = null;
            this.tenSach = null;
            this.tenTG = null;
            this.maNXB = null;
            this.giaBan = 0;
            this.soLuong = 0;
        }
        public Sach(string maSach, string tenSach, string maTG, string maNXB, decimal giaBan, int soLuong)
        {
            this.maSach = maSach;
            this.tenSach = tenSach;
            this.tenTG = maTG;
            this.maNXB = maNXB;
            this.giaBan = giaBan;
            this.soLuong = soLuong;
        }
        public string MaSach
        {
            get { return this.maSach; }
            set { this.maSach = value; }
        }
        public string TenSach
        {
            get { return this.tenSach; }
            set { this.tenSach = value; }
        }
        public string TenTG
        {
            get { return this.tenTG; }
            set { this.tenTG = value; }
        }
        public string MaNXB
        {
            get { return this.maNXB; }
            set { this.maNXB = value; }
        }
        public decimal GiaBan
        {
            get { return this.giaBan; }
            set { this.giaBan = value; }
        }
        public int SoLuong
        {
            get { return this.soLuong; }
            set { this.soLuong = value; }
        }
    }
}
