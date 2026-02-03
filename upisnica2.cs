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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ednevnik410b
{
    public partial class upisnica2 : Form
    {
        DataTable odeljenje, osoba, upisnica;
        public upisnica2()
        {
            InitializeComponent();
        }
        private void combo1populate()
        {
            SqlConnection veza = konekcija.povezi();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT id, str(razred)+'-'+indeks as naziv FROM odeljenje", veza);
            odeljenje = new DataTable();
            adapter.Fill(odeljenje);
            comboBox1.DataSource = odeljenje;
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "naziv";
        }
        private void combo2populate()
        {
            SqlConnection veza = konekcija.povezi();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT id, ime+' '+prezime as naziv FROM osoba", veza);
            osoba = new DataTable();
            adapter.Fill(osoba);
            comboBox2.DataSource = osoba;
            comboBox2.ValueMember = "id";
            comboBox2.DisplayMember = "naziv";
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int broj_sloga = dataGridView1.CurrentRow.Index;
                comboBox1.SelectedValue = dataGridView1.Rows[broj_sloga].Cells["odeljenje_id"].Value.ToString();
                comboBox2.SelectedValue = dataGridView1.Rows[broj_sloga].Cells["osoba_id"].Value.ToString();
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string naredba = "INSERT INTO upisnica (odeljenje_id, osoba_id) VALUES(";
            naredba += comboBox1.SelectedValue.ToString() + ", ";
            naredba += comboBox2.SelectedValue.ToString() + ")";
            SqlConnection veza = konekcija.povezi();
            SqlCommand komanda = new SqlCommand(naredba, veza);
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();
            gridpopulate();
        }

        private void gridpopulate()
        {
            SqlConnection veza = konekcija.povezi();
            string wrk = "SELECT ime+' '+prezime as ucenik, str(razred)+'-'+indeks as naziv, osoba_id, odeljenje_id FROM upisnica JOIN osoba ON osoba_id = osoba.id JOIN odeljenje ON odeljenje_id=odeljenje.id";
            SqlDataAdapter adapter = new SqlDataAdapter(wrk, veza);
            upisnica = new DataTable();
            adapter.Fill(upisnica);
            dataGridView1.DataSource = upisnica;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Columns["osoba_id"].Visible = false;
            dataGridView1.Columns["odeljenje_id"].Visible = false;
        }
        private void upisnica2_Load(object sender, EventArgs e)
        {
            combo1populate();
            combo2populate();
            gridpopulate();
        }
    }
}
