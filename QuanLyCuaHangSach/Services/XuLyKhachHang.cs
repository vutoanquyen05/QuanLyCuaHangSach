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
        public bool KiemTraMaKhachHang(string maKH)
        {
            foreach (KhachHang khachHang in dsKhachHang)
                if (khachHang.MaKH.Equals(maKH))
                    return true;
            return false;
        }
        public bool Them(KhachHang khachHang)
        {
            if (khachHang == null) return false;
            if (!KiemTraMaKhachHang(khachHang.MaKH))
            {
                dsKhachHang.Add(khachHang);
                return true;
            }
            return false;
        }
        public bool Sua(KhachHang khachHangCu, KhachHang khachHangMoi)
        {
            if (khachHangCu == null || khachHangMoi == null) return false;
            int viTri = dsKhachHang.IndexOf(khachHangCu);
            if (viTri != -1)
            {
                dsKhachHang[viTri] = khachHangMoi;
                return true;
            }
            return false;
        }
        public bool Xoa(KhachHang khachHang)
        {
            if (khachHang == null) return false;
            if (dsKhachHang.Contains(khachHang))
            {
                dsKhachHang.Remove(khachHang);
                return true;
            }
            return false;
        }
    }
}
