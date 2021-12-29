using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhLaiSuatNganHang
{
    class Program
    {
        static void Main(string[] args)
        {
            string ten;
            int tienGui, kyHan;
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Nhập tên khách hàng: ");
            ten = Console.ReadLine();
            Console.Write("Số tiền muốn gửi: ");
            tienGui = int.Parse(Console.ReadLine());
            Console.Write("Nhập kỳ hạn: ");
            kyHan = int.Parse(Console.ReadLine());
            Console.ReadLine();
        }
    }
}
