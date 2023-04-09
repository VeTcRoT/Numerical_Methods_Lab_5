namespace Lab_5
{
    internal class LinearRegression
    {
        public double[] XCoordinates { get; set; }
        public double[] YCoordinates { get; set; }
        public int N { get => XCoordinates.Length; }
        public LinearRegression(double[] xCoordinates, double[] yCoordinates)
        {
            XCoordinates = xCoordinates;
            YCoordinates = yCoordinates;
        }
        public double[] GetResult()
        {
            double xMean = XCoordinates.Average();
            double yMean = YCoordinates.Average();

            double a = 0, b = 0;

            for (int i = 0; i < N; i++)
            {
                a += (XCoordinates[i] - xMean) * (YCoordinates[i] - yMean);
                b += Math.Pow(XCoordinates[i] - xMean, 2);
            }

            a /= b;

            b = yMean - a * xMean;

            return new double[] { a, b };
        }
    }
}
