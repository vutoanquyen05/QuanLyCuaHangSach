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
        private string maKH;
        private string maNV;
        private DateTime ngayLap;
        private string soDienThoai;
        List<ChiTietHoaDon> chiTietHoaDon;

        public HoaDon()
        {
            this.maHD = null;
            this.maKH = null;
            this.maNV = null;
            this.ngayLap = DateTime.Now;
            this.soDienThoai = null;
            this.chiTietHoaDon = new List<ChiTietHoaDon>();
        }
        public HoaDon(string maHD, string maKH, string maNV, DateTime ngayLap, string soDienThoai, List<ChiTietHoaDon> chiTietHoaDon)
        {
            this.maHD = maHD;
            this.maKH = maKH;
            this.maNV = maNV;
            this.ngayLap = ngayLap;
            this.soDienThoai = soDienThoai;
            this.chiTietHoaDon = chiTietHoaDon;
        }
        public string MaHD
        {
            get { return this.maHD; }
            set { this.maHD = value; }
        }
        public string MaKH
        {
            get { return this.maKH; }
            set { this.maKH = value; }
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
        public List<ChiTietHoaDon> ChiTietHoaDon
        {
            get { return this.chiTietHoaDon; }
            set { this.chiTietHoaDon = value; }
        }
    }
}
