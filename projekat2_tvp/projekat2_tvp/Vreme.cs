using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace projekat2_tvp
{
    public partial class Vreme : Form
    {
        ListBox racun;
        Baza baza;
        List<Racun> lista_racuna;
        public Vreme(ListBox l)
        {
            racun = l;
            baza = new Baza();
            lista_racuna = new List<Racun>();
            InitializeComponent();
        }

        private void Vreme_Load(object sender, EventArgs e)
        {
            foreach (var item in racun.Items)
            {
                listBox2.Items.Add(item);
            }
        }

        private void Generisi_Click(object sender, EventArgs e)
        {
            baza.OtvoriKonekciju();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = baza.Conn;
            cmd.CommandText = "SELECT * FROM Racun";
            OleDbDataReader reader = cmd.ExecuteReader();
            lista_racuna.Clear();
            while (reader.Read())
            {
                lista_racuna.Add(new Racun(int.Parse(reader["id_racun"].ToString()), double.Parse(reader["cena"].ToString()),
                    DateTime.Parse(reader["datum"].ToString()), reader["vreme"].ToString()));
            }
            foreach (var item in lista_racuna)
            {
                if(DateTime.Compare(item.Datum,dateTimePicker1.Value.Date)>=0&& DateTime.Compare(item.Datum, dateTimePicker2.Value.Date) <= 0)
                {
                    //MessageBox.Show("asdfas");
                    listBox1.Items.Add("Racun" + item.Id + "Vreme" + item.Vreme);
                }
            }
            baza.ZatvoriKonekciju();
        }
    }
}
