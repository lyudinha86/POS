using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace POS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            pictureBox1.MouseClick += mouseClick;
            pictureBox2.MouseClick += mouseClick;
            pictureBox3.MouseClick += mouseClick;
            pictureBox4.MouseClick += mouseClick;
            pictureBox5.MouseClick += mouseClick;
            pictureBox6.MouseClick += mouseClick;
            pictureBox7.MouseClick += mouseClick;
            pictureBox8.MouseClick += mouseClick;
        }
        int preco;
        string item;
        int quantidade;
        int total;
        private void mouseClick(object sender, MouseEventArgs e)
        {
            

            var clickpic = (PictureBox)sender;
            if(clickpic==pictureBox1)
            {
                item = "Bolacha Aveia";
                preco=1;
                quantidade = int.Parse(Interaction.InputBox("qual quantidade?", "Quantidade", ""));

                MessageBox.Show(quantidade.ToString());
            }
            else if (clickpic == pictureBox2)
            {
                item = "Chocolade Milka";
                preco = 3;
                quantidade = int.Parse(Interaction.InputBox("qual quantidade?", "Quantidade", ""));

                MessageBox.Show(quantidade.ToString());
            }

            else if (clickpic == pictureBox3)
            {
                item = "Bolacha Milka";
                preco = 3;
                quantidade = int.Parse(Interaction.InputBox("qual quantidade?", "Quantidade", ""));

                MessageBox.Show(quantidade.ToString());
            }
            else if (clickpic == pictureBox4)
            {
                item = "Oreo";
                preco = 1;
                quantidade = int.Parse(Interaction.InputBox("qual quantidade?", "Quantidade", ""));

                MessageBox.Show(quantidade.ToString());
            }
            else if (clickpic == pictureBox5)
            {
                item = "Agua";
                preco = 1;
                quantidade = int.Parse(Interaction.InputBox("qual quantidade?", "Quantidade", ""));

                MessageBox.Show(quantidade.ToString());
            }
            else if (clickpic == pictureBox6)
            {
                item = "Coca-Cola";
                preco = 2;
                quantidade = int.Parse(Interaction.InputBox("qual quantidade?", "Quantidade", ""));

                MessageBox.Show(quantidade.ToString());
            }
            else if (clickpic == pictureBox7)
            {
                item = "Sumo";
                preco = 5;
                quantidade = int.Parse(Interaction.InputBox("qual quantidade?", "Quantidade", ""));

                MessageBox.Show(quantidade.ToString());
            }
            else if (clickpic == pictureBox8)
            {
                item = "Fanta";
                preco = 1;
                quantidade = int.Parse(Interaction.InputBox("qual quantidade?", "Quantidade", ""));

                MessageBox.Show(quantidade.ToString());
            }
            total = preco * quantidade;
            this.dataGridView1.Rows.Add(item, preco, quantidade, total.ToString());
            int sum = 0;
            for (int row = 0; row < dataGridView1.Rows.Count; row++)
            {
                sum = sum + Convert.ToInt32(dataGridView1.Rows[row].Cells[3].Value);

            }
            txtsum.Text = sum.ToString();
           
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            if (fb.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string path = "C:\\Users\\oeira\\Downloads\\Teste.csv";
                    using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Unicode))
                    {
                     String cabecalho = "";
                     for (int k = 0; k < dataGridView1.Rows.Count; k++)
                        {
                         for (int i = 0; i < dataGridView1.Columns.Count; i++)
                            {
                                String valor = dataGridView1.Rows[k].Cells[i].Value.ToString();

                                valor = valor.Replace("\n", "");
                                valor = valor.Replace("\r", "");

                                if (dataGridView1.Columns[i].Visible)
                                {
                                    if (cabecalho == "")
                                    {
                                        cabecalho = valor;
                                    }
                                    else
                                    {
                                        cabecalho += "\t" + valor;
                                    }
                                }

                            }
                            sw.WriteLine(cabecalho);
                            cabecalho = "";

                        }
                    } 

                    Process.Start(new ProcessStartInfo(@path) { UseShellExecute = true });

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Nenhuma pasta selecionada!");
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }
    }
}

