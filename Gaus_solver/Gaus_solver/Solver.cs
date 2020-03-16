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

        private readonly int maxUnknowns = 50;
        private readonly int endChar = 122;
        private int rows = -1;
        private int cols = -1;
        private double[,] matrix;

        private Display console;

        public Solver()
        {
            console = new Display();
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
            while (a)
            {
                a = !myMethod();
            }
        }

        private bool InitMatrix()
        {
            int rows = 0;
            Console.Write("Entern the unknowns count: ");
            try{
                rows = int.Parse(Console.ReadLine());
                if(rows < 2){
                    Console.WriteLine("Very few unknowns!");
                    return false;
                } 
                else if(rows > maxUnknowns)
                {
                    Console.WriteLine("Too many unknowns!");
                    return false;
                }
            }
            catch{
                Console.WriteLine("Wrong input format!");
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
                    Console.WriteLine($"Enter row {i + 1}:");

                    string[] line = Console.ReadLine().Split(' ').ToArray();
                    for (int y = 0; y < line.Count(); y++)
                    {
                        matrix[i, y] = double.Parse(line[y]);
                    }
                }
            }
            catch{
                console.ClearAndPrintProgramInfo();
                Console.WriteLine("Wrong input format!");
                return false;
            }
            
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
                        return "No solution for one or more of the unknowns!";
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
            result = result.Substring(0, result.Length - 1);
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
    }
}
