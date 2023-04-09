using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    internal class EmpiricalFormula
    {
        public double[] XCoordinates { get; set; }
        public double[] YCoordinates { get; set; }
        public EmpiricalFormula(double[] xCoordinates, double[] yCoordinates)
        {
            XCoordinates = xCoordinates;
            YCoordinates = yCoordinates;
        }
        public double[] GetResult()
        {
            double sumX = XCoordinates.Sum();
            double sumY = YCoordinates.Sum();
            double sumXY = XCoordinates.Zip(YCoordinates, (x, y) => x * y).Sum();
            double sumX2 = XCoordinates.Select(x => x * x).Sum();
            double n = XCoordinates.Length;

            double a = (n * sumXY - sumX * sumY) / (n * sumX2 - sumX * sumX);
            double b = (sumY - a * sumX) / n;

            return new double[2] { a, b };
        }
    }
}
