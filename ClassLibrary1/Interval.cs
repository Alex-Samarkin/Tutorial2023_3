using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Interval
    {
        /// <summary>
        /// The nominal value, номинальное значение интервала
        /// </summary>
        public double Nominal { get; set; } = 0;
        /// <summary>
        /// Upper deviation, верхнее отклонение (от номинала)
        /// </summary>
        public double LowerDev { get; set; } = 0;
        /// <summary>
        /// Lower deviation, нижнее отклонение (от номинала)
        /// </summary>
        public double UpperDev { get; set; } = 0;

        /// <summary>
        /// Диапазон интервала
        /// </summary>
        public double TotalDev => -LowerDev + UpperDev;
        /// <summary>
        /// Максимальное значение
        /// </summary>
        public double MaxValue => Nominal + UpperDev;
        /// <summary>
        /// Минимальное значение
        /// </summary>
        public double MinValue => Nominal + LowerDev;
        /// <summary>
        /// Среднее
        /// </summary>
        public double Mean => (MaxValue-MinValue) / 2.0;

        public override string ToString()
        {
            return $"[{LowerDev,15:f5} => {Nominal,15:f5} <= {UpperDev,15:f5}]";
        }

    }
}
