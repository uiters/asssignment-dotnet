using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySpa.DichVuSpa
{
    class ChongNang : DichVu
    {
        public ChongNang()
        {
            this.TenDV = "Chong Nang";
            this.MoTa = "Su dung kem chong nang de bao ve lan da";
            this.ThoiGian = 30;
            this.Gia = 50000;
            this.BatBuoc = false;
        }
    }
}
