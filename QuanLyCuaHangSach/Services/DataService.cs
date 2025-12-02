using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using QuanLyCuaHangSach.DataStructures;
using QuanLyCuaHangSach.Models;

namespace QuanLyCuaHangSach.Services
{
    public static class DataService
    {
        // Định nghĩa đường dẫn các file dữ liệu
        private const string Sachtxt = "Data/SACH.txt";
        private const string KhachHangtxt = "Data/KHACHHANG.txt";
        private const string NhanVientxt = "Data/NHANVIEN.txt";
        private const string HoaDontxt = "Data/HOADON.txt";

        static DataService()
        {
            if (!Directory.Exists("Data")) Directory.CreateDirectory("Data");
        }

        //  LÝ SÁCH (LINKED LIST)
        public static LinkedListSach XuLySach()
        {
            LinkedListSach list = new LinkedListSach();
            if (!File.Exists(Sachtxt)) return list;

            try
            {
                string[] lines = File.ReadAllLines(Sachtxt);
                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    try { list.Them(Sach.FromCsv(line)); } catch { }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc file Sách: " + ex.Message);
            }
            return list;
        }

        public static void LuuSach(LinkedListSach books)
        {
            try
            {
                List<string> lines = books.ToList().Select(s => s.ToString()).ToList();
                File.WriteAllLines(Sachtxt, lines);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu file Sách: " + ex.Message);
            }
        }

        //  XỬ LÝ KHÁCH HÀNG (LIST)
        public static List<KhachHang> XuLyKhachHang()
        {
            List<KhachHang> list = new List<KhachHang>();
            if (!File.Exists(KhachHangtxt)) return list;

            try
            {
                foreach (string line in File.ReadAllLines(KhachHangtxt))
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        var kh = KhachHang.FromCsv(line);
                        if (kh != null) list.Add(kh);
                    }
                }
            }
            catch { }
            return list;
        }

        // XỬ LÝ NHÂN VIÊN (LIST) 
        public static List<NhanVien> XuLyNhanVien()
        {
            List<NhanVien> list = new List<NhanVien>();
            if (!File.Exists(NhanVientxt)) return list;

            try
            {
                foreach (string line in File.ReadAllLines(NhanVientxt))
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        var nv = NhanVien.FromCsv(line);
                        if (nv != null) list.Add(nv);
                    }
                }
            }
            catch { }
            return list;
        }

        // XỬ LÝ HÓA ĐƠN (GHI THÊM - APPEND) 
        public static void XuLyHoaDon(HoaDon invoice)
        {
            try
            {
                // Ghi nối tiếp vào cuối file thay vì ghi đè
                string line = invoice.ToString() + Environment.NewLine;
                File.AppendAllText(HoaDontxt, line, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu Hóa đơn: " + ex.Message);
            }
        }


        // HÀM LƯU KHÁCH HÀNG
        public static void LuuKhachHang(List<KhachHang> customers)
        {
            try
            {
                // Chuyển danh sách thành các dòng text
                List<string> lines = new List<string>();
                foreach (var kh in customers)
                {
                    lines.Add(kh.ToString()); // Gọi hàm ToString() của KhachHang
                }

                // Ghi đè xuống file
                File.WriteAllLines(KhachHangtxt, lines, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu file Khách hàng: " + ex.Message);
            }
        }


        //HÀM LƯU NHÂN VIÊN
        public static void LuuNhanVien(List<NhanVien> employees)
        {
            try
            {
                List<string> lines = new List<string>();
                foreach (var nv in employees)
                {
                    lines.Add(nv.ToString()); // Gọi hàm ToString() của NhanVien
                }

                File.WriteAllLines(NhanVientxt, lines, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu file Nhân viên: " + ex.Message);
            }
        }

    }
}