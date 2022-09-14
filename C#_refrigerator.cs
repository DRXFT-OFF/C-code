using System;
using System.Globalization;
using System.Threading;
using System.Linq;
using System.Collections;
using System.Text;




namespace main
{
    class Fridge
    {
        private int temp = 9;
        private bool isDoor_open = false;
        private string[] products = { "Пиво", "Хлеб", "Масло" };

        public void Open_Door()
        {
            Console.Clear();
            if (!isDoor_open)
            {
                isDoor_open = true;
                Console.WriteLine("Вы открыли дверь холодильника");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Лапоть, дверь уже открыта!");
            }
        }
        public void Close_Door()
        {
            Console.Clear();
            if (isDoor_open)
            {
                isDoor_open = false;
                Console.WriteLine("Вы закрыли дверь холодильника");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Лапоть, дверь уже закрыта!");
            }
        }

        public void Print_Temp()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Температура: {temp}°C");
            Console.ResetColor();
        }

        public void Look_Products()
        {
            Console.Clear();
            if (isDoor_open)
            {
                Console.WriteLine("Продукты:");
                foreach (var item in products)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Лапоть, сначала открой дверь холодильника!");
            }
            
        }
        public void Get_Products()
        {
            if (isDoor_open)
            {
                Console.Clear();
                foreach (var item in products)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Что хотите взять?");
                var result = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine());
                if (products.Contains(result))
                {
                    Console.Clear();
                    Console.WriteLine("Вы взяли: " + result);
                    products = Remove_products(products, result);
                    Console.WriteLine("В холодильнике:");
                    foreach (var item in products)
                    {
                        Console.WriteLine(item);
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Продукт не найден в холодильнике");
                }
            }

            else
            {
                Console.Clear();
                Console.WriteLine("Лапоть, сначала открой дверь холодильника!");
            }
        }

        public void Put_Products()
        {
            if (isDoor_open)
            {
                Console.Clear();
                foreach (var item in products)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Что хотите положить?");
                var result = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Вы положили: " + result);
                products = Add_products(products, result);
                Console.WriteLine("В холодильнике:");
                foreach (var item in products)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Лапоть, сначала открой дверь холодильника!");
            }
        }

        public void Change_T()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Текущая температура: " + temp + "°C");
            Console.ResetColor();
            Console.WriteLine("Доступный диапазон изменения температуры: 1-9°C");
            Console.Write("Введите температуру для установки: ");
            int change_t = int.Parse(Console.ReadLine());
            if (change_t < 1 || change_t > 9)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Недопустимая температура для изменения");
                Console.ResetColor();
            }
            else
            {
                if (change_t < 3)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Угроза заморозки продуктов!");
                    Console.ResetColor();
                    Console.Write("Подтвердить? Д/Н");
                    var ans = Console.ReadKey(true).Key;
                    if (ans == ConsoleKey.L)
                    {
                        Console.Clear();
                        temp = change_t;
                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Температура изменена!");
                        Console.WriteLine("Текущая температура: " + temp + "°C");
                        Console.ResetColor();
                    }
                    else if (ans == ConsoleKey.Y)
                    {
                        Console.Clear();
                        Console.WriteLine("Температура не была изменена!");

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Текущая температура: " + temp + "°C");
                        Console.ResetColor();
                    }
                }
                else
                {
                    temp = change_t;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Температура изменена!");
                    Console.WriteLine("Текущая температура: " + temp + "°C");
                    Console.ResetColor();
                }
            }
        }

        protected string[] Remove_products(string[] products, string del_value)
        {
            string[] new_products = new string[products.Length - 1];
            int index;
            for (int i = 0; i < new_products.Length; i++)
            {
                if (products[i] == del_value)
                {
                    index = i;
                    for (int i2 = index; i2 < new_products.Length; i2++)
                    {
                        new_products[i2] = products[i2 + 1];
                    }
                    break;
                }
                    
                new_products[i] = products[i];
            }
            return new_products;
        }

        protected string[] Add_products(string[] products, string add_value)
        {
            string[] new_products = new string[products.Length + 1];
            for (int i = 0; i < products.Length; i++)
                new_products[i] = products[i];
            new_products[new_products.Length - 1] = add_value;
            return new_products;
        }

        public int Get_Temp()
        {
            return temp;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Fridge fridge = new Fridge();
            Random random = new Random();
            while (true)
            {
                Console.WriteLine("Что хотите сделать?");
                Console.WriteLine("Доступные действия: \n открыть/закрыть дверь(1) \n посмотреть температуру/продукты(2) \n взять/положить продукты(3) \n изменить температуру(4) \n \n закрыть программу(0)");
                int num_choise = int.Parse(Console.ReadLine());
                switch (num_choise)
                {
                    case 0:
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Доступные действия: \n открыть(1)/закрыть дверь(2)");
                        int num_do = int.Parse(Console.ReadLine());
                        switch (num_do)
                        {
                            case 1:
                                fridge.Open_Door();
                                break;
                            case 2:
                                fridge.Close_Door();
                                break;
                            default:
                                Console.WriteLine("Неверный ввод");
                                break;
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Доступные действия: \n посмотреть температуру(1)/продукты(2)");
                        int num_do_1 = int.Parse(Console.ReadLine());
                        switch (num_do_1)
                        {
                            case 1:
                                fridge.Print_Temp();
                                break;
                            case 2:
                                fridge.Look_Products();
                                break;
                            default:
                                Console.WriteLine("Неверный ввод");
                                break;
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Доступные действия: \n взять(1)/положить продукты(2)");
                        int num_do_2 = int.Parse(Console.ReadLine());
                        switch (num_do_2)
                        {
                            case 1:
                                fridge.Get_Products();
                                break;
                            case 2:
                                fridge.Put_Products();
                                break;
                            default:
                                Console.WriteLine("Неверный ввод");
                                break;
                        }
                        break;
                    case 4:
                        fridge.Change_T();
                        break;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }
                if (num_choise == 0)
                    break;
                Console.WriteLine("Нажмите Enter, чтобы продолжить выполнение программы/любую кнопку для закрытия");
                ConsoleKey end_key = Console.ReadKey(true).Key;
                if (end_key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    continue;
                }
                else
                    break;
            }
        }    
    }
}
