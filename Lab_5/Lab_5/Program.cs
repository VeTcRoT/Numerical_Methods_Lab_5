using Lab_5;

double[] x = { 1, 2, 3, 4 };
double[] y = { -3, -1, 0, 7 };

double x0 = 1.75;

var interpolationPolynomial = new InterpolationPolynomial(x, y, x0);

Console.WriteLine(new string('-', 30) + "Task 1" + new string('-', 30));
Console.WriteLine("\nInterpolation Polynomial: " + interpolationPolynomial.GetResult());

var lagrangeInterpolation = new LagrangeInterpolation(x, y, x0);

Console.WriteLine("\n" + new string('-', 30) + "Task 2" + new string('-', 30));
Console.WriteLine("\nLagrange Interpolation: " + lagrangeInterpolation.GetResult());

var empiricalFormula = new EmpiricalFormula(x, y);
double[] empiricalFormulaResult = empiricalFormula.GetResult(); 

Console.WriteLine("\n" + new string('-', 30) + "Task 3" + new string('-', 30));
Console.WriteLine("\nEmpirical Formula: y = {0}x + {1}", empiricalFormulaResult[0], empiricalFormulaResult[1]);

var linearRegression = new LinearRegression(x, y);
double[] linearRegressionResult = linearRegression.GetResult();

Console.WriteLine("\n" + new string('-', 30) + "Task 4" + new string('-', 30));
Console.WriteLine("\nLinear Regression: y = {0}x + {1}", linearRegressionResult[1], linearRegressionResult[0]);

var polynomialRegression = new PolynomialRegression(x, y, 2);
double[] polynomialRegressionResult = polynomialRegression.GetResult();

Console.WriteLine("\nPolynomial Regression: y = {0:f4}x^2 + {1:f4}x + {2:f4}", polynomialRegressionResult[2], polynomialRegressionResult[1], polynomialRegressionResult[0]);