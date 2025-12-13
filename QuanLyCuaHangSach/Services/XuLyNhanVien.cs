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
        public bool Them(NhanVien nhanVien)
        {
            this.dsNhanVien.Add(nhanVien);
            return true;
        }
    }
}
