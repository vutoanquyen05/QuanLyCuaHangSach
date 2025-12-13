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
        private XuLyKhachHang xuLyKhachHang;
        public KhachHangWindow()
        {
            InitializeComponent();
        }
        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            TruyCapDuLieu.docFile("KHACHHANG.txt");
            HienThiDSKhachHang();
            xuLyKhachHang = new XuLyKhachHang();
        }
        private void HienThiDSKhachHang()
        {
            List<KhachHang> dsKhachHang = TruyCapDuLieu.khoiTao().getDSKhachHang();
            dgvKhachHang.ItemsSource = null;
            dgvKhachHang.ItemsSource = dsKhachHang.ToList();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng");
                return;
            }

            KhachHang khachHangMoi = new KhachHang(txtMaKH.Text, txtTenKH.Text, txtSDT.Text, txtDiaChi.Text);
            bool ketQuaThem = xuLyKhachHang.Them(khachHangMoi);
            if (ketQuaThem)
            {
                MessageBox.Show("Thêm khách hàng thành công!");
                TruyCapDuLieu.ghiFile("KHACHHANG.txt");
                HienThiDSKhachHang();
            }
            else MessageBox.Show("Mã khách hàng đã tồn tại");
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (dgvKhachHang.SelectedItem is KhachHang khachHangCu)
            {
                KhachHang khachHangMoi = new KhachHang(txtMaKH.Text, txtTenKH.Text, txtSDT.Text, txtDiaChi.Text);
                bool ketQuaSua = xuLyKhachHang.Sua(khachHangCu, khachHangMoi);
                if (ketQuaSua)
                {
                    MessageBox.Show("Sửa khách hàng thành công!");
                    TruyCapDuLieu.ghiFile("KHACHHANG.TXT");
                    HienThiDSKhachHang();
                }
                else MessageBox.Show("Sửa khách hàng thất bại!");
            }
            else MessageBox.Show("Vui lòng chọn khách hàng cần sửa!");
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (dgvKhachHang.SelectedItem is KhachHang khachHang)
            {
                bool ketQuaXoa = xuLyKhachHang.Xoa(khachHang);
                if (ketQuaXoa)
                {
                    MessageBox.Show("Xóa khách hàng thành công!");
                    TruyCapDuLieu.ghiFile("KHACHHANG.TXT");
                    HienThiDSKhachHang();
                }
                else MessageBox.Show("Xóa khách hàng thất bại!");
            }
            else MessageBox.Show("Vui lòng chọn khách hàng cần xóa!");
        }

        private void btnLamMoi_Click(object sender, RoutedEventArgs e)
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtMaKH.Focus();
        }

        private void dgvKhachHang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvKhachHang.SelectedItem is KhachHang select)
            {
                txtMaKH.Text = select.MaKH;
                txtTenKH.Text = select.TenKH;
                txtSDT.Text = select.SoDienThoai;
                txtDiaChi.Text = select.DiaChi;
            }
        }
    }
}
