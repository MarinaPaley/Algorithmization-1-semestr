namespace Task_1_2
{
    internal static class Program
    {
        /// <summary >
        /// Точка входа в программу.
        /// </summary >
        /// <param name="args"> Список формальных параметров. </param >
        static void Main(string[] args)
        {
            double side1 = GetNumber("Введите side1 = ");
            double side2 = GetNumber("Введите side2 = ");
            double angle = GetNumber("Введите углол между сторонами angle = ");

            double side3 = GetSide(side1, side2, angle);

            double s = GetArea(side1, side2, angle);

            Console.WriteLine($"side1 = {side1}; side2 = {side2}; угол = {angle}; третья сторона = {side3}");
            Console.WriteLine($"площадь = {s}");
        }

        /// <summary >
        /// Получает число.
        /// </summary >
        /// <param name="message"> Сообщение пользователю.</param >
        /// <returns > Число, введенное с клавиатуры. </returns >
        static double GetNumber(string message = "")
        {
            Console.Write(message);
            string? input = Console.ReadLine();
            return double.Parse(input);
        }

        /// <summary >
        /// Получает расчёт функции.
        /// </summary >
        /// <param name="side1"> Переменная a. </param >
        /// <param name="side2"> Переменная b. </param >
        /// <param name="angle"> Переменная c. </param >
        /// <param name="s"> Переменная z. </param >
        /// <returns > Значение функции. </returns >
        static double GetArea(double side1, double side2, double angle)
        {
            return 0.5 * side1 * side2 * ConvertToRadian(angle);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        private static double ConvertToRadian(double angle)
        {
            return Math.Sin(angle * Math.PI / 180);
        }

        static double GetSide(double side1, double side2, double angle)
        {

            return Math.Sqrt(side1 * side1 + side2 * side2 - 2 * side1 * side2 * Math.Cos(ConvertToRadian(angle)));

        }
    }
}