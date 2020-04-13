using System;
using System.Collections.Generic;
using System.Text;
using QuanLySpa.DichVuSpa;

namespace QuanLySpa
{
    class HoaDon
    {
        public KhachHang khachHang { get; set; }
        public List<DichVu> dsDichVu { get; set; }

        public HoaDon()
        {
            //Cac dich vu bat buoc
            dsDichVu = new List<DichVu>();
            khachHang = new KhachHang();


            dsDichVu.Add(new TayTrang());
            dsDichVu.Add(new RuaMat());
            dsDichVu.Add(new MatNa());

        }

        public void NhapThongTinHoaDon()
        {

            //Nhap thong tin khach
            khachHang.NhapThongTin();

            Random rd = new Random();
            int dvSuDungThem = rd.Next(3,7);
            switch (dvSuDungThem)
            {
                case 3:
                    break;
                case 4:
                    dsDichVu.Add(new Toner());
                    Console.WriteLine("Su dung them Toner");
                    break;
                case 5:
                    dsDichVu.Add(new Serum());
                    Console.WriteLine("Su dung them Serum");
                    break;
                case 6:
                    dsDichVu.Add(new KemDuong());
                    Console.WriteLine("Su dung them KemDuong");
                    break;
                case 7:
                    dsDichVu.Add(new ChongNang());
                    Console.WriteLine("Su dung them ChongNang");
                    break;
            }
        }

        public int GetTongTien()
        {
            int tongTien = 0;

            foreach(DichVu dv in dsDichVu)
            {
                tongTien += dv.Gia;
            }

            khachHang.DoanhThu = tongTien;

            return tongTien;
        }

        public int GetTongThoiGian()
        {
            int tongThoiGian = 0;

            foreach(DichVu dv in dsDichVu)
            {
                tongThoiGian += dv.ThoiGian;
            }

            return tongThoiGian;
        }

        public void XuatThongTinHoaDon()
        {
            Console.WriteLine("Khach hang : " + khachHang.HoTen);
            Console.WriteLine("Quy trinh : ");
            foreach(DichVu dv in dsDichVu)
            {
                Console.WriteLine("     " + dv.TenDV);
            }
            Console.WriteLine("Tong thoi gian : " + this.GetTongThoiGian() + " phut");
            Console.WriteLine("Tong tien : " + this.GetTongTien() + " vnd");
        }
    }
}
