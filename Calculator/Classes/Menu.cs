using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


///////////////////////////////////////////////////////////////////////////////
//
// Author: Ethan H.
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 7
// Description: Calculator using dispatch tables.
//
///////////////////////////////////////////////////////////////////////////////
namespace Calculator.Classes
{
    public class Menu
    {
        public static Dictionary<string, dynamic> dispatchTable = new();
        Calc calc = new Calc();
        FileManager fileManager = new FileManager();

        /// <summary>
        /// Just has the dispatchTable and the actions for such. Gets created
        /// when creating a menu class.
        /// </summary>
        public Menu()
        {
            dispatchTable["Add"] = new Action<string, string>((x, y) => calc.Add(x, y));
            dispatchTable["Subtract"] = new Action<string, string>((x, y) => calc.Subtract(x, y));
            dispatchTable["Multiply"] = new Action<string, string>((x, y) => calc.Multiply(x, y));
            dispatchTable["Divide"] = new Action<string, string>((x, y) => calc.Divide(x, y));
            dispatchTable["Mod"] = new Action<string, string>((x, y) => calc.Mod(x, y));
            dispatchTable["Square"] = new Action<string>((x) => calc.Square(x));
            dispatchTable["SquareRoot"] = new Action<string>((x) => calc.SquareRoot(x));
            dispatchTable["Exponentiate"] = new Action<string, string>((x, y) => calc.Exponentiate(x, y));
            dispatchTable["Factorial"] = new Action<string>((x) => calc.Factorial(x));


            dispatchTable["Save"] = new Action<Dictionary<string, double>>((x) => fileManager.fileSave(x));
            dispatchTable["Load"] = new Action<string, Dictionary<string, double>>((x, y) => fileManager.fileLoad(x, y));
            dispatchTable["Clear"] = new Action(() => calc.clearState());
            dispatchTable["Store"] = new Action<string, string>((x, y) => calc.Store(x, y));

        }

        /// <summary>
        /// Loops the menu while loop infinitely, press ctrl-c to exit.
        /// 
        /// Probably should've added and exit and it is easily doable, just forgot.
        /// </summary>
        public void menuLoop()
        {
            while (true)
            {
                MenuString();
                string[] input = Console.ReadLine().Split(" ");


                // If this has three items (add 1 2), if it's store it will do it normally,
                // if not dispatchCompute.
                if (input.Length == 3)
                {
                    if(input[0] == "Store")
                    {
                        dispatchTable[input[0]](input[1], input[2]);
                    }
                    else
                    {
                        dispatchCompute(input[0], input[1], input[2]);
                    }
                }
                else if (input.Length == 2)
                {
                    // Needed because it was throwing errors doing it normally, since
                    // the code is written to auto fill in with calc.getState().ToString().
                    if (input[0] == "Square" || input[0] == "SquareRoot" || input[0] == "Factorial")
                    {
                        dispatchCompute(input[0], input[1]);
                    }
                    else if (input[0] == "Store")
                    {
                        dispatchTable[input[0]](input[1], calc.getState().ToString());
                    }
                    else if (input[0] == "Load")
                    {
                        dispatchTable[input[0]](input[1], calc.variables);
                    }
                    else
                    {
                        dispatchCompute(input[0], calc.getState().ToString(), input[1]);
                    }
                }
                else if (input.Length == 1)
                {
                    // Basically only for the one liners, specific cases.
                    if (input[0] == "Clear")
                    {
                        dispatchTable[input[0]]();
                    }
                    else if(input[0] == "Save")
                    {
                        dispatchTable[input[0]](calc.variables);
                    }
                }
            }
        }

        /// <summary>
        /// Used to check to see if the thing to check is an actual variable, double, or invalid.
        /// First if is to check if double, for each is to check to see if any matches.
        /// If false, invalid variable.
        /// </summary>
        /// <param name="variableToCheck"> Any variable you want to check. </param>
        /// <returns> True or false depending on if valid. </returns>
        public bool variableCheck(string variableToCheck)
        {
            if (double.TryParse(variableToCheck, out double value))
            {
                return true;
            }

            foreach (var item in calc.variables.Keys)
            {
                if (variableToCheck == item)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Dispatch table fix, takes in the dispatch action as well as input, to 
        /// see if the variable is valid. If false from variableCheck, will not compute.
        /// </summary>
        /// <param name="input0"> Dispatch table action. </param>
        /// <param name="input1"> The variable or value. </param>
        public void dispatchCompute(string input0, string input1)
        {
            var result1 = variableCheck(input1);
            if (result1 == false)
            {
                Console.Clear();
                Console.WriteLine("The variable you entered is invalid! Please try a different variable.");
            }
            else
            {
                dispatchTable[input0](input1);
            }
        }

        /// <summary>
        /// Same as the top overloaded one, but for two values instead of one.
        /// </summary>
        /// <param name="input0"> Dispatch table action. </param>
        /// <param name="input1"> The first variable or value. </param>
        /// <param name="input2"> The second variable or value. </param>
        public void dispatchCompute(string input0, string input1, string input2)
        {
            var result1 = variableCheck(input1);
            var result2 = variableCheck(input2);
            if(result1 == true && result2 == true)
            {
                dispatchTable[input0](input1, input2);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("The variable you entered is invalid! Please try a different variable.");
            }
        }

        /// <summary>
        /// Clean looking menu system that shows all the possible values
        /// as well as anything else you may need to do.
        /// 
        /// Could use an exit.
        /// </summary>
        public void MenuString()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please select a choice: (Case Sensitive)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("Add");
            Console.WriteLine("Subtract");
            Console.WriteLine("Multiply");
            Console.WriteLine("Divide");
            Console.WriteLine("Mod (Modulus)");
            Console.WriteLine("Square (^2)");
            Console.WriteLine("SquareRoot");
            Console.WriteLine("Exponentiate");
            Console.WriteLine("Factorial");
            Console.WriteLine();
            Console.WriteLine("Store (Store variable: a-z A-Z only)");
            Console.WriteLine("Save (Save variables to file)");
            Console.WriteLine("Load (Load variables from file: include file string, no ext)");
            Console.WriteLine("Clear");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Current State: {calc.getState()}");
            Console.ForegroundColor = ConsoleColor.White;


        }
    }
}
