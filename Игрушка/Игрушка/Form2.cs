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
    public partial class Form2 : Form
    {
        string path = @"C:\Users\Lenovo\Desktop\2 курс\pr\";
        Bitmap[] pictures;
        int babl;
        public Form2(string name, int cash)
        {
            InitializeComponent();
            label2.Text = name;
            label6.Text = Convert.ToString(cash);
            this.pictures = new Bitmap[10];
            for (int i = 0; i < 10; i++)
            {
                this.pictures[i] = new Bitmap(path + (i + 1).ToString() + ".jpg");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Random random = new Random();
            int a = random.Next(10);
            int b = random.Next(10);
            int c = random.Next(10);
            babl = Convert.ToInt32(textBox1.Text);
            pictureBox1.Image = this.pictures[a];
            pictureBox2.Image = this.pictures[b];
            pictureBox3.Image = this.pictures[c];
            if (a == b && b == c && a == c)
            {
                
                int d;
                label4.Text = "Победа";
                d = Convert.ToInt32(label6.Text) +(2* babl);
                label6.Text = Convert.ToString(d);
               
            }
            else
            {
                int s;
                label4.Text = "Вы проиграли";
                s = Convert.ToInt32(label6.Text) - babl;
                label6.Text = Convert.ToString(s);
            }
        }

       
    }
}
