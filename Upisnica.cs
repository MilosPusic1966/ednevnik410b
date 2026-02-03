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
    public partial class Upisnica : Form
    {
        int br_reda;
        DataTable osoba, upisnica, odeljenje;
        public Upisnica()
        {
            InitializeComponent();
        }

        public void popuni_combo()
        {
            
            comboBox2.SelectedValue = upisnica.Rows[br_reda]["osoba_id"].ToString();
            comboBox3.SelectedValue = upisnica.Rows[br_reda]["odeljenje_id"].ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            br_reda--;
            popuni_combo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string komanda = "INSERT INTO upisnica VALUES(";
            komanda = komanda + comboBox2.SelectedValue.ToString();
            komanda = komanda + "," + comboBox3.SelectedValue.ToString();
            komanda = komanda + ")";
            
            SqlConnection veza = konekcija.povezi();
            SqlCommand naredba = new SqlCommand(komanda, veza);
            try
            {
                veza.Open();
                naredba.ExecuteNonQuery();
                veza.Close();
            }
            catch (Exception greska)
            {
                MessageBox.Show(greska.GetType().ToString());
            }
        }

        private void Upisnica_Load(object sender, EventArgs e)
        {
            br_reda = 0;
            SqlConnection veza = konekcija.povezi();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM upisnica", veza);
            upisnica = new DataTable();
            da.Fill(upisnica);
            da = new SqlDataAdapter("SELECT id, ime+' '+prezime as naziv FROM osoba", veza);
            osoba = new DataTable();
            da.Fill(osoba);
            da = new SqlDataAdapter("SELECT id, cast(razred as varchar)+' '+indeks as naziv FROM odeljenje", veza);
            odeljenje = new DataTable();
            da.Fill(odeljenje);
            comboBox2.DataSource = osoba;
            comboBox2.ValueMember = "id";
            comboBox2.DisplayMember = "naziv";
            
            comboBox3.DataSource = odeljenje;
            comboBox3.ValueMember = "id";
            comboBox3.DisplayMember = "naziv";
            popuni_combo();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            br_reda++;
            popuni_combo();
        }
    }
}
