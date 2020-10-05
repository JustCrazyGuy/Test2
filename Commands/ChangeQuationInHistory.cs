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
        private readonly History HistQu;

        public ChangeQuationInHistory(History HistQu)
        {
            this.HistQu = HistQu;
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

            if (!HistQu.quations.ContainsKey(currentWord))
            {
                return "Вопрос не найден";
            }

            HistQu.quations.TryGetValue(currentWord, out busket);
            HistQu.quations.Remove(currentWord);

            WriteLine("Вопрос найден,введите новый");
            currentWord = ReadLine();
            HistQu.quations.Add(currentWord, busket);

            return "Вопрос успешно изменен!";
        }
    }
}
