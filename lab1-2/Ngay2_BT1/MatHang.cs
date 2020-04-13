using System;
using System.Collections.Generic;
using System.Text;

namespace Ngay2_BT1
{
    class MatHang
    {
        public int MaMH { get; set; }
        public string TenMH { get; set; }
        public int SoLuong { get; set; }
        public float DonGia { get; set; }
        public float ThanhTien { get; set; }

        public MatHang(int mamh, string tenmh, int soluong, float dongia)
        {
            this.MaMH = mamh;
            this.TenMH = tenmh;
            this.SoLuong = soluong;
            this.DonGia = dongia;
            this.ThanhTien = soluong * dongia;
        }

        public MatHang()
        {
        }

        public static void ThemMatHang(MatHang m, List<MatHang> danhsach)
        {
            danhsach.Add(m);
        }

        public static MatHang TimMatHang(int maMH, List<MatHang> danhsach)
        {
            return danhsach.Find(x => x.MaMH.Equals(maMH));
        }
        public static void XoaMatHang(int maMH, List<MatHang> danhsach)
        {
            danhsach.Remove(TimMatHang(maMH,danhsach));
        }

        public static void XuatDanhSach(List<MatHang> danhsach)
        {
            foreach(MatHang matHang in danhsach)
            {
                Console.WriteLine("Ma mat hang : " + matHang.MaMH
                    + "\n Ten mat hang : " + matHang.TenMH
                    + "\n So luong : " + matHang.SoLuong
                    + "\n Don gia :  " + matHang.DonGia
                    + "\n Thanh tien : " + matHang.ThanhTien
                    + "\n");
            }
        }
    }
}
