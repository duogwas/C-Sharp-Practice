using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai7
{
    class Program
    {
        static void DoWhile()
        {
            Console.OutputEncoding = Encoding.UTF8;
            int n;
            int i = 1, gt = 1;
            Console.Write("Nhập n: ");
            n = int.Parse(Console.ReadLine());
            do
            {
                gt *= i;
                i++;
            } while (i <= n);
            Console.WriteLine("Kết quả: {0}!={1}", n, gt);
            Console.ReadLine();
        }

        static void While()
        {
            Console.OutputEncoding = Encoding.UTF8;
            int n;
            int i = 1, gt = 1;
            Console.Write("Nhập n: ");
            n = int.Parse(Console.ReadLine());
            while (i <= n)
            {
                gt *= i;
                i++;
            }
            Console.WriteLine("Kết quả: {0}!={1}", n, gt);
            Console.ReadLine();
        }

        static void For()
        {
            Console.OutputEncoding = Encoding.UTF8;
            int n;
            int gt = 1;
            Console.Write("Nhập n: ");
            n = int.Parse(Console.ReadLine());
            for (int i = 1; i<= n; i++)
            {
                gt *= i;
            }
            Console.WriteLine("Kết quả: {0}!={1}", n, gt);
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            DoWhile();
            While();
            For();
        }
    }
}
