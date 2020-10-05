using ConsoleApp6.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp6.Commands
{
    class ChangePassword : ICommand
    {
        private readonly Dictionary<string, User> users;

        public ChangePassword(Dictionary<string, User> users)
        {
            this.users = users;
        }
        public bool CanRun(string input)
        {
            return input == "ChangePassword";
        }

        public string GetMenuRow()
        {
            return "ChangePassword - Изменить пароль";
        }

        public string Run(string input, ref bool isExit)
        {
            User user;
            List<int> busket = new List<int>();
            WriteLine("Введите свой логин: ");
            string currentWord = ReadLine();
            users.TryGetValue(currentWord,out user);
            WriteLine("Введите новый пароль: ");
            user.Password = ReadLine();
            return "Пароль успешно изменен!";
        }
    }
}
