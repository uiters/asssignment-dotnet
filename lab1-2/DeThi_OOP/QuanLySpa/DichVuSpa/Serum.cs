using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySpa.DichVuSpa
{
    class Serum : DichVu
    {
        public Serum()
        {
            this.TenDV = "Serum";
            this.MoTa = "Su dung cac san pham serum de tang duong am";
            this.ThoiGian = 10;
            this.Gia = 50000;
            this.BatBuoc = false;
        }
    }
}
