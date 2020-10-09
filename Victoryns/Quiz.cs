using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6.Victoryns
{
    [Serializable]
    class Quiz
    {
        public Quiz()
        {
            biolige = new Dictionary<string, List<int>>();
            history = new Dictionary<string, List<int>>();
        }
        public Dictionary<String, List<int>> biolige { set; get; }
        public Dictionary<String, List<int>> history { set; get; }

        public static implicit operator Dictionary<object, object>(Quiz v)
        {
            throw new NotImplementedException();
        }
    }
}
