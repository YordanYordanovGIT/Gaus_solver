using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaus_solver
{
    public class Display
    {
        //Gaus solver v1.0 by Yordan Yordanov, March 2020
        //Linear equations system solver

        const string readPromptStr = "console> ";

        public void WriteLine(string message = "")
        {
            if (message.Length > 0)
            {
                Console.WriteLine(message);
            }
        }

        public string ReadLine(string promptMessage = "")
        {
            Console.WriteLine();
            Console.Write(readPromptStr + promptMessage);
            return Console.ReadLine();
        }

        public void WriteMenu()
        {
            Clear();

            PrintProgramInfo();

            Console.WriteLine("(1) Calculate linear system of equations");
            Console.WriteLine("(Q) <== Quit =====");
        }

        public void PrintProgramInfo()
        {
            Console.WriteLine("===================== Gaus Solver v1.0 =====================");
            Console.WriteLine("============== by Yordan Yordanov, 11A, No.10 ==============");
            Console.WriteLine();
        }

        public void ClearAndPrintProgramInfo()
        {
            Clear();
            Console.WriteLine("===================== Gaus Solver v1.0 =====================");
            Console.WriteLine("============== by Yordan Yordanov, 11A, No.10 ==============");
            Console.WriteLine();
        }

        public void PressAnyKey()
        {
            Console.WriteLine();
            Console.Write("Press any key to continue.");
            Console.ReadKey();
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void EnterMatrixInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Warning: The calculator works when the system has only one solution!");
            Console.WriteLine();
            Console.WriteLine("Enter linear system of equations following this model:");
            Console.WriteLine("a1.x + b1.y + c1.z = k");
            Console.WriteLine("a2.x + b2.y + c2.z = l");
            Console.WriteLine("a3.x + b3.y + c3.z = m");
            Console.WriteLine();
            Console.WriteLine("Enter only the coefficients and results splitted by spaces! Follow the model below:");
            Console.WriteLine("a1 b1 c1 k");
            Console.WriteLine("a2 b2 c2 l");
            Console.WriteLine("a3 b3 c3 m");
            Console.WriteLine();
            Console.WriteLine("For example:");
            Console.WriteLine("2.5 -3 4 8");
            Console.WriteLine("8 -5 3 8");
            Console.WriteLine("1 2 -5 2");
            Console.WriteLine();
        }
    }
}
