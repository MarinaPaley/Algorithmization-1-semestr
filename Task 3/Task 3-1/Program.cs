namespace Task_3_1
{
    internal class Program
    {
        /// <summary>
        /// Коды ошибок.
        /// </summary>
        enum ErrorCode
        {
            /// <summary>
            /// Значение по умолчанию.
            /// </summary>
            None,

            /// <summary>
            /// Отрицательное число.
            /// </summary>
            ErrorLessOrEqualZero,

            /// <summary>
            /// Неправильное преобразование к вещественному числу.
            /// </summary>
            ConvertToDouble,

            /// <summary>
            /// Левая граница больше правой.
            /// </summary>
            DomainLeftAboveRight,
        }

        /// <summary>
        /// Основная функция.
        /// </summary>
        /// <param name="args"> Формальные параметры. </param>
        static void Main(string[] args)
        {
            var left = GetDouble("Введите левую границу отрезка = ");
            var right = GetDouble("Введите правую границу отрезка = ");
            CheckRange(left, right);

            var step = GetpositiveNumber("Введите шаг расчета = ");

            Iterate(left, right, step);
        }

        /// <summary>
        /// Проверяет границы участка.
        /// </summary>
        /// <param name="left"> Левая граница. </param>
        /// <param name="right"> Правая граница. </param>
        private static void CheckRange(double left, double right)
        {
            if (left >= right)
            {
                Exit("Левая граница должна быть больше правой!", ErrorCode.DomainLeftAboveRight);
            }
        }

        /// <summary>
        /// Расчет заданной функции на участке.
        /// </summary>
        /// <param name="left"> Левая граница. </param>
        /// <param name="right"> Правая граница.</param>
        /// <param name="step"> Шаг расчета. </param>
        private static void Iterate(double left, double right, double step)
        {
            var x = left;
            while (x <= right)
            {
                if (!IsExist(x))
                {
                    Console.WriteLine($"x = {x:G6}, Функция не существует");
                }
                else
                {
                    var y = GetResult(x);
                    Console.WriteLine($"x = {x:G6}; y = {y:G6}");
                }

                x += step;
            }
        }

        /// <summary>
        /// Получает вещественное число.
        /// </summary>
        /// <param name="message"> Сообщение пользователю. </param>
        /// <returns> Вещественное число.</returns>
        /// <remarks> Аварийно завершает программу с кодом ошибки.</remarks>
        private static double GetDouble(string message)
        {
            Console.Write(message);
            string? input = Console.ReadLine();
            if (!double.TryParse(input, out double result))
            {
                Exit("Введено не целое число", ErrorCode.ConvertToDouble);
            }

            return result;
        }
 

        /// <summary>
        /// Получаем сторону многоугольника.
        /// </summary>
        /// <param name="message"> Сообщение пользователю. </param>
        /// <returns> Сторона многоугольника. </returns>
        /// <remarks> Аварийно закрывает программу при неправильном вводе с кодом ошибки <see cref="CodeError.ErrorLessOrEqualZero"/>.</remarks>
        private static double GetpositiveNumber(string message)
        {
            double result = GetDouble(message);

            if (result <= 0)
            {
                Exit("Шаг должен быть больше нуля", ErrorCode.ErrorLessOrEqualZero);
            }

            return result;
        }

        private static bool IsExist(double x)
        {
            return (Math.Abs(Math.Sin(x) * Math.Cos(x) - 0.707) > double.Epsilon)
                && (x * x >= 1);
        }

        /// <summary>
        /// Получает расчёт функции.
        /// </summary>
        /// <param name="x"> Переменная x. </param>
        /// <returns> Значение функции. </returns>
        private static double GetResult(double x)
        {
            return (2 * Math.Abs(x * x * x) + 5.0 / 2.0 * Math.Sqrt(x * x - 1)) /
                (Math.Sin(x) * Math.Cos(x) - 0.707);
        }

        /// <summary>
        /// Аварийно завергает работу програграммы.
        /// </summary>
        /// <param name="messge"> Сообщение пользователю.  </param>
        /// <param name="errorCode"> Код ошибки. </param>
        private static void Exit(string messge, ErrorCode errorCode)
        {
            Console.WriteLine(messge);
            Environment.Exit((int)errorCode);
        }
    }
}
