using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien
{
    class SinhVien
    {
        private int mMaSV { get; set; }
        private string HoTen { get; set; }
        private string NgaySinh { get; set; }
        private string DiaChi { get; set; }
        private int SoDT { get; set; }

        public SinhVien()
        {
            this.mMaSV = 00000;
            this.HoTen = "Nguyen Van A";
            this.NgaySinh = "1/1/1999";
            this.DiaChi = "KTX DHQG HCM";
            this.SoDT = 012345678;
        }
        public SinhVien(int maSV, string hoten, string ngaysinh, string diachi, int sodt)
        {
            this.mMaSV = maSV;
            this.HoTen = hoten;
            this.NgaySinh = ngaysinh;
            this.DiaChi = diachi;
            this.SoDT = sodt;
        }

        public void XemThongTin()
        {
            Console.WriteLine("Thong tin SV : " + mMaSV
               + "\nHo ten : " + this.HoTen
               + "\nNgay sinh : " + this.NgaySinh
               + "\nDia chi : "+ this.DiaChi
               + "\nSo DT : " + this.SoDT);
        }
    }
}
