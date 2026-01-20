using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ednevnik410b
{
    public partial class Glavna : Form
    {
        public Glavna()
        {
            InitializeComponent();
        }

        private void osobeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 osoba = new Form1();
            osoba.ShowDialog();
        }

        private void upisniceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Upisnica prikaz = new Upisnica();
            prikaz.ShowDialog();
        }

        private void Glavna_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void predmetiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sifarnik nova = new sifarnik("predmet");
            nova.ShowDialog();

        }

        private void skolskeGodineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sifarnik nova = new sifarnik("skolska_godina");
            nova.ShowDialog();
        }

        private void smeroviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sifarnik nova = new sifarnik("smer");
            nova.ShowDialog();
        }
    }
}
