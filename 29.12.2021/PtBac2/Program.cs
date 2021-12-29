using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PtBac2
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c, d;
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Nhập a: ");
            a = double.Parse(Console.ReadLine());
            Console.Write("Nhập b: ");
            b = double.Parse(Console.ReadLine());
            Console.Write("Nhập c: ");
            c = double.Parse(Console.ReadLine());
            d = Math.Pow(b, 2) - 4 * a * c;
            Console.WriteLine("\nPHƯƠNG TRÌNH {0}x^2 + {1}x + {2} =0", a, b, c);
            if (d > 0)
            {
                Console.WriteLine("\nPhương trình có hai nghiệm phân biệt: ");
                Console.WriteLine("X1 = {0}", ((-b - Math.Sqrt(d)) / 2 * a));
                Console.WriteLine("X2 = {0}", ((-b + Math.Sqrt(d)) / 2 * a));

            }
            else if (d == 0)
            {
                Console.Write("\nPhương trình có hai nghiệm kép: ");
                Console.WriteLine("X1 = X2 = {0}", -b / 2 * a);
            }
            else if (d < 0)
            {
                Console.WriteLine("\nPhương trình vô nghiệm");
            }
            Console.ReadLine();
        }
    }
}
