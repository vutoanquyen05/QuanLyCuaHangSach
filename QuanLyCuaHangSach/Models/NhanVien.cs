using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Models
{
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string ChucVu { get; set; }
        public string SDT { get; set; }
        public string MaQL { get; set; }
        public override string ToString()
        {
            return $"{MaNV},{TenNV},{ChucVu},{SDT},{MaQL}";
        }

        public static NhanVien FromCsv(string csvLine)
        {
            string[] parts = csvLine.Split(',');
            // Kiểm tra độ dài để tránh lỗi nếu file bị trống hoặc sai
            if (parts.Length != 5) return null;

            return new NhanVien
            {
                MaNV = parts[0],
                TenNV = parts[1],
                ChucVu = parts[2],
                SDT = parts[3],
                MaQL = parts[4]
            };
        }
    }
}
