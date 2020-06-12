using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kampusGymTeretana.Klase
{
    class urediKlasa
    {
        public int id { get; protected set; }
        public int gym_id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string spol { get; set; }
        public string datum_rodenja { get; set; }
        public string email { get; set; }
        public string datum_placanja { get; set; }
        public string datum_vrijedi_do { get; set; }
        public string vrsta_treninga { get; set; }
        public string slika { get; set; } //bilo string
    }
}
