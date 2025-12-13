using QuanLyCuaHangSach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Services
{
    [Serializable]
    internal class XuLySach
    {
        private List<Sach> dsSach;
        public XuLySach()
        {
            dsSach = new List<Sach>();
            TruyCapDuLieu duLieu = TruyCapDuLieu.khoiTao();
            this.dsSach = duLieu.getDSSach();
        }
        public List<Sach> getDSSach()
        {
            return this.dsSach;
        }
        public bool KiemTraMaSach(string maSach)
        {
            foreach (Sach sach in dsSach)
                if (sach.MaSach.Equals(maSach))
                    return true;
            return false;
        }
        public bool Them(Sach sach)
        {
            if (KiemTraMaSach(sach.MaSach))
                return false;
            this.dsSach.Add(sach);
            return true;
        }
        public bool Sua(Sach sachCu, Sach sachMoi)
        {
            if (sachCu == null || sachMoi == null) return false;
            int viTri = dsSach.IndexOf(sachCu);
            if (viTri != -1)
            {
                dsSach[viTri] = sachMoi;
                return true;
            }
            return false;
        }
        public bool Xoa(Sach sach)
        {
            if (sach == null) return false;
            if (dsSach.Contains(sach))
            {
                dsSach.Remove(sach);
                return true;
            }
            return false;
        }
    }
}
