using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Authentication.ExtendedProtection;

namespace _1_projekt_lode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] pole = new char[11, 11];
            
            vyplnPole(pole);
            lod(pole);
            cislovani(pole);
           

            int pocet = 0;
            int pocetTahu = 0;
            char[,] pole2 = new char[11, 11];

            while (pocet < 3)
            {

                int tahX;
                int tahY;

                //zadání tahu

                Console.Write("Zadej sloupec: ");

                while (!int.TryParse(Console.ReadLine(), out tahX) || tahX < 1 || tahX > 10)
                {
                    Console.WriteLine("Neplatný vstup. Zadej platný sloupec (1-10): ");
                }

                Console.Write("Zadej řádek: ");

                while (!int.TryParse(Console.ReadLine(), out tahY) || tahY < 1 || tahY > 10)
                {
                    Console.WriteLine("Neplatný vstup. Zadej platný řádek (1-10): ");
                }

                // je loď trefena?

                if (pole[tahY, tahX] == '#')
                {
                    string text = "trefena";
                    Console.ForegroundColor = ConsoleColor.Red;
                    strela(text, tahX, tahY, pole);
                    pocetTahu++;
                    pocet++;

                }
                else
                {
                    string text2 = "jsi minul";
                    pocetTahu++;
                    strela(text2, tahX, tahY, pole);

                }
                vyplnPole2(pole2);
                cislovani(pole);


                Console.ForegroundColor = ConsoleColor.White;

            }

            if(pocet == 3)
            {
                Console.WriteLine("Loď potopena, potřeboval jsi na to " + pocetTahu + " tahů");
            }

        }
        static void vyplnPole(char[,] pole)
        {
            for (int i = 1; i < pole.GetLength(0); i++)
            {

                for (int j = 1; j < pole.GetLength(1); j++)
                {
                    pole[i, j] = '~';
                }
            }
        }
        static void lod(char[,] pole)
        {
            int sloupec;
            int radek;

            Random random = new Random();

            radek = random.Next(1, pole.GetLength(0));
            sloupec = random.Next(1, pole.GetLength(1) - 3);

            pole[radek, sloupec] = '#';
            pole[radek, sloupec + 1] = '#';
            pole[radek, sloupec + 2] = '#';

        }

        static void cislovani(char[,] pole)
        {
            // Očíslování sloupců
            Console.Write("  ");
            for (int i = 1; i < pole.GetLength(1); i++)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            // Očíslování řádků
            for (int i = 1; i < pole.GetLength(0); i++)
            {
                Console.Write($"{i} ");
                for (int j = 1; j < pole.GetLength(1); j++)
                {
                    // skrytí lodě

                    char symbol = ' ';
                    
                  if (pole[i,j] == '#')
                  {
                        symbol = '~';
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
       
       static void vyplnPole2(char[,] pole2)
        {
            
            for (int i = 1; i < pole2.GetLength(0); i++)
            {

                for (int j = 1; j < pole2.GetLength(1); j++)
                {
                    pole2[i, j] = '~';
                }
            }
        }

       
        static void strela(string text, int tahX, int tahY, char[,] pole)
        {
            Console.WriteLine("Loď " + text);
            pole[tahY, tahX] = 'X';
            
        }
        
    }
}