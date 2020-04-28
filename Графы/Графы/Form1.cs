using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Графы
{
    public partial class Form1 : Form
    {
        int n;
        int m;
        int a;

        public Form1()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            groupBox1.Enabled = false;
            DataGriView1();
        }
        public void DataGriView1()
        {
            n = Convert.ToInt32(numericUpDown1.Value);
            m = Convert.ToInt32(numericUpDown2.Value);
            a = Convert.ToInt32(numericUpDown3.Value);
            for (int i = 0; i < n; i++)
            {
                dataGridView1.Columns.Add("Suppliers" + (i + 1), "Поставщик" + (i + 1));
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[i].HeaderCell.Value = "Поставщик" + (i + 1);
            }
            for (int i = 0; i < m; i++)
            {
                dataGridView1.Columns.Add("Consumers" + (i + 1), "Потребитель" + (i + 1));
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[n + i].HeaderCell.Value = "Потребитель" + (i + 1);
            }
            for (int i = 0; i < a; i++)
            {
                dataGridView1.Columns.Add("Storage" + (i + 1), "Склад" + (i + 1));
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[n + m + i].HeaderCell.Value = "Склад" + (i + 1);
            }
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView2.Columns.Add(dataGridView1.Columns[i].Name, dataGridView1.Columns[i].HeaderText);
                dataGridView2.Rows.Add();
                dataGridView2.AllowUserToAddRows = false;
            }


            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (i != j) dataGridView1[j, i].Value = 0;
                    else
                    {
                        dataGridView1[j, i].Value = "-";
                        dataGridView1[j, i].ReadOnly = true;
                    }
                }
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            groupBox1.Enabled = true;

        }
        int widthStep;
        int r;
        int heightStep;
        public void Painting()
        {
            n = Convert.ToInt32(numericUpDown1.Value);
            m = Convert.ToInt32(numericUpDown2.Value);
            a = Convert.ToInt32(numericUpDown3.Value);

            widthStep = pictureBox1.Width / 5;
            heightStep = pictureBox1.Height / (2 * n);
            r = Math.Min(widthStep, heightStep);

            Graphics graphics = Graphics.FromHwnd(pictureBox1.Handle);
            Pen pen = new Pen(Color.Black, 2);
            for (int i = 0; i < n; i++)
            {
                graphics.DrawEllipse(pen, new RectangleF(widthStep / 2, i == 0 ? heightStep / 2 : heightStep / 2 + i * 2 * heightStep, r, r));

            }
            heightStep = pictureBox1.Height / (2 * m);
            r = Math.Min(widthStep, heightStep);
            pen = new Pen(Color.Blue, 2);
            for (int i = 0; i < m; i++)
            {

                graphics.DrawEllipse(pen, new RectangleF(2 * widthStep, i == 0 ? heightStep / 2 : heightStep / 2 + i * 2 * heightStep, r, r));

            }
            heightStep = pictureBox1.Height / (2 * a);
            r = Math.Min(widthStep, heightStep);
            pen = new Pen(Color.DarkOrange, 2);
            for (int i = 0; i < a; i++)
            {
                graphics.DrawEllipse(pen, new RectangleF(Convert.ToInt32(3.5 * widthStep), i == 0 ? heightStep / 2 : heightStep / 2 + i * 2 * heightStep, r, r));

            }

        }
        public int[,] Mas()
        {
            int[,] mas = new int[dataGridView1.Rows.Count, dataGridView1.Columns.Count];
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    string value = dataGridView1[j, i].Value.ToString();
                    if (value != "-") mas[j, i] = Convert.ToInt32(dataGridView1[j, i].Value);
                    else mas[j, i] = 0;
                }
            }
            return mas;
        }
        public int[] Ms()
        {
            int[] ms = new int[dataGridView2.Columns.Count];
            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                ms[i] = Convert.ToInt32(dataGridView2[i, 0].Value);
            }
            return ms;
        }
        public int[,] Mass(int[] ms)
        {
            int[,] mass = new int[dataGridView1.Columns.Count + 1, dataGridView1.Rows.Count + 1];
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    if (i < n)
                    {
                        mass[dataGridView1.ColumnCount - 1, i] = ms[i];

                    }
                    else
                    {
                        mass[i, dataGridView1.RowCount - 1] = ms[i];
                    }
                }
            }
            return mass;
        }
        private void letsgo_Click(object sender, EventArgs e)
        {
            Painting();
            int[,] mas = Mas();
            int[] ms = Ms();
            int[,] mass = Mass(ms);
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (mas[i, j] == 1)
                        if (i < n)
                            if (mass[i, dataGridView1.ColumnCount - 1] > 0 && mass[dataGridView1.RowCount - 1, j] > 0)
                            {
                                int t = Math.Min(mass[i, dataGridView1.ColumnCount - 1], mass[dataGridView1.RowCount - 1, j]);
                                mass[i, j] = t;
                                mass[i, dataGridView1.ColumnCount - 1] -= t;
                                mass[dataGridView1.RowCount - 1, j] -= t;
                            }
                }
            }


            dataGridView3.AllowUserToAddRows = false;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView3.Columns.Add(dataGridView1.Columns[i].Name, dataGridView1.Columns[i].HeaderText);
                dataGridView3.Rows.Add();
            }
            dataGridView3.Columns.Add("Ogr", "Огр");
            dataGridView3.Rows.Add();
            dataGridView3.Rows[dataGridView3.Rows.Count - 1].HeaderCell.Value = "Огр";

            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView3.Columns.Count; j++)
                {
                    dataGridView3[j, i].Value = mass[j, i];
                }
            }
            for (int j = 0; j < dataGridView3.ColumnCount - 1; j++)
            {
                if (j < n) dataGridView3[dataGridView3.ColumnCount - 1, j].Value = ms[j];
                else
                    dataGridView3[j, dataGridView3.RowCount - 1].Value = ms[j];

            }
            // рисование линий 
            int linewidthStep;
            int lineheightStep;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (i < n)
                    {
                        linewidthStep = widthStep;
                        lineheightStep = Convert.ToInt32(Height / (2 * n) + (1 * 1.5 * i));
                    }
                    else if (i < (n + m))
                    {
                        linewidthStep = Convert.ToInt32(2.5 * widthStep);
                        lineheightStep = Convert.ToInt32(Height / (2 * m) + (1 * 1.5 * i));
                    }
                    else
                    {
                        linewidthStep = 4 * widthStep;
                        lineheightStep = Convert.ToInt32(Height / (2 * a) + (1 * 1.5 * i));
                    }
                }
            }


            dataGridView1.Hide();
            dataGridView2.Hide();
            dataGridView3.Show();
        }
        public List<int> GetAvalableSuppliers(int[,] mas, int[] ms, int[,] mss, int j)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                if (mas[i, j] != 0 && mss[i, j] < ms[i] && mss[i, j] < ms[j])
                {
                    result.Add(i);
                }
            }
            return result;
        }

        public bool CheckOptimixeIsReal()
        {
            int row = 0;
            int col = 0;
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {

                    row += Convert.ToInt32(dataGridView3[i, dataGridView1.Columns.Count].Value);

                    col += Convert.ToInt32(dataGridView3[dataGridView3.Rows.Count, i].Value);
                }
            }
            return (row != 0 && col != 0);
        }
    }
}
