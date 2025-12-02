using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Models
{
    public class KhachHang
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public override string ToString()
        {
            return $"{MaKH},{TenKH},{SDT},{DiaChi}";
        }

        public static KhachHang FromCsv(string csvLine)
        {
            string[] parts = csvLine.Split(',');
            if (parts.Length != 4) return null;

            return new KhachHang
            {
                MaKH = parts[0],
                TenKH = parts[1],
                SDT = parts[2],
                DiaChi = parts[3]
            };
        }
    }
}
