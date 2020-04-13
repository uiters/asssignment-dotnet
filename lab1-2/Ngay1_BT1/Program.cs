using System;

namespace QuanLySinhVien
{
    class Program
    {
        static void Main(string[] args)
        {
            SinhVien svtest = new SinhVien();
            svtest.XemThongTin();

            SinhVien sv = new SinhVien(17520186, "Pham Trung Truong", "04/07/1999", "KTX Khu B DHQG", 012345678);
            sv.XemThongTin();

            Console.ReadLine();
        }
    }
}
