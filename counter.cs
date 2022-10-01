using System;
using System.Globalization;
using System.Threading;
using System.Linq;
using System.Collections;
using System.Text;




namespace main
{

    class Program
    {
        static string Convert_num(int num_from, int num_to) // сделать конвертацию через 2 перехода (из 2 в 16-ю)
        {
            if (num_to == 10)
            {
                string num = Console.ReadLine();
                string[] numbers = new string[num.Length];

                string now = num;
                for (int i = 0; i < numbers.Length; i++)
                {
                    now = Char.ToString(num.ElementAt(num.Length - 1));
                    num = num.Remove(num.Length - 1, 1);
                    switch (now)
                    {
                        case "A":
                            now = "10";
                            break;
                        case "B":
                            now = "11";
                            break;
                        case "C":
                            now = "12";
                            break;
                        case "D":
                            now = "13";
                            break;
                        case "E":
                            now = "14";
                            break;
                        case "F":
                            now = "15";
                            break;
                        default:
                            break;
                    }
                    numbers[i] = now;
                    if (int.Parse(now) >= num_from)
                    {
                        Console.WriteLine("Неверный ввод! Число не соответсвует системе!");
                        return "Error";
                    }
                }
                int[] right_numbers = new int[numbers.Length];
                for (int i = 0; i < right_numbers.Length; i++)
                {
                    right_numbers[i] = int.Parse(numbers[i]);
                }
                ulong sum = 0;
                for (int i = right_numbers.Length - 1; i >= 0; i--)
                {
                    sum += (ulong)(right_numbers[i] * Math.Pow(num_from, i));
                }
                return sum.ToString();
            }
            if (num_from != 10)
            {
                try
                {
                    return Convert.ToString(int.Parse(Convert_num(num_from, 10)), num_to);
                }
                catch (System.ArgumentException)
                {
                    Console.WriteLine("К сожалению, данное действие невозможно");
                    return "None";
                }
            }


            if (num_from == 10)
                try
                {
                    return Convert.ToString(int.Parse(Console.ReadLine()), num_to);
                }
                catch (System.ArgumentException)
                {
                    Console.WriteLine("К сожалению, данное действие невозможно");
                    return "None";
                }
            else
                return "Ошибка! Неверный ввод!";
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Из какой системы? Доступные: 2, 3, 8, 10, 12, 16");
            int num_from = int.Parse(Console.ReadLine());
            Console.WriteLine("В какую систему? Доступные: 2, 3, 8, 10, 12, 16");
            int num_to = int.Parse(Console.ReadLine());
            if (num_from != num_to)
            {
                Console.WriteLine(Convert_num(num_from, num_to));
            }
            else
                Console.WriteLine("Невозможен перевод в одинаковую систему счисление");

            Console.ReadLine();
        }
    }
}
