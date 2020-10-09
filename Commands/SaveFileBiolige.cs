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
    class SaveInFileBiolige : ICommand
    {
        private readonly Quiz Quast;

        public SaveInFileBiolige(Quiz Quast)
        {
            this.Quast = Quast;
        }
        public bool CanRun(string input)
        {
            return input == "SaveFileBio";
        }

        public string GetMenuRow()
        {
            return "SaveFileBio - Сохранить викторину по биологии";
        }
        public string Run(string input, ref bool isExit)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            const string Path = "Biolige.txt";
            
            using (Stream FileS = File.OpenWrite(Path.ToLower()))
            {
                serializer.Serialize(FileS, Quast.biolige);
            }
            return "Сохранение прошло успешно\n";
        }
    }
}
