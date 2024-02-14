using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandConsole.Commands
{
    internal class CommandCalc : ICommand
    {
        public string Name => "calc";

        public string HelpText => "calc-[type of calculation: add, sub, div, mul]-[first number]-[second number] -> Do some simple calculations with two numbers";

        public void Execute(string Parameter, string Parameter2, string Parameter3)
        {
            if (Parameter2 == null || Parameter3 == null)
                throw new Exception("Not enough numbers given.");

            int number1 = Convert.ToInt32(Parameter2);
            int number2 = Convert.ToInt32(Parameter3);
            switch (Parameter)
            {
                case "add":
                    int sumReturn = number1 + number2;
                    Console.WriteLine($"{number1} + {number2} = " + sumReturn);
                    break;
                case "sub":
                    sumReturn = number1 - number2;
                    Console.WriteLine($"{number1} - {number2} = " + sumReturn);
                    break;
                case "div":
                    sumReturn = number1 / number2;
                    Console.WriteLine($"{number1}/{number2} = " + sumReturn);
                    break;
                case "mul":
                    sumReturn = number1 * number2;
                    Console.WriteLine($"{number1}*{number2} = " + sumReturn);
                    break;
                default:
                    throw new Exception("Couldnt calculate");
            }
        }
    }
}
