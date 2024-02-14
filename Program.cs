using System;
using System.Data;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using CommandConsole.Commands;

namespace CommandConsole
{
    internal class Program
    {
        public static string userInput;

        public static void Main(string[] args)
        {
            Framework framework = new Framework();
            while (true)
            {
                userInput = Console.ReadLine();
                if (userInput == null)
                {
                    throw new Exception("Input cant be empty");
                }

                framework.Execute(userInput);
            }
        }

    }
}