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
    ///
    public class FileManager
    {
        string fileLocation = @"../../../variables.txt";

        /// <summary>
        /// For file saving, basically takes in the dictionary (variables) and writes it out in the format
        /// {0} {1} making it very easy to read back in.
        /// </summary>
        /// <param name="dictionary"> Variables dictionary from calc. </param>
        public void fileSave(Dictionary<string, double> dictionary)
        {
            using (StreamWriter file = new StreamWriter(fileLocation))
                foreach (var item in dictionary)
                    file.WriteLine("{0} {1}", item.Key, item.Value);
            Console.Clear();
        }
        
        /// <summary>
        /// For loading, I couldn't get it to work directly with the dictionary so I made it so it for loops
        /// to add everything to the right dictionary in calc.
        /// I also made it remvoe currentValue because I did not like the way it looks.
        /// 
        /// Do not try to load a file without saving and exiting.
        /// I couldn't figure/didn't have time to find a work around.
        /// </summary>
        /// <param name="fileName"> Takes in file, minus the .txt from user. </param>
        /// <param name="dictionary"> Calc dictionary so we can access it. </param>
        public void fileLoad(string fileName, Dictionary<string, double> dictionary)
        {
            var fileLocationToUse = $@"../../../{fileName}.txt";

            var res = File.ReadAllLines(fileLocationToUse)
                .Select(x => x.Split(' '))
                .ToDictionary(x => x[0], x => Convert.ToDouble(x[1]));

            for (int i = 0; i < res.Count; i++)
            {
                dictionary.Add(res.Keys.ElementAt(i), Convert.ToDouble(res.Values.ElementAt(i)));
            }

            if(dictionary.Keys.Contains("currentValue"))
            {
                dictionary.Remove("currentValue");
            }

            Console.Clear();
        }
    }
}