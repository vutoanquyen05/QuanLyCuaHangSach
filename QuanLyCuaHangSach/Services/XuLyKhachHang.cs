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
            // Khởi tạo danh sách
            this.dsKhachHang = new List<KhachHang>();

            // Đổ dữ liệu từ TruyCapDuLieu vào danh sách
            this.dsKhachHang = TruyCapDuLieu.khoiTao().getDSKhachHang();
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

            // Lấy vị trí của khách hàng cũ trong danh sách, nếu không có thì viTri = -1
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
