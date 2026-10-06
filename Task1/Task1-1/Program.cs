namespace Task1_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const double a = 1;
            const double b = 2;
            const double c = 1.5;

            Console.Write("x = ");
            string input = Console.ReadLine();
            double x = double.Parse(input);

            double y = 5.0 / 2 + Math.Sin(a/b + c);
            Console.WriteLine($"x = {x}, y = {y}");
        }
    }
}
