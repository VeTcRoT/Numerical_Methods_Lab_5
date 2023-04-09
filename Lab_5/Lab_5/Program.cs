using Lab_5;

double[] x = { 1, 2, 3, 4 };
double[] y = { -3, -1, 0, 7 };

double x0 = 1.75;

var interpolationPolynomial = new InterpolationPolynomial(x, y, x0);

Console.WriteLine(new string('-', 30) + "Task 1" + new string('-', 30));
Console.WriteLine("\ninterpolation Polynomial: " + interpolationPolynomial.GetResult());
