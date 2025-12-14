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
            dsHoaDon = new List<HoaDon>();
            dsChiTietHoaDon = new List<ChiTietHoaDon>();
            dsSach = new List<Sach>();
            TruyCapDuLieu duLieu = TruyCapDuLieu.khoiTao();
            this.dsHoaDon = duLieu.getDSHoaDon();
            this.dsChiTietHoaDon = duLieu.getDSChiTietHoaDon();
            this.dsSach = duLieu.getDSSach();
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
                    if (s.SoLuong >= soLuong)
                    {
                        s.SoLuong -= soLuong;

                        // Lưu lại vào file sách ngay sau khi trừ
                        TruyCapDuLieu.khoiTao().LuuSach();

                        return true; // cập nhật thành công
                    }
                    else
                        return false; // không đủ số lượng
                }
            }
            return false; // không tìm thấy sách
        }
        public bool Them(HoaDon hoaDon)
        {
            if (hoaDon == null) return false;

            // Kiểm tra trùng mã hóa đơn
            if (KiemTraMaHoaDon(hoaDon))
                return false;

            // Thêm hóa đơn vào danh sách
            this.dsHoaDon.Add(hoaDon);

            // Thêm chi tiết và cập nhật kho
            foreach (ChiTietHoaDon chiTiet in hoaDon.ChiTietHoaDon)
            {
                chiTiet.MaHD = hoaDon.MaHD;
                this.dsChiTietHoaDon.Add(chiTiet);

                // Gọi hàm cập nhật số lượng sách
                if (!CapNhatSoLuongSach(chiTiet.MaSach, chiTiet.SoLuong))
                    return false; // thất bại nếu không đủ số lượng hoặc không tìm thấy sách
            }

            return true; // thành công
        }
    }
}
