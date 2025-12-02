using QuanLyCuaHangSach.DataStructures;
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
    /// Interaction logic for SachWindow.xaml
    /// </summary>
    public partial class SachWindow : Window
    {
        private LinkedListSach dsSach;
        public SachWindow()
        {
            InitializeComponent();
            dsSach = DataService.XuLySach();
            HienThiSach();
        }
        private void HienThiSach()
        {
            dgvSach.ItemsSource = dsSach.ToList();
        }

        private void LamMoi()
        {
            txtMaSach.Clear();
            txtTenSach.Clear();
            txtMaTG.Clear();
            txtMaNXB.Clear();
            txtGiaBan.Clear();
            txtSoLuong.Clear();
            txtMaSach.Focus();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            string maSach = txtMaSach.Text.Trim();

            if (string.IsNullOrEmpty(maSach))
            {
                MessageBox.Show("Mã sách không được để trống.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (dsSach.TimMaSach(maSach) != null)
            {
                MessageBox.Show("Mã sách đã tồn tại. Vui lòng nhập mã khác.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                Sach newSach = new Sach
                {
                    MaSach = maSach,
                    TenSach = txtTenSach.Text,
                    MaTG = txtMaTG.Text,
                    MaNXB = txtMaNXB.Text,
                    GiaBan = decimal.Parse(txtGiaBan.Text),
                    SoLuong = int.Parse(txtSoLuong.Text)
                };

                dsSach.Them(newSach);
                DataService.LuuSach(dsSach);
                HienThiSach();
                LamMoi();
                MessageBox.Show("Thêm sách thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng kiểm tra định dạng số (Giá bán, Tồn kho).", "Lỗi định dạng", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi hệ thống", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            string maSach = txtMaSach.Text.Trim();
            Sach sachToUpdate = dsSach.TimMaSach(maSach);

            if (sachToUpdate == null)
            {
                MessageBox.Show("Không tìm thấy sách để sửa.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                sachToUpdate.TenSach = txtTenSach.Text;
                sachToUpdate.MaTG = txtMaTG.Text;
                sachToUpdate.MaNXB = txtMaNXB.Text;
                sachToUpdate.GiaBan = decimal.Parse(txtGiaBan.Text);
                sachToUpdate.SoLuong = int.Parse(txtSoLuong.Text);

                DataService.LuuSach(dsSach);
                HienThiSach();
                MessageBox.Show("Cập nhật sách thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng kiểm tra định dạng số (Giá bán, Tồn kho).", "Lỗi định dạng", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            string maSach = txtMaSach.Text.Trim();
            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa sách có mã {maSach}?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (dsSach.XoaTheoMaSach(maSach))
                {
                    DataService.LuuSach(dsSach);
                    HienThiSach();
                    LamMoi();
                    MessageBox.Show("Xóa sách thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sách cần xóa.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, RoutedEventArgs e)
        {
            LamMoi();
        }

        private void dgvNhanVien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvSach.SelectedItem is Sach select)
            {
                txtMaSach.Text = select.MaSach;
                txtTenSach.Text = select.TenSach;
                txtMaTG.Text = select.MaTG;
                txtMaNXB.Text = select.MaNXB;
                txtGiaBan.Text = select.GiaBan.ToString();
                txtSoLuong.Text = select.SoLuong.ToString();
            }
        }
    }
}
