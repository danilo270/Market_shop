using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekat2_tvp
{
    class Racun
    {
        private int id_racun;
        private double cena;
        private DateTime datum;
        private string vreme;

        public Racun(int id_racun, double cena, DateTime datum, string vreme)
        {
            this.id_racun = id_racun;
            this.cena = cena;
            this.datum = datum;
            this.vreme = vreme;
        }
        public Racun() { }
        public int Id { get {return id_racun; } set { this.id_racun = value; } }
        public double Cena { get { return cena; } set { this.cena = value; } }
        public DateTime Datum{ get { return datum; } set { this.datum = value; } }
        public string Vreme { get { return vreme; } set { this.vreme = value; } }
    }
}
