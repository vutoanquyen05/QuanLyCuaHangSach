using QuanLyCuaHangSach.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Services
{
    [Serializable]
    internal class TruyCapDuLieu
    {
        private static TruyCapDuLieu instance = null;
        private List<Sach> dsSach;
        private List<KhachHang> dsKhachHang;
        private List<NhanVien> dsNhanVien;
        private List<HoaDon> dsHoaDon;
        private List<ChiTietHoaDon> dsChiTietHoaDon;

        private TruyCapDuLieu()
        {
            dsSach = new List<Sach>();
            dsKhachHang = new List<KhachHang>();
            dsNhanVien = new List<NhanVien>();
            dsHoaDon = new List<HoaDon>();
            dsChiTietHoaDon = new List<ChiTietHoaDon>();
        }
        public static TruyCapDuLieu khoiTao()
        {
            if (instance == null)
                instance = new TruyCapDuLieu();
            return instance;
        }

        public List<Sach> getDSSach()
        {
            return dsSach;
        }
        public List<KhachHang> getDSKhachHang()
        {
            return dsKhachHang;
        }
        public List<NhanVien> getDSNhanVien()
        {
            return dsNhanVien;
        }
        public List<HoaDon> getDSHoaDon()
        {
            return dsHoaDon;
        }
        public List<ChiTietHoaDon> getDSChiTietHoaDon()
        {
            return dsChiTietHoaDon;
        }

        public static bool docFile(string tenFile)
        {
            try
            {
                FileStream fs = new FileStream(tenFile, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                instance = (TruyCapDuLieu)bf.Deserialize(fs);
                fs.Close();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }
        public static bool ghiFile(string tenFile)
        {
            try
            {
                FileStream fs = new FileStream(tenFile, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, instance);
                fs.Close();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }
    }
}
