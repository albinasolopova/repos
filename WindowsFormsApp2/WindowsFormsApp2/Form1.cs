using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Calc calc = new Calc();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 0;
        }

        private void one_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 1;
        }

        private void two_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 2;
        }

        private void three_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 3;
        }

        private void four_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 4;
        }

        private void five_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 5;
        }

        private void six_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 6;
        }

        private void seven_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 7;
        }

        private void eight_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 8;
        }

        private void plus_Click(object sender, EventArgs e)
        {
            calc.Save(Convert.ToDouble(textBox1.Text));
            textBox1.Clear();
            plus.Enabled = false;

        }

        private void nine_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 9;
        }

        private void minus_Click(object sender, EventArgs e)
        {
            calc.Save(Convert.ToDouble(textBox1.Text));
            textBox1.Clear();
            minus.Enabled = false;
        }

        private void division_Click(object sender, EventArgs e)
        {
            calc.Save(Convert.ToDouble(textBox1.Text));
            textBox1.Clear();
            division.Enabled = false;
        }

        private void ymnogenie_Click(object sender, EventArgs e)
        {
            calc.Save(Convert.ToDouble(textBox1.Text));
            textBox1.Clear();
            ymnogenie.Enabled = false;
        }

        private void equally_Click(object sender, EventArgs e)
        {
            double num2 = Convert.ToDouble(textBox1.Text);
            if (!plus.Enabled)
                textBox1.Text = (calc.Sum(num2)).ToString();
            else if (!minus.Enabled)
                textBox1.Text = (calc.Substract(num2)).ToString();
            else if (!ymnogenie.Enabled)
                textBox1.Text = (calc.Miltiply(num2)).ToString();
            else if (!division.Enabled)
                textBox1.Text = (num2 != 0) ? (calc.Division(num2)).ToString(): "Ошибка";
        }

        private void point_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + ",";
        }

        private void sqrt_Click(object sender, EventArgs e)
        {
            calc.Save(Convert.ToDouble(textBox1.Text));
            textBox1.Clear();
            textBox1.Text = (calc.Sqrt()).ToString();
            
        }
    }
}
