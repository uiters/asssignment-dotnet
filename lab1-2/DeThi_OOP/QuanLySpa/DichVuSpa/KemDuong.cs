using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySpa.DichVuSpa
{
    class KemDuong : DichVu
    {
        public KemDuong()
        {
            this.TenDV = "Kem Duong";
            this.MoTa = "Su dung kem duong de cap am";
            this.ThoiGian = 10;
            this.Gia = 50000;
            this.BatBuoc = false;
        }
    }
}
