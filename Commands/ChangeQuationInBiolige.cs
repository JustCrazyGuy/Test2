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
        private readonly Quiz Quast;

        public ChangeQuationInBiolige(Quiz Quast)
        {
            this.Quast = Quast;
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

            if (!Quast.biolige.ContainsKey(currentWord))
            {
                return "Вопрос не найден";
            }

            Quast.biolige.TryGetValue(currentWord, out busket);
            Quast.biolige.Remove(currentWord);

            WriteLine("Вопрос найден,введите новый");
            currentWord = ReadLine();
            Quast.biolige.Add(currentWord, busket);

            return "Вопрос успешно изменен!";
        }
    }
}
