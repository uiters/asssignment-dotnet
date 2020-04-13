using System;
using System.Collections.Generic;

namespace Ngay2_BT1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Tao danh sach cac mat hang ban dau
            List<MatHang> danhsach = new List<MatHang>();

            danhsach.Add(new MatHang() { MaMH = 001, TenMH = "Laptop Asus", SoLuong = 11, DonGia = 1000000});
            danhsach.Add(new MatHang() { MaMH = 002, TenMH = "Laptop Dell", SoLuong = 10, DonGia = 2400000 });
            danhsach.Add(new MatHang() { MaMH = 003, TenMH = "Laptop Microsoft", SoLuong = 15, DonGia = 3600000 });
            danhsach.Add(new MatHang() { MaMH = 004, TenMH = "Laptop Apple", SoLuong = 21, DonGia = 5600000 });
            danhsach.Add(new MatHang() { MaMH = 005, TenMH = "Laptop Xiaomi", SoLuong = 16, DonGia = 4500000 });



            //Test them mat hang vao danh sach
            MatHang.ThemMatHang(new MatHang() { MaMH = 006, TenMH = "Laptop LG", SoLuong = 18, DonGia = 2300000 }, danhsach);
            MatHang.XuatDanhSach(danhsach);

            //Test xoa mat hang vao danh sach
            MatHang.XoaMatHang(1, danhsach);
            MatHang.XuatDanhSach(danhsach);

            //Test tim mat hang trong danh sach
            MatHang mh = MatHang.TimMatHang(2,danhsach);
            MatHang.ThemMatHang(mh, danhsach);
            MatHang.XuatDanhSach(danhsach);


            Console.ReadLine();
        }
    }
}
