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
            // Khởi tạo danh sách
            this.dsSach = new List<Sach>();

            // Đổ dữ liệu từ TruyCapDuLieu vào danh sách
            this.dsSach = TruyCapDuLieu.khoiTao().getDSSach();
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
            if (sach == null) return false;
            if (!KiemTraMaSach(sach.MaSach))
            {
                dsSach.Add(sach);
                return true;
            }
            return false;
        }
        public bool Sua(Sach sachCu, Sach sachMoi)
        {
            if (sachCu == null || sachMoi == null) return false;

            // Lấy vị trí của sách cũ trong danh sách, nếu không có thì viTri = -1
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
