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
            Console.Write("Введите цену дорого продукта: ");
            double high_cost = int.Parse(Console.ReadLine());
            Console.Write("Введите вес дорого продукта: ");
            double weight_hp = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Введите цену дешёвого продукта: ");
            double low_cost = int.Parse(Console.ReadLine());
            Console.Write("Введите вес дешёвого продукта: ");
            double weight_lp = int.Parse(Console.ReadLine());

            Console.WriteLine();

            double low_cost_ef = weight_lp / low_cost;
            double high_cost_ef = weight_hp / high_cost;

            if (low_cost_ef > high_cost_ef)
            {
                Console.WriteLine("Покупайте дешёвый продукт");
            }
            else if (high_cost_ef > low_cost_ef)
            {
                Console.WriteLine("Покупайте дорогой продукт");
            }
            else
            { 
                Console.WriteLine("Одинаково");
            }
            Console.ReadLine();
        }    
    }
}
