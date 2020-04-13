using System;
using System.Collections.Generic;
using System.Text;

namespace Ngay1_BT2
{
    class HinhChuNhat
    {
        private float mChieuDai { get; set; }
        private float mChieuRong { get; set; }

        public HinhChuNhat()
        {
            this.mChieuDai = 1;
            this.mChieuRong = 2;
        }

        public HinhChuNhat(float chieuDai, float chieuRong)
        {
            this.mChieuDai = chieuDai;
            this.mChieuRong = chieuRong;
        }
        
        public float TinhChuVi()
        {
            return this.mChieuDai * this.mChieuRong;
        }
    }
}
