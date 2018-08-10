using System;
using Xunit;
using TestSolution;
using System.IO;
using System.Collections.Generic;

namespace Tests
{
    public class UnitTests
    {
        [Theory]
        [InlineData("../../../../TestSolution/Data/names.txt")]
        public void CanGetNamesFromStream(string path)
        {
            INamesProcessor processor = new Names();

            using (StreamReader sr = new StreamReader(path))
            {
                string name = processor.GetName(sr);
                Assert.NotNull(name);
            }

        }

        [Theory]
        [InlineData("../../../../TestSolution/Data/list.txt")]
        public void CanGetTextFromStream(string path)
        {
            ITextProcessor processor = new Text();

            using (StreamReader sr = new StreamReader(path))
            {
                string text = processor.GetText(sr);
                Assert.NotNull(text);
            }
        }

        [Theory]
        [InlineData("../../../../TestSolution/Data/names.txt")]
        public void INamesProcessorCheckNormalization(string path)
        {
            INamesProcessor namesProcessor = new Names();

            using (StreamReader sr = new StreamReader(path))
            {
                string name = namesProcessor.GetName(sr);

                foreach(char c in name)
                {
                    Assert.True(char.IsLower(c));
                }
            }

        }

        [Theory]
        [InlineData("../../../../TestSolution/Data/names.txt")]
        public void ITextProcessorCheckNormalization(string path)
        {
            ITextProcessor listProcessor = new Text();

            using (StreamReader sr = new StreamReader(path))
            {
                string name = listProcessor.GetText(sr);

                foreach (char c in name)
                {
                    Assert.True(char.IsLower(c));
                }
            }
        }

        [Theory]
        [InlineData("../../../../TestSolution/Data/names.txt", "../../../../TestSolution/Data/list.txt", "Oliver", new int[] { 11927, 18571, 65847 })]
        public void CompareAgainstKnown(string namesPath, string listPath, string knownName, int[] knownLines)
        {
            INamesProcessor namesProcessor = new Names();
            ITextProcessor textProcessor = new Text();
            ComparisonProcessor processor = new ComparisonProcessor(namesProcessor, textProcessor);
            processor.Compare(namesPath, listPath);

            List<int> lines = processor.NameLinePairs[knownName.Trim().ToLower()];

            Assert.Equal(knownLines.Length, lines.Count);

            for(int i = 0; i < knownLines.Length; i++)
            {
                Assert.Equal(knownLines[i], lines[i]);
            }
        }
    }
}
