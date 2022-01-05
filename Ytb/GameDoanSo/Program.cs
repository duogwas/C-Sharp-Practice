using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDoanSo
{
    class Program
    {
        static void DoanSo()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Random rd = new Random();
            int soCuaMay = rd.Next(501);
            int soCuaBan;
            int soLanDoan = 0;
            Console.WriteLine("Máy đã ra một số trong khoảng [0,500], mời bạn đoán");
            while (true)
            {
                soLanDoan++;
                Console.Write("Lần đoán thứ {0}: ", soLanDoan);
                soCuaBan = int.Parse(Console.ReadLine());
                if(soCuaBan == soCuaMay)
                {
                    Console.WriteLine("Chúc mừng, bạn đã đoán đúng");
                    break;
                }
                if (soCuaBan > soCuaMay)
                {
                    Console.WriteLine("Số bạn đoán lớn hơn số của máy");
                }
                else
                {
                    Console.WriteLine("Số bạn đoán nhỏ hơn số của máy");
                }
                if (soLanDoan == 6)
                {
                    Console.WriteLine("Bạn chỉ còn 1 lần đoán nữa");
                }
                if (soLanDoan == 7)
                {
                    Console.WriteLine("GAME OVER!!!");
                    Console.WriteLine("Số của máy: {0}", soCuaMay);
                    break;
                }
            }
            Console.ReadLine();

        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            while (true)
            {
                DoanSo();
                Console.WriteLine("Bạn có muốn chơi tiếp không? [Y/N]: ");
                string check = Console.ReadLine();
                if(check=="N" || check == "n")
                {
                    break;
                }
            }            
        }
    }
}
