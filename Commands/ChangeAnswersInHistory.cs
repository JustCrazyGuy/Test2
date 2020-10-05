using ConsoleApp6.Victoryns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp6.Commands
{
    class ChangeAnswersInHistory : ICommand
    {
        private readonly History HistQu;

        public ChangeAnswersInHistory(History HistQu)
        {
            this.HistQu = HistQu;
        }

        public bool CanRun(string input)
        {
            return input == "ChangeAnHist";
        }

        public string GetMenuRow()
        {
            return "ChangeAnHist - Изменить ответ на викторину по истории: ";
        }


        public string Run(string input, ref bool isExit)
        {
            List<int> busket = new List<int>();

            WriteLine("Введите вопрос,ответ которого хотите изменить: ");
            string currentWord = ReadLine();
            List<int> NewWords = new List<int>();

            HistQu.quations.TryGetValue(currentWord, out busket);

            if (!HistQu.quations.ContainsKey(currentWord))
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
            HistQu.quations.Remove(currentWord);
            HistQu.quations.Add(currentWord2, busket);
            return "Ответ успешно изменён!";
        }
    }
}
