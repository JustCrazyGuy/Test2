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
        private readonly Quiz quast;

        public StartBioQuiz(Quiz quast)
        {
            try
            {
                const string Path = "Biolige.txt";
                using (Stream FileS = File.OpenRead(Path))
                {
                    try
                    {
                        BinaryFormatter Serializer = new BinaryFormatter();
                        quast.biolige = (Dictionary<string, List<int>>)Serializer.Deserialize(FileS);
                    }
                    catch (SerializationException e)
                    {
                        WriteLine("Failed to deserialize. Reason: " + e.Message);
                        throw;
                    }
                }
                foreach (var count in quast.biolige)
                {
                    this.quast.biolige = quast.biolige;
                }
            }
            catch
            {
                WriteLine("Викторина по биологии не найдена!Пожалуйста создайте её и перезапустите программу\n");
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
            foreach(var count in quast.biolige)
            {
                quast.biolige.TryGetValue(quast.biolige.Keys.ToString(), out answer);
                WriteLine(quast.biolige.Keys);
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
            return "Конец! ваши баллы: " + reallyAnswer.ToString() + "из " + quast.biolige.Count.ToString();
        }
    }
}
