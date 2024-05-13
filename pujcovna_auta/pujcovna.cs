using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace pujcovna_auta
{
    internal class pujcovna
    {
        public List<auto> auta;
        public List<zakaznik> zakaznici;
        public List<zaznam> zaznam;

        public pujcovna()
        {
            auta = new List<auto>();
            zakaznici = new List<zakaznik>();
            zaznam = new List<zaznam>();
        }

       
        // přídání nové auto do seznamu 
        public void PridatV()
        {
            Console.WriteLine("Zadej SPZ nového vozidla");  //SPZ
            string spz = Console.ReadLine();

            Console.WriteLine("Zadej výrobce vozidla");     //výrobce
            string vyrobce = Console.ReadLine();

            Console.WriteLine("Zadej model vozidla");       //model
            string model = Console.ReadLine();

            Console.WriteLine("Zadej typ vozidla: (A,B)");      //typ
            string typ = Console.ReadLine().ToUpper();

            while (typ != "A" && typ != "B")
            {
                Console.WriteLine("Typ se neshoduje, zadej znovu");
                typ = Console.ReadLine();
            }

            int rok;
            Console.WriteLine("Zadej rok výroby");      //rok výroby
            while(!int.TryParse(Console.ReadLine(), out rok) || rok < 1900 || rok > DateTime.Now.Year) 
            {
                Console.WriteLine("Zadali jste nerealný rok, zkuste to znovu");
            }

            Console.WriteLine("Zadej cenu vozidla");        //původní cena 
            int cena;
            while (!int.TryParse(Console.ReadLine(), out cena) || cena < 100)
            {
                Console.WriteLine("Neplatný vstup, zkuste znovu");
            }

            string dostupnost = "dostupné";

            string kdo = "-";

            Console.WriteLine("Zadej stav tachometru");     //stav tachometru
            int tachometr;
            while (!int.TryParse(Console.ReadLine(), out tachometr) || tachometr < 0)
            {
                Console.WriteLine("Číslo není zadané správně, zkuste to znovu");
            }

            Console.WriteLine("Zadej počet míst ve vozidle");       //počet míst
            int mista; 
            while(!int.TryParse(Console.ReadLine() , out mista) || mista < 0)
            {
                Console.WriteLine("Počet míst není zadaný správně, zkus to znovu");
            }

            auto a = new auto(spz, vyrobce, model, typ, rok, cena, dostupnost, kdo, tachometr, mista);
            auta.Add(a);
        }

        //upravení záznamu o vozidle
        public void UpravitV()
        {
            Console.WriteLine("Zadej index vozidla které chceš upravit");
            int index;

            while (!int.TryParse(Console.ReadLine(), out index) || index > auta.Count || index < 0)
            {
                Console.WriteLine("Číslo není zadané správně, zkus to znovu");
                
            }

            Console.WriteLine($"Aktuální spz vozidla je {auta[index].SPZ}, chceš změnit? A/N");
            if(Console.ReadLine().ToLower() == "a")
            {
                Console.WriteLine("Zadej novou SPZ vozidla: ");
                auta[index].SPZ = Console.ReadLine();
            }

            Console.WriteLine($"Aktuální výrobce vozidla je {auta[index].Vyrobce}, chceš změnit? A/N");
            if (Console.ReadLine().ToLower() == "a")
            {
                Console.WriteLine("Zadej nového výrobce: ");
                auta[index].Vyrobce = Console.ReadLine();
            }

            Console.WriteLine($"Aktuální model vozidla je {auta[index].Model}, chceš změnit? A/N");
            if(Console.ReadLine().ToLower() == "a")
            {
                Console.WriteLine("Zadej nový model: ");
                auta[index].Model = Console.ReadLine();
            }

            Console.WriteLine($"Aktuální rok výroby {auta[index].Rok}, chceš upravit? A/N");
            if(Console.ReadLine().ToLower() == "a")
            {
                Console.WriteLine("Zadej nový rok výroby");
                int rok;
                while (!int.TryParse(Console.ReadLine(), out rok) || rok < 1900 || rok > DateTime.Now.Year)
                {
                    Console.WriteLine("Zadali jste nerealný rok, zkuste to znovu");
                }

                auta[index].Rok = rok;
            }

            Console.WriteLine($"Akruální kupní cena je {auta[index].Cena}, chceš změnit? A/N");
            if(Console.ReadLine().ToLower() == "a")
            {
                Console.WriteLine("Zadej novou cenu: ");
                int cena;
                while (!int.TryParse(Console.ReadLine(), out cena) || cena < 100)
                {
                    Console.WriteLine("Neplatný vstup, zkuste znovu");
                }

                auta[index].Cena = cena;
            }

            Console.WriteLine($"Aktuální stav vozidla je {auta[index].Dostupnost}, chceš upravit A/N");
            if (Console.ReadLine().ToLower() == "a")
            {
                Console.WriteLine("Zadej nový stav: ");
                auta[index].Dostupnost = Console.ReadLine();
            }

            Console.WriteLine($"Aktuální stav tachometru je {auta[index].Tachometr}, chceš upravit A/N");
            if (Console.ReadLine().ToLower() == "a")
            {
                Console.WriteLine("Zadej nový stav tachometru: ");
                int tachometr;
                while (!int.TryParse(Console.ReadLine(), out tachometr) || tachometr < 0)
                {
                    Console.WriteLine("Číslo není zadané sprýávně, zkuste to znovu");
                }

                auta[index].Tachometr = tachometr;
            }

            Console.WriteLine($"Aktuální počet míst je {auta[index].Mista}, chceš upravit A/N");
            if (Console.ReadLine().ToLower() == "a")
            {
                Console.WriteLine("Zadej nový počet: ");
                int mista;
                while (!int.TryParse(Console.ReadLine(), out mista) || mista < 0)
                {
                    Console.WriteLine("Počet míst není zadaný správně, zkus to znovu");
                }

                auta[index].Mista = mista;
            }
        }

        //odebrání vozidla
        public void OdebratV()
        {
            Console.WriteLine("Zadej index vozidla které chceš odebrat");
            int index;
            while (!int.TryParse(Console.ReadLine(), out index) || index > auta.Count || index < 0)
            {
                Console.WriteLine("Číslo není zadané správně, zkus to znovu");
            }
            auta.RemoveAt(index);
        }

        //výpis všech aut a jejich informace 
        public void VypisV()
        {
                for (int i = 0; i < auta.Count; i++)
                {
                    Console.Write(i + ".");
                    auta[i].Vypis();
                }
           
        }

        // výpis všech aut + jen základní informace 
        public void VypisV2()
        {
            for(int i = 0; i < auta.Count; i++)
            {
                Console.WriteLine($"{i}. Výrobce: {auta[i].Vyrobce}, Model: {auta[i].Model}, SPZ: {auta[i].SPZ} ");
            }
        }

        //přidání nového zákazníka do seznamu 
        public void PridatZ()
        {
            Console.WriteLine("Zadej jméno a přijmení zákazníka");      //jméno
            string jmeno = Console.ReadLine().ToLower();

            Console.WriteLine("Zadej datum narození");                  //datum narození
            DateTime datum;

            while (!DateTime.TryParse(Console.ReadLine(), out datum) || datum.Year < 1920)
            {
                Console.WriteLine("Neplatný vstup, zkus to znovu");
            }

            Console.WriteLine("Zadej telefonní číslo");                 //telefonní číslo
            int telefon;

            while(!int.TryParse(Console.ReadLine(), out telefon) || telefon < 100000000)
            {
                Console.WriteLine("Neplatný vstup, zkus to znovu");
            }

            Console.WriteLine("Zadej email zákazníka");              //email
            string email = Console.ReadLine();

            string opravneni = Opravneni(datum);

            zakaznik z = new zakaznik(jmeno, datum, telefon, email, opravneni);
            zakaznici.Add(z);
        }

        // oprávnění zda zákazník může řídit 
        public string Opravneni(DateTime datum)
        {
            //ověření věku zákazníka

            int rok = DateTime.Now.Year;
            string povoleno = "-";

            int overeni = rok - datum.Year; //výpočet let
            if (overeni < 16)
            {
                Console.WriteLine("Zákazník nemá opravnění řídit!");
                povoleno = "-";
            }
            else if (overeni < 18 && overeni >= 16)
            {
                Console.WriteLine("Zákazník může řídit vozidla typu A");
                povoleno = "A";
            }
            else if (overeni >= 18)
            {
                Console.WriteLine("Zákazník může řídit vozidla typu A i B");
                povoleno = "B";
            }

            return povoleno;
        }

        //výpočet ceny za celou výpůjčku 
        public int Vypocet(DateTime vypujcka, DateTime vraceni, int index)
        {
            TimeSpan delka = vraceni - vypujcka;
            int dny = (int)delka.TotalDays;

            int cena = cenaDen(index) * dny;

            return cena;
        }
        
        //výpočet ceny vozidla na den
        public int cenaDen(int index)
        {
            int cena = (auta[index].Cena / 365) / 3;
            return cena;
        }


        // upravení dat o zákazníkovi
        public void UpravitZ()
        {
            Console.WriteLine("Zadej index zákazníka jehož informace chceš upravit");
            int index;
            while (!int.TryParse(Console.ReadLine(), out index) && index > zakaznici.Count && index < 0)
            {
                Console.WriteLine("Číslo není zadané správně, zkus to znovu");
            }

            Console.WriteLine($"Aktuální jméno: {zakaznici[index].Jmeno}, chceš změnit? A/N");
            if (Console.ReadLine().ToLower() == "a")
            {
                Console.WriteLine("Zadej nové jméno: ");
                zakaznici[index].Jmeno = Console.ReadLine();
            }

            Console.WriteLine($"Aktuální datum narození: {zakaznici[index].Datum}, chceš změnit? A/N");
            if (Console.ReadLine().ToLower() == "a")
            {
                Console.WriteLine("Zadej nového datum: ");
                zakaznici[index].Datum = DateTime.Parse( Console.ReadLine());
            }

            Console.WriteLine($"Aktuální tel. číslo: {zakaznici[index].Telefon}, chceš změnit? A/N");
            if (Console.ReadLine().ToLower() == "a")
            {
                Console.WriteLine("Zadej nové tel. číslo: ");
                zakaznici[index].Telefon = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"Aktuální email: {zakaznici[index].Email}, chceš upravit? A/N");
            if (Console.ReadLine().ToLower() == "a")
            {
                Console.WriteLine("Zadej nový email:");
                zakaznici[index].Email = Console.ReadLine();
            }
        }

        //výpis zákazníků se všemi informacemi

        public void VypisZ()
        {
                for (int i = 0; i < zakaznici.Count; i++)
                {
                    Console.WriteLine(i + ". ");
                    zakaznici[i].vypis();
                }
            
        }

        //odrabrání zákazníků
        public void OdebratZ()
        {
            Console.WriteLine("Zadej index zákazníka, kterého chceš odebrat: ");
            int index;
            while (!int.TryParse(Console.ReadLine(), out index) || index > zakaznici.Count || index < 0)
            {
                Console.WriteLine("Číslo není zadané správně, zkus to znovu");
            }

            zakaznici.RemoveAt(index);
            Console.WriteLine("Zákazník úspěšně odebrán");
        }

        //výpis záznamu
        public void VypisZaz()
        {
            foreach(zaznam zaznam in zaznam)
            {
                zaznam.Vypis();
            }
        }

        //půjčení vozidla
        public void Pujcit()
        {

            int index;
            Console.WriteLine("Zadej index vozidla které chceš půjčit");
            while (!int.TryParse(Console.ReadLine(), out index) || index < 0 || index > auta.Count)
            {
                Console.WriteLine("Neplatný vsup, zadej znovu");
            }


            //ošetření zda je vozidlo dostupné 

            if (auta[index].Dostupnost == "dostupné")
            {

                Console.WriteLine("Vozidlo je dostupné");

                Console.WriteLine("Kdo si vozidlo půjčuje?");
                string jmeno = Console.ReadLine().ToLower();

                //ošetření zda je zákazník evidován
                for (int i = 0; i < zakaznici.Count; i++)
                {
                    if (jmeno == zakaznici[i].Jmeno)
                    {
                        // ošetření zda zákazník může řídit vozidlo s tímto typem
                        if (zakaznici[i].Opravneni == auta[index].Typ)
                        {
                            auta[index].Kdo = jmeno;
                            string spz = auta[index].SPZ;

                            Console.WriteLine("Od kdy bude auto vypůjčené? ");
                            DateTime odkdy;
                            while (!DateTime.TryParse(Console.ReadLine(), out odkdy))
                            {
                                Console.WriteLine("Neplatný vstup, zkus to znovu");
                            }

                            Console.WriteLine("Do kdy bude auto vypůjčené,");
                            DateTime dokdy;
                            while (!DateTime.TryParse(Console.ReadLine(), out dokdy))
                            {
                                Console.WriteLine("Neplatný vstup, zkus to znovu");
                            }

                            Console.WriteLine("Poznámky: ");
                            string poznamky = Console.ReadLine();

                            //přdání do záznamu
                            zaznam z = new zaznam(jmeno, spz, odkdy, dokdy, poznamky);
                            zaznam.Add(z);

                            //změna dostupnosti
                            auta[index].Dostupnost = "vypůjčené";
                        }
                        else
                        {
                            Console.WriteLine("Zákazník nemá oprávnění řídit toto vozidlo");
                        }
                    }
                }

                // pokud není zákazník v záznamu, můžeme ho přidat 
                for (int i = 0; i < zakaznici.Count; i++)
                {
                    if (jmeno != zakaznici[i].Jmeno)
                    {
                        Console.WriteLine("Zákazník není v záznamu, chceš přidat? A/N");
                        if (Console.ReadLine().ToLower() == "a")
                        {
                            PridatZ();
                        }
                    }
                }

            }

            else
            {
                Console.WriteLine("Vozidlo je vypůjčené");
            }
        }

        //vrácení vozidla
        public void Vraceni()
        {
            Console.WriteLine("Kdo vrací vozidlo ");
            string jmeno = Console.ReadLine().ToLower();

            //ošetření zda je zákazník evidován
            for (int i = 0; i < zakaznici.Count; i++)
            {
                if (jmeno == zaznam[i].Jmeno)
                {

                    Console.WriteLine("Zadej datum vrácení");
                    DateTime datum;
                    while (!DateTime.TryParse(Console.ReadLine(), out datum))
                    {
                        Console.WriteLine("Neplatný vstup, zkus to znovu");
                    }

                    //ošetření, zda bylo auto vráceno v čas

                    if (datum.Year - zaznam[i].Vraceni.Year == 0)
                    {
                        if (datum.Month - zaznam[i].Vraceni.Month == 0)
                        {
                            if (datum.Day - zaznam[i].Vraceni.Day == 0)
                            {
                                Console.WriteLine("Vozidlo vráceno včas");
                                for (int j = 0; j < auta.Count; j++)
                                {
                                    if (auta[j].SPZ == zaznam[i].SPZ)
                                    {

                                        auta[j].Dostupnost = "dotupné";         //změna dostupnosti

                                        Console.WriteLine("Zadej stav tachometru");     //změna tachometru 
                                        int t;
                                        while (!int.TryParse(Console.ReadLine(), out t) || t <= auta[j].Tachometr) //ošetření vstupu, aby nový stav nebyl menší nebo stejný jako předtím
                                        {
                                            Console.WriteLine("Neplatný vstup, zadej znovu");
                                        }

                                        auta[j].Tachometr = t;
                                        Console.WriteLine("Celková cena: " + Vypocet(zaznam[i].Vypujcka, datum, j));
                                        Console.WriteLine("Poznámky: ");
                                        string poznamky = Console.ReadLine();
                                        zaznam z = new zaznam(jmeno, auta[j].SPZ, zaznam[i].Vypujcka, datum, poznamky);     //přidání výpůjčky do záznamu
                                        zaznam[i] = z;

                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int j = 0; j < auta.Count; j++)
                        {
                            if (auta[j].SPZ == zaznam[i].SPZ)
                            {
                                Console.WriteLine("Vozidlo vráceno pozdě! \nCelková cena: ");
                                Console.Write(Vypocet(zaznam[i].Vypujcka, datum, j));
                                Console.WriteLine("Poznámky: ");
                                string poznamky = Console.ReadLine();
                                zaznam z = new zaznam(jmeno, auta[j].SPZ, zaznam[i].Vypujcka, datum, poznamky);     //přidání výpůjčky do záznamu
                                zaznam[i] = z;
                            }
                        }

                    }
                }
            }

        }
    }
}
