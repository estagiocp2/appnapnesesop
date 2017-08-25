using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace appCadastroNapneSesop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
             if (textBox1.Text != "")
                    {
                        BD.executar("SELECT * FROM login WHERE login = '" + textBox1.Text + "' and senha = '" + textBox2.Text + "'"); ;

                         if (textBox1.Text == "root" && textBox2.Text == "toor")
                    {
                        BD.leitor.Close();
                        textBox1.Clear();
                        textBox2.Clear();
                        Form3 f3 = new Form3();
                        f3.Show();
                        this.Hide();
                    }
                    else if (BD.leitor.Read())
                        {
                            
                            if (textBox1.Text == BD.leitor.GetString(0) && textBox2.Text == BD.leitor.GetString(1))
                            {

                               BD.leitor.Close();
                                textBox1.Clear();
                               textBox2.Clear();
                                Form2 f2 = new Form2();
                                f2.Show();
                                this.Hide();
                            }
                            
                    }
                        else
                            MessageBox.Show("Login e/ou senha incorreto!", "Acesso negado!");
                        textBox1.Clear();
                        textBox2.Clear();
                        BD.leitor.Close();

                    }

                
            }
            catch (MySqlException er)
            {
                MessageBox.Show(er.ToString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Digite um login.");
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                MessageBox.Show("Digite uma senha.");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar == false)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }


    
    }
