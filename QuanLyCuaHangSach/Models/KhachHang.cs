using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Models
{
    [Serializable]
    internal class KhachHang
    {
        private string maKH;
        private string tenKH;
        private string soDienThoai;
        private string diaChi;
        public KhachHang()
        {
            this.maKH = null;
            this.tenKH = null;
            this.soDienThoai = null;
            this.diaChi = null;
        }
        public KhachHang(string maKH, string tenKH, string soDienThoai, string diaChi)
        {
            this.maKH = maKH;
            this.tenKH = tenKH;
            this.soDienThoai = soDienThoai;
            this.diaChi = diaChi;
        }
        public string MaKH
        {
            get { return this.maKH; }
            set { this.maKH = value; }
        }
        public string TenKH
        {
            get { return this.tenKH; }
            set { this.tenKH = value; }
        }
        public string SoDienThoai
        {
            get { return this.soDienThoai; }
            set { this.soDienThoai = value; }
        }
        public string DiaChi
        {
            get { return this.diaChi; }
            set { this.diaChi = value; }
        }
    }
}
