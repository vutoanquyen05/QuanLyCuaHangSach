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

    public partial class LapHoaDonWindow : Window
    {
        private XuLyHoaDon xuLyHoaDon;

        // Giỏ hàng tạm thời
        private class GioHang
        {
            public string MaSach { get; set; }
            public int SoLuong { get; set; }
            public decimal DonGia { get; set; }
            public decimal ThanhTien { get { return SoLuong * DonGia; } }
        }
        private List<GioHang> gioHang = new List<GioHang>();

        public LapHoaDonWindow()
        {
            InitializeComponent();
        }

        private void HienThiDSSach()
        {
            // Lấy danh sách sách từ TruyCapDuLieu và hiển thị lên DataGrid
            List<Sach> dsSach = TruyCapDuLieu.khoiTao().getDSSach();
            dgvSach.ItemsSource = null;
            dgvSach.ItemsSource = dsSach.ToList();
        }

        private void HienThiGioHang()
        {
            dgvGioHang.ItemsSource = null;
            dgvGioHang.ItemsSource = gioHang.ToList();

            // Cập nhật tổng tiền
            decimal tongTien = 0;
            foreach (GioHang sach in gioHang)
                tongTien += sach.ThanhTien;
            txtTongTien.Text = tongTien.ToString("N0"); // Định dạng số với dấu phân cách hàng nghìn
        }

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            // Khởi tạo XuLyHoaDon và đọc dữ liệu sách
            xuLyHoaDon = new XuLyHoaDon();
            TruyCapDuLieu.khoiTao().DocSach();
            HienThiDSSach();
            HienThiGioHang();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra nhập liệu
            if (string.IsNullOrWhiteSpace(txtMaSach.Text))
                MessageBox.Show("Vui lòng nhập hoặc chọn sách");

            if (dgvSach.SelectedItem is Sach sach)
            {
                GioHang item = new GioHang()
                {
                    MaSach = sach.MaSach,
                    SoLuong = int.Parse(txtSoLuong.Text),
                    DonGia = sach.GiaBan
                };
                this.gioHang.Add(item);
                HienThiGioHang();
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (dgvGioHang.SelectedItem is GioHang item)
            {
                gioHang.Remove(item);
                HienThiGioHang();
            }
        }

        private void btnThanhToan_Click(object sender, RoutedEventArgs e)
        {
            if (gioHang.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMaHD.Text) ||
                string.IsNullOrWhiteSpace(txtMaKH.Text) ||
                string.IsNullOrWhiteSpace(txtMaNV.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text)
                )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin hóa đơn");
                return;
            }

            //Tạo hóa đơn tạm thời
            HoaDon hoaDon = new HoaDon()
            {
                MaHD = txtMaHD.Text,
                MaKH = txtMaKH.Text,
                MaNV = txtMaNV.Text,    
                SoDienThoai = txtSDT.Text,
                NgayLap = DateTime.Now,
                ChiTietHoaDon = new List<ChiTietHoaDon>()
            };

            //Thêm chi tiết từ giỏ hàng
            foreach (GioHang sach in gioHang)
            {
                ChiTietHoaDon chiTiet = new ChiTietHoaDon()
                {
                    MaHD = hoaDon.MaHD,
                    MaSach = sach.MaSach,
                    SoLuong = sach.SoLuong,
                    GiaBan = sach.DonGia
                };
                hoaDon.ChiTietHoaDon.Add(chiTiet);
            }

            //Lưu hóa đơn
            bool ketQuaThem = xuLyHoaDon.Them(hoaDon);
            if (ketQuaThem)
            {
                TruyCapDuLieu.khoiTao().LuuHoaDon();
                TruyCapDuLieu.khoiTao().LuuChiTietHoaDon();
                MessageBox.Show("Thanh toán hóa đơn thành công!");
                this.Close();
            }
            else
                MessageBox.Show("Mã hóa đơn đã tồn tại hoặc sách trong giỏ hàng không đủ số lượng!");
        }

        private void dgvSach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvSach.SelectedItem is Sach sach)
                txtMaSach.Text = sach.MaSach;
        }
    }
}
