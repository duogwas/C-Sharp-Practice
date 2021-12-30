using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai5
{
    class Program
    {
        /// <summary>
        /// Tính tổng 2 số
        /// </summary>
        /// <param name="a">số a kiểu int</param>
        /// <param name="b">số b kiểu int</param>
        /// <returns>trả về tổng 2 số a, b</returns>
        int Tong2So (int a, int b)
        {
            return a + b;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int kq = (new Program()).Tong2So(4, 5);
            Console.WriteLine("Kết quả: {0}", kq);
            Console.ReadLine();
        }
    }
}
