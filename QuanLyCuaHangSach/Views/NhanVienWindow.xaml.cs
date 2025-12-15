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
        private XuLyNhanVien xuLyNhanVien;
        public NhanVienWindow()
        {
            InitializeComponent();
        }

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            xuLyNhanVien = new XuLyNhanVien();
            TruyCapDuLieu.khoiTao().DocNhanVien();
            HienThiDSNhanVien();
        }

        private void HienThiDSNhanVien()
        {
            List<NhanVien> dsNhanVien = TruyCapDuLieu.khoiTao().getDSNhanVien();
            dgvNhanVien.ItemsSource = null;
            dgvNhanVien.ItemsSource = dsNhanVien.ToList();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên");
                return;
            }

            NhanVien nhanVienMoi = new NhanVien(txtMaNV.Text, txtTenNV.Text, cboChucVu.Text, txtSDT.Text, txtMaQL.Text);
            bool ketQuaThem = xuLyNhanVien.Them(nhanVienMoi);
            if (ketQuaThem)
            {
                MessageBox.Show("Thêm nhân viên thành công!");
                TruyCapDuLieu.khoiTao().LuuNhanVien();
                HienThiDSNhanVien();
            }
            else MessageBox.Show("Mã nhân viên đã tồn tại");
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (dgvNhanVien.SelectedItem is NhanVien nhanVienCu)
            {
                NhanVien nhanVienMoi = new NhanVien(txtMaNV.Text, txtTenNV.Text, cboChucVu.Text, txtSDT.Text, txtMaQL.Text);
                bool ketQuaSua = xuLyNhanVien.Sua(nhanVienCu, nhanVienMoi);
                if (ketQuaSua)
                {
                    MessageBox.Show("Sửa nhân viên thành công!");
                    TruyCapDuLieu.khoiTao().LuuNhanVien();
                    HienThiDSNhanVien();
                }
                else MessageBox.Show("Sửa nhân viên thất bại!");
            }
            else MessageBox.Show("Vui lòng chọn nhân viên cần sửa!");
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (dgvNhanVien.SelectedItem is NhanVien nhanVien)
            {
                bool ketQuaXoa = xuLyNhanVien.Xoa(nhanVien);
                if (ketQuaXoa)
                {
                    MessageBox.Show("Xóa nhân viên thành công!");
                    TruyCapDuLieu.khoiTao().LuuNhanVien();
                    HienThiDSNhanVien();
                }
                else MessageBox.Show("Xóa nhân viên thất bại!");
            }
            else MessageBox.Show("Vui lòng chọn nhân viên cần xóa!");
        }

        private void btnLamMoi_Click(object sender, RoutedEventArgs e)
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            cboChucVu.SelectedIndex = -1;
            txtSDT.Clear();
            txtMaQL.Clear();
            txtMaNV.Focus();
        }

        private void btnLoc_Click(object sender, RoutedEventArgs e)
        {
            // Lấy danh sách gốc
            List<NhanVien> dsNV = TruyCapDuLieu.khoiTao().getDSNhanVien();
            List<NhanVien> dsKetQua = new List<NhanVien>();

            // Đọc dữ liệu từ TextBox và ComboBox
            string hoTen = txtLocHoTen.Text != null ? txtLocHoTen.Text.Trim() : string.Empty;
            string chucVu = cboLocChucVu.SelectedItem != null ? (cboLocChucVu.SelectedItem as ComboBoxItem).Content.ToString() : string.Empty;

            // Nếu không nhập gì và chọn "Tất cả" thì hiển thị toàn bộ
            if (string.IsNullOrEmpty(hoTen) && (string.IsNullOrEmpty(chucVu) || chucVu == "Tất cả"))
                HienThiDSNhanVien();

            // Lọc thủ công
            foreach (NhanVien nv in dsNV)
            {
                // Lọc theo họ tên
                if (!string.IsNullOrEmpty(hoTen))
                    if (string.IsNullOrEmpty(nv.TenNV) || nv.TenNV.IndexOf(hoTen, StringComparison.OrdinalIgnoreCase) < 0)
                        continue;

                // Lọc theo chức vụ
                if (!string.IsNullOrEmpty(chucVu) && chucVu != "Tất cả")
                    if (string.IsNullOrEmpty(nv.ChucVu) || nv.ChucVu.IndexOf(chucVu, StringComparison.OrdinalIgnoreCase) < 0)
                        continue;

                dsKetQua.Add(nv);
            }

            // Gán kết quả vào DataGrid
            dgvNhanVien.ItemsSource = dsKetQua;
        }


        private void dgvNhanVien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvNhanVien.SelectedItem is NhanVien select)
            {
                txtMaNV.Text = select.MaNV;
                txtTenNV.Text = select.TenNV;
                cboChucVu.Text = select.ChucVu;
                txtSDT.Text = select.SoDienThoai;
                txtMaQL.Text = select.MaQL;
            }
        }
    }
}
