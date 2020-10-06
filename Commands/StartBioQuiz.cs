using ConsoleApp6.Victoryns;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp6.Commands
{
    class StartBioQuiz : ICommand
    {
        private readonly Biolige bioQu;

        public StartBioQuiz(Biolige bioQu)
        {
            using (Stream FileS = File.OpenRead("Biolige.txt"))
            {
                try
                {
                    BinaryFormatter Serializer = new BinaryFormatter();
                    bioQu = (Biolige)Serializer.Deserialize(FileS);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                    throw;
                }
            }
            foreach (var count in bioQu.quations)
            {
                this.bioQu = bioQu;
            }
        }

        public bool CanRun(string input)
        {
            return input == "1";
        }

        public string GetMenuRow()
        {
            return "1 - Начать викторину по биологии";
        }

        public string Run(string input, ref bool isExit)
        {
            List<int> answer = new List<int>();
            //List<int> yourAnswer = new List<int>();
            int yourAnswer;
            int niceAnswer = 0;
            bool reallyAnswer = false;
            bool endAnswer = false;
            foreach(var count in bioQu.quations)
            {
                bioQu.quations.TryGetValue(bioQu.quations.Keys.ToString(), out answer);
                WriteLine(bioQu.quations.Keys);
                do
                {
                    yourAnswer = Convert.ToInt32(ReadLine());
                    if (answer.Contains(yourAnswer))
                    {
                        reallyAnswer = true;
                    }

                }
                while (!endAnswer);
                if (reallyAnswer == true)
                {
                    ++niceAnswer;
                    reallyAnswer = false;
                }
            }
            return "Конец! ваши баллы: " + reallyAnswer.ToString() + "из " + bioQu.quations.Count.ToString();
        }
    }
}
