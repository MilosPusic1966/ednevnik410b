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

        public void popuni_txt()
        {
            textBox1.Text = tabela.Rows[br_reda][0].ToString();
            textBox2.Text = tabela.Rows[br_reda][1].ToString();
            textBox3.Text = tabela.Rows[br_reda][2].ToString();
            textBox4.Text = tabela.Rows[br_reda][3].ToString();
            textBox5.Text = tabela.Rows[br_reda][4].ToString();
            textBox6.Text = tabela.Rows[br_reda][5].ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection("Data Source=DESKTOP-6LPEK0P\\SQLEXPRESS;Initial catalog=dnevnik410b;Integrated security=true");
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM osoba", veza);
            tabela = new DataTable();
            da.Fill(tabela);
            br_reda = 0;
            popuni_txt();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            br_reda++;
            popuni_txt();
        }
    }
}
