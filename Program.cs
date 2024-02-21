using System.Runtime.InteropServices;

namespace _2_projekt_miny
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool opakovat = true;
            while (opakovat == true)
            {
                string[,] pole = new string[11, 11];
                string[,] pole2 = new string[11, 11];
                vyplnPole(pole);
                miny(pole); // 10
                cislovani(pole);
                int pocet = 0;
                int tahX;
                int tahY;
                int pocetMin = 10;

                while (pocet < 90 || pocetMin >= 0)
                {
                    //pokud chce uživatel označit políčko s minou, napíše "chci" 
                    while (Console.ReadLine().ToUpper() == "CHCI")
                    {
                        Console.WriteLine("Chceš označit políčko");

                        //zadání sloupce
                        Console.WriteLine("Zadej sloupec: ");
                        while (!int.TryParse(Console.ReadLine(), out tahX) || tahX < 1 || tahX > 11)
                        {
                            Console.WriteLine("Neplatný vstup. Zadej platný sloupec (1-10): ");
                        }

                        //zadání řádku
                        Console.WriteLine("Zadej řádek: ");
                        while (!int.TryParse(Console.ReadLine(), out tahY) || tahY < 1 || tahY > 11)
                        {
                            Console.WriteLine("Neplatný vstup. Zadej platný řádek (1-10): ");
                        }

                        //odečtení miny
                        if (pole[tahY, tahX] == "*")
                        {
                            pocetMin-- ;
                        }

                        if (pocetMin == 0)
                        {
                            break;
                        }
                        Console.Clear();

                        //označní miny znakem X
                        pole[tahY, tahX] = "X";
                        vyplnPole2(pole2);
                        cislovani(pole);
                        Console.WriteLine("Pokračuj dále");
                    }
                    
                    //výhra
                    if (pocet == 90 || pocetMin ==0)
                    {
                        Console.WriteLine("Vyhrál jsi, nestoupl jsi ani na jednu minu");
                        break;
                    }

                    //zadání sloupce
                    Console.WriteLine("Zadej sloupec: ");

                    while (!int.TryParse(Console.ReadLine(), out tahX) || tahX < 1 || tahX > 10)
                    {
                        Console.WriteLine("Neplatný vstup. Zadej platný sloupec (1-10): ");
                    }

                    //zadání řádku
                    Console.WriteLine("Zadej řádek: ");
                    while (!int.TryParse(Console.ReadLine(), out tahY) || tahY < 1 || tahY > 10)
                    {
                        Console.WriteLine("Neplatný vstup. Zadej platný řádek (1-10): ");
                    }

                    //stoupnutí na minu
                    if (pole[tahY, tahX] == "*")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Stoupl jsi na minu, hra končí!");
                        break;
                    }
                    Console.Clear();

                    //nový výpis
                    pocet++;
                    strela(pole, tahX, tahY);
                    vyplnPole2(pole2);
                    cislovani(pole);
                    
                }
                Console.ForegroundColor = ConsoleColor.White;
                //hra znovu?
                Console.WriteLine("Chceš hrát znovu? A/N");
                string vyber = Console.ReadLine().ToUpper();
                if (vyber == "A")
                {
                    opakovat = true;
                }
                else
                {
                    opakovat = false;
                }
                Console.Clear();
            }
        }

        //vytvoření hracího pole
        static void vyplnPole(string[,] pole)
        {
            for (int i = 1; i < pole.GetLength(0); i++)
            {

                for (int j = 1; j < pole.GetLength(1); j++)
                {
                    pole[i, j] = "■";
                }
            }
        }

        static void vyplnPole2(string[,] pole)
        {
            for (int i = 1; i < pole.GetLength(0); i++)
            {

                for (int j = 1; j < pole.GetLength(1); j++)
                {
                    pole[i, j] = "■";
                }
            }
        }

        //čílování pole
        static void cislovani(string[,] pole)
        {
            // Sloupce
            Console.Write("   ");
            for (int i = 1; i < pole.GetLength(1); i++)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            // Řádky
            for (int i = 1; i < pole.GetLength(0); i++)
            {
                if (i < 10)
                {
                    Console.Write($"{i}  ");
                } else
                {
                    Console.Write($"{i} ");
                }
                for (int j = 1; j < pole.GetLength(1); j++)
                {
                    string symbol = " ";

                    //skrytí min
                    if (pole[i, j] == "*")
                    {
                        symbol = "■";
                        Console.Write(symbol + " ");
                    }
                    else
                    { 
                        Console.Write(pole[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
            //náhodné umístění min
            static void miny(string[,] pole)
            {
                Random random = new Random();
                for (int k = 0; k < 10; k++)
                {
                    int sloupec = random.Next(1, 11);
                    int radek = random.Next(1, 11);
                 // ošetření, že nebude více min na sobě
                if (pole[sloupec, radek] == "*")
                {
                    sloupec = random.Next(1, 11);
                    radek = random.Next(1, 11);
                }

                    pole[sloupec, radek] = "*";
                }

            }

            static void strela(string[,] pole, int tahX, int tahY)
            {
                int pocet = 0;
                // Kontrola okolních polí
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        int radek = tahY + i;
                        int sloupec = tahX + j;

                    //počítání min v okolí
                        if (radek >= 0 && radek < pole.GetLength(1) && radek >= 0 && sloupec < pole.GetLength(0))
                        {
                            if (pole[radek, sloupec] == "*" || pole[radek, sloupec] == "X")
                                pocet++;
                        }

                    }

                }
                //vložení počtu min v okolí do pole
                pole[tahY, tahX] = pocet.ToString();
            }
    }
}