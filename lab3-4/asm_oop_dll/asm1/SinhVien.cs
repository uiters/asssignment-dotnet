using System.ComponentModel.Design;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien
{
    class SinhVien
    {
        private string mMaSV { get; set; }
        private string HoTen { get; set; }
        private string NgaySinh { get; set; }
        private string DiaChi { get; set; }
        private int SoDT { get; set; }

        public SinhVien()
        {
            this.mMaSV = "100";
            this.HoTen = "Nguyen Van A";
            this.NgaySinh = "1/1/1999";
            this.DiaChi = "KTX DHQG HCM";
            this.SoDT = 012345678;
        }
        public SinhVien(string maSV, string hoten, string ngaysinh, string diachi, int sodt)
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
               + "\nDia chi : " + this.DiaChi
               + "\nSo DT : " + this.SoDT);
        }

        public static bool ThemSinhVien(SinhVien newSV, List<SinhVien> listSV)
        {
            SinhVien sinhVien = listSV.FirstOrDefault(sv => sv.mMaSV.Equals(newSV.mMaSV));

            if (sinhVien == null)
            {
                listSV.Add(newSV);
                return true;
            }

            return false;
        }

        public static void TimSinhVien(string maSV, List<SinhVien> listSV)
        {
            SinhVien sinhvien = listSV.FirstOrDefault(sv => sv.mMaSV.Equals(maSV));


            if (sinhvien != null)
            {
                sinhvien.XemThongTin();
            }
            else
            {
                Console.WriteLine("Khong tim thay sinh vien voi ma sinh vien : " + maSV);
            }
        }

        public static bool UpdateSinhVien(SinhVien SV, List<SinhVien> listSV)
        {
            SinhVien sinhVien = listSV.FirstOrDefault(sv => sv.mMaSV.Equals(SV.mMaSV));

            if (sinhVien != null)
            {
                sinhVien.HoTen = SV.HoTen;
                sinhVien.NgaySinh = SV.NgaySinh;
                sinhVien.SoDT = SV.SoDT;
                sinhVien.DiaChi = SV.DiaChi;

                return true;
            }

            return false;
        }
    }
}
