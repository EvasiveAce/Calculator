using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public class Calc
    {

        public Dictionary<string, double> variables = new();


        /// <summary>
        /// Just to get the current state.
        /// If not there, equal 0.
        /// </summary>
        /// <returns> Returns the state value. </returns>
        public double getState()
        {
            return variables.ContainsKey("currentValue") ? variables["currentValue"] : 0;
        }

        /// <summary>
        /// Clear state to 0.
        /// </summary>
        public void clearState()
        {
            variables["currentValue"] = 0;
            Console.Clear();
        }
        
        /// <summary>
        /// Parse from string to a value, if variable it will
        /// continue being a string. Checks it through variables dictionary.
        /// </summary>
        /// <param name="value"> Value you want to parse. </param>
        /// <returns> The parsed/not parsed data. </returns>
        public double Parse(string value)
        {
            double x;
            if (variables.ContainsKey(value))
            {
                x = variables[value];
            }
            else
            {
                double.TryParse(value, out x);
            }
            return x;
        }

        //public void Store(string key)
        //{
        //    double x;

        //    if (Regex.IsMatch(key, @"^[a-zA-Z]+$"))
        //    {
        //        double.TryParse(this.getState().ToString(), out x);
        //        variables[key] = x;
        //    }
        //    else
        //    {
        //        Console.WriteLine("This variable contains an off limit digit. Please try again");
        //    }

        //}

        /// <summary>
        /// Storing a variable and value. Makes sure to match only
        /// characters to not include digits/special chars.
        /// </summary>
        /// <param name="key"> The variable key. </param>
        /// <param name="value"> The variable value. </param>
        public void Store(string key, string value)
        {
            double x;
            
            if (Regex.IsMatch(key, @"^[a-zA-Z]+$"))
            {
                double.TryParse(value, out x);
                variables[key] = x;

                calcString($"{key} = {x}");

            }
            else
            {
                Console.Clear();
                Console.WriteLine("This variable contains an off limit digit. Please try again");
                
            }

        }

        //public void Add(string a)
        //{
        //    double x = Parse(a);
        //    variables["currentValue"] = this.getState() + x;

        //    calcString($"{this.getState()} + {x} = {variables["currentValue"]}");

        //}

        /// <summary>
        /// Takes two strings in, parses them, and adds them.
        /// </summary>
        /// <param name="a"> First value. </param>
        /// <param name="b"> Second value. </param>
        public void Add(string a, string b)
        {
            double x = Parse(a);
            double y = Parse(b);
            variables["currentValue"] = x + y;

            calcString($"{x} + {y} = {variables["currentValue"]}");

        }

        //public void Subtract(string a)
        //{
        //    double x = Parse(a);
        //    var temp = this.getState();
        //    Console.WriteLine(temp);
        //    variables["currentValue"] = this.getState() - x;

        //    calcString($"{temp} - {x} = {variables["currentValue"]}");

        //}

        /// <summary>
        /// Takes two strings in, parses them, and subtracts them.
        /// </summary>
        /// <param name="a"> First value. </param>
        /// <param name="b"> Second value. </param>
        public void Subtract(string a, string b)
        {
            double x = Parse(a);
            double y = Parse(b);
            variables["currentValue"] = x - y;

            calcString($"{x} - {y} = {variables["currentValue"]}");

        }

        //public void Multiply(string a)
        //{
        //    double x = Parse(a);
        //    variables["currentValue"] = this.getState() * x;

        //    calcString($"{this.getState()} * {x} = {variables["currentValue"]}");

        //}

        /// <summary>
        /// Takes two strings in, parses them, and multiplies them.
        /// </summary>
        /// <param name="a"> First value. </param>
        /// <param name="b"> Second value. </param>
        public void Multiply(string a, string b)
        {
            double x = Parse(a);
            double y = Parse(b);
            variables["currentValue"] = x * y;

            calcString($"{x} * {y} = {variables["currentValue"]}");

        }

        //public void Divide(string a)
        //{
        //    double x = Parse(a);
        //    variables["currentValue"] = this.getState() / x;
        //}

        /// <summary>
        /// Takes two strings in, parses them, and divides them.
        /// </summary>
        /// <param name="a"> First value. </param>
        /// <param name="b"> Second value. </param>
        public void Divide(string a, string b)
        {
            double x = Parse(a);
            double y = Parse(b);
            variables["currentValue"] = x / y;

            calcString($"{x} / {y} = {variables["currentValue"]}");

        }

        //public void Mod(string a)
        //{
        //    double x = Parse(a);
        //    variables["currentValue"] = this.getState() % x;
        //}

        /// <summary>
        /// Takes two strings in, parses them, and gets the modulus of them.
        /// </summary>
        /// <param name="a"> First value. </param>
        /// <param name="b"> Second value. </param>
        public void Mod(string a, string b)
        {
            double x = Parse(a);
            double y = Parse(b);
            variables["currentValue"] = x % y;

            calcString($"{x} % {y} = {variables["currentValue"]}");

        }

        /// <summary>
        /// Takes a string in, parses it, and squares it by 2.
        /// </summary>
        /// <param name="a"> First value. </param>
        public void Square(string a)
        {
            double x = Parse(a);
            variables["currentValue"] = Math.Pow(x, 2);

            calcString($"{x} ^ {2} = {variables["currentValue"]}");

        }

        /// <summary>
        /// Takes a string in, parses it, and square roots it.
        /// </summary>
        /// <param name="a"> First value. </param>
        public void SquareRoot(string a)
        {
            double x = Parse(a);
            variables["currentValue"] = Math.Sqrt(x);

            calcString($"√{x} = {variables["currentValue"]}");

        }

        /// <summary>
        /// Takes two strings in, parses them, and squares the first by the second.
        /// </summary>
        /// <param name="a"> First value. </param>
        /// <param name="b"> Second value. </param>
        public void Exponentiate(string a, string b)
        {
            double x = Parse(a);
            double y = Parse(b);
            variables["currentValue"] = Math.Pow(x, y);

            calcString($"{x} ^ {y} = {variables["currentValue"]}");

        }

        /// <summary>
        /// Takes a string in, parses it, and does a factorial on it.
        /// </summary>
        /// <param name="a"> First value. </param>
        public void Factorial(string a)
        {
            double x = Parse(a);
            double result = 1;
            for (double i = x; i > 0; i--)
            {
                result *= i;
            }

            variables["currentValue"] = result;

            calcString($"!{x} = {variables["currentValue"]}");
        }

        /// <summary>
        /// A simple and good looking menu for the calculating. 
        /// </summary>
        /// <param name="statement"> The statement that it takes in for the actual computing. </param>
        public void calcString(string statement)
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(statement);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
