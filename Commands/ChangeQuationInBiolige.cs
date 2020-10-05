using ConsoleApp6.Victoryns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp6.Commands
{
    class ChangeQuationInBiolige : ICommand
    {
        private readonly Biolige bioQu;

        public ChangeQuationInBiolige(Biolige bioQu)
        {
            this.bioQu = bioQu;
        }

        public bool CanRun(string input)
        {
            return input == "ChangeQBio";
        }

        public string GetMenuRow()
        {
            return "ChangeQBio - Изменить вопрос в викторине по биологии";
        }

        public string Run(string input, ref bool isExit)
        {
            List<int> busket = new List<int>();
            WriteLine("Введите вопрос который хотите изменить: ");
            string currentWord = ReadLine();

            if (!bioQu.quations.ContainsKey(currentWord))
            {
                return "Вопрос не найден";
            }

            bioQu.quations.TryGetValue(currentWord, out busket);
            bioQu.quations.Remove(currentWord);

            WriteLine("Вопрос найден,введите новый");
            currentWord = ReadLine();
            bioQu.quations.Add(currentWord, busket);

            return "Вопрос успешно изменен!";
        }
    }
}
