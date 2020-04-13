using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySpa.DichVuSpa
{
    class MatNa : DichVu
    {
        public MatNa()
        {
            this.TenDV = "Mat Na";
            this.MoTa = "Su dung loai mat na phu hop loai da ket hop nghe nhac thu gian";
            this.ThoiGian = 30;
            this.Gia = 100000;
            this.BatBuoc = true;
        }
    }
}
