using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Yêu cầu thêm using để nhận diện lớp Sach
using QuanLyCuaHangSach.Models;
namespace QuanLyCuaHangSach.DataStructures
{
    public class NodeSach
    {
        public Sach Data { get; set; }
        public NodeSach Next { get; set; }

        public NodeSach(Sach sach)
        {
            Data = sach;
            Next = null;
        }
    }
    public class LinkedListSach
    {
        public NodeSach Head { get; set; }

        // Thêm vào cuối danh sách
        public void Them(Sach sach)
        {
            NodeSach newNode = new NodeSach(sach);
            if (Head == null)
            {
                Head = newNode;
                return;
            }
            NodeSach current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }

        //Tìm kiếm sách theo Mã
        public Sach TimMaSach(string maSach)
        {
            NodeSach current = Head;
            while (current != null)
            {
                if (current.Data.MaSach.Equals(maSach, System.StringComparison.OrdinalIgnoreCase))
                {
                    return current.Data;
                }
                current = current.Next;
            }
            return null;
        }

        //  Xóa sách theo Mã
        public bool XoaTheoMaSach(string maSach)
        {
            if (Head == null) return false;

            // Xóa Node đầu
            if (Head.Data.MaSach.Equals(maSach, System.StringComparison.OrdinalIgnoreCase))
            {
                Head = Head.Next;
                return true;
            }

            NodeSach current = Head;
            while (current.Next != null)
            {
                if (current.Next.Data.MaSach.Equals(maSach, System.StringComparison.OrdinalIgnoreCase))
                {
                    current.Next = current.Next.Next;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        // Chuyển đổi sang List (phục vụ hiển thị DataGrid trong WPF)
        public List<Sach> ToList()
        {
            List<Sach> list = new List<Sach>();
            NodeSach current = Head;
            while (current != null)
            {
                list.Add(current.Data);
                current = current.Next;
            }
            return list;
        }
    }
}
