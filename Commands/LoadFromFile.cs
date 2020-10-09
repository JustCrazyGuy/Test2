using ConsoleApp6.Victoryns;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6.Commands
{
    class LoadFromFile : ICommand
    {
        private readonly Quiz Quast;

        public LoadFromFile(Quiz Quast)
        {
            this.Quast = Quast;
        }

        public bool CanRun(string input)
        {
            return input == "LoadFromFile";
        }


        public string GetMenuRow()
        {
            return "LoadFromFile - Загрузить данные из файла";
        }
        public string Run(string input, ref bool isExit)
        {
            Quiz BuffDictionary1 = new Quiz();
            Quiz BuffDictionary2 = new Quiz();
            BinaryFormatter Serializer = new BinaryFormatter();
            using (Stream FileS = File.OpenRead("Biolige.txt"))
            {
                BuffDictionary1 = Serializer.Deserialize(FileS) as Quiz;
            }
            Quast.biolige = BuffDictionary1.biolige;
            using (Stream FileS = File.OpenRead("History.txt"))
            {
                BuffDictionary2 = Serializer.Deserialize(FileS) as Quiz;
            }
            Quast.history = BuffDictionary2.history;
            return "Загрузка прошло успешно\n";
        }
    }
}
