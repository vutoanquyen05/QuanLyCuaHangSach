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
    /// Interaction logic for HoaDonWindow.xaml
    /// </summary>
    public partial class HoaDonWindow : Window
    {
        private XuLyHoaDon xuLyHoaDon;
        public HoaDonWindow()
        {
            InitializeComponent();
        }

        private void HienThiDSHoaDon(List<HoaDon> dsHoaDon)
        {
            dgvHoaDon.ItemsSource = null;
            dgvHoaDon.ItemsSource = dsHoaDon.ToList();

            //Cập nhật số lượng hóa đơn
            txtSoLuongHD.Text = dsHoaDon.Count.ToString();

            // Tính và cập nhật tổng doanh thu
            decimal tongDoanhThu = 0;
            foreach (HoaDon hd in dsHoaDon)
                tongDoanhThu += hd.TongTien;
            txtTongDoanhThu.Text = tongDoanhThu.ToString("N0");
        }

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            // Thiết lập giá trị mặc định cho DatePicker
            DateTime today = DateTime.Now;
            dtpTuNgay.SelectedDate = new DateTime(today.Year, today.Month, 1); // Ngày 1 đầu tháng
            dtpDenNgay.SelectedDate = today;

            // Đọc dữ liệu từ file
            TruyCapDuLieu.khoiTao().DocSach();
            TruyCapDuLieu.khoiTao().DocHoaDon();
            TruyCapDuLieu.khoiTao().DocChiTietHoaDon();

            xuLyHoaDon = new XuLyHoaDon();

            // Hiển thị danh sách hóa đơn
            List<HoaDon> dsHoaDon = TruyCapDuLieu.khoiTao().getDSHoaDon();
            HienThiDSHoaDon(dsHoaDon);
        }

        private void btnHienThiTatCa_Click(object sender, RoutedEventArgs e)
        {
            DateTime today = DateTime.Now;
            dtpTuNgay.SelectedDate = new DateTime(today.Year, today.Month, 1); // Ngày 1 đầu tháng
            dtpDenNgay.SelectedDate = today;
            HienThiDSHoaDon(xuLyHoaDon.GetDSHoaDon());
        }

        private void btnLoc_Click(object sender, RoutedEventArgs e)
        {
            // Lọc hóa đơn theo khoảng thời gian
            if (dtpTuNgay.SelectedDate != null && dtpDenNgay.SelectedDate != null)
            {
                DateTime tuNgay = dtpTuNgay.SelectedDate.Value.Date; // Lấy phần ngày, bỏ phần giờ (00:00:00)
                DateTime denNgay = dtpDenNgay.SelectedDate.Value.Date.AddDays(1).AddSeconds(-1); // Lấy đến 23:59:59 của ngày kết thúc

                // Lọc danh sách và hiển thị kết quả lên DataGrid
                List<HoaDon> ketQuaLoc = new List<HoaDon>();
                foreach (HoaDon hd in xuLyHoaDon.GetDSHoaDon())
                {
                    if (hd.NgayLap >= tuNgay && hd.NgayLap <= denNgay)
                        ketQuaLoc.Add(hd);
                }
                HienThiDSHoaDon(ketQuaLoc);
            }
            else MessageBox.Show("Vui lòng chọn thời gian!");
        }
    }
}
