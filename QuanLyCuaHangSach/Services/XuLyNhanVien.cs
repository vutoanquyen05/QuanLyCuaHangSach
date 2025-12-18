using QuanLyCuaHangSach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Services
{
    [Serializable]
    internal class XuLyNhanVien
    {
        private List<NhanVien> dsNhanVien;
        public XuLyNhanVien()
        {
            // Khởi tạo danh sách
            this.dsNhanVien = new List<NhanVien>();

            // Đổ dữ liệu từ TruyCapDuLieu vào danh sách
            this.dsNhanVien = TruyCapDuLieu.khoiTao().getDSNhanVien();
        }
        public bool KiemTraMaNhanVien(string maNV)
        {
            foreach (NhanVien nhanVien in dsNhanVien)
                if (nhanVien.MaNV.Equals(maNV))
                    return true;
            return false;
        }
        public bool Them(NhanVien nhanVien)
        {
            if (nhanVien == null) return false;
            if (!KiemTraMaNhanVien(nhanVien.MaNV))
            {
                dsNhanVien.Add(nhanVien);
                return true;
            }
            return false;
        }
        public bool Sua(NhanVien nhanVienCu, NhanVien nhanVienMoi)
        {
            if (nhanVienCu == null || nhanVienMoi == null) return false;

            // Lấy vị trí của nhân viên cũ trong danh sách, nếu không có thì viTri = -1
            int viTri = dsNhanVien.IndexOf(nhanVienCu);
            if (viTri != -1)
            {
                dsNhanVien[viTri] = nhanVienMoi;
                return true;
            }
            return false;
        }
        public bool Xoa(NhanVien nhanVien)
        {
            if (nhanVien == null) return false;
            if (dsNhanVien.Contains(nhanVien))
            {
                dsNhanVien.Remove(nhanVien);
                return true;
            }
            return false;
        }
    }
}
