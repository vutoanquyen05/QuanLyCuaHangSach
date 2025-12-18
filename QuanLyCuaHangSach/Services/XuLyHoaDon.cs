using QuanLyCuaHangSach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Services
{
    [Serializable]
    internal class XuLyHoaDon
    {
        private List<HoaDon> dsHoaDon;
        private List<ChiTietHoaDon> dsChiTietHoaDon;
        private List<Sach> dsSach;
        public XuLyHoaDon()
        {
            // Khởi tạo danh sách
            this.dsHoaDon = new List<HoaDon>();
            this.dsChiTietHoaDon = new List<ChiTietHoaDon>();
            this.dsSach = new List<Sach>();

            // Đổ dữ liệu từ TruyCapDuLieu vào danh sách
            this.dsHoaDon = TruyCapDuLieu.khoiTao().getDSHoaDon();
            this.dsChiTietHoaDon = TruyCapDuLieu.khoiTao().getDSChiTietHoaDon();
            this.dsSach = TruyCapDuLieu.khoiTao().getDSSach();
        }
        public List<HoaDon> GetDSHoaDon()
        {
            return this.dsHoaDon;
        }
        private bool KiemTraMaHoaDon(HoaDon hoaDon)
        {
            foreach (HoaDon hd in this.dsHoaDon)
            {
                if (hd.MaHD == hoaDon.MaHD)
                    return true;
            }
            return false;
        }
        private bool CapNhatSoLuongSach(string maSach, int soLuong)
        {
            foreach (Sach s in this.dsSach)
            {
                if (s.MaSach == maSach)
                {
                    // Kiểm tra đủ số lượng thì trừ rồi lưu dữ liệu
                    if (s.SoLuong >= soLuong)
                    {
                        s.SoLuong -= soLuong;
                        TruyCapDuLieu.khoiTao().LuuSach();
                        return true;
                    }
                    else
                        return false;
                }
            }
            return false;
        }
        public bool Them(HoaDon hoaDon)
        {
            if (hoaDon == null) return false;

            if (KiemTraMaHoaDon(hoaDon))
                return false;

            // Kiểm tra tồn kho trước
            foreach (ChiTietHoaDon chiTiet in hoaDon.ChiTietHoaDon)
            {
                Sach s = this.dsSach.FirstOrDefault(x => x.MaSach == chiTiet.MaSach);

                // Nếu không đủ thì dừng
                if (s == null || s.SoLuong < chiTiet.SoLuong)
                    return false;
            }

            this.dsHoaDon.Add(hoaDon);

            foreach (ChiTietHoaDon chiTiet in hoaDon.ChiTietHoaDon)
            {
                chiTiet.MaHD = hoaDon.MaHD;
                this.dsChiTietHoaDon.Add(chiTiet);

                // Cập nhật tồn kho
                CapNhatSoLuongSach(chiTiet.MaSach, chiTiet.SoLuong);
            }

            return true;
        }

    }
}
