using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using ConsoleApp6.Victoryns;

namespace ConsoleApp6.Commands
{
    class SaveInFileHistory : ICommand
    {
        private readonly Quiz Quast;

        public SaveInFileHistory(Quiz Quast)
        {
            this.Quast = Quast;
        }
        public bool CanRun(string input)
        {
            return input == "SaveFileHist";
        }

        public string GetMenuRow()
        {
            return "SaveFileHist - Сохранить викторину по истории";
        }
        public string Run(string input, ref bool isExit)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            using (Stream FileS = File.OpenWrite("History.txt"))
            {
                serializer.Serialize(FileS, Quast.history);
            }
            return "Сохранение прошло успешно\n";
        }
    }
}
