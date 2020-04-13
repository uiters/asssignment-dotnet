using System;
using System.Collections.Generic;

namespace QuanLySpa
{
    class Program
    {
        static void Main(string[] args)
        {
            List<HoaDon> listHD = new List<HoaDon>();
            List<KhachHang> listKH = new List<KhachHang>();

            for(int i = 0; i < 5; i++)
            {
                HoaDon hoaDon = new HoaDon();
                hoaDon.NhapThongTinHoaDon();
                listHD.Add(hoaDon);
                listKH.Add(hoaDon.khachHang);
            }



            foreach(HoaDon hd in listHD)
            {
                hd.XuatThongTinHoaDon();
            }

            int DoanhThuMax = 0;
            foreach(KhachHang kh in listKH)
            {
                if (DoanhThuMax < kh.DoanhThu)
                    DoanhThuMax = kh.DoanhThu;

                Console.WriteLine("Khach hang : " + kh.HoTen);
                Console.WriteLine("Doanh thu : " + kh.DoanhThu);
            }
            Console.WriteLine("Khach hang chi tieu nhieu nhat : " + DoanhThuMax);

        }
    }
}
