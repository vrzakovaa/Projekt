using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pujcovna_auta
{
    internal class auto
    {
        public string SPZ { get; set; }
        public string Vyrobce { get; set; }
        public string Model { get; set; }
        public int Rok { get; set; }        //rok výroby
        public int Cena { get; set; } //kupní cena auta 
        public string Dostupnost { get; set; }
        public string Kdo { get; set; } //kdo má vozidlo vypůjčené
        public int Tachometr { get; set; }  //stav tachometru
        public int Mista { get; set; }      //počet míst
        public string Typ { get; set; }     //typ A/B

        public auto(string spz, string vyrobce, string model, string typ, int rok, int cena, string dostupnost, string kdo, int tachometr, int mista)
        {
            SPZ = spz;
            Vyrobce = vyrobce;
            Model = model;
            Typ = typ;
            Rok = rok;
            Cena = cena;
            Dostupnost = dostupnost;
            Kdo = kdo; 
            Tachometr = tachometr;
            Mista = mista;
        }
        public void Vypis()
        {
            Console.WriteLine($"\tVýrobce {Vyrobce} \n\tSPZ: {SPZ} \n\tModel {Model} \n\tTyp {Typ} \n\tRok výroby {Rok} \n\tKupní cena {Cena} \n\tStav tachometru {Tachometr}\n\tPočet míst {Mista} \n\tStav {Dostupnost} \n\t{Kdo}") ;
        }
        
    }

   
}
