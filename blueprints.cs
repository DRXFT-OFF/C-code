using System;
using System.Globalization;
using System.Threading;
using System.Linq;
using System.Collections;
using System.Text;




namespace main
{
    enum Blueprints
    { 
        White,
        Green,
        Blue,
        Purple,
        Yellow,
        Orange
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Сколько у вас денег?");
            int money = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите, какой чертёж хотите покупать (0-белый/5-оранжевый)");
            int id_color = int.Parse(Console.ReadLine());

            int[] colors_sum = new int[id_color + 1];
            int[] colors_price = new int[id_color + 1];

            for (int i = 0; i <= id_color; i++)
            {
                Console.WriteLine($"Введите цену дня чертежа {Enum.GetName(typeof(Blueprints), i)}");
                colors_price[i] = int.Parse(Console.ReadLine());
            }

            for (int i = id_color; i > id_color - 2; i--)
            {
                    for (int j = 0; j < 1; j++)
                    {
                        colors_sum[i] = colors_price[i] * 3;
                    }
            }
            int counter = 1;
            for (int i = id_color - 2; i >= 0; i--)
            {
                colors_sum[i] = colors_price[i] * 3;
                for (int k = 0; k < counter; k++)
                {
                    for (int j = 0; j < 1; j++)
                    {
                        colors_sum[i] *= 3;
                    }
                }
                counter++;
            }
            Console.Clear();
            Console.WriteLine("Цены:");
            for (int i = 0; i <= id_color; i++)
            {
                Console.WriteLine("Чертёж:" + Enum.GetName(typeof(Blueprints), i) + "\t Цена:" + (i == id_color ? colors_price[id_color] : colors_sum[i]));
            }
            int Cur_id = int.MaxValue;
            int Min_id = 0;
            for (int i = 0; i < colors_sum.Length; i++)
            {
                if (i == id_color && colors_price[id_color] < Cur_id)
                {
                    Cur_id = colors_price[id_color];
                    Min_id = i;
                }
                if (colors_sum[i] < Cur_id)
                { 
                    Cur_id = colors_sum[i];
                    Min_id = i;
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Наиболее выгодный: {Enum.GetName(typeof(Blueprints), Min_id)}");
            int count = 0;
            int pay = 0;
            while (money >= Cur_id)
            {
                money -= Cur_id;
                pay += Cur_id;
                count++;
            }
            Console.WriteLine();
            Console.WriteLine($"Вы можете купить {Enum.GetName(typeof(Blueprints), Min_id)} чертежи в кол-ве {count} штук \nВы потратите: {pay} \nУ вас останется: {money}");

            Console.ReadLine();
        }    
    }
}
