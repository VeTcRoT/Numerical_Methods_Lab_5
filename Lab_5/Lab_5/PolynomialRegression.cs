namespace Lab_5
{
    internal class PolynomialRegression
    {
        public double[] XCoordinates { get; set; }
        public double[] YCoordinates { get; set; }
        public int Degree { get; set; }
        public int N { get => XCoordinates.Length; }
        public PolynomialRegression(double[] xCoordinates, double[] yCoordinates, int degree)
        {
            XCoordinates = xCoordinates;
            YCoordinates = yCoordinates;
            Degree = degree + 1;
        }
        private double[,] MatrixTranspose(double[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            double[,] result = new double[n, m];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }
            return result;
        }
        private double[,] MatrixMultiply(double[,] a, double[,] b)
        {
            int m = a.GetLength(0);
            int n = b.GetLength(1);
            int p = a.GetLength(1);

            double[,] result = new double[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < p; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return result;
        }
        private double[] MatrixVectorMultiply(double[,] matrix, double[] vector)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            double[] result = new double[m];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result[i] += matrix[i, j] * vector[j];
                }
            }
            return result;
        }
        private double[] MatrixVectorSolve(double[,] matrix, double[] vector)
        {
            int n = vector.Length;
            double[,] a = new double[n, n + 1];
            double[] x = new double[n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = matrix[i, j];
                }
                a[i, n] = vector[i];
            }

            for (int i = 0; i < n; i++)
            {
                double maxElement = Math.Abs(a[i, i]);
                int maxRow = i;
                for (int k = i + 1; k < n; k++)
                {
                    if (Math.Abs(a[k, i]) > maxElement)
                    {
                        maxElement = Math.Abs(a[k, i]);
                        maxRow = k;
                    }
                }

                for (int k = i; k < n + 1; k++)
                {
                    double tmp = a[maxRow, k];
                    a[maxRow, k] = a[i, k];
                    a[i, k] = tmp;
                }

                for (int k = i + 1; k < n; k++)
                {
                    double c = a[k, i] / a[i, i];
                    for (int j = i; j < n + 1; j++)
                    {
                        if (i == j)
                        {
                            a[k, j] = 0;
                        }
                        else
                        {
                            a[k, j] -= c * a[i, j];
                        }
                    }
                }
            }

            for (int i = n - 1; i >= 0; i--)
            {
                x[i] = a[i, n] / a[i, i];
                for (int k = i - 1; k >= 0; k--)
                {
                    a[k, n] -= a[k, i] * x[i];
                }
            }

            return x;
        }
        public double[] GetResult()
        {
            double[,] X = new double[N, Degree];
            double[] Y = new double[N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < Degree; j++)
                {
                    X[i, j] = Math.Pow(XCoordinates[i], j);
                }
                Y[i] = YCoordinates[i];
            }

            double[,] XTransposeX = MatrixMultiply(MatrixTranspose(X), X);
            double[] XTransposeY = MatrixVectorMultiply(MatrixTranspose(X), Y);
            double[] coefficients = MatrixVectorSolve(XTransposeX, XTransposeY);

            return coefficients;
        }
    }
}
