namespace Task1_1
{
    internal class Program
    {
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        /// <param name="args"> Аргументы. </param>
        static void Main(string[] args)
        {
            const double a = 1;
            const double b = 2;
            const double c = 1.5;
            double x = GetNumber("x = ");
            double y = GetResult(a, b, c);
            Console.WriteLine($"x = {x}, y = {y}");
        }

        /// <summary>
        /// Расчитывает значение заданной функции.
        /// </summary>
        /// <param name="a"> Аргумент a.</param>
        /// <param name="b"> Аргумент b.</param>
        /// <param name="c"> Аргумент c.</param>
        /// <returns> Значение функции.</returns>
        private static double GetResult(
            double a,
            double b,
            double c)
        {
            return 5.0 / 2 + Math.Sin(a / b + c);
        }

        /// <summary>
        /// Считывает число с клавиатуры.
        /// </summary>
        /// <param name="message"> Надпись для пользователя. </param>
        /// <returns> Число.</returns>
        private static double GetNumber(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine();
            return double.Parse(input);
        }
    }
}
