using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai6
{
    class Program
    {
        static void Main(string[] args)
        {
            //if else
            /*toán tử 3 ngôi
             * <điều kiện> ? <bt1> : <bt2>
             * nếu điều kiện đúng thì thực hiện bt1, ngc lại thực hiện biểu thức 2
             */
            Console.OutputEncoding = Encoding.UTF8;
            int x;
            Console.Write("Nhập số x: ");
            x = int.Parse(Console.ReadLine());
            string check = (x % 2 == 0) ? "số chẵn" : "số lẻ";
            Console.WriteLine("{0} là {1}", x, check);

            /* dùng toán tử 3 ngôi để xếp loại
             * [0,5) yếu
             * [5,6.5) trung bình
             * [6.5,8) khá
             * [8,10] giỏi
             */
            double diem;
            Console.Write("Nhập điểm: ");
            diem = double.Parse(Console.ReadLine());
            string kq = (diem >= 0 && diem < 5) ? "Yếu" : (diem >= 5 && diem < 6.5) ? "Trung bình" : (diem >= 6.5 && diem < 8) ? "Khá" : (diem >= 8 && diem <= 10) ? "Giỏi" : "Điểm phải nằm trong khoảng 0-10";
            if (kq == "Yếu" || kq == "Trung bình" || kq == "Khá" || kq == "Giỏi")
            {
                Console.WriteLine("Xếp loại: {0}", kq);
            }
            else
            {
                Console.WriteLine("{0}", kq);
            }

            //switch...case
            int a, b;
            char bt;
            Console.Write("Nhập số a: ");
            a = int.Parse(Console.ReadLine());
            Console.Write("Nhập số b: ");
            b = int.Parse(Console.ReadLine());
            Console.Write("Nhập phép tính (+,-,*,/): ");
            bt = Console.ReadLine()[0];
            switch (bt)
            {
                case '+':
                    Console.WriteLine("{0}+{1}={2}", a, b, a + b);
                    break;
                case '-':
                    Console.WriteLine("{0}-{1}={2}", a, b, a - b);
                    break;
                case '*':
                    Console.WriteLine("{0}*{1}={2}", a, b, a * b);
                    break;
                case '/':
                    if (b == 0)
                    {
                        Console.WriteLine("Không thể thực hiện phép chia cho 0");
                    }
                    else
                    {
                        double chia = (double)a / b;
                        Console.WriteLine("{0}/{1}={2}", a, b, chia);
                    }
                    break;
                default:
                    break;
            }

            //switch..case check 1 tháng có bn ngày
            int thang;
            Console.Write("Nhập tháng: ");
            thang = int.Parse(Console.ReadLine());
            switch (thang)
            {
                case 1:
                    Console.WriteLine("Tháng {0} có 31 ngày", thang);
                    break;
                case 2:
                    int nam;
                    Console.Write("Nhập năm: ");
                    nam = int.Parse(Console.ReadLine());
                    if (nam % 4 == 0 && nam % 100 != 0 || nam % 400 == 0)
                    {
                        Console.WriteLine("Tháng {0} năm {1} có 29 ngày", thang, nam);
                    }
                    else
                    {
                        Console.WriteLine("Tháng {0} năm {1} có 28 ngày", thang, nam);
                    }
                    break;
                case 3:
                    Console.WriteLine("Tháng {0} có 31 ngày", thang);
                    break;
                case 4:
                    Console.WriteLine("Tháng {0} có 30 ngày", thang);
                    break;
                case 5:
                    Console.WriteLine("Tháng {0} có 31 ngày", thang);
                    break;
                case 6:
                    Console.WriteLine("Tháng {0} có 30 ngày", thang);
                    break;
                case 7:
                    Console.WriteLine("Tháng {0} có 31 ngày", thang);
                    break;
                case 8:
                    Console.WriteLine("Tháng {0} có 31 ngày", thang);
                    break;
                case 9:
                    Console.WriteLine("Tháng {0} có 30 ngày", thang);
                    break;
                case 10:
                    Console.WriteLine("Tháng {0} có 31 ngày", thang);
                    break;
                case 11:
                    Console.WriteLine("Tháng {0} có 30 ngày", thang);
                    break;
                case 12:
                    Console.WriteLine("Tháng {0} có 31 ngày", thang);
                    break;
                default:
                    Console.WriteLine("Không tồn tại tháng {0}", thang);
                    break;
            }

            Console.ReadLine();

        }
    }
}




