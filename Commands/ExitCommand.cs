using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6.Commands
{
    class ExitCommand : ICommand
    {
        public bool CanRun(string input)
        {
            return input == "exit";
        }

        public string GetMenuRow()
        {
            return "exit - выход";
        }

        public string Run(string input, ref bool isExit)
        {
            isExit = true;
            return "Работа приложения завершена.";
        }
    }
}
