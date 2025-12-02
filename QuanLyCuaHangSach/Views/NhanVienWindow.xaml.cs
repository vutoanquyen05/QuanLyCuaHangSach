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
    /// Interaction logic for NhanVienWindow.xaml
    /// </summary>
    public partial class NhanVienWindow : Window
    {
        private List<NhanVien> dsNhanVien;
        public NhanVienWindow()
        {
            InitializeComponent();
            XuLyDuLieu();
        }
        private void XuLyDuLieu()
        {
            dsNhanVien = DataService.XuLyNhanVien();
            dgvNhanVien.ItemsSource = null;
            dgvNhanVien.ItemsSource = dsNhanVien;
        }

        private void LamMoi()
        {
            txtMaNV.Clear(); txtTenNV.Clear(); txtChucVu.Clear(); txtSDT.Clear(); txtMaQL.Clear();
            txtMaNV.Focus();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text)) { MessageBox.Show("Nhập Mã NV đi bạn ơi!"); return; }
            if (dsNhanVien.Any(x => x.MaNV == txtMaNV.Text)) { MessageBox.Show("Mã này có rồi!"); return; }

            var nvMoi = new NhanVien
            {
                MaNV = txtMaNV.Text,
                TenNV = txtTenNV.Text,
                ChucVu = txtChucVu.Text,
                SDT = txtSDT.Text,
                MaQL = txtMaQL.Text
            };

            dsNhanVien.Add(nvMoi);
            DataService.LuuNhanVien(dsNhanVien); // Lưu luôn
            XuLyDuLieu();
            LamMoi();
            MessageBox.Show("Thêm nhân viên thành công!");
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            var nv = dsNhanVien.FirstOrDefault(x => x.MaNV == txtMaNV.Text);
            if (nv == null) { MessageBox.Show("Không tìm thấy NV này"); return; }

            nv.TenNV = txtTenNV.Text;
            nv.ChucVu = txtChucVu.Text;
            nv.SDT = txtSDT.Text;
            nv.MaQL = txtMaQL.Text;

            DataService.LuuNhanVien(dsNhanVien);
            XuLyDuLieu();
            MessageBox.Show("Sửa xong rồi nha!");
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            var nv = dsNhanVien.FirstOrDefault(x => x.MaNV == txtMaNV.Text);
            if (nv != null && MessageBox.Show("Xóa thật không?", "Hỏi nhỏ", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                dsNhanVien.Remove(nv);
                DataService.LuuNhanVien(dsNhanVien);
                XuLyDuLieu();
                LamMoi();
            }
        }

        private void btnLamMoi_Click(object sender, RoutedEventArgs e)
        {
            LamMoi();
        }

        private void dgvNhanVien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvNhanVien.SelectedItem is NhanVien select)
            {
                txtMaNV.Text = select.MaNV;
                txtTenNV.Text = select.TenNV;
                txtChucVu.Text = select.ChucVu;
                txtSDT.Text = select.SDT;
                txtMaQL.Text = select.MaQL;
            }
        }
    }
}
