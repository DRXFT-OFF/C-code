using System;
using System.Globalization;
using System.Threading;
using System.Linq;


namespace main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку для подсчёта символов");

            string str = Console.ReadLine();
            uint words = 0;
            uint wosymb = Convert.ToUInt32(str.Length);

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    wosymb -= 1;
                    words += 1;
                }
            }
            Console.WriteLine($"Слова: {words + 1} \nСимволы: {str.Length} \nСимволы без пробелов: {wosymb}");

            Console.ReadLine();
        }
    }
}