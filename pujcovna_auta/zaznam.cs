using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pujcovna_auta
{
    internal class zaznam
    {
        public string Jmeno { get; set; }
        public string SPZ { get; set; }
        public DateTime Vypujcka { get; }
        public DateTime Vraceni { get; }
        public string Poznamky { get; }

        public zaznam(string jmeno, string spz, DateTime vypujcka, DateTime vraceni, string poznamky)
        {
            Jmeno = jmeno;
            SPZ = spz;
            Vypujcka = vypujcka;
            Vraceni = vraceni;
            Poznamky = poznamky;
        }

        public void Vypis()
        {
            Console.WriteLine($"Jméno: {Jmeno} \n\tSPZ vozidla: {SPZ} \n\tOd kdy: {Vypujcka}; Do kdy {Vraceni} \n\tPoznámky: {Poznamky}");
        }
    }

    
}
