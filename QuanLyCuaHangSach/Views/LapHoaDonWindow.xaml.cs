using QuanLyCuaHangSach.Models;
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

namespace QuanLyCuaHangSach.Views
{
    /// <summary>
    /// Interaction logic for HoaDonWindow.xaml
    /// </summary>
    
    // Class phụ để hiển thị lên DataGrid (bao gồm Thành Tiền)
    public class GioHang
    {
        public string MaSach { get; set; }
        public int SoLuong { get; set; }
        public float DonGia { get; set; }
        public float ThanhTien => SoLuong * DonGia;
    }
    public partial class LapHoaDonWindow : Window
    {
        private List<KhachHang> dsKhachHang; // Danh sách khách hàng
        private List<NhanVien> dsNhanVien;  // Danh sách nhân viên
        private List<GioHang> gioHang = new List<GioHang>();// Giỏ hàng tạm thời
        public LapHoaDonWindow()
        {
            InitializeComponent();
        }
        private void HienThiDanhSach(DataGridView dgv, List<ChiTietHoaDon> ds)
        {
            dgv.DataSource = ds.ToList();
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

        private void btnLamMoi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dgvLapHoaDon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvLapHoaDon.SelectedItem is ChiTietHoaDon select)
            {
                txtMaSach.Text = select.MaSach;
                txtSoLuong.Text = select.SoLuong.ToString();
            }
        }
    }
}
