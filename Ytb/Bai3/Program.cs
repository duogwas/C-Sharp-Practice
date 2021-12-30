using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai3
{
    class Program
    {
        static void Main(string[] args)
        {
            //test khai báo biến
            int soLuong = 0;
            double diemToan = 9.75;
            string ten = "duogwas";
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Họ và tên: {0}", ten);
            Console.WriteLine("Điểm Toán:{0}", diemToan);
           
            //test ép kiểu
            double d = 1 / 2;
            Console.WriteLine("d={0}/{1}={2}", 1, 2, d);
            double d2 = (double)1 / 2;
            Console.WriteLine("d2={0}/{1}={2}", 1, 2, d2);
            double d3 = 1.0 / 2;
            Console.WriteLine("d3={0}/{1}={2}", 1.0, 2, d3);

            //test implicit type
            var t = 5;
            Console.WriteLine("Kiểu của t:{0}", t.GetType().ToString());
            var t2 = 10.5;
            Console.WriteLine("Kiểu của t2:{0}", t2.GetType().ToString());
            var t3 = "10/01/2001";
            Console.WriteLine("Kiểu của t3:{0}", t3.GetType().ToString());
            var t4 = new DateTime(2001, 10, 04);
            Console.WriteLine("Kiểu của t4:{0}", t4.GetType().ToString());

            //test hằng số
            const double PI = 3.14;

            Console.ReadLine();
        }
    }
}
