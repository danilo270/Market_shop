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
using System.IO;
using System.Threading;
namespace projekat2_tvp
{
    
    public partial class DodajArtikal : Form
    {
        Baza baza;
        ListBox racun;
        public DodajArtikal(ListBox l1)
        {
            racun = l1;
            baza = new Baza();
            InitializeComponent();
        }

        private void DodajArtikal_Load(object sender, EventArgs e)
        {
            foreach (var item in racun.Items)
            {
                listBox1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id_artikla22=0, id_grupa2=0;
            try
            {
                baza.OtvoriKonekciju();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                /*string query1 = @"INSERT INTO Artikal(Naziv,cena,popust)
                VALUES(@naziv,@cena,@popust)";
                string query2= "Select * from Artikal";
                string query3 = @"INSERT INTO Grupa(id_grupa,id_artikla)
                VALUES(@id_grupa,@id_artikla)";
                cmd.CommandText = string.Join(";", query1, query2, query3);*/
                cmd.CommandText = @"INSERT INTO Artikal(Naziv,cena,popust)
                VALUES(@naziv,@cena,@popust)";
                cmd.Parameters.AddWithValue("Naziv",textBox1.Text );
                cmd.Parameters.AddWithValue("Cena", double.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("Popust",int.Parse(textBox3.Text) );
                int c = cmd.ExecuteNonQuery();
                if(comboBox1.Text.Equals("Voce i Povrce"))
                {
                    id_grupa2 = 1;
                }
                if (comboBox1.Text.Equals("Meso i Sirevi"))
                {
                    id_grupa2 = 2;
                }
                if (comboBox1.Text.Equals("Slatkisi"))
                {
                    id_grupa2 = 3;
                }
                if (comboBox1.Text.Equals("Hemikalije"))
                {
                    id_grupa2= 4;
                }
                cmd.CommandText = @"Select * from Artikal";
                c = cmd.ExecuteNonQuery();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string naziv = reader["Naziv"].ToString();
                    if (textBox1.Text==naziv)
                    {
                        id_artikla22 = int.Parse(reader["id_artikla"].ToString());
                    }
                }
                reader.Close();
                cmd.Dispose();
                cmd.Connection = baza.Conn;
                cmd.CommandText = @"INSERT INTO Grupa(id_grupa,id_artikla2)
                VALUES(@id_grupa,@id_artikla2)";
                //MessageBox.Show("" + cmd.CommandText);
                Grupa g = new Grupa(id_grupa2, id_artikla22);
                cmd.Parameters.AddWithValue("id_grupa", id_grupa2.ToString());
                cmd.Parameters.AddWithValue("id_artikla2",id_artikla22.ToString());
                c = cmd.ExecuteNonQuery();
                if (c > 0)
                {
                    MessageBox.Show("Uspesno!");
                }
                else
                {
                    MessageBox.Show("Neuspesno!");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally { baza.ZatvoriKonekciju(); }
        }
    }
}

