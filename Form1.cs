using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection.Emit;

namespace ednevnik410b
{
    public partial class Form1 : Form
    {
        int br_reda;
        DataTable tabela;
        public Form1()
        {
            InitializeComponent();
        }

        public void load_data()
        {
            SqlConnection veza = konekcija.povezi();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM osoba", veza);
            tabela = new DataTable();
            da.Fill(tabela);
        }
        public void popuni_txt()
        {
            if (tabela.Rows.Count == 0)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
            }
            else
            {
                textBox1.Text = tabela.Rows[br_reda][0].ToString();
                textBox2.Text = tabela.Rows[br_reda][1].ToString();
                textBox3.Text = tabela.Rows[br_reda][2].ToString();
                textBox4.Text = tabela.Rows[br_reda][3].ToString();
                textBox5.Text = tabela.Rows[br_reda][4].ToString();
                textBox6.Text = tabela.Rows[br_reda][5].ToString();
            }
            if (br_reda == tabela.Rows.Count - 1) button6.Enabled = false;
            else button6.Enabled = true;
            if (br_reda == 0) button2.Enabled = false;
            else button2.Enabled = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            load_data();
            br_reda = 0;
            popuni_txt();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            br_reda++;
            popuni_txt();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            br_reda--;
            popuni_txt();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            br_reda = 0; 
            popuni_txt();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            br_reda= tabela.Rows.Count-1;
            popuni_txt();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // DODAJ
            /*
           
             *   INSERT INTO osoba
             * VALUES('Ime','Prezime','Adresa','1204007123456',
             * 'aaa@bbb.cc','123',1)
             */
            string naredba = "INSERT INTO osoba VALUES('";
            naredba = naredba + textBox2.Text + "','";
            naredba = naredba + textBox3.Text + "','";
            naredba = naredba + textBox4.Text + "','";
            naredba = naredba + textBox5.Text + "','";
            naredba = naredba + textBox6.Text + "','";
            naredba = naredba + textBox7.Text + "',";
            naredba = naredba + textBox8.Text + ")";
            SqlConnection veza = konekcija.povezi();
            SqlCommand komanda = new SqlCommand(naredba, veza);
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();
            load_data();
            popuni_txt();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // BRISI
            if (br_reda == tabela.Rows.Count - 1)
            {
                br_reda--;
            }
            string naredba = "DELETE FROM osoba WHERE id=" +
                textBox1.Text;
            SqlConnection veza = konekcija.povezi();
            SqlCommand komanda = new SqlCommand(naredba, veza);
            try
            {
                veza.Open();
                komanda.ExecuteNonQuery();
                veza.Close();
            }
            catch (Exception greska)
            {
                MessageBox.Show(greska.GetType().ToString());
            }
            load_data();
            popuni_txt();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // MENJAJ
            // UPDATE osoba
            // SET adresa = 'Cara Dusana',
            // jmbg = '4444'
            // WHERE id = 4
            string naredba = "UPDATE osoba ";
            naredba = naredba + "SET ime='"+textBox2.Text + "',";
            naredba = naredba + "prezime='"+textBox3.Text + "',";
            naredba = naredba + "adresa='"+textBox4.Text + "',";
            naredba = naredba + "jmbg='"+textBox5.Text + "',";
            naredba = naredba + "email='"+textBox6.Text + "',";
            naredba = naredba + "pass='"+textBox7.Text + "'";   
            naredba = naredba + " WHERE id="+textBox1.Text;
            SqlConnection veza = konekcija.povezi();
            SqlCommand komanda = new SqlCommand(naredba, veza);
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();
            load_data();
            popuni_txt();
        }
    }
}
