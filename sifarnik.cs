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
    public partial class sifarnik : Form
    {
        SqlDataAdapter Adapter;
        DataTable podaci;
        public sifarnik()
        {
            InitializeComponent();
        }

        private void sifarnik_Load(object sender, EventArgs e)
        {
            Adapter = new SqlDataAdapter("SELECT * FROM predmet", konekcija.povezi());
            podaci = new DataTable();
            Adapter.Fill(podaci);
            dataGridView1.DataSource = podaci;
        }
    }
}
