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
    public partial class Form1 : Form
    {
        Baza baza;
        Racun racun;
        Artikal artikal;
        List<Artikal> lista_artikla = new List<Artikal>();
        public Form1()
        {
            baza = new Baza();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            baza.OtvoriKonekciju();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = baza.Conn;
            cmd.CommandText = "SELECT * FROM Artikal";
            OleDbDataReader reader = cmd.ExecuteReader();
            lista_artikla.Clear();
            while (reader.Read())
            {
                lista_artikla.Add(new Artikal(int.Parse(reader["id_artikla"].ToString()), int.Parse(reader["Popust"].ToString()),
                    reader["Naziv"].ToString(),double.Parse(reader["cena"].ToString())));
            }
            comboBox1.DataSource = lista_artikla;
            comboBox1.DisplayMember = "Naziv";
            comboBox1.ValueMember = "Id";
            baza.ZatvoriKonekciju();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            racun = new Racun();
            artikal = (Artikal)comboBox1.SelectedItem;
            artikal.Kol = int.Parse(textBox1.Text);
            racun.Cena += int.Parse(textBox1.Text) * artikal.Cena;
            listBox1.Items.Add(artikal.Naziv + ":" + artikal.Cena+"X"+textBox1.Text);
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            artikal = (Artikal)comboBox1.SelectedItem;
            racun.Cena -= artikal.Kol * artikal.Cena;
            listBox1.Items.Remove(listBox1.Items[listBox1.SelectedIndex]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                baza.OtvoriKonekciju();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                cmd.CommandText = @"INSERT INTO Racun(cena,datum,vreme)
                VALUES(@cena,@datum,@vreme)";
                cmd.Parameters.AddWithValue("cena", racun.Cena);
                cmd.Parameters.AddWithValue("datum", DateTime.Today);
                cmd.Parameters.AddWithValue("vreme", DateTime.Now.ToLocalTime().ToShortTimeString());
                int rez = cmd.ExecuteNonQuery();
                if (rez > 0)
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

        private void button4_Click(object sender, EventArgs e)
        {
            Form f = new DodajArtikal(listBox1);
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form f1 = new Vreme(listBox1);
            f1.Show(); 
        }
    }
}
