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
        private readonly Biolige Bio;
        private readonly History Hist;
        public LoadFromFile(Biolige Dictionary, History Dictionary2)
        {
            this.Bio = Dictionary;
            this.Hist = Dictionary2;
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
            Biolige BuffDictionary1 = new Biolige();
            History BuffDictionary2 = new History();
            BinaryFormatter Serializer = new BinaryFormatter();
            using (Stream FileS = File.OpenRead("Biolige.txt"))
            {
                BuffDictionary1 = Serializer.Deserialize(FileS) as Biolige;
            }
            Bio.quations = BuffDictionary1.quations;
            using (Stream FileS = File.OpenRead("History.txt"))
            {
                BuffDictionary2 = Serializer.Deserialize(FileS) as History;
            }
            Hist.quations = BuffDictionary2.quations;
            return "Загрузка прошло успешно\n";
        }
    }
}
