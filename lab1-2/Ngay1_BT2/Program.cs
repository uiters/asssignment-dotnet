using System;

namespace Ngay1_BT2
{
    class Program
    {
        static void Main(string[] args)
        {
            HinhChuNhat hcn1 = new HinhChuNhat();
            Console.WriteLine("Chu vi HCN 1 : " + hcn1.TinhChuVi());
            HinhChuNhat hcn2 = new HinhChuNhat(4,5);
            Console.WriteLine("Chu vi HCN 1 : " + hcn2.TinhChuVi());
            
            Console.ReadLine();
        }
    }
}
