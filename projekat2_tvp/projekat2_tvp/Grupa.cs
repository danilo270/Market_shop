using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekat2_tvp
{
    class Grupa
    {
        private double id_grupa, id_artikla;

        public Grupa(int id_grupa, int id_artikla)
        {
            this.id_grupa = id_grupa;
            this.id_artikla = id_artikla;
        }
        public double Id_grupa { get { return id_grupa; } set { this.id_grupa = value; } }
        public double Id_artikla { get { return id_artikla; } set { this.id_artikla = value; } }
    }
}
