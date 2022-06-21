using parcial.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parcial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (veterinariaEntities db = new veterinariaEntities()) 
            {
                mascotas masco = new mascotas();
                textBox1.Text = masco.nombre;
                textBox2.Text = masco.raza;
                textBox3.Text = masco.edad;
                textBox4.Text = masco.dueño;

                db.mascotas.Add(masco);
                db.SaveChanges();
                

            }
        }
    }
}
