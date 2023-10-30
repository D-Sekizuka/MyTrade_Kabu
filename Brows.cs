using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MyTrade_Kabu
{
    public partial class Brows : Form
    {
        string useFileName = "";

        public Brows(string fileName)
        {
            useFileName = fileName;
            InitializeComponent();
        }

        private void Brows_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(useFileName);

            textBox1.Text = sr.ReadLine();
            textBox2.Text = sr.ReadLine();
            textBox3.Text = sr.ReadLine();
            textBox4.Text = sr.ReadLine();
            textBox5.Text = sr.ReadLine();
            textBox6.Text = sr.ReadLine();
            textBox7.Text = sr.ReadLine();
            textBox8.Text = sr.ReadLine();
            textBox9.Text = sr.ReadLine();
            textBox10.Text = sr.ReadLine();
            textBox11.Text = sr.ReadLine();
            textBox12.Text = sr.ReadLine();
            textBox13.Text = sr.ReadToEnd();
        }
    }
}
