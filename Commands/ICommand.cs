using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6.Commands
{
    interface ICommand
    {
        bool CanRun(string input);
        string Run(string input, ref bool isExit);
        string GetMenuRow();

    }
}
