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
            dsNhanVien = new List<NhanVien>();
            TruyCapDuLieu duLieu = TruyCapDuLieu.khoiTao();
            this.dsNhanVien = duLieu.getDSNhanVien();
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
