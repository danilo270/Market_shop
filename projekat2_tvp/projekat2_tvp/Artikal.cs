using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekat2_tvp
{
    class Artikal
    {
        private int id_artikla, popust;
        private string naziv;
        private double cena;
        private int kolicina;
        public Artikal(int id_artikla, int popust, string naziv, double cena)
        {
            this.id_artikla = id_artikla;
            this.popust = popust;
            this.naziv = naziv;
            this.cena = cena;
        }
        public int Id { get {return id_artikla; } set { this.Id = value ; } }
        public int Popust { get { return popust; } set { this.popust = value; } }
        public string Naziv{ get { return naziv; } set { this.naziv = value; } }
        public double Cena{ get { return cena; } set { this.cena = value; } }
        public int Kol { get { return kolicina; } set { this.kolicina = value; } }
        public override string ToString()
        {
            return "" + this.naziv;
        }
    }
}
