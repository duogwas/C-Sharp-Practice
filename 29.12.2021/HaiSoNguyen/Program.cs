using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiSoNguyen
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, cong, tru, nhan;
            double chia;
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Số thứ 1: ");
            a = int.Parse(Console.ReadLine());
            Console.Write("Số thứ 2: ");
            b = int.Parse(Console.ReadLine());

            cong = a + b;
            Console.WriteLine("\nKết quả phép cộng 2 số: {0}", cong);

            tru = a - b;
            Console.WriteLine("\nKết quả phép trừ 2 số: {0} ", tru);

            nhan = a * b;
            Console.WriteLine("\nKết quả phép nhân 2 số: {0}", nhan);

            if (b != 0)
            {
                chia = (double)a / b;
                Console.WriteLine("\nKết quả phép chia 2 số: {0}", chia);
            }
            else
            {
                Console.WriteLine("\nKhông thể thực hiện phép chia cho 0");
            }
            Console.ReadLine();
        }
    }
}
