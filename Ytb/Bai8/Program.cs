using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai8
{
    class Program
    {
        /*Tham trị: sau khi thoát khỏi hàm vẫn giữ giá trị gốc
         *Tham biến(tham chiếu): sau khi thoát khỏi hàm nó sẽ lấy giá trị bị thay đổi trong hàm
         *+ ref: bắt buộc phải khởi tạo giá trị cho biến trước khi vào hàm
         *+ out: bắt buộc phải gán giá trị cho biến trước khi rời khỏi hàm
         */
        static int TinhGiaiThua(int n)
        {
            int giaiThua = 1;
            for (int i = 1; i <= n; i++)
            {
                giaiThua *= i;
            }
            return giaiThua;
        }

        static void fn1(int a)
        {
            a = a + 5;
            Console.WriteLine("a trong hàm fn1: {0}", a);
        }

        static void fn2(ref int b)
        {
            b = b + 3;
            Console.WriteLine("b trong hàm fn2: {0}", b);
        }

        static void fn3(out int c)
        {
            c = 100;
            Console.WriteLine("c trong hàm fn3: {0}", c);
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int n;
            Console.Write("Nhập n: ");
            n = int.Parse(Console.ReadLine());
            int gt=TinhGiaiThua(n);
            Console.WriteLine("Kết quả: {0}!={1}", n, gt);

            //tham trị
            int a = 3;
            Console.WriteLine("a trước khi vào hàm fn1: {0}", a);
            fn1(a);
            Console.WriteLine("a sau khi vào hàm fn1: {0}", a);

            //tham biến với ref
            int b = 10;
            Console.WriteLine("b trước khi vào hàm fn2: {0}", b);
            fn2(ref b);
            Console.WriteLine("b sau khi vào hàm fn2: {0}", b);

            //tham biến với out
            int c = 15;
            Console.WriteLine("c trước khi vào hàm fn3: {0}", c);
            fn3(out c);
            Console.WriteLine("c sau khi vào hàm fn3: {0}", c);

            Console.ReadLine();
        }
    }
}
