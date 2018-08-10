using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TestSolution
{

    public class Names : INamesProcessor
    {
        /// <summary>
        /// Get the name.
        /// </summary>
        /// <param name="s"></param>
        public string GetName(StreamReader sr)
        {

            var line = "";
            do
            {
                line = sr.ReadLine();

                if (line != null)
                {
                    return line.Trim().ToLower();
                }


            } while (line != null);

            return null;
        }
    }

    public class Text : ITextProcessor
    {
        public string GetText(StreamReader sr)
        {

            var line = "";
            do
            {
                line = sr.ReadLine();

                if (line != null)
                {
                    return line.Trim().ToLower();
                }


            } while (line != null);

            return null;
        }
    }


    public class ComparisonProcessor
    {
        public Dictionary<string, List<int>> NameLinePairs { get; } = new Dictionary<string, List<int>>();

        public INamesProcessor NamesProcessor { get; }

        public ITextProcessor TextProcessor { get; }

        public ComparisonProcessor(INamesProcessor namesProcessor, ITextProcessor textProcessor)
        {
            NamesProcessor = namesProcessor;
            TextProcessor = textProcessor;

            if (NamesProcessor == null)
                throw new ArgumentException("NamesProcessor can't be null.");

            if (TextProcessor == null)
                throw new ArgumentException("TextProcessor can't be null.");
        }

        public void Compare(string namesPath, string listPath)
        {
            using (StreamReader sr = new StreamReader(namesPath))
            {
                string name = "";

                do
                {
                    name = this.NamesProcessor.GetName(sr);

                    if (name != null && !this.NameLinePairs.ContainsKey(name)) //name could be repeated
                    {
                        this.NameLinePairs.Add(name, new List<int>());
                    }

                } while (name != null);
            }

            using (StreamReader sr = new StreamReader(listPath))
            {
                string text = "";

                int i = 1; //assumes that a 1 based index is desired since we're printing a list

                do
                {
                    text = this.TextProcessor.GetText(sr);

                    if (text != null && this.NameLinePairs.ContainsKey(text))
                    {
                        this.NameLinePairs[text].Add(i);
                    }

                    i++;

                } while (text != null);

            }
        }

    }
}
