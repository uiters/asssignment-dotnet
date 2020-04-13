using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySpa.DichVuSpa
{
    class TayTrang : DichVu
    {
        public TayTrang()
        {
            this.TenDV = "Tay Trang";
            this.MoTa = "Su dung oliu tinh khiet de tay di lop trang diem";
            this.ThoiGian = 5;
            this.Gia = 30000;
            this.BatBuoc = true;
        }
    }
}
