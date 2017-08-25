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
    public partial class Form3 : Form
    {
        public Form3()
        {

            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                BD.executar("SELECT * FROM login WHERE login = '" + textBox1.Text + "'");
                if (BD.leitor.Read())
                {
                    textBox2.Text = BD.leitor.GetString(1);
                    MessageBox.Show("Usuário já existente.");
                    button3.Visible = true;
                    button2.Enabled = true;
                    button1.Visible = false;
                    textBox1.Enabled = false;
                    button4.Visible = true;
                }
                BD.leitor.Close();
            }
            catch (MySqlException er)
            {
                MessageBox.Show(er.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BD.executar("DELETE FROM login WHERE login = '" + textBox1.Text + "' and senha= '" + textBox2.Text + "'");
            MessageBox.Show("Usuário deletado.");
            textBox1.Clear();
            textBox2.Clear();
            button3.Visible = false;
            textBox1.Enabled = true;
            button1.Visible = true;
            button2.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BD.executar("INSERT INTO login VALUES('" + textBox1.Text + "', '" + textBox2.Text + "')");
            MessageBox.Show("Usuário inserido.");
            textBox1.Clear();
            textBox2.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            BD.executar("UPDATE login SET senha='" + textBox2.Text + "' WHERE login = '" + textBox1.Text + "'");
            MessageBox.Show("Usuário atualizado.");
            textBox1.Clear();
            textBox2.Clear();
            button3.Visible = false;
            textBox1.Enabled = true;
            button1.Visible = true;
            button2.Enabled = false;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            button3.Visible = false;
            textBox1.Enabled = true;
            button1.Visible = true;
            button2.Enabled = false;
            button4.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("Apenas números.");
                textBox1.Clear();
                
            }
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

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^0-9]"))
            {
                MessageBox.Show("Apenas números.");
                textBox2.Clear();

            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
    
