using ConsoleApp6.Victoryns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp6.Commands
{
    class ChangeAnswersInBiolige : ICommand
    {
        private readonly Biolige BioQu;

        public ChangeAnswersInBiolige(Biolige BioQu)
        {
            this.BioQu = BioQu;
        }

        public bool CanRun(string input)
        {
            return input == "ChangeAnBio";
        }

        public string GetMenuRow()
        {
            return "ChangeAnBio - Изменить ответ на викторину по биологии: ";
        }


        public string Run(string input, ref bool isExit)
        {
            List<int> busket = new List<int>();

            WriteLine("Введите вопрос,ответ которого хотите изменить: ");
            string currentWord = ReadLine();
            List<int> NewWords = new List<int>();

            BioQu.quations.TryGetValue(currentWord, out busket);

            if (!BioQu.quations.ContainsKey(currentWord))
            {

                return "Вопрос не найден";
            }
            WriteLine("Вопрос найден,введите какой ответ хотите изменить: ");

            if (!busket.Remove(Convert.ToInt32(ReadLine())))
            {
                return "Ответ не найден";
            }
            WriteLine("Введите новый ответ: ");
            busket.Add(Convert.ToInt32(ReadLine()));
            string currentWord2 = currentWord;
            BioQu.quations.Remove(currentWord);
            BioQu.quations.Add(currentWord2, busket);
            return "Ответ успешно изменён!";
        }
    }
}
