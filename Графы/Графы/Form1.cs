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
            n = Convert.ToInt32(numericUpDown1.Value);
            m = Convert.ToInt32(numericUpDown2.Value);
            a = Convert.ToInt32(numericUpDown3.Value);
            groupBox1.Enabled = false;
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

        private void letsgo_Click(object sender, EventArgs e)
        {
            
            Graphics graphics = Graphics.FromHwnd(pictureBox1.Handle);
            for (int i = 0; i < n; i++)
            {
                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawEllipse(pen, new RectangleF(0, i * 100, 50, 50));

            }
            for (int i = 0; i < m; i++)
            {
                Pen pen = new Pen(Color.Blue, 2);
                graphics.DrawEllipse(pen, new RectangleF(i + 100, i * 100, 50, 50));

            }
            for (int i = 0; i < a; i++)
            {
                Pen pen = new Pen(Color.DarkOrange, 2);
                graphics.DrawEllipse(pen, new RectangleF(i + 200, i * 100, 50, 50));

            }
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

            int[] ms = new int[dataGridView2.Columns.Count];
            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                ms[i]= Convert.ToInt32(dataGridView2[i, 0].Value);
            }

            int[,] mass = new int[dataGridView1.Columns.Count + 1, dataGridView1.Rows.Count + 1];
            for ( int i=0; i<dataGridView1.ColumnCount; i++)
            {
                for ( int j=0; j<dataGridView1.RowCount; j++)
                {
                    if (i < n)
                    {
                        mass[dataGridView1.ColumnCount-1, i] = ms[i];

                    }
                    else
                    {
                        mass[i, dataGridView1.RowCount-1] = ms[i];
                    }
                }
            }
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
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView3.Columns.Add(dataGridView1.Columns[i].Name, dataGridView1.Columns[i].HeaderText); 
                dataGridView3.Rows.Add();
            }
            
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView3.Columns.Add(dataGridView1.Columns[i].Name, dataGridView1.Columns[i].HeaderText); ;
                dataGridView3.Rows.Add();
            }
            
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                  dataGridView3[j, i].Value= mass[j, i];
                }
            }
            dataGridView1.Hide();
            dataGridView2.Hide();
            dataGridView3.Show();


        }
    }
}
