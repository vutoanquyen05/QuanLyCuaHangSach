using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Models
{
    [Serializable]
    internal class HoaDon
    {
        private string maHD;
        private string hoTenKH;
        private string maNV;
        private DateTime ngayLap;
        private string soDienThoai;
        List<ChiTietHoaDon> chiTietHoaDons = new List<ChiTietHoaDon>();

        public HoaDon()
        {
            this.maHD = null;
            this.hoTenKH = null;
            this.maNV = null;
            this.ngayLap = DateTime.Now;
            this.soDienThoai = null;
            this.chiTietHoaDons = null;
        }
        public HoaDon(string maHD, string hoTenKH, string maNV, DateTime ngayLap, string soDienThoai, List<ChiTietHoaDon> chiTietHoaDons)
        {
            this.maHD = maHD;
            this.hoTenKH = hoTenKH;
            this.maNV = maNV;
            this.ngayLap = ngayLap;
            this.soDienThoai = soDienThoai;
            this.chiTietHoaDons = chiTietHoaDons;
        }
        public string MaHD
        {
            get { return this.maHD; }
            set { this.maHD = value; }
        }
        public string HoTenKH
        {
            get { return this.hoTenKH; }
            set { this.hoTenKH = value; }
        }
        public string MaNV
        {
            get { return this.maNV; }
            set { this.maNV = value; }
        }
        public DateTime NgayLap
        {
            get { return this.ngayLap; }
            set { this.ngayLap = value; }
        }
        public string SoDienThoai
        {
            get { return this.soDienThoai; }
            set { this.soDienThoai = value; }
        }
        public List<ChiTietHoaDon> ChiTietHoaDons
        {
            get { return this.chiTietHoaDons; }
            set { this.chiTietHoaDons = value; }
        }
    }
}
