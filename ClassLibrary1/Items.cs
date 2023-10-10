using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Items
    {
        public List<double> Values { get; set; } = new List<double>();

        public void Fill(double value = 0, int n = 100)
        {
            Values.Clear();
            for (int i = 0; i < n; i++)
            {
                Values.Add(value);
            }
        }
        public void Seq(double Start=0.0, double step=1.0, int n=100)
        {
            Values.Clear() ;
            for (int i = 0; i<n; i++)
            {
                Values.Add(Start+(double)i*step);
            }
        }
        public void LinSpace(double Start = 0.0, double Stop = 1.0, int n = 100)
        {
            double step = (Stop-Start)/n;
            Seq(Start, step, n);
        }
        public void ARange(double Start = 0.0, double Stop = 1.0, double step = 0.01)
        {
            int n = (int)((Stop-Start)/step);
            Seq(Start, step, n);
        }

        public void Generate (Func<double> generator, int n)
        {
            Values.Clear ();
            for (int i = 0;i < n;i++)
            {
                // создаем какукю-то переменную и добавляем ее
                // var x = generator();
                // Values.Add(x);
                Values.Add(generator());
            }
        }
        public void RandomDouble(int n=100)
        {
            // генератор случайных чисел
            Random random = new Random();
            // функция - без скобок, здесь надо передавать именно функцию
            Generate(random.NextDouble,n);
        }
        public void RandomDouble(double From, double To,int n=100)
        {
            // генератор случайных чисел
            Random random = new Random();
            // функция - без скобок, здесь надо передавать именно функцию
            Generate(random.NextDouble, n);
            for (int i = 0;i<Values.Count;i++)
            {
                Values[i] = From+(To-From)*Values[i];
            }
        }
        /// <summary>
        /// создание колонки на базе существующей с помощью функции-генератор
        /// </summary>
        /// <param name="generator">функция, принимающая один аргумент double 
        /// и возвращающая результат double</param>
        /// <param name="items"></param>
        public void Generate(Func<double,double> generator, Items items)
        {
            Values.Clear();
            foreach (double item in Values)
            {
                Values.Add(generator(item));
            }
        }
        /// <summary>
        /// замена значений в колонке значениями функции transform
        /// </summary>
        /// <param name="transform">функция, принимающая один параметр и возвращающая результат</param>
        public void Transform(Func<double,double> transform)
        {
            for (int i = 0; i < Values.Count;i++)
            {
                Values[i] = transform(Values[i]);
            }
        }
        public void Sin(Items items)
        {
            Generate(Math.Sin, items);
        }

        public string ToLongString(int first, int last, string filler=" ... ")
        {
            StringBuilder sb = new StringBuilder($"First {first} from {Values.Count} [ ");
            for (int i = 0; i < first; i++)
            {
                sb.Append($"{Values[i],10:f4} ");
            }
            sb.Append(filler);
            for (int i = Values.Count-last; i < Values.Count;i++)
            {
                sb.Append($"{Values[i],10:f4}");
            }
            sb.Append($" ] Last {last}");
            return sb.ToString();
        }

        public string TableFirstN(int n)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"First {n} from {Values.Count}");
            for(int i = 0;i < n;i++)
            {
                sb.AppendLine($"{i,-12} {Values[i],12:f4}");
            }
            return sb.ToString();
        }
        public string TableLastN(int n)
        {
            StringBuilder sb = new StringBuilder();
            
            for (int i = Values.Count-n; i < Values.Count; i++)
            {
                sb.AppendLine($"{i,-12} {Values[i],12:f4}");
            }
            sb.AppendLine($"Last {n} from {Values.Count}");
            return sb.ToString();
        }
        public string Table(int n)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(TableFirstN(n));
            sb.AppendLine("  . . .  ");
            sb.AppendLine(TableLastN(n));
            return sb.ToString();
        }

        public string Plot(int From, int To, int w = 100)
        {
            StringBuilder sb = new StringBuilder();
            var data = Values.GetRange(From,To);
            var min = data.Min();
            var max = data.Max();
            var h = max-min;
            sb.AppendLine($"From {From} to {To}, min = {min}, max = {max}");
            foreach (double x in data) { 
                var l = (int)((x-min)/h*w);
                var s = new string('#', l);
                var s2 = new string('-', w - l);
                sb.AppendLine("[" + s + "|" + s2 + "]" +$"{x,10:f4}");
            }
            return sb.ToString();
        }

    }
}
