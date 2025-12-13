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
        public bool Them(Sach sach)
        {
            this.dsSach.Add(sach);
            return true;
        }
    }
}
