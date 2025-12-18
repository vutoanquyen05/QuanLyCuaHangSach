using QuanLyCuaHangSach.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace QuanLyCuaHangSach.Services
{
    [Serializable]
    internal class TruyCapDuLieu
    {
        // --- ĐỊNH NGHĨA TÊN FILE CỐ ĐỊNH ---
        private const string FileSach = "Data/SACH.txt";
        private const string FileKH = "Data/KHACHHANG.txt";
        private const string FileNV = "Data/NHANVIEN.txt";
        private const string FileHD = "Data/HOADON.txt";
        private const string FileCTHD = "Data/CHITIETHOADON.txt";


        // --- CÁC DANH SÁCH DỮ LIỆU ---
        private static TruyCapDuLieu instance = null;
        private List<Sach> dsSach;
        private List<KhachHang> dsKhachHang;
        private List<NhanVien> dsNhanVien;
        private List<HoaDon> dsHoaDon;
        private List<ChiTietHoaDon> dsChiTietHoaDon;

        private TruyCapDuLieu()
        {
            dsSach = new List<Sach>();
            dsKhachHang = new List<KhachHang>();
            dsNhanVien = new List<NhanVien>();
            dsHoaDon = new List<HoaDon>();
            dsChiTietHoaDon = new List<ChiTietHoaDon>();
        }

        //--- PHƯƠNG THỨC KHỞI TẠO ---
        public static TruyCapDuLieu khoiTao()
        {
            if (instance == null)
                instance = new TruyCapDuLieu();
            return instance;
        }


        //--- CÁC PHƯƠNG THỨC LẤY DỮ LIỆU ---
        public List<Sach> getDSSach()
        {
            return dsSach;
        }
        public List<KhachHang> getDSKhachHang()
        {
            return dsKhachHang;
        }
        public List<NhanVien> getDSNhanVien()
        {
            return dsNhanVien;
        }
        public List<HoaDon> getDSHoaDon()
        {
            return dsHoaDon;
        }
        public List<ChiTietHoaDon> getDSChiTietHoaDon()
        {
            return dsChiTietHoaDon;
        }


        //--- CÁC PHƯƠNG THỨC LƯU FILE ---
        public void LuuSach()
        {
            try
            {
                // Tạo thư mục nếu chưa tồn tại
                Directory.CreateDirectory(Path.GetDirectoryName(FileSach));
                // Ghi dữ liệu vào file
                using (StreamWriter sw = new StreamWriter(FileSach, false, Encoding.UTF8))
                {
                    foreach (var s in dsSach)
                        sw.WriteLine($"{s.MaSach}|{s.TenSach}|{s.TenTG}|{s.MaNXB}|{s.GiaBan}|{s.SoLuong}");
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi lưu Sách: " + ex.Message); }
        }
        public void LuuKhachHang()
        {
            try
            {
                // Tạo thư mục nếu chưa tồn tại
                Directory.CreateDirectory(Path.GetDirectoryName(FileKH));
                // Ghi dữ liệu vào file
                using (StreamWriter sw = new StreamWriter(FileKH, false, Encoding.UTF8))
                {
                    foreach (var kh in dsKhachHang)
                        sw.WriteLine($"{kh.MaKH}|{kh.TenKH}|{kh.SoDienThoai}|{kh.DiaChi}");
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi lưu Khách Hàng: " + ex.Message); }
        }
        public void LuuNhanVien()
        {
            try
            {
                // Tạo thư mục nếu chưa tồn tại
                Directory.CreateDirectory(Path.GetDirectoryName(FileNV));
                // Ghi dữ liệu vào file
                using (StreamWriter sw = new StreamWriter(FileNV, false, Encoding.UTF8))
                {
                    foreach (var nv in dsNhanVien)
                        sw.WriteLine($"{nv.MaNV}|{nv.TenNV}|{nv.ChucVu}|{nv.SoDienThoai}|{nv.MaQL}");
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi lưu Nhân Viên: " + ex.Message); }
        }
        public void LuuHoaDon()
        {
            try
            {
                // Tạo thư mục nếu chưa tồn tại
                Directory.CreateDirectory(Path.GetDirectoryName(FileHD));
                // Ghi dữ liệu vào file
                using (StreamWriter sw = new StreamWriter(FileHD, false, Encoding.UTF8))
                {
                    foreach (var hd in dsHoaDon)
                        sw.WriteLine($"{hd.MaHD}|{hd.MaKH}|{hd.MaNV}|{hd.SoDienThoai}|{hd.NgayLap:dd/MM/yyyy HH:mm:ss}");
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi lưu Hóa Đơn: " + ex.Message); }
        }
        public void LuuChiTietHoaDon()
        {
            try
            {
                // Tạo thư mục nếu chưa tồn tại
                Directory.CreateDirectory(Path.GetDirectoryName(FileCTHD));
                // Ghi dữ liệu vào file
                using (StreamWriter sw = new StreamWriter(FileCTHD, false, Encoding.UTF8))
                {
                    //Duyệt từng hóa đơn
                    foreach (var hd in dsHoaDon)
                    {
                        //Duyệt chi tiết của hóa đơn
                        foreach (var ct in hd.ChiTietHoaDon)
                            sw.WriteLine($"{ct.MaHD}|{ct.MaSach}|{ct.TenSach}|{ct.GiaBan}|{ct.SoLuong}|{ct.ThanhTien}");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi lưu Chi Tiết Hoá Đơn: " + ex.Message); }
        }


        //--- CÁC PHƯƠNG THỨC ĐỌC FILE ---
        public void DocSach()
        {
            // Nếu file không tồn tại thì thoát
            if (!File.Exists(FileSach)) return;

            // Xóa dữ liệu cũ trong danh sách
            dsSach.Clear();
            try
            {
                // Đọc từng dòng trong file
                foreach (string line in File.ReadLines(FileSach, Encoding.UTF8))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    // Mỗi phần tử cách nhau bởi dấu '|' sẽ được lưu vào mảng p
                    string[] p = line.Split('|');

                    // Kiểm tra đủ phần tử rồi thêm vào danh sách
                    if (p.Length >= 6)
                        dsSach.Add(new Sach { MaSach = p[0], TenSach = p[1], TenTG = p[2], MaNXB = p[3], GiaBan = decimal.Parse(p[4]), SoLuong = int.Parse(p[5]) });
                }
            }
            catch { }
        }
        public void DocKhachHang()
        {
            // Nếu file không tồn tại thì thoát
            if (!File.Exists(FileKH)) return;

            // Xóa dữ liệu cũ trong danh sách
            dsKhachHang.Clear();
            try
            {
                // Đọc từng dòng trong file
                foreach (string line in File.ReadLines(FileKH, Encoding.UTF8))
                {
                    //  Nếu dòng trống thì bỏ qua
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    // Mỗi phần tử cách nhau bởi dấu '|' sẽ được lưu vào mảng p
                    string[] p = line.Split('|');

                    // Kiểm tra đủ phần tử rồi thêm vào danh sách
                    if (p.Length >= 4)
                        dsKhachHang.Add(new KhachHang { MaKH = p[0], TenKH = p[1], SoDienThoai = p[2], DiaChi = p[3] });
                }
            }
            catch { }
        }
        public void DocNhanVien()
        {
            // Nếu file không tồn tại thì thoát
            if (!File.Exists(FileNV)) return;

            // Xóa dữ liệu cũ trong danh sách
            dsNhanVien.Clear();
            try
            {
                // Đọc từng dòng trong file
                foreach (string line in File.ReadLines(FileNV, Encoding.UTF8))
                {
                    //  Nếu dòng trống thì bỏ qua
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    // Mỗi phần tử cách nhau bởi dấu '|' sẽ được lưu vào mảng p
                    string[] p = line.Split('|');

                    // Kiểm tra đủ phần tử rồi thêm vào danh sách
                    if (p.Length >= 5)
                        dsNhanVien.Add(new NhanVien { MaNV = p[0], TenNV = p[1], ChucVu = p[2], SoDienThoai = p[3], MaQL = p[4] });
                }
            }
            catch { }
        }
        public void DocHoaDon()
        {
            // Nếu file không tồn tại thì thoát
            if (!File.Exists(FileHD)) return;

            // Xóa dữ liệu cũ trong danh sách
            dsHoaDon.Clear();
            try
            {
                // Đọc từng dòng trong file
                foreach (string line in File.ReadLines(FileHD, Encoding.UTF8))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    // Mỗi phần tử cách nhau bởi dấu '|' sẽ được lưu vào mảng p
                    string[] p = line.Split('|');

                    // Kiểm tra đủ phần tử rồi thêm vào danh sách
                    if (p.Length >= 5)
                    {
                        dsHoaDon.Add(new HoaDon { MaHD = p[0], MaKH = p[1], MaNV = p[2], SoDienThoai = p[3],
                            //ParseExact yêu cầu chuỗi phải khớp chính xác với định dạng
                            //CultureInfo.InvariantCulture đảm bảo việc parse ngày giờ luôn ổn định, không bị ảnh hưởng bởi cài đặt hệ thống
                            NgayLap = DateTime.ParseExact(p[4], "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                            ChiTietHoaDon = new List<ChiTietHoaDon>() });
                    }
                }
            }
            catch { }
        }
        public void DocChiTietHoaDon()
        {
            // Nếu file không tồn tại thì thoát
            if (!File.Exists(FileCTHD)) return;

            // Xóa dữ liệu cũ trong danh sách
            dsChiTietHoaDon.Clear();
            try
            {
                // Đọc từng dòng trong file
                foreach (string line in File.ReadLines(FileCTHD, Encoding.UTF8))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    // Mỗi phần tử cách nhau bởi dấu '|' sẽ được lưu vào mảng p
                    string[] p = line.Split('|');

                    // Kiểm tra đủ phần tử rồi thêm vào danh sách
                    if (p.Length >= 5)
                    {
                        ChiTietHoaDon ct = new ChiTietHoaDon { MaHD = p[0], MaSach = p[1], TenSach = p[2], GiaBan = decimal.Parse(p[3]), SoLuong = int.Parse(p[4]) };
                        dsChiTietHoaDon.Add(ct);

                        // Ghép chi tiết vào đúng hóa đơn
                        foreach (HoaDon hd in dsHoaDon)
                        {
                            if (hd.MaHD == ct.MaHD)
                            {
                                hd.ChiTietHoaDon.Add(ct);
                                break;
                            }
                        }
                    }
                }
            }
            catch { }
        }
    }
}
