using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathNet.Numerics;
using MathNet.Numerics.Statistics;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.Random;


namespace ClassLibrary1
{
    public class StudentDistr
    {
        public double Location { get; set; } = 0;
        public double Scale { get; set; } = 1;
        public int DOF { get; set; } = 1;
        public StudentT StudentT { get; set; } = new MathNet.Numerics.Distributions.StudentT();
        public double PDF (double x) => StudentT.PDF(Location,Scale,DOF,x);
        public double PDFLn(double x) => StudentT.PDFLn(Location, Scale, DOF, x);
        public double CDF(double x) => StudentT.CDF(Location, Scale, DOF, x);
        public double InvCDF(double x) => StudentT.InvCDF(Location, Scale, DOF, x);

        public double PLesserThan(double x) => CDF(x);
        public double PGreaterThan(double x) => 1 - CDF(x);
        public double PBetween(double from, double to) => CDF(from)-CDF(to);

        public double Sample() => StudentT.Sample(Location, Scale, DOF);
        public double[] Samples(int n)
        { 
            double[] samples = new double[n];
            StudentT.Samples(samples);
            return samples;
        }

        // 
        public Interval Interval(double mean, double sd, double n, double P = 0.95)
        {
            // https://en.wikipedia.org/wiki/Student%27s_t-distribution#Numerical_methods
            // https://en.wikipedia.org/wiki/Student%27s_t-distribution#Quantiles
            // https://en.wikipedia.org/wiki/Student%27s_t-distribution#Confidence_intervals

            // TODO : добавить код для расчета интервала

            return new Interval();
        }
        public Interval Interval(Items items, double P = 0.95) => Interval(items.Mean(), items.SD(), items.Count(), P);

    }
}
