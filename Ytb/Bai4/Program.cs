using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int a = 5, b = 5, c = 5, d = 5;
            a += 1; //a = a+1
            Console.WriteLine("a={0}", a);
            b -= 2; //b = b-2
            Console.WriteLine("b={0}", b);
            c *= 3; //c = c-3;
            Console.WriteLine("c={0}", c);
            d /=4; //d = d/4
            Console.WriteLine("d={0}", d);

            //test chẵn lẻ
            int e;
            Console.Write("Nhập e: ");
            e = int.Parse(Console.ReadLine());
            if (e % 2 == 0)
            {
                Console.WriteLine("{0} là số chẵn", e);
            }
            else
            {
                Console.WriteLine("{0} là số lẻ", e);
            }
            
            //test năm nhuận
            int nam;
            Console.Write("Nhập năm: ");
            nam = int.Parse(Console.ReadLine());
            //năm nhuận chia hết cho 4 nhưng k chia hết cho 100
            //hoặc chia hết cho 400
            if (nam % 4 == 0 && nam % 100 != 0 || nam %400 ==0)
            {
                Console.WriteLine("{0} là năm nhuận", nam);
            }
            else
            {
                Console.WriteLine("{0} không phải năm nhuận", nam);
            }

            //nhập vào 1 điểm kiểm tra đậu hay rớt
            double diem;
            Console.Write("Nhập điểm: ");
            diem = double.Parse(Console.ReadLine());
            if (diem > 5) //tương đương if(!(diem < 5))
            {
                Console.WriteLine("Kết quả: Đậu");
            }
            else
            {
                Console.WriteLine("Kết quả: Rớt");
            }

            /* a++, a--
             * Nếu ++, -- đứng trước biến thì gọi là Prefix
             * Nếu đứng sau biến thì gọi là Postfix
             * Trong TH cả Pre và Post nằm trong 1 biểu thức hỗn hợp thì:
             * B1: xử lý Prefix
             * B2: thực hiện các phép toán còn lại
             * B3: gán giá trị cho biến bên tái dấu bằng
             * B4: tiến hành tính Postfix
             * vd: x=5, y=8, z=x++ - ++y -5
             * b1: prefix: y=9
             * b2: 5-9-5=-9
             * b3: z=-9
             * b4: x=6
             */

            int x = 5, y = 8, z;
            z = x++ - ++y - 5;
            Console.WriteLine("x={0}, y={1}, z={2}", x, y, z);




            Console.ReadLine();
        }
    }
}
