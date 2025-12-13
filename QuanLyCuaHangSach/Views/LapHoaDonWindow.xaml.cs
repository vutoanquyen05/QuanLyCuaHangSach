using QuanLyCuaHangSach.Models;
using QuanLyCuaHangSach.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace QuanLyCuaHangSach.Views
{
    /// <summary>
    /// Interaction logic for LapHoaDonWindow.xaml
    /// </summary>
    public class GioHang
    {
        public string MaSach { get; set; }
        public int SoLuong { get; set; }
        public float DonGia { get; set; }
        public float ThanhTien => SoLuong * DonGia;
    }
    public partial class LapHoaDonWindow : Window
    {
        private List<Sach> Sach;
        private List<KhachHang> dsKhachHang;
        private List<NhanVien> dsNhanVien;

        private List<GioHang> gioHang = new List<GioHang>();
        public LapHoaDonWindow()
        {
            InitializeComponent();
        }

        private void HienThiDanhSach(DataGridView dgv, List<ChiTietHoaDon> ds)
        {

        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dgvSach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgvGioHang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnThanhToan_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
