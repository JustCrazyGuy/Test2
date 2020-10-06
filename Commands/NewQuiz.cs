using ConsoleApp6.Victoryns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp6.Commands
{
    class NewQuiz : ICommand
    {
        private readonly Biolige BioQu;
        private readonly History HistQu;

        public NewQuiz(Biolige BioQu, History HistQu)
        {
            this.BioQu = BioQu;
            this.HistQu = HistQu;
        }
      

        public bool CanRun(string input)
        {
            return input == "CreateNewQuiz";
        }

        public string GetMenuRow()
        {
            return "CreateNewQuiz - Создать новую виторину";
        }

        public string Run(string input, ref bool isExit)
        {
            string quation;
            int key1;
            int key2;
            bool EndWords = true;
            List<int> Answers = new List<int>();
            {
                WriteLine("Выберете дисциплину(1-История 2-Биология): ");
                key1 =Convert.ToInt32(ReadLine());
                if (key1 > 2 || key1 < 1)
                {
                    return "Ошибка ввода";
                }
                //for (int i = 0; i < 20; i++)
                for (int i = 0; i < 2; i++)

                {
                    WriteLine("Введите Вопрос: ");
                quation = ReadLine();
                quation.Trim();
                    do
                    {
                        WriteLine("Введите правильный(ые) ответы в цифрах: ");
                        Answers.Add(Convert.ToInt32(ReadLine()));
                        WriteLine("\nЭто последний ответ? (1-да 2-нет)");
                        key2 = Convert.ToInt32(ReadLine());
                        if (key2 == 1)
                        {
                            EndWords = false;
                        }
                        else if (key2 == 2)
                        {
                            //
                        }
                        else
                        {
                            WriteLine("Ошибка ввода");
                        }
                    } while (EndWords);
                    EndWords = true;
                    if (key1 == 1)
                    {
                        HistQu.quations.Add(quation, Answers);
                    }
                    else
                    {
                        BioQu.quations.Add(quation, Answers);
                    }
                }
            }
            return "Создание прошло успешно!";
        }
    }
}
