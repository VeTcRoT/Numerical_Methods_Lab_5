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
Console.WriteLine("\nLinear Regression: y = {0}x + {1}", empiricalFormulaResult[0], empiricalFormulaResult[1]);