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
        public int Lang { get; set; }

        const string readPromptStrEn = "console> ";
        const string readPromptStrBg = "конзола> ";

        public void WriteLine(string message = "")
        {
            if (message.Length > 0)
            {
                Console.WriteLine(message);
            }
        }

        public string ReadLine(string promptMessage = "")
        {
            string readPromptStr = "";
            if (Lang == 0)
                readPromptStr = readPromptStrEn;
            else if (Lang == 1)
                readPromptStr = readPromptStrBg;

            Console.WriteLine();
            Console.Write(readPromptStr + promptMessage);
            return Console.ReadLine();
        }

        public void WriteMenu()
        {
            PrintProgramInfo(true);

            if (Lang == 0)
            {
                Console.WriteLine("(1) Calculate linear system of equations");
                Console.WriteLine("(2) Bulgarian");
                Console.WriteLine("(Q) <== Quit =====");
            }
            else if (Lang == 1)
            {
                Console.WriteLine("(1) Калкулатор за системи линейни уравнения");
                Console.WriteLine("(2) Английски");
                Console.WriteLine("(Q) <== Изход =====");
            }
        }

        public void PrintProgramInfo(bool clear)
        {
            if (clear)
                Clear();

            if (Lang == 0)
            {
                Console.WriteLine("===================== Gaus Solver v1.0 =====================");
                Console.WriteLine("============== by Yordan Yordanov, 11A, No.10 ==============");
            }
            else if (Lang == 1)
            {
                Console.WriteLine("===================== Gaus Solver v1.0 =====================");
                Console.WriteLine("============== от Йордан Йорданов, 11A, No.10 ==============");
            }
            Console.WriteLine();
        }

        public void PressAnyKey()
        {
            Console.WriteLine();
            if (Lang == 0)
            {
                Console.Write("Press any key to continue.");
            }
            else if (Lang == 1)
            {
                Console.Write("Натиснете клавиш, за да продължите.");
            }
            Console.ReadKey();

        }

        public void Clear()
        {
            Console.Clear();
        }

        public void EnterMatrixInfo()
        {
            Console.WriteLine();
            if (Lang == 0)
            {
                Console.WriteLine("Warning: The calculator works when there is one solution to the system only!");
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
                Console.WriteLine("Example:");
                Console.WriteLine("2.5 -3 4 8");
                Console.WriteLine("8 -5 3 8");
                Console.WriteLine("1 2 -5 2");
            }
            else if (Lang == 1)
            {
                Console.WriteLine("Внимание: Калкулатора работи само ако системата има едно единствено решение!");
                Console.WriteLine();
                Console.WriteLine("Въведете система линейни уравнения по подеобие на следния модел:");
                Console.WriteLine("a1.x + b1.y + c1.z = k");
                Console.WriteLine("a2.x + b2.y + c2.z = l");
                Console.WriteLine("a3.x + b3.y + c3.z = m");
                Console.WriteLine();
                Console.WriteLine("Въведете само коефициентите и резултатите! Използвайте модела по - долу:");
                Console.WriteLine("a1 b1 c1 k");
                Console.WriteLine("a2 b2 c2 l");
                Console.WriteLine("a3 b3 c3 m");
                Console.WriteLine();
                Console.WriteLine("Пример:");
                Console.WriteLine("2.5 -3 4 8");
                Console.WriteLine("8 -5 3 8");
                Console.WriteLine("1 2 -5 2");
            }
            Console.WriteLine();
        }
    }
}
