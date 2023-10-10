﻿using System;
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
    }
}
