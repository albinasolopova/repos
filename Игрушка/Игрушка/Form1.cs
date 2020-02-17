using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Игрушка
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            int cash = Convert.ToInt32(textBox2.Text);
            Form form = new Form2(name, cash);
            form.Show();
            this.Hide();
        }
    }
}
