using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Models
{
    public class HoaDon
    {
        public string MaHD { get; set; }
        public string MaKH { get; set; }
        public string MaNV { get; set; }
        public DateTime NgayLap { get; set; }
        public float TongTien { get; set; }

        public List<ChiTietHoaDon> ChiTietHoaDon { get; set; } = new List<ChiTietHoaDon>();

        public override string ToString()
        {
            // Nối danh sách chi tiết thành 1 chuỗi dài, ngăn cách bằng dấu chấm phẩy ;
            string chiTietStr = string.Join(";", ChiTietHoaDon.Select(ct => ct.ToString()));

            // Lưu ngày tháng dạng năm-tháng-ngày để dễ đọc
            return $"{MaHD},{MaKH},{MaNV},{NgayLap:yyyy-MM-dd},{TongTien.ToString(CultureInfo.InvariantCulture)},{chiTietStr}";
        }
    }
}
