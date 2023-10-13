using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ScreenTable
    {
        public int W1 { get; set; } = 30;
        public int W2 { get; set; } = 50;
        public char HBoard { get; set; } = '-';
        public char VBoard { get; set; } = '|';

        public List<string> Names { get; set; } = new List<string>();
        public List<string> Names2 { get;set; } = new List<string>();

        public void Add(string name, string value)
        { 
            this.Names.Add(name); 
            this.Names2.Add(value); 
        }
        public void Add(string name, double value)
        {
            this.Names.Add(name);
            this.Names2.Add($"{value,15:f5}");
        }
        string w_string(string content, int w)
        {
            var s1 = new string(' ', w - 1 - content.Length - 1);
            return s1+content+" ";
        }
        string w2_string(string content1, string content2) 
        { 
            return VBoard.ToString()+w_string(content1,W1)+
                VBoard.ToString() + w_string(content2, W2)+
                VBoard.ToString();
        }
        string hborder()
        {
            return new string(HBoard, W1 + W2 + 1);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(hborder());
            for (int i = 0; i < this.Names.Count; i++)
            {
                sb.AppendLine(w2_string(Names[i], Names2[i]));
                sb.AppendLine(hborder());
            }
            return sb.ToString();
        }
    }
}
