using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniWindowGameLib.Core
{
    public static class Formater
    {
        public static string Indent(int levelTabs)
        {
            string indent = "";
            for(int i = 0; i < levelTabs; i++)
            {
                indent += "    ";
            }

            return indent;
        }
    }
}
