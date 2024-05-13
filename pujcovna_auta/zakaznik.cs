using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pujcovna_auta
{
    internal class zakaznik
    {
        public string Jmeno { get; set; }
        public DateTime Datum { get; set; }
        public int Telefon { get; set; }
        public string Email { get; set; }
        
        public string Opravneni { get; set; }       //oprávnění za může řídit vozila typu A nebo B

        public zakaznik(string jmeno, DateTime datum, int telefon, string email, string opravneni)
        {
            Jmeno = jmeno;
            Datum = datum.Date;
            Telefon = telefon;
            Email = email;
            Opravneni = opravneni;
        }

        public void vypis()
        {
            Console.WriteLine($"Jméno: {Jmeno}, datum narození: {Datum}, tel. číslo: {Telefon}, email: {Email}, oprávnění: Může řídit vozidlo s typem {Opravneni}");
        }
    }
}
