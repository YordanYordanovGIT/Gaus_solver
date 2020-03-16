using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaus_solver
{
    public class MainController
    {
        //Gaus solver v1.0 by Yordan Yordanov, March 2020
        //Linear equations system solver

        Display console;
        bool run = true;

        public MainController()
        {
            console = new Display();
        }

        public void Run()
        {
            while (run)
            {
                console.WriteMenu();

                var consoleInput = console.ReadLine(); //read from console
                if (string.IsNullOrWhiteSpace(consoleInput)) continue;

                try
                {
                    string result = Execute(consoleInput);//execute command

                    console.WriteLine(result);//return result
                }
                catch (Exception ex)
                {
                    console.WriteLine(ex.Message); //return error
                }

                console.PressAnyKey();
            }
        }

        string Execute(string command)
        {
            //process command with switch - case
            string result = "";

            switch (command.ToLower())
            {
                case "q":
                    result = "Exitting application!";
                    run = false;
                    break;
                case "1":
                    Solver gaus = new Solver();
                    result = gaus.Run();
                    break;
                default:
                    result = "Unknown command!";
                    break;
            }

            return result;
        }
    }
}
