using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Column
    {
        public Head Head { get; set; } = new Head();
        public Items Items { get; set; } = new Items();

        public string HR(string pattern = "[=]", int w = 100)
        {
            var s = new String(pattern[1], w - 2);
            return $"{pattern[0]}{s}{pattern[2]}";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(HR());
            sb.AppendLine(Head.ToString());
            sb.AppendLine(HR());
            sb.AppendLine(Items.Table(12));
            sb.AppendLine(HR());
            return sb.ToString();
        }
    }
}
