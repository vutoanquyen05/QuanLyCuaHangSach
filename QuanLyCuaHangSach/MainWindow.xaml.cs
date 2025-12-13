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
            SachWindow window = new SachWindow();
            window.Show();
        }

        private void btnKhachHang_Click(object sender, RoutedEventArgs e)
        {
            KhachHangWindow window = new KhachHangWindow();
            window.Show();
        }

        private void btnNhanVien_Click(object sender, RoutedEventArgs e)
        {
            NhanVienWindow window = new NhanVienWindow();
            window.Show();
        }

        private void btnHoaDon_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLapHoaDon_Click(object sender, RoutedEventArgs e)
        {
            LapHoaDonWindow window = new LapHoaDonWindow();
            window.Show();
        }

        private void btnLocSach_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLocKhachHang_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
