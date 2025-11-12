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
            if (br_reda == tabela.Rows.Count - 1)
                button6.Enabled = false;
            else button6.Enabled = true;
            if (br_reda == 0)
                button2.Enabled = false;
            else button2.Enabled = true;

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
             *  naredba = insert into osoba
             *  values textbox1.text +
             *   ",'"+textbox1.text + "',"
             *   VALUES('Marko', 'Ilic',...
             *   INSERT INTO osoba
             * VALUES('Ime','Prezime','Adresa','1204007123456',
             * 'aaa@bbb.cc','123',1)
             */
            string naredba = "INSERT ONTO osoba VALUES('";
            naredba = naredba + textBox2.Text + "','";
            naredba = naredba + textBox3.Text + "','";
            naredba = naredba + textBox4.Text + "','";
            naredba = naredba + textBox5.Text + "','";
            naredba = naredba + textBox6.Text + "','";
            naredba = naredba + textBox7.Text + "',";
            naredba = naredba + textBox8.Text + ")";
        }
    }
}
