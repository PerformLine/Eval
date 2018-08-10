using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace TestSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initial solution


            //Simply read in names and list and use a dictionary to compare
            //for ~O(1) lookup. Assumes that the names list will fit in memory.

            Stopwatch sw = new Stopwatch();
            sw.Start();

            Dictionary<string, List<int>> nameLinePairs = new Dictionary<string, List<int>>();

            using (StreamReader sr = new StreamReader("../../../Data/names.txt"))
            {
                var line = "";
                do
                {
                    line = sr.ReadLine();

                    if(line != null)
                    {
                        nameLinePairs.Add(line.Trim().ToLower(), new List<int>());
                    }


                } while (line != null);

            }

            using (StreamReader sr = new StreamReader("../../../Data/list.txt"))
            {
                int i = 1; //assumes that a 1 based index is desired since we're printing a list
                var line = "";
                do
                {
                    line = sr.ReadLine();

                    if (line != null)
                    {
                        var key = line.Trim().ToLower();

                        if (nameLinePairs.ContainsKey(key))
                        {
                            nameLinePairs[key].Add(i);
                        }
                        
                        i++;
                    }


                } while (line != null);
            }


            sw.Stop();

            System.Diagnostics.Trace.WriteLine("Elapsed time to create dictionary and lookup values:" + sw.ElapsedMilliseconds + "ms");

            //Print the solution
            foreach (string s in nameLinePairs.Keys)
            {
                List<int> lines = nameLinePairs[s];

                var list = "";

                foreach (int line in lines)
                    list += line.ToString() + ", ";

                if (list.Length > 0)
                    list = list.Substring(0, list.Length - 2);

                Console.WriteLine(s + ":" + list);
            }

            Console.ReadLine();


        }
    }
}
