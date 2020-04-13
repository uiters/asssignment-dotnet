using System;
using MyAssembly;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            MyAssembly.BasicMath basicMath = new MyAssembly.BasicMath();

            Console.WriteLine("Can bac 2 cua n = "+n+ ": " + basicMath.SqrtNum(n));
            Console.WriteLine("Binh phuong cua n = " + n + ": " + basicMath.SquareNum(n));
            Console.WriteLine("Giai thua cua n = " + n + ": " + basicMath.FactorialNum(n));
            Console.WriteLine(" n = " + n + ": la so nguyen to " + basicMath.KiemTraSNT(n));
        }
    }
}
