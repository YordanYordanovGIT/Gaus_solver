using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaus_solver
{
    public class Solver
    {
        //Gaus solver v1.0 by Yordan Yordanov, March 2020
        //Linear equations system solver
        private string[] strArrEn = { "Enter the unknowns count: ", "Very few unknowns!", "Too many unknowns!", "Wrong input format!", "No solution for one or more of the unknowns!" };
        private string[] strArrBg = { "Въведете брой неизвестни: ", "Прекалено малко неизвестни!", "Прекалено много неизвестни!", "Грешен формат на входните данни!", "Няма решение за едно или повече от неизвестните!" };
        private readonly int maxUnknowns = 50;
        private readonly int endChar = 122;
        private double[,] matrix;
        private int rows = -1;
        private int cols = -1;
        private int lang = 0;

        private Display console;

        public Solver(int lang)
        {
            console = new Display();
            console.Lang = lang;
            this.lang = lang;
        }
        
        public string Run()
        {
            RunUntilDone(InitMatrix);
            RunUntilDone(EnterMatrix);

            return CalculateSystem();
        }

        private void RunUntilDone(Func<bool> myMethod)
        {
            bool a = true;
            while (a){
                a = !myMethod();
            }
        }

        private bool InitMatrix()
        {
            int rows = 0;
            Console.Write(langStr(0, lang));
            try{
                rows = int.Parse(Console.ReadLine());
                if(rows < 2){
                    Console.WriteLine(langStr(1, lang));
                    return false;
                } 
                else if(rows > maxUnknowns)
                {
                    Console.WriteLine(langStr(2, lang));
                    return false;
                }
            }
            catch{
                Console.WriteLine(langStr(3, lang));
                return false;
            }
            
            this.rows = rows;
            cols = rows + 1;
            matrix = new double[rows, cols];
            return true;
        }

        private bool EnterMatrix()
        {
            console.EnterMatrixInfo();
            try{
                for (int i = 0; i < rows; i++)
                {
                    if(lang == 0)
                        Console.WriteLine($"Enter row {i + 1}:");
                    else if(lang == 1)
                        Console.WriteLine($"Въведете ред {i + 1}:");

                    string[] line = Console.ReadLine().Split(' ').ToArray();
                    for (int y = 0; y < line.Count(); y++)
                    {
                        matrix[i, y] = double.Parse(line[y]);
                    }
                }
            }
            catch{
                console.PrintProgramInfo(true);
                Console.WriteLine(langStr(3, lang));
                return false;
            }
            Console.WriteLine();

            return true;
        }

        private string CalculateSystem()
        {
            int currentStage = 0;
            for (int i = 0; i < rows; i++)
            {
                if (matrix[currentStage, currentStage] == 0) //check if we need to make a swap
                {
                    bool res = NotNullDiagLineSwap(currentStage);
                    if (!res)
                        return langStr(4, lang);
                }

                double diagNum = matrix[currentStage, currentStage]; //make diagonal of 1s
                if(diagNum != 1)
                    DivideLineBy(currentStage, diagNum);

                for (int y = 1 + currentStage; y < rows; y++) //make column of 0s
                {
                    double toZero = matrix[y, currentStage];
                    if (toZero != 0)
                        Line1MinusLine2(y, currentStage, toZero);
                }
                currentStage++;
            }

            return CalculateResult();
        }

        private string CalculateResult()
        {
            string result = "";
            double[] unknowns = new double[rows];
            int unknownsCountOnLine = 1;

            unknowns[0] = matrix[rows - 1, cols - 1];
            for (int i = rows - 2; i > -1; i--)
            {
                unknowns[unknownsCountOnLine] = matrix[i, cols - 1];
                for (int y = 1; y < unknownsCountOnLine + 1; y++)
                {
                    unknowns[unknownsCountOnLine] -= matrix[i, cols - 1 - y] * unknowns[y - 1];
                }
                unknownsCountOnLine++;
            }
            Array.Reverse(unknowns);
            int lng = unknowns.Length;
            for (int i = 0; i < lng; i++)
            {
                result += $"{(char)(endChar - lng + 1 + i)}={unknowns[i]}, ";
            }
            result = result.Substring(0, result.Length - 2);
            return result;
        }

        private bool NotNullDiagLineSwap(int stage) //check if the digit we need to make 1 is 0 and swap the line with a non 0 one
        {
            int targetLine = -1;
            for (int i = 1 + stage; i < rows; i++)
            {
                if (matrix[i, stage] != 0)
                {
                    targetLine = i;
                    break;
                }
            }
            if (targetLine == -1)
                return false;

            SwapRows(stage, targetLine);
            return true;
        }

        private void SwapRows(int line1, int line2) //swap 2 lines
        {
            for (int i = 0; i < cols; i++)
            {
                double buff = matrix[line1, i];
                matrix[line1, i] = matrix[line2, i];
                matrix[line2, i] = buff;
            }
        }

        private void DivideLineBy(int lineNum, double num) //Divide a line by a number
        {
            for (int i = 0; i < cols; i++)
            {
                matrix[lineNum, i] = matrix[lineNum, i] / num;
            }
        }

        private void Line1MinusLine2(int line1, int line2, double multiplyer) //Subtract line2 * multiplyer from line1
        {
            for (int i = 0; i < cols; i++)
            {
                matrix[line1, i] = matrix[line1, i] - (matrix[line2, i] * multiplyer);
            }
        }

        private string langStr(int num, int lang)
        {
            string[] langData = new string[6];

            if (lang == 0)
                langData = strArrEn;
            else if (lang == 1)
                langData = strArrBg;

            return langData[num];
        }
    }
}
