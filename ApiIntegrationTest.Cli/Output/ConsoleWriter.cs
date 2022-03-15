using System;
using System.Collections.Generic;
using System.Text;

namespace ApiIntegrationTest.Cli.Output
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
