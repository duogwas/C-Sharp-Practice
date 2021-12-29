using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HinhTron
{
    class Program
    {
        static void Main(string[] args)
        {
            double r, dientich, chuvi;
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Nhập bán kính: ");
            r = double.Parse(Console.ReadLine());
            dientich = Math.Pow(r, 2) * Math.PI;
            chuvi = 2 * Math.PI * r;
            Console.WriteLine("\nDiện tích hình tròn bán kính {0} là: {1}", r, dientich);
            Console.WriteLine("\nChu vi hình tròn bán kính {0} là: {1}", r, chuvi);
            Console.ReadLine();
        }
    }
}
