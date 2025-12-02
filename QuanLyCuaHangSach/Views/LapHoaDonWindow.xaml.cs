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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

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
        private LinkedListSach khoSach;     // Danh sách sách trong kho (Linked List)
        private List<KhachHang> dsKhachHang; // Danh sách khách hàng
        private List<NhanVien> dsNhanVien;  // Danh sách nhân viên

        private List<GioHang> gioHang = new List<GioHang>();// Giỏ hàng tạm thời
        public LapHoaDonWindow()
        {
            InitializeComponent();
            XuLyDuLieu();
        }

        private void XuLyDuLieu()
        {
            // 1. Tải toàn bộ dữ liệu vào bộ nhớ để kiểm tra Khóa Ngoại (FK)
            khoSach = DataService.XuLySach();
            dsKhachHang = DataService.XuLyKhachHang();
            dsNhanVien = DataService.XuLyNhanVien();
            // Tự động tạo mã hóa đơn ngẫu nhiên cho tiện (Ví dụ: HD + GiờPhútGiây)
            txtMaHD.Text = "HD" + DateTime.Now.ToString("mmss");
        }

        private void HienThiDanhSach(DataGridView dgv, List<ChiTietHoaDon> ds)
        {
            dgv.DataSource = ds.ToList();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            string maSach = txtMaSach.Text.Trim();

            // Kiểm tra nhập số lượng
            if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương.", "Lỗi nhập liệu");
                return;
            }

            // Kiểm tra Sách có tồn tại kh (Tìm trong Linked List)
            Sach sachTrongKho = khoSach.TimMaSach(maSach);
            if (sachTrongKho == null)
            {
                MessageBox.Show("Mã sách không tồn tại trong kho!", "Lỗi khóa ngoại");
                return;
            }

            // Kiểm tra Tồn kho 
            if (sachTrongKho.SoLuong < soLuong)
            {
                MessageBox.Show($"Không đủ hàng! Kho chỉ còn {sachTrongKho.SoLuong} cuốn.", "Hết hàng");
                return;
            }

            // Thêm vào giỏ hàng tạm
            var item = new GioHang
            {
                MaSach = sachTrongKho.MaSach,
                SoLuong = soLuong,
                DonGia = (float)sachTrongKho.GiaBan
            };
            gioHang.Add(item);

            // Cập nhật giao diện
            CapNhatGioHang();

            // Xóa ô nhập để nhập tiếp
            txtMaSach.Clear();
            txtSoLuong.Clear();
            txtMaSach.Focus();
        }

        private void CapNhatGioHang()
        {
            // Mẹo để làm mới DataGrid trong WPF
            dgvLapHoaDon.ItemsSource = null;
            dgvLapHoaDon.ItemsSource = gioHang;

            // Tính tổng tiền
            float total = gioHang.Sum(x => x.ThanhTien);
            // Hiển thị tiền có dấu phẩy ngăn cách (N0)
            txtTongTien.Text = total.ToString("N0") + " VNĐ";
        }

        private void btnThanhToan_Click(object sender, RoutedEventArgs e)
        {
            if (gioHang.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống!", "Cảnh báo");
                return;
            }

            string maKH = txtMaKH.Text.Trim();
            string maNV = txtMaNV.Text.Trim();

            // Kiểm tra Khóa Ngoại (Khách hàng & Nhân viên)
            // (Mô phỏng việc CSDL kiểm tra ràng buộc FK)
            bool khachTonTai = false;
            foreach (var kh in dsKhachHang) { if (kh.MaKH == maKH) { khachTonTai = true; break; } }

            bool nhanVienTonTai = false;
            foreach (var nv in dsNhanVien) { if (nv.MaNV == maNV) { nhanVienTonTai = true; break; } }

            if (!khachTonTai)
            {
                MessageBox.Show("Mã Khách hàng không tồn tại! Vui lòng kiểm tra lại.", "Lỗi khóa ngoại");
                return;
            }
            if (!nhanVienTonTai)
            {
                MessageBox.Show("Mã Nhân viên không tồn tại!", "Lỗi khóa ngoại");
                return;
            }

            try
            {
                // Tạo đối tượng Hóa Đơn
                HoaDon hdMoi = new HoaDon
                {
                    MaHD = txtMaHD.Text,
                    MaKH = maKH,
                    MaNV = maNV,
                    NgayLap = DateTime.Now,
                    TongTien = gioHang.Sum(x => x.ThanhTien)
                };

                // Chuyển đổi từ Giỏ hàng hiển thị sang Chi tiết hóa đơn lưu trữ
                foreach (var item in gioHang)
                {
                    hdMoi.ChiTietHoaDon.Add(new ChiTietHoaDon
                    {
                        MaSach = item.MaSach,
                        SoLuong = item.SoLuong,
                        DonGia = item.DonGia
                    });

                    // CẬP NHẬT TỒN KHO 
                    // Tìm lại sách trong Linked List và trừ tồn kho
                    Sach s = khoSach.TimMaSach(item.MaSach);
                    if (s != null)
                    {
                        s.SoLuong = s.SoLuong - item.SoLuong;
                    }
                }

                // LƯU DỮ LIỆU
                // Lưu Hóa đơn (vào file HOADON.txt)
                DataService.XuLyHoaDon(hdMoi);

                // Lưu lại Kho sách (Ghi đè file SACH.txt với số lượng tồn kho MỚI)
                DataService.LuuSach(khoSach);

                MessageBox.Show("Lập hóa đơn thành công! Tồn kho đã được cập nhật.", "Thành công");
                this.Close(); // Đóng cửa sổ này
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}", "Lỗi hệ thống");
            }
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
