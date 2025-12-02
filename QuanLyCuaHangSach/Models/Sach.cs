using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Models
{
    public class Sach
    {
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public string MaTG { get; set; }     // FK: Mã Tác giả
        public string MaNXB { get; set; }    // FK: Mã NXB
        public decimal GiaBan { get; set; }
        public int SoLuong { get; set; }

        // Phương thức chuyển đổi đối tượng thành chuỗi CSV để ghi file
        public override string ToString()
        {
            // Sử dụng InvariantCulture để đảm bảo dấu thập phân là '.' khi ghi file
            return $"{MaSach},{TenSach},{MaTG},{MaNXB},{GiaBan.ToString(CultureInfo.InvariantCulture)},{TonKho}";
        }

        // Phương thức tạo đối tượng từ chuỗi CSV (cần cho Xử Lý)
        public static Sach FromCsv(string csvLine)
        {
            string[] parts = csvLine.Split(',');
            if (parts.Length != 6) throw new FormatException("Định dạng CSV không hợp lệ cho Sách.");

            return new Sach
            {
                MaSach = parts[0],
                TenSach = parts[1],
                MaTG = parts[2],
                MaNXB = parts[3],
                // Sử dụng InvariantCulture để đọc dấu thập phân '.'
                GiaBan = decimal.Parse(parts[4], CultureInfo.InvariantCulture),
                SoLuong = int.Parse(parts[5])
            };
        }
}
