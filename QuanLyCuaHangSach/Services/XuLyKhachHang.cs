using QuanLyCuaHangSach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Services
{
    [Serializable]
    internal class XuLyKhachHang
    {
        private List<KhachHang> dsKhachHang;
        public XuLyKhachHang()
        {
            dsKhachHang = new List<KhachHang>();
            TruyCapDuLieu duLieu = TruyCapDuLieu.khoiTao();
            this.dsKhachHang = duLieu.getDSKhachHang();
        }
        public bool Them(KhachHang khachHang)
        {
            this.dsKhachHang.Add(khachHang);
            return true;
        }
    }
}
