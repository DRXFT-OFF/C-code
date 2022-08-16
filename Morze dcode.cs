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
            string morze = Console.ReadLine();
            morze += " ";
            string now = "";

            for (int i = 0; i < morze.Length; i++)
            {
                now += morze[i];

                if (morze[i] == ' ')
                {
                    switch (now)
                    {
                        case ".- ":
                            Console.WriteLine("A");
                            break;
                        case "-... ":
                            Console.WriteLine("B");
                            break;
                        case "-.-. ":
                            Console.WriteLine("C");
                            break;
                        case "-.. ":
                            Console.WriteLine("D");
                            break;
                        case ". ":
                            Console.WriteLine("E");
                            break;
                        case "..-. ":
                            Console.WriteLine("F");
                            break;
                        case "--. ":
                            Console.WriteLine("G");
                            break;
                        case ".... ":
                            Console.WriteLine("H");
                            break;
                        case ".. ":
                            Console.WriteLine("I");
                            break;
                        case ".--- ":
                            Console.WriteLine("J");
                            break;
                        case "-.- ":
                            Console.WriteLine("K");
                            break;
                        case ".-.. ":
                            Console.WriteLine("L");
                            break;
                        case "-- ":
                            Console.WriteLine("M");
                            break;
                        case "-. ":
                            Console.WriteLine("N");
                            break;
                        case "--- ":
                            Console.WriteLine("O");
                            break;
                        case ".--. ":
                            Console.WriteLine("P");
                            break;
                        case "--.- ":
                            Console.WriteLine("Q");
                            break;
                        case ".-. ":
                            Console.WriteLine("R");
                            break;
                        case "... ":
                            Console.WriteLine("S");
                            break;
                        case "- ":
                            Console.WriteLine("T");
                            break;
                        case "..- ":
                            Console.WriteLine("U");
                            break;
                        case "...- ":
                            Console.WriteLine("V");
                            break;
                        case ".-- ":
                            Console.WriteLine("W");
                            break;
                        case "-..- ":
                            Console.WriteLine("X");
                            break;
                        case "-.-- ":
                            Console.WriteLine("Y");
                            break;
                        case "--.. ":
                            Console.WriteLine("Z");
                            break;

                        default:
                            break;
                    }
                    now = "";
                    continue;
                }
            }
            Console.ReadLine();
        }
    }
}
