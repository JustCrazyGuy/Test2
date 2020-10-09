using ConsoleApp6.Victoryns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp6.Commands
{
    class ChangeQuationInHistory : ICommand
    {
        private readonly Quiz Quast;

        public ChangeQuationInHistory(Quiz Quast)
        {
            this.Quast = Quast;
        }
        public bool CanRun(string input)
        {
            return input == "ChangeQHist";
        }

        public string GetMenuRow()
        {
            return "ChangeQHist - Изменить вопрос в викторине по истории";
        }

        public string Run(string input, ref bool isExit)
        {
            List<int> busket = new List<int>();
            WriteLine("Введите вопрос который хотите изменить: ");
            string currentWord = ReadLine();

            if (!Quast.history.ContainsKey(currentWord))
            {
                return "Вопрос не найден";
            }

            Quast.history.TryGetValue(currentWord, out busket);
            Quast.history.Remove(currentWord);

            WriteLine("Вопрос найден,введите новый");
            currentWord = ReadLine();
            Quast.history.Add(currentWord, busket);

            return "Вопрос успешно изменен!";
        }
    }
}
