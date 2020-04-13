using System.Linq;
using System.Collections.Generic;
using System;

namespace QuanLySinhVien
{
    class Program
    {
        static void Main(string[] args)
        {
            List<SinhVien> listSV = new List<SinhVien>(){
                new SinhVien("111", "Nguyen Van A", "1/1/1999","KTX DHQG",01234567),
                new SinhVien("112", "Nguyen Van B", "2/1/1999","KTX DHQG",01234567),
                new SinhVien("113", "Nguyen Van C", "3/1/1999","KTX DHQG",01234567),
                new SinhVien("114", "Nguyen Van D", "4/1/1999","KTX DHQG",01234567),
                new SinhVien("115", "Nguyen Van E", "5/1/1999","KTX DHQG",01234567),
            };

            //Xuat thong tin danh sach
            Console.WriteLine("Danh sach cac sinh vien : ");
            foreach (var sv in listSV)
            {
                sv.XemThongTin();
            }


            //Them sinh vien
            SinhVien newSV = new SinhVien("116", "Nguyen Van F", "6/1/1999", "KTX DHQG", 01234567);
            if (SinhVien.ThemSinhVien(newSV, listSV))
            {
                Console.WriteLine("Them thanh cong!");
            }
            else
            {
                Console.WriteLine("Them khong thanh cong!");
            }

            //Update sinh vien
            SinhVien updateSV = new SinhVien("118", "Nguyen Van T", "6/1/1999", "KTX DHQG", 01234567);
            if (SinhVien.ThemSinhVien(updateSV, listSV))
            {
                Console.WriteLine("Sua thanh cong!");
            }
            else
            {
                Console.WriteLine("Sua khong thanh cong!");
            }


            //Tim sinh vien
            SinhVien.TimSinhVien("111", listSV);
        }
    }
}
