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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection("Data Source=DESKTOP-6LPEK0P\\SQLEXPRESS;Initial catalog=dnevnik410b;Integrated security=true");
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM osoba", veza);
            DataTable tabela = new DataTable();
            da.Fill(tabela);
            textBox1.Text = tabela.Rows[0][0].ToString();
            textBox2.Text = tabela.Rows[0][1].ToString();
        }
    }
}
