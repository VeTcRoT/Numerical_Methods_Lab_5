using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_5
{
    internal class LagrangeInterpolation
    {
        public double[] XCoordinates { get; set; }
        public double[] YCoordinates { get; set; }
        public double X0 { get; set; }
        public int N { get => XCoordinates.Length; }
        public LagrangeInterpolation(double[] xCoordinates, double[] yCoordinates, double x0)
        {
            XCoordinates = xCoordinates;
            YCoordinates = yCoordinates;
            X0 = x0;
        }
        public double GetResult()
        {
            double result = 0;

            for (int i = 0; i < N; i++)
            {
                double term = YCoordinates[i];
                for (int j = 0; j < N; j++)
                {
                    if (j != i)
                    {
                        term *= (X0 - XCoordinates[j]) / (XCoordinates[i] - XCoordinates[j]);
                    }
                }
                result += term;
            }

            return result;
        }
    }
}
