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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuanLyCuaHangSach.Views
{
    /// <summary>
    /// Interaction logic for KhachHangWindow.xaml
    /// </summary>
    public partial class KhachHangWindow : Window
    {
        private List<KhachHang> dsKhachHang;
        public KhachHangWindow()
        {
            InitializeComponent();
            XuLyDuLieu();
        }
        private void XuLyDuLieu()
        {
            dsKhachHang = DataService.XuLyKhachHang();
            dgvKhachHang.ItemsSource = null; // Reset
            dgvKhachHang.ItemsSource = dsKhachHang;
        }

        private void LamMoi()
        {
            txtMaKH.Clear(); txtTenKH.Clear(); txtSDT.Clear(); txtDiaChi.Clear();
            txtMaKH.Focus();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text)) { MessageBox.Show("Vui lòng nhập Mã KH"); return; }

            // Kiểm tra trùng Mã
            if (dsKhachHang.Any(x => x.MaKH == txtMaKH.Text))
            {
                MessageBox.Show("Mã Khách hàng này đã tồn tại!"); return;
            }

            var khMoi = new KhachHang
            {
                MaKH = txtMaKH.Text,
                TenKH = txtTenKH.Text,
                SDT = txtSDT.Text,
                DiaChi = txtDiaChi.Text
            };

            dsKhachHang.Add(khMoi);
            DataService.LuuKhachHang(dsKhachHang); // Lưu file ngay
            XuLyDuLieu();
            LamMoi();
            MessageBox.Show("Thêm thành công!");
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            var khCanSua = dsKhachHang.FirstOrDefault(x => x.MaKH == txtMaKH.Text);
            if (khCanSua == null) { MessageBox.Show("Không tìm thấy Mã KH để sửa"); return; }

            khCanSua.TenKH = txtTenKH.Text;
            khCanSua.SDT = txtSDT.Text;
            khCanSua.DiaChi = txtDiaChi.Text;

            DataService.LuuKhachHang(dsKhachHang);
            XuLyDuLieu();
            MessageBox.Show("Cập nhật thành công!");
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            var khCanXoa = dsKhachHang.FirstOrDefault(x => x.MaKH == txtMaKH.Text);
            if (khCanXoa != null)
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa?", "Xác nhận", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    dsKhachHang.Remove(khCanXoa);
                    DataService.LuuKhachHang(dsKhachHang);
                    XuLyDuLieu();
                    LamMoi();
                }
            }
        }

        private void btnLamMoi_Click(object sender, RoutedEventArgs e)
        {
            LamMoi();
        }

        // Chọn dòng trong bảng thì hiện lên ô nhập
        private void dgvKhachHang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvKhachHang.SelectedItem is KhachHang select)
            {
                txtMaKH.Text = select.MaKH;
                txtTenKH.Text = select.TenKH;
                txtSDT.Text = select.SDT;
                txtDiaChi.Text = select.DiaChi;
            }
        }
    }
}
