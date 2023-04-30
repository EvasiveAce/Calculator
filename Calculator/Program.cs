using Calculator.Classes;
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
namespace Calculator
{
    class Program
    {
        public static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.menuLoop();
        }
    }

}