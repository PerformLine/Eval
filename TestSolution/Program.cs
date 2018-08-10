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
            //Allow for user specified file locations.
            //arg[0]: the path to the names
            //arg[1]: the path to the list

            if(args.Length <= 0)
            {
                args = new string[2];
                args[0] = "../../../Data/names.txt";
                args[1] = "../../../Data/list.txt";
            }

            if (!File.Exists(args[0]))
                throw new Exception("Invalid names path.");

            if (!File.Exists(args[1]))
                throw new Exception("Invalid list path.");

            //Simply read in names and list and use a dictionary to compare
            //for ~O(1) lookup. Assumes that the names list will fit in memory.

            Stopwatch sw = new Stopwatch();
            sw.Start();

            INamesProcessor namesProcessor = new Names();
            ITextProcessor textProcessor = new Text();
            ComparisonProcessor processor = new ComparisonProcessor(namesProcessor, textProcessor);
            processor.Compare(args[0], args[1]);

            sw.Stop();

            System.Diagnostics.Trace.WriteLine("Elapsed time to create dictionary and lookup values:" + sw.ElapsedMilliseconds + "ms");

            Print(processor.NameLinePairs);

            Console.ReadLine();
        }

        static void Print(Dictionary<string, NameLinePairValue> nameLinePairs)
        {
            //Print the solution
            foreach (string s in nameLinePairs.Keys)
            {
                List<int> lines = nameLinePairs[s].Lines;

                var list = "";

                foreach (int line in lines)
                    list += line.ToString() + ", ";

                if (list.Length > 0)
                    list = list.Substring(0, list.Length - 2);

                Console.WriteLine(nameLinePairs[s].OriginalName + ": " + list);
            }
        }
    }
}
