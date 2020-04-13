using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySpa
{
    class KhachHang
    {
        public string HoTen { get; set; }
        public int DoanhThu { get; set; }

        public KhachHang()
        {
            HoTen = null;
            DoanhThu = 0;
        }

        public void NhapThongTin()
        {
            Console.WriteLine("Nhap ten khach hang : ");
            this.HoTen = Console.ReadLine();
        }
    }
}
