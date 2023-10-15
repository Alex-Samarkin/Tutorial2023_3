using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Histogram
    {
        /// <summary>
        /// Список бинов с границами и количеством значений (изначально нулевой)
        /// </summary>
        public List<HistogramBin> Bins { get; set; } = new List<HistogramBin>();

        public int BinsCount(Items items)
        {
            return (int)(3.2 * Math.Log10(items.Values.Count) + 1);
        }
        public void Construct(Items items)
        {
            // очищаем бины
            Bins.Clear();

            // сортируем
            var sorted = items.Sorted;
            // считаем количество бинов
            var K = BinsCount(items);
            // считаем ширину бинов
            var h = (items.Values.Max() - items.Values.Min()) / K;
            // создаем бины
            for (int i = 0; i < K+1; i++)
            {
                // создаем бин  
                var bin = new HistogramBin();
                // добавляем бин
                bin.Set(items.Values.Min() + h * (double)i, h);
                Bins.Add(bin);
            }
            // добавляем значения в бины, сейчас это накопленные значения
            foreach (var bin in Bins)
            {
                bin.Count = sorted.FindLastIndex(x => bin.To >= x);
            }
            // рассчитываем разницу
            for (int i = Bins.Count-1; i > 1; i--)
            {
                Bins[i].Count = Bins[i].Count - Bins[i - 1].Count;
            }
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            var max = Bins.Max(x => x.Count);

            if (Bins.Count > 0)
            {
                foreach (var bin in Bins)
                {
                    stringBuilder.Append(bin.ToString());
                    var h = (int)((double)bin.Count / max * 100.0);
                    var s = new string('#', h/2);
                    stringBuilder.AppendLine(s);
                    
                }
            }
            return stringBuilder.ToString();
        }

    }
}
