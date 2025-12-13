using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Models
{
    [Serializable]
    internal class NhanVien
    {
        private string maNV;
        private string tenNV;
        private string chucVu;
        private string soDienThoai;
        private string maQL;
        public NhanVien()
        {
            this.maNV = null;
            this.tenNV = null;
            this.chucVu = null;
            this.soDienThoai = null;
            this.maQL = null;
        }
        public NhanVien(string maNV, string tenNV, string chucVu, string soDienThoai, string maQL)
        {
            this.maNV = maNV;
            this.tenNV = tenNV;
            this.chucVu = chucVu;
            this.soDienThoai = soDienThoai;
            this.maQL = maQL;
        }
        public string MaNV
        {
            get { return this.maNV; }
            set { this.maNV = value; }
        }
        public string TenNV
        {
            get { return this.tenNV; }
            set { this.tenNV = value; }
        }
        public string ChucVu
        {
            get { return this.chucVu; }
            set { this.chucVu = value; }
        }
        public string SoDienThoai
        {
            get { return this.soDienThoai; }
            set { this.soDienThoai = value; }
        }
        public string MaQL
        {
            get { return this.maQL; }
            set { this.maQL = value; }
        }
    }
}
