using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Head
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "Value";
        public string Description { get; set; } = "Value";
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Id {Id,-6} {Name}");
            sb.AppendLine(Description);
            return sb.ToString();
        }
    }
}
