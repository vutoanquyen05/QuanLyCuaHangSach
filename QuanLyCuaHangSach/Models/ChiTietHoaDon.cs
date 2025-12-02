using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Models
{
    internal class ChiTietHoaDon
    {
        public string MaSach { get; set; }
        public int SoLuong { get; set; }
        public float DonGia { get; set; }
        public override string ToString()
        {
            return $"{MaSach}|{SoLuong}|{DonGia.ToString(CultureInfo.InvariantCulture)}";
        }

        // Đọc từ chuỗi file ra đối tượng
        public static ChiTietHoaDon FromString(string detailString)
        {
            string[] subParts = detailString.Split('|');
            if (subParts.Length != 3) return null;

            return new ChiTietHoaDon
            {
                MaSach = subParts[0],
                SoLuong = int.Parse(subParts[1]),
                DonGia = float.Parse(subParts[2], CultureInfo.InvariantCulture)
            };
        }
    }
}
