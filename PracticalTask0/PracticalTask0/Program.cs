namespace PracticalTask0
{
    /// <summary>
    /// Класс обеспечивает вывод неповторяющихся символов.
    /// </summary>
    /// <remarks>
    /// Класс принимает строку, в которой подсчитывает количество неодинаковых 
    /// последовательных символов и выводит это значение на консоль.
    /// </remarks>
    internal class Program
    {
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        /// <param name="args">Список аргументов для командной строки.</param>
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Введите строку: ");
                string? str = Console.ReadLine();
                bool equal = false;                 // равенство элементов
                int match = 0;                      // количество совпадений
                int maxDiffr = 0;                   // неодинаковые символы
                
                // Массив повторяющихся символов.
                char[] matches = new char[0];

                // Проверка на отсутствие значения.
                if (str?.Length > 0 && str?.Length >= 2)
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        // Проверка каждого символа на совпадение с последующим.
                        for (int j = i + 1; j < str.Length; j++)
                        {
                            if (str[i] == str[j])
                            {
                                match++;

                                for (int k = 0; k < matches.Length; k++)
                                {
                                    // Проверка на совпадение с ранее совпавшими 
                                    // элементами.
                                    if (str[j] == matches[k]) equal = true;
                                }
                                if (!equal) matches = Add(str[j], matches);
                            }
                            equal = false;      // сброс для следующего сравнения
                        }
                    }
                    if (matches.Length == 1)
                    {
                        // Один элемент в массиве - все символы одинаковы.
                        maxDiffr = 0;
                    }
                    else if (match >= (str.Length - 1))
                    {
                        // Много совпадений - вывод количества повторяющихся.
                        maxDiffr = matches.Length;
                    }
                    else maxDiffr = str.Length - match;

                    if (maxDiffr == 0)
                    {
                        Console.WriteLine("В данной строке все символы одинаковы.");
                    }
                    else
                    {
                        Console.WriteLine($"Максимальное количество "
                                          + $"неодинаковых последовательных " +
                                          $"символов в данной строке: {maxDiffr}");
                    }
                    break;      // выход
                }
                else if (str?.Length > 0 && str?.Length < 2)
                {
                    Console.WriteLine("Введите больше одного символа");
                }
                else Console.WriteLine("Строка пуста!");
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Метод для добавления элементов в массив.
        /// </summary>
        /// <param name="str">Символ для добавления.</param>
        /// <param name="matches">Массив для добавления.</param>
        /// <returns>
        /// Возвращает массив заполненный повторяющимися элементами.
        /// </returns>
        static char[] Add(char str, char[] matches)
        {
            char[] equals = new char[matches.Length + 1];      // временный массив

            for (int i = 0; i < matches.Length; i++) equals[i] = matches[i];
            
            // На последнее место - принятый элемент.
            equals[matches.Length] = str;

            return equals;
        }
    }
}