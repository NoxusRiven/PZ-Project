using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniWindowGameLib.Exception
{
    public class NullCharacterException : System.Exception
    {
        public NullCharacterException() : base("Character cannot be null.")
        {
        }

        public NullCharacterException(string message) : base(message)
        {
        }

        public NullCharacterException(string message, System.Exception inner) : base(message, inner)
        {
        }
    }
}
