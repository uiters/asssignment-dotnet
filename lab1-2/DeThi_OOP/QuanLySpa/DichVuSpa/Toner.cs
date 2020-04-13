using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySpa.DichVuSpa
{
    class Toner : DichVu
    {
        public Toner()
        {
            this.TenDV = "Toner";
            this.MoTa = "Su dung toner de cap am cho da";
            this.ThoiGian = 10;
            this.Gia = 50000;
            this.BatBuoc = false;
        }
    }
}
