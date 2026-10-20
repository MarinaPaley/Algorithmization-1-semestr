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
        Perimetr,
        /// <summary>
        /// Радиус.
        /// </summary>
        Radius
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ActionType actionType = GetActionType();

            Console.WriteLine("Hello, World!");
        }
    }
}
