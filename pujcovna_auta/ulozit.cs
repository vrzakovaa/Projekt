using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace pujcovna_auta
{
    
    internal class ulozit
    {
        pujcovna p = new pujcovna(); 
        string saveZakaznici;

        public void Ulozit(string filePath)     //uložení vozidel
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                //Newtonsoft.Json.JsonSerializer(p.auta);
                foreach (auto auto in p.auta)
                {
                    writer.WriteLine($"{auto.SPZ}, {auto.Vyrobce}, {auto.Model}, {auto.Typ}, {auto.Rok}, {auto.Cena}, {auto.Dostupnost}, {auto.Kdo}, {auto.Tachometr}, {auto.Mista}");
                }

            }
            Console.WriteLine("Data byla úspěšně uložena do souboru.");
        }

        public void UlozitZ(string filePath)        //uložení zákazníků
        {
            saveZakaznici = JsonSerializer.Serialize(p.zakaznici, saveZakaznici);
            StreamWriter writer = new StreamWriter(filePath);
            writer.WriteLine(saveZakaznici);
            writer.Close();
            /*
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (zakaznik z in p.zakaznici)
                {
                    writer.WriteLine($"{z.Jmeno}, {z.Datum}, {z.Telefon}, {z.Email}, {z.Opravneni}");
                }
                writer.Close();
            }
            Console.WriteLine("Data byla úspěšně uložena do souboru.");
            */
        }

        public void UlozitZaz(string filePath)      //uložení záznamu
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (zaznam zaznam in p.zaznam)
                {
                    writer.WriteLine($"{zaznam.Jmeno}, {zaznam.SPZ}, {zaznam.Vypujcka}, {zaznam.Vraceni}, {zaznam.Poznamky}");
                }

            }
            Console.WriteLine("Data byla úspěšně uložena do souboru.");
        }


        public List<auto> Nacist(string filePath)       //načtení vozidel
        {
            List<auto> auta = new List<auto>();

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 10)
                        {
                            string spz = parts[0];
                            string vyrobce = parts[1];
                            string model = parts[2];
                            string typ = parts[3];
                            int rok = parts.ToString()[4];
                            int cena = parts.ToString()[5];
                            string dostupnost = parts[6];
                            string kdo = parts[7];
                            int tachometr = parts.ToString()[8];
                            int mista = parts.ToString()[9];

                            auto a = new auto(spz, vyrobce, model, typ, rok, cena, dostupnost, kdo, tachometr, mista);
                            auta.Add(a);
                            
                        }
                    }
                }
                Console.WriteLine("Data byla úspěšně načtena ze souboru.");
            }
            else
            {
                Console.WriteLine("Soubor neexistuje.");
            }
            return auta;
        }

        public List<zakaznik> NacistZ(string filePath)      //načtení zákazníků
        {
            List<zakaznik> z = new List<zakaznik>();

            if (File.Exists(filePath))
            {
                saveZakaznici = File.ReadAllText(filePath);
                z = JsonSerializer.Deserialize<List<zakaznik>>(saveZakaznici);
                if (z == null)
                {
                    Console.WriteLine("No data found in json");
                    return z;
                }
                /*
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 5)
                        {
                            string jmeno = parts[0];
                            DateTime datum = DateTime.Parse(parts[1]);
                            int telefon = int.Parse(parts[2]);
                            string email = parts[3];
                            string opravneni = parts[4];

                            zakaznik zaz = new zakaznik(jmeno, datum, telefon, email, opravneni);
                            z.Add(zaz);
                        }
                    }
                }
                */
                Console.WriteLine("Data byla úspěšně načtena ze souboru.");
            }
            else
            {
                Console.WriteLine("Soubor neexistuje.");
            }
            return z;
        }

        public List<zaznam> NacistZaz(string filePath)      //načtení záznamu
        {
            List<zaznam> zaz = new List<zaznam>();
            if (File.Exists(filePath))
            {
                
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 5)
                        {
                            string jmeno = parts[0];
                            string spz = parts[1];
                            DateTime vypujcka = DateTime.Parse(parts[2]);
                            DateTime vraceni = DateTime.Parse(parts[3]);
                            string poznamky = parts[4];

                            zaznam z = new zaznam(jmeno, spz, vypujcka, vraceni, poznamky);
                            zaz.Add(z);
                        }
                    }
                }
                Console.WriteLine("Data byla úspěšně načtena ze souboru.");
            }
            else
            {
                Console.WriteLine("Soubor neexistuje.");
            }

            return zaz;
        }
    }
}
