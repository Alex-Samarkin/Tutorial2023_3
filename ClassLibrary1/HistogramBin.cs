using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    /// <summary>
    /// класс для гистограмм
    /// изменяет значения в колонке
    /// </summary>
    public class HistogramBin
    {
        /// <summary>
        /// начало интервала
        /// </summary>
        public double From { get; set; } = 0;
        /// <summary>
        /// конец интервала
        /// </summary>
        public double To { get; set; } = 0;
        /// <summary>
        /// количество значений
        /// </summary>
        public int Count { get; set; } = 0;

        public void Set(double center, double h)
        {
            From = center - h / 2;
            To = center + h / 2;
            Count = 0;
        }

        public override string ToString() => $"|From {From,12:f4} |To {To,12:f4} |Freq {Count,16} | ";
    }
}
