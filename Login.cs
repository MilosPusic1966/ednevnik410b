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

namespace ednevnik410b
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("email i password ne mogu biti prazni");
            }
            else
            {
                SqlConnection veza = konekcija.povezi();
                SqlCommand naredba = new SqlCommand("SELECT * FROM osoba WHERE email=@username", veza);
                naredba.Parameters.AddWithValue("@username", textBox1.Text);
                SqlDataAdapter da = new SqlDataAdapter(naredba);
                DataTable tabela = new DataTable();
                da.Fill(tabela);
                int count = tabela.Rows.Count;
                if (count == 1)
                {
                    if (String.Compare(tabela.Rows[0]["pass"].ToString(), textBox2.Text) == 0)
                    {
                        MessageBox.Show("Login Successful!");
                        int prava = (int) tabela.Rows[0]["uloga"];
                        // Logovanje uspelo
                        this.Hide();
                        Glavna nova = new Glavna();
                        nova.Show();
                    }
                    else
                    {
                        MessageBox.Show("Pogresna lozinka");
                    }
                }
                else
                {
                    MessageBox.Show("Taj email ne postoji");
                }
            }
        }
    }
}
