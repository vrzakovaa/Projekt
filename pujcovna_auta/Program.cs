namespace pujcovna_auta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            pujcovna p = new pujcovna();
            ulozit u = new ulozit();

            int volba = 0;
            while (volba != 20)
            {
                Console.WriteLine("MENU VOZIDLA");
                Console.WriteLine("\t1. Přidat \n\t2. Upravit \n\t3. Odebrat \n\t4. Cena za den \n\t5. Vypsat seznam aut ");
                Console.WriteLine("MENU ZÁKAZNÍKŮ");
                Console.WriteLine("\t6. Přidat \n\t7. Upravit \n\t8. Oprávnění \n\t9. Výpis \n\t10. Přehled záznamů \n\t11. Odebrat \n\t12. Vypůjčit vozidlo \n\t13. Vrátit vozidlo ");
                Console.WriteLine("MENU SOUBORŮ");
                Console.WriteLine("\t14. Uložit seznam vozidel \n\t15. Načíst vozidla ze souborů \n\t16. Uložit seznam zákaznáků \n\t17. Načíst zákazníky ze souborů \n\t18. Uložit záznamy \n\t19. Načíst záznamy ze souborů \n\t20. Exit ");
                
                while (!int.TryParse(Console.ReadLine(), out volba) || volba < 1 || volba > 20)
                {
                    Console.WriteLine("Číslo se neshoduje s možnostmi, zkus novu: ");
                    
                }

                switch (volba)
                {

                    //přidání vozidla
                    case 1:
                        p.PridatV();
                        Console.ReadKey();
                        break;

                    case 2:
                        //úprava vozidla 
                        p.VypisV2();
                        if (p.auta.Count == 0)      //ošetření zda je v listu nějaké vozidlo
                        {
                            Console.WriteLine("V záznamu není žádné auto");
                            Console.ReadKey();
                            
                        }
                        else
                        {
                            p.UpravitV();
                        }
                        Console.ReadKey();
                        break;


                    case 3:
                        //odabrání vozidla
                        if (p.auta.Count == 0)
                        {
                            Console.WriteLine("V záznamu není žádné auto");
                            Console.ReadKey();

                        }
                        else
                        {
                            p.VypisV2();
                            p.OdebratV();
                        }
                        Console.ReadKey();
                        break;

                    case 4:
                        //výpočet ceny za den
                        if (p.auta.Count == 0)
                        {
                            Console.WriteLine("V záznamu není žádné auto");
                            Console.ReadKey();

                        }
                        else
                        {
                            p.VypisV2();
                            Console.WriteLine("Zadej index vozidla pro výpočet");
                            int index = int.Parse(Console.ReadLine());

                            int cena = p.cenaDen(index);
                            Console.WriteLine(cena);
                            Console.ReadKey();
                        }
                        Console.ReadKey();

                        break;

                    case 5:
                        //výpis seznamu vozidel
                        if (p.auta.Count == 0)
                        {
                            Console.WriteLine("V záznamu není žádné auto");
                            Console.ReadKey();

                        }
                        else
                        {
                            p.VypisV();
                            Console.ReadKey();

                        }
                        Console.ReadKey();

                        break;
               

                        //zákazníci
                    case 6:
                        //přidat zákazníka
                        p.PridatZ();
                        Console.ReadKey();

                        break;

                    case 7:
                       //upravit zákazníka
                        if (p.zakaznici.Count == 0)
                        {
                            Console.WriteLine("V záznamu není žádný zákazník");
                            Console.ReadKey();

                        }
                        else
                        {
                            p.UpravitZ();

                        }
                        Console.ReadKey();

                        break;
                        

                    case 8:
                        //zjištěné oprávnění 
                        if (p.zakaznici.Count == 0)
                        {
                            Console.WriteLine("V záznamu není žádný zákazník");

                        }
                        else
                        {
                            p.VypisZ();
                            Console.WriteLine("Zaden index zákazníka, pro kterého chceš zjistit oprávnění");
                            int index = 0;
                            while (!int.TryParse(Console.ReadLine(), out index) && index < p.zakaznici.Count && index > p.zakaznici.Count)
                            {
                                Console.WriteLine("Číslo se neshoduje, zkus znovu");
                            }
                            p.Opravneni(p.zakaznici[index].Datum);

                        }
                        Console.ReadKey();

                        break;

                    case 9:
                        //výpis zákazníků
                        if (p.zakaznici.Count == 0)
                        {
                            Console.WriteLine("V záznamu není žádný zákazník");

                        }
                        else
                        {
                            p.VypisZ();
                        }
                        Console.ReadKey();

                        break;

                    case 10:
                        //výpis záznamů (zákazník + jeho výpůjčky)
                        if (p.zaznam.Count == 0)
                        {
                            Console.WriteLine("Neexistuje žádný záznam");
                        }
                        else
                        {
                            p.VypisZaz();
                        }
                        Console.ReadKey();

                        break;


                    case 11:
                        //odebrat zákazníka
                        if (p.zakaznici.Count == 0)
                        {
                            Console.WriteLine("V záznamu není žádný zákazník");
                            Console.ReadKey();

                        }
                        else
                        {
                            p.OdebratZ();
                        }
                        Console.ReadKey();

                        break;


                       
                    case 12:
                        //vypůjčení vozidla
                        if (p.auta.Count == 0)
                        {
                            Console.WriteLine("V záznamu není žádné auto");

                        }
                        else
                        {
                            p.VypisV2();
                            p.Pujcit();
                        }
                        Console.ReadKey();

                        break;

                    case 13:
                        //vrácení vozidla
                        if (p.auta.Count == 0)
                        {
                            Console.WriteLine("V záznamu není žádné auto");

                        }
                        else
                        {
                            p.VypisZ();
                            p.Vraceni();
                        }
                        Console.ReadKey();
                        break;


                    
                    case 14:
                        //ukládání do souborů vozidla
                        Console.WriteLine("Zadej cestu");
                        string filepath = Console.ReadLine();
                        u.Ulozit(filepath);
                        Console.ReadKey();
                        break;

                    case 15:
                        //načtení vozidla
                        Console.WriteLine("Zadej cestu");
                        filepath = Console.ReadLine();
                        p.auta.Clear();
                        p.auta = u.Nacist(filepath);
                        Console.ReadKey();
                        break;

                    case 16:
                        //uložení zákazníků 
                        Console.WriteLine("Zadej cestu");
                        filepath = Console.ReadLine();
                        u.UlozitZ(filepath);
                        Console.ReadKey();
                        break;

                    case 17:
                        //načtení zákazníků
                        Console.WriteLine("Zadej cestu");
                        filepath = Console.ReadLine();
                        p.zakaznici.Clear();
                        p.zakaznici = u.NacistZ(filepath);
                        Console.ReadKey();
                        break;

                    case 18:
                        //uložeí záznamu
                        Console.WriteLine("Zadej cestu");
                        filepath = Console.ReadLine();
                        u.UlozitZaz(filepath);
                        Console.ReadKey();
                        break;

                    case 19:
                        //načtení záznamu
                        Console.WriteLine("Zadej cestu");
                        filepath = Console.ReadLine();
                        p.zaznam.Clear();
                        p.zaznam = u.NacistZaz(filepath);
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            }
        }
    }
}
