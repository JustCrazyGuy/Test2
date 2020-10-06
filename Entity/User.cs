using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6.Entity
{
    [Serializable]
   public class User
    {
      
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }

        public static implicit operator Dictionary<object, object>(User v)
        {
            throw new NotImplementedException();
        }
    }
}
