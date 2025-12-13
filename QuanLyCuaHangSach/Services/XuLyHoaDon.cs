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
        public bool Them(HoaDon hoaDon)
        {
            this.dsHoaDon.Add(hoaDon);
            return true;
        }
    }
}
