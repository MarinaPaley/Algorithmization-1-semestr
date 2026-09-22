namespace Task1_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const double a = 2.0;
            const double b = 1.0;
            const double c = 3.0;

            Console.WriteLine("Введите x = ");
            string input = Console.ReadLine();

            double x = double.Parse(input);
            double numerator = Numerator(a, b, c, x);
            double denominator = Denominator(c, x);

            double y = numerator / denominator;

           Console.WriteLine($"x = {x}, y = {y}");
        }

        static double Numerator(double a, double c, double b, double x)
        {
            return (a * Math.Pow(Math.Abs(x), 3) +
                b * Math.Sqrt(x * x + 1));
        }

        static double Denominator(double c, double x)
        {
            return c + Math.Sin(x) * Math.Sin(x)
                + Math.Cos(x) * Math.Cos(x);
        }
    }
}
