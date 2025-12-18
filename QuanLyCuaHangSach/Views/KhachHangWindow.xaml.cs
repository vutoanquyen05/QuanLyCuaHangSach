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

        private void HienThiDSKhachHang()
        {
            // Lấy danh sách khách hàng từ TruyCapDuLieu và hiển thị lên DataGrid
            List<KhachHang> dsKhachHang = TruyCapDuLieu.khoiTao().getDSKhachHang();
            dgvKhachHang.ItemsSource = null;
            dgvKhachHang.ItemsSource = dsKhachHang.ToList();
        }

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            // Khởi tạo XuLyKhachHang và đọc dữ liệu khách hàng
            xuLyKhachHang = new XuLyKhachHang();
            TruyCapDuLieu.khoiTao().DocKhachHang();
            HienThiDSKhachHang();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
                MessageBox.Show("Vui lòng nhập mã khách hàng");

            KhachHang khachHangMoi = new KhachHang(txtMaKH.Text, txtTenKH.Text, txtSDT.Text, txtDiaChi.Text);
            bool ketQuaThem = xuLyKhachHang.Them(khachHangMoi);

            if (ketQuaThem)
            {
                MessageBox.Show("Thêm khách hàng thành công!");
                TruyCapDuLieu.khoiTao().LuuKhachHang();
                HienThiDSKhachHang();
            }
            else
                MessageBox.Show("Mã khách hàng đã tồn tại");
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
                    TruyCapDuLieu.khoiTao().LuuKhachHang();
                    HienThiDSKhachHang();
                }
                else
                    MessageBox.Show("Sửa khách hàng thất bại!");
            }
            else
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa!");
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (dgvKhachHang.SelectedItem is KhachHang khachHang)
            {
                bool ketQuaXoa = xuLyKhachHang.Xoa(khachHang);

                if (ketQuaXoa)
                {
                    MessageBox.Show("Xóa khách hàng thành công!");
                    TruyCapDuLieu.khoiTao().LuuKhachHang();
                    HienThiDSKhachHang();
                }
                else
                    MessageBox.Show("Xóa khách hàng thất bại!");
            }
            else
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!");
        }

        private void btnLamMoi_Click(object sender, RoutedEventArgs e)
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtMaKH.Focus();
        }

        private void btnLoc_Click(object sender, RoutedEventArgs e)
        {
            // Lấy danh sách gốc
            List<KhachHang> dsKH = TruyCapDuLieu.khoiTao().getDSKhachHang();
            List<KhachHang> dsKetQua = new List<KhachHang>();

            // Đọc dữ liệu từ TextBox
            string hoTen = txtLocHoTen.Text != null ? txtLocHoTen.Text.Trim() : string.Empty;
            string sdt = txtLocSDT.Text != null ? txtLocSDT.Text.Trim() : string.Empty;

            if (string.IsNullOrEmpty(hoTen) && string.IsNullOrEmpty(sdt))
                HienThiDSKhachHang();

            foreach (KhachHang kh in dsKH)
            {
                // Lọc theo họ tên
                if (!string.IsNullOrEmpty(hoTen))
                    if (string.IsNullOrEmpty(kh.TenKH) || kh.TenKH.IndexOf(hoTen, StringComparison.OrdinalIgnoreCase) < 0)
                        continue;

                // Lọc theo số điện thoại
                if (!string.IsNullOrEmpty(sdt))
                    if (string.IsNullOrEmpty(kh.SoDienThoai) || kh.SoDienThoai.IndexOf(sdt, StringComparison.OrdinalIgnoreCase) < 0)
                        continue;

                dsKetQua.Add(kh);
            }

            // Gán kết quả vào DataGrid
            dgvKhachHang.ItemsSource = dsKetQua;
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
