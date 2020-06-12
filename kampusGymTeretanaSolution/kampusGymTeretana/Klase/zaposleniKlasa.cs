using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kampusGymTeretana.Klase
{
    class zaposleniKlasa
    {
        public int id { get; protected set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string datum_rodenja { get; set; }
        public string email { get; set; }
        public int mobitel { get; set; }
        public string slika { get; set; } //bilo string

        public int id_zaposlenika { get; set; }
    }
}
