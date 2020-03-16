using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gaus_solver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            MainController mc = new MainController();
            mc.Run();
        }
    }
}
