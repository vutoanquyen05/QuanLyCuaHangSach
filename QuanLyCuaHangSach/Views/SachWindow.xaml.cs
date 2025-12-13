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
    /// Interaction logic for SachWindow.xaml
    /// </summary>
    public partial class SachWindow : Window
    {
        private XuLySach xuLySach;

        public SachWindow()
        {
            InitializeComponent();
        }

        private void HienThiDSSach()
        {
            List<Sach> dsSach = TruyCapDuLieu.khoiTao().getDSSach();
            dgvSach.ItemsSource = null;
            dgvSach.ItemsSource = dsSach.ToList();
        }

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            xuLySach = new XuLySach();
            TruyCapDuLieu.khoiTao().DocSach();
            HienThiDSSach();

        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSach.Text)) 
            { 
                MessageBox.Show("Vui lòng nhập mã khách hàng");
                return;
            }

            Sach sachMoi = new Sach(txtMaSach.Text, txtTenSach.Text, txtMaTG.Text, txtMaNXB.Text, decimal.Parse(txtGiaBan.Text), int.Parse(txtSoLuong.Text));
            bool ketQuaThem = xuLySach.Them(sachMoi);
            if (ketQuaThem)
            {
                MessageBox.Show("Thêm sách thành công!");
                TruyCapDuLieu.khoiTao().LuuSach();
                HienThiDSSach();
            }
            else MessageBox.Show("Mã sách đã tồn tại");
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (dgvSach.SelectedItem is Sach sachCu)
            {
                Sach sachMoi = new Sach(txtMaSach.Text, txtTenSach.Text, txtMaTG.Text, txtMaNXB.Text, decimal.Parse(txtGiaBan.Text), int.Parse(txtSoLuong.Text));
                bool ketQuaSua = xuLySach.Sua(sachCu, sachMoi);
                if (ketQuaSua)
                {
                    MessageBox.Show("Sửa sách thành công!");
                    TruyCapDuLieu.khoiTao().LuuSach();
                    HienThiDSSach();
                }
                else MessageBox.Show("Sửa sách thất bại!");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sách cần sửa!");
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (dgvSach.SelectedItem is Sach sach)
            {
                bool ketQuaXoa = xuLySach.Xoa(sach);
                if (ketQuaXoa)
                {
                    MessageBox.Show("Xóa sách thành công!");
                    TruyCapDuLieu.khoiTao().LuuSach();
                    HienThiDSSach();
                }
                else MessageBox.Show("Xóa sách thất bại!");
            }
            else MessageBox.Show("Vui lòng chọn sách cần xóa!");
        }

        private void btnLamMoi_Click(object sender, RoutedEventArgs e)
        {
            txtMaSach.Clear();
            txtTenSach.Clear();
            txtMaTG.Clear();
            txtMaNXB.Clear();
            txtGiaBan.Clear();
            txtSoLuong.Clear();
            txtMaSach.Focus();
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
