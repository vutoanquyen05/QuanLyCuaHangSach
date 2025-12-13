using QuanLyCuaHangSach.DataStructures;
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
        private List<KhachHang> dsKhachHang;
        private LinkedListSach dsSach;
        public MainWindow()
        {
            InitializeComponent();
            XuLyDuLieu();
        }

        private void btnKho_Click(object sender, RoutedEventArgs e)
        {

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

        private void XuLyDuLieu()
        {
            //Dữ liệu khách hàng
            dsKhachHang = DataService.XuLyKhachHang();
            dgvKhachHang.ItemsSource = null; // Reset
            dgvKhachHang.ItemsSource = dsKhachHang;

            //Dữ liệu sách
            dsSach = DataService.XuLySach();
            dgvSach.ItemsSource = dsSach.ToList();
        }

        private void btnLocSach_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLocKhachHang_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
