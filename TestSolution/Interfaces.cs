using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TestSolution
{
    public interface INamesProcessor
    {
        
        /// <summary>
        /// This method should obtain the name and do something with it, such as adding it to a dictionary.
        /// </summary>
        /// <param name="s"></param>
        string GetName(StreamReader sr);
    }

    public interface ITextProcessor
    {
        /// <summary>
        /// This 
        /// </summary>
        /// <param name="s"></param>
        string GetText(StreamReader sr);
    }

}
