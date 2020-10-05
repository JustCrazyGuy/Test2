using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6.Victoryns
{
    [Serializable]
    class Biolige
    {
        public Biolige()
        {
            quations = new Dictionary<string, List<int>>();
        }
        public Dictionary<string, List<int>> quations { set; get; }

        public static implicit operator Dictionary<object, object>(Biolige v)
        {
            throw new NotImplementedException();
        }
    }
}
