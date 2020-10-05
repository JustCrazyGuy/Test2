using ConsoleApp6.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp6.Commands
{
    class ChangeBirthday : ICommand
    {
        private readonly Dictionary<string, User> users;

        public ChangeBirthday(Dictionary<string, User> users)
        {
            this.users = users;
        }
        public bool CanRun(string input)
        {
            return input == "ChangeBirthday";
        }

        public string GetMenuRow()
        {
            return "ChangeBirthday - Изменить дату рождения";
        }

        public string Run(string input, ref bool isExit)
        {
            User user;
            List<int> busket = new List<int>();
            WriteLine("Введите свой логин: ");
            string currentWord = ReadLine();
            users.TryGetValue(currentWord, out user);
            WriteLine("Введите новую дату рождения: ");
            user.Birthday = Convert.ToDateTime(ReadLine());
            return "Дата рождения успешно изменена!";
        }
    }
}
