using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDaiDoanThang
{
    class Program
    {
        static void Main(string[] args)
        {
            double xA, yA, xB, yB, dodaiAB;

            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("NHẬP TỌA ĐỘ ĐIỂM A");
            Console.Write("Nhập hoành độ: ");
            xA = double.Parse(Console.ReadLine());
            Console.Write("Nhập tung độ: ");
            yA = double.Parse(Console.ReadLine());
            Console.WriteLine("Tọa độ điểm A({0};{1})", xA, yA);

            Console.WriteLine("\nNHẬP TỌA ĐỘ ĐIỂM B");
            Console.Write("Nhập hoành độ: ");
            xB = double.Parse(Console.ReadLine());
            Console.Write("Nhập tung độ: ");
            yB = double.Parse(Console.ReadLine());
            Console.WriteLine("Tọa độ điểm B({0};{1})", xB, yB);

            dodaiAB = Math.Sqrt(Math.Pow((xB - xA), 2) + Math.Pow((yB - yA), 2));
            Console.WriteLine("\nĐộ dài đoạn thẳng AB = {0}", dodaiAB);
            Console.ReadLine();
        }
    }
 }

