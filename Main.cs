using System;
using System.Collections.Generic;
using Wox.Plugin;
using System.IO;

namespace Appendisso
{
    public class Main : IPlugin
    {
        string fileToAppendPath = "c:\\Users\\Example.txt";


        public void Init(PluginInitContext context)
        {
        }

        public List<Result> Query(Query query)
        {
            // Get text typed by user
            string text = query.Search;

            var result = new Result
            {
                Title = "Append to file",
                SubTitle = fileToAppendPath + " " + text,
                IcoPath = "Images\\appendisso.png",
                Action = (Func<ActionContext, bool>)(c =>
               {
                   // When the user hits enter, run the method
                   Append(text);
                   // And hide the search bar
                   return true;
               })
            };

            return new List<Result> { result };
        }

        public void Append(string text)
        {
            // Append text to path + a new line
            File.AppendAllText(fileToAppendPath, text + Environment.NewLine);
        }
    }
}
