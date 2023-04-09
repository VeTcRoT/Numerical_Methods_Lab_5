namespace Lab_5
{
    internal class InterpolationPolynomial
    {
        public double[] XCoordinates { get; set; }
        public double[] YCoordinates { get; set; }
        public double X0 { get; set; }
        public int N { get => XCoordinates.Length; }
        public InterpolationPolynomial(double[] xCoordinates, double[] yCoordinates, double x0)
        {
            XCoordinates = xCoordinates;
            YCoordinates = yCoordinates;
            X0 = x0;
        }
        private double[,] GetMatrixCoefficients()
        {
            var coefficients = new double[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    coefficients[i, j] = Math.Pow(XCoordinates[i], j);
                }
            }
            return coefficients;
        }
        private double[] SolveSystem()
        {
            double[,] coefficients = GetMatrixCoefficients();
            double[] valuesVector = (double[])YCoordinates.Clone();

            for (int k = 0; k < N - 1; k++)
            {
                for (int i = k + 1; i < N; i++)
                {
                    double factor = coefficients[i, k] / coefficients[k, k];
                    for (int j = k + 1; j < N; j++)
                    {
                        coefficients[i, j] -= factor * coefficients[k, j];
                    }
                    valuesVector[i] -= factor * valuesVector[k];
                }
            }
            double[] x = new double[N];

            x[N - 1] = valuesVector[N - 1] / coefficients[N - 1, N - 1];

            for (int i = N - 2; i >= 0; i--)
            {
                double sum = 0;
                for (int j = i + 1; j < N; j++)
                {
                    sum += coefficients[i, j] * x[j];
                }
                x[i] = (valuesVector[i] - sum) / coefficients[i, i];
            }

            return x;
        }
        public double GetResult()
        {
            double[] c = SolveSystem();

            double y0 = 0;

            for (int i = 0; i < N; i++)
            {
                y0 += c[i] * Math.Pow(X0, i);
            }

            return y0;
        }
    }
}
