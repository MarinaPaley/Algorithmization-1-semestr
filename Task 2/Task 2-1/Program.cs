namespace Task_2_1
{
    /// <summary>
    /// Перечислимый тип для выбора действия.
    /// </summary>
    enum ActionType
    {
        /// <summary>
        /// Значение по умолчанию.
        /// </summary>
        None = 0,
        /// <summary>
        /// Периметр.
        /// </summary>
        Perimeter,
        /// <summary>
        /// Радиус.
        /// </summary>
        Radius
    }

    /// <summary>
    /// Коды ошибок.
    /// </summary>
    enum ErrorCode
    {
        /// <summary>
        /// Значение по умолчанию.
        /// </summary>
        None = 0,

        /// <summary>
        /// Неправильное преобразование к типу Enum.
        /// </summary>
        ConvertEnum = 1,

        /// <summary>
        /// Невозможно построить многоугольник.
        /// </summary>
        DomainQuantity = 2,

        /// <summary>
        /// Неправильное преобразование к целому числу.
        /// </summary>
        ConvertToInt = 3,

        /// <summary>
        /// Отрицательная сторона.
        /// </summary>
        DomainSide = 4,

        /// <summary>
        /// Неправильное преобразование к вещественному числу.
        /// </summary>
        ConvertToDouble = 5,

        /// <summary>
        /// Неправильный выбор действия.
        /// </summary>
        ActionType = 6
    }

    /// <summary>
    /// Точка входа.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Основная функция.
        /// </summary>
        /// <param name="args"> Список аргументов.</param>
        static void Main(string[] args)
        {
            double side = GetSide("Введите длину стороны = ");
            int quantity = GetQuantity("Введите количество сторон многоугольника = ");
            ActionType actionType = GetActionType();
            switch (actionType)
            {
                case (ActionType.Perimeter):
                    {
                        double perimetr = GetPerimetr(side, quantity);
                        Console.WriteLine($"Периметр многоугольника равен {perimetr}");
                        break;
                    }
                case (ActionType.Radius):
                    {
                        double radius = GetRadius(side, quantity);
                        Console.WriteLine($"Радиус вписанной окружности равен {radius}");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Неправильный выбор действия");
                        Environment.Exit((int)ErrorCode.ActionType);
                        break;
                    }
            }
        }

        /// <summary>
        /// Получает радиус вписанной окружности.
        /// </summary>
        /// <param name="side"> Длина стороны многоугольника.</param>
        /// <param name="quantity"> Количество сторон многоугольника.</param>
        /// <returns> Радиус.</returns>
        private static double GetRadius(double side, int quantity)
        {
            return side / (2 * Math.Tan(ConvertToRadian(180.0/quantity)));
        }

        /// <summary>
        /// Преобразует градусы в радианы.
        /// </summaryConvertToRadian
        /// <param name="degree"> Угол в градусах. </param>
        /// <returns> Угол в радианах.</returns>
        private static double ConvertToRadian(double degree)
        {
            return degree * Math.PI / 180;
        }

        /// <summary>
        /// Получает периметр многоугольника.
        /// </summary>
        /// <param name="side"></param>
        /// <param name="quantity"></param>
        /// <returns> Периметр.</returns>
        private static double GetPerimetr(double side, int quantity)
        {
            return side * quantity;
        }

        /// <summary>
        /// Получает действие от пользователя.
        /// </summary>
        /// <returns> Действие. </returns>
        private static ActionType GetActionType()
        {
            Console.WriteLine("Выберите действие: Perimeter или Radius");
            string? input = Console.ReadLine();
            if (!Enum.TryParse(input, ignoreCase: true, out ActionType result))
            {
                Console.WriteLine("Неправильный выбор");
                Environment.Exit((int)ErrorCode.ConvertEnum);
            }

            return result;
        }

        /// <summary>
        /// Получает количество сторон многоугольника.
        /// </summary>
        /// <param name="message"> Сообщение пользователю. </param>
        /// <returns> Количество сторон многоугольника.</returns>
        /// <remarks> Аварийно завершает программу с кодом ошибки. </remarks>
        private static int GetQuantity(string message)
        {
            int quantity = GetInt(message);
            if (quantity <= 2)
            {
                Console.WriteLine("Количество сторон многоугольника должно быть больше двух!");
                Environment.Exit((int)ErrorCode.DomainQuantity);
            }

            return quantity;
        }

        /// <summary>
        /// Получает целое число из консоли.
        /// </summary>
        /// <param name="message"> Сообщение пользователю.</param>
        /// <returns> Целое число. </returns>
        /// <remarks> Аварийно завершает программу с кодом ошибки. </remarks>
        private static int GetInt(string message)
        {
            Console.Write(message);
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int result))
            {
                Console.WriteLine("Введено не целое число");
                Environment.Exit((int)ErrorCode.ConvertToInt);
            }

            return result;
        }

        /// <summary>
        /// Получает длину стороны многоугольника.
        /// </summary>
        /// <param name="message"> Сообщение пользователю.</param>
        /// <returns> Длину стороны многоугольника.</returns>
        /// <remarks> Аварийно завершает программу с кодом ошибки.</remarks>
        private static double GetSide(string message)
        {
            double side = GetDouble(message);
            if (side <= 0)
            {
                Console.WriteLine("Длина стороны должна быть больше нуля");
                Environment.Exit((int)ErrorCode.DomainSide);
            }

            return side;
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
                Console.WriteLine("Введено не целое число");
                Environment.Exit((int)ErrorCode.ConvertToDouble);
            }

            return result;
        }
    }
}
