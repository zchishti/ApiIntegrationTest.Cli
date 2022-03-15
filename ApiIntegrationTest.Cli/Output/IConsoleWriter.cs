using System;
using System.Collections.Generic;
using System.Text;

namespace ApiIntegrationTest.Cli.Output
{
    public interface IConsoleWriter
    {
        public void WriteLine(string text);
    }
}
