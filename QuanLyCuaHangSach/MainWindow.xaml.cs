using QuanLyCuaHangSach.Models;
using QuanLyCuaHangSach.Services;
using QuanLyCuaHangSach.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuanLyCuaHangSach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            TruyCapDuLieu.khoiTao().DocKhachHang();
            HienThiDSKhachHang();

            TruyCapDuLieu.khoiTao().DocSach();
            HienThiDSSach();
        }

        private void HienThiDSSach()
        {
            List<Sach> dsSach = TruyCapDuLieu.khoiTao().getDSSach();
            dgvSach.ItemsSource = null;
            dgvSach.ItemsSource = dsSach.ToList();
        }

        private void HienThiDSKhachHang()
        {
            List<KhachHang> dsKhachHang = TruyCapDuLieu.khoiTao().getDSKhachHang();
            dgvKhachHang.ItemsSource = null;
            dgvKhachHang.ItemsSource = dsKhachHang.ToList();
        }

        private void btnSach_Click(object sender, RoutedEventArgs e)
        {
            Window window = Application.Current.Windows.OfType<SachWindow>().FirstOrDefault();
            if (window == null)
                new SachWindow().Show();
            else
                window.Activate();
        }

        private void btnKhachHang_Click(object sender, RoutedEventArgs e)
        {
            Window window = Application.Current.Windows.OfType<KhachHangWindow>().FirstOrDefault();
            if (window == null)
                new KhachHangWindow().Show();
            else
                window.Activate();
        }

        private void btnNhanVien_Click(object sender, RoutedEventArgs e)
        {
            Window window = Application.Current.Windows.OfType<NhanVienWindow>().FirstOrDefault();
            if (window == null)
                new NhanVienWindow().Show();
            else
                window.Activate();
        }

        private void btnHoaDon_Click(object sender, RoutedEventArgs e)
        {
            Window window = Application.Current.Windows.OfType<HoaDonWindow>().FirstOrDefault();
            if (window == null)
                new HoaDonWindow().Show();
            else
                window.Activate();
        }

        private void btnLapHoaDon_Click(object sender, RoutedEventArgs e)
        {
            Window window = Application.Current.Windows.OfType<LapHoaDonWindow>().FirstOrDefault();
            if (window == null)
                new LapHoaDonWindow().Show();
            else
                window.Activate();
        }

        private void btnLamMoi_Click(object sender, RoutedEventArgs e)
        {
            TruyCapDuLieu.khoiTao().DocKhachHang();
            HienThiDSKhachHang();

            TruyCapDuLieu.khoiTao().DocSach();
            HienThiDSSach();
        }

        private void btnLocSach_Click(object sender, RoutedEventArgs e)
        {
            // Lấy danh sách gốc
            List<Sach> dsSach = TruyCapDuLieu.khoiTao().getDSSach();
            List<Sach> dsKetQua = new List<Sach>();

            // Đọc dữ liệu từ TextBox
            string maSach = txtLocMaSach.Text != null ? txtLocMaSach.Text.Trim() : string.Empty;
            string tenSach = txtLocTenSach.Text != null ? txtLocTenSach.Text.Trim() : string.Empty;

            // Nếu không nhập gì thì hiển thị toàn bộ
            if (string.IsNullOrEmpty(maSach) && string.IsNullOrEmpty(tenSach))
                HienThiDSSach();

            // Lọc thủ công
            foreach (Sach s in dsSach)
            {
                // Kiểm tra MaSach
                if (!string.IsNullOrEmpty(maSach))
                    if (string.IsNullOrEmpty(s.MaSach) || s.MaSach.IndexOf(maSach, StringComparison.OrdinalIgnoreCase) < 0)
                        continue;

                // Kiểm tra TenSach
                if (!string.IsNullOrEmpty(tenSach))
                    if (string.IsNullOrEmpty(s.TenSach) || s.TenSach.IndexOf(tenSach, StringComparison.OrdinalIgnoreCase) < 0)
                        continue;

                dsKetQua.Add(s);
            }
            // Gán kết quả vào DataGrid
            dgvSach.ItemsSource = dsKetQua;
        }

        private void btnLocKhachHang_Click(object sender, RoutedEventArgs e)
        {
            // Lấy danh sách gốc
            List<KhachHang> dsKH = TruyCapDuLieu.khoiTao().getDSKhachHang();
            List<KhachHang> dsKetQua = new List<KhachHang>();

            // Đọc dữ liệu từ TextBox
            string hoTen = txtLocHoTen.Text != null ? txtLocHoTen.Text.Trim() : string.Empty;
            string sdt = txtLocSDT.Text != null ? txtLocSDT.Text.Trim() : string.Empty;

            // Nếu không nhập gì thì hiển thị toàn bộ
            if (string.IsNullOrEmpty(hoTen) && string.IsNullOrEmpty(sdt))
                HienThiDSKhachHang();

            // Lọc thủ công
            foreach (KhachHang kh in dsKH)
            {
                if (!string.IsNullOrEmpty(hoTen))
                    if (string.IsNullOrEmpty(kh.TenKH) || kh.TenKH.IndexOf(hoTen, StringComparison.OrdinalIgnoreCase) < 0)
                        continue;

                if (!string.IsNullOrEmpty(sdt))
                    if (string.IsNullOrEmpty(kh.SoDienThoai) || kh.SoDienThoai.IndexOf(sdt, StringComparison.OrdinalIgnoreCase) < 0)
                        continue;

                dsKetQua.Add(kh);
            }

            // Gán kết quả vào DataGrid
            dgvKhachHang.ItemsSource = dsKetQua;
        }
    }
}
