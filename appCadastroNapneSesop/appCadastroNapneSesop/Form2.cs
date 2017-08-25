using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appCadastroNapneSesop
{
    public partial class Form2 : Form
    {
        public Form2()
        {

            InitializeComponent();
            button1.Visible = true;
            button4.Visible = false;
            button2.Enabled = false;
            checkBox3.Visible = false;
            checkBox4.Visible = false;
            checkBox5.Visible = false;
            checkBox6.Visible = false;
            checkBox7.Visible = false;
            checkBox8.Visible = false;
            checkBox9.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
        }
        public string a = "null";
        public string b = "null";
        public string c = "null";
        public string d = "null";
        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^0-9]"))
            {
                MessageBox.Show("Apenas números.");
                textBox2.Clear();

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                checkBox6.Visible = true;
                checkBox7.Visible = true;
                checkBox8.Visible = true;
                checkBox9.Visible = true;
            }
            else
            {
                checkBox6.Visible = false;
                checkBox7.Visible = false;
                checkBox8.Visible = false;
                checkBox9.Visible = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                a = "Sim";
            else
                a = "Não";
            if (checkBox2.Checked == true)
                b = "Sim";
            else
                b = "Não";
            if (radioButton1.Checked == true)
            {
                c = "Sim";
                d = "Não";
            }
            else if (radioButton2.Checked == true)
            {
                c = "Não";
                d = "Sim";
            }

            BD.executar("INSERT INTO alunos(matricula,nome,turma,data_nasc,ne_pa,ne_npa,napne_srm,napne_la) VALUES('" + textBox2.Text + "', '" + textBox1.Text + "', '" + comboBox3.Text + "', '" + maskedTextBox1.Text + "', '" + a + "','" + b + "', '" + c + "', '" + d + "')");
            MessageBox.Show("Usuário cadastrado.");
            textBox2.Clear();
            textBox1.Clear();
            comboBox2.Items.Clear();
            comboBox2.Items.Add("1º ano");
            comboBox2.Items.Add("2º ano");
            comboBox2.Items.Add("3º ano");
            comboBox2.Items.Add("4º ano");
            comboBox2.Items.Add("5º ano");
            comboBox3.Items.Clear();
            maskedTextBox1.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            }

        private void comboBox2_Leave(object sender, EventArgs e)
        {
            if (comboBox2.Text == "1º ano")
            {
                comboBox3.Items.Clear();
                for (int i = 101; i < 113; i++)
                    comboBox3.Items.Add(i);
                
            }
            else if (comboBox2.Text == "2º ano")
            {
                comboBox3.Items.Clear();
                for (int i = 201; i < 213; i++)
                    comboBox3.Items.Add(i);
            }
            else if (comboBox2.Text == "3º ano")
            {
                comboBox3.Items.Clear();
                for (int i = 301; i < 313; i++)
                    comboBox3.Items.Add(i);
            }
            else if (comboBox2.Text == "4º ano")
            {
                comboBox3.Items.Clear();
                for (int i = 401; i < 413; i++)
                    comboBox3.Items.Add(i);
            }
            else if (comboBox2.Text == "5º ano")
            {
                comboBox3.Items.Clear();
                for (int i = 501; i < 513; i++)
                    comboBox3.Items.Add(i);
            }
           
            }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
            BD.leitor.Close();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            BD.executar("SELECT * FROM alunos WHERE matricula = '"+textBox2.Text+"'");
            if (BD.leitor.Read())
            {
                textBox1.Text = BD.leitor.GetString(1);
                maskedTextBox1.Text = BD.leitor.GetString(3);
                comboBox3.Text = BD.leitor.GetString(2);
                if (BD.leitor.GetString(4) == "Sim")
                {
                    checkBox1.Checked = true;
                }
                else
                    checkBox1.Checked = false;
                if (BD.leitor.GetString(5) == "Sim")
                {
                    checkBox2.Checked = true;
                }
                else
                    checkBox2.Checked = false;
                if (BD.leitor.GetString(6) == "Sim")
                {
                    radioButton1.Checked = true;
                }
                else
                    radioButton2.Checked = true;

                comboBox3.Items.Add(BD.leitor.GetString(2));
                comboBox3.SelectedItem = BD.leitor.GetString(2);
                string ano = BD.leitor.GetString(2);

                switch(ano[0])
                {
                    case '1':
                        comboBox2.SelectedItem = "1º ano";
                        break;
                    case '2':
                        comboBox2.SelectedItem = "2º ano";
                        break;
                    case '3':
                        comboBox2.SelectedItem = "3º ano";
                        break;
                    case '4':
                        comboBox2.SelectedItem = "4º ano";
                        break;
                    case '5':
                        comboBox2.SelectedItem = "5º ano";
                        break;


                        
                }
                button1.Visible = false;
                button4.Visible = true;
                button2.Enabled = true;
                
            }
            else
            {
                textBox1.Clear();
                comboBox2.Items.Clear();
                comboBox2.Items.Add("1º ano");
                comboBox2.Items.Add("2º ano");
                comboBox2.Items.Add("3º ano");
                comboBox2.Items.Add("4º ano");
                comboBox2.Items.Add("5º ano");
                comboBox3.Items.Clear();
                maskedTextBox1.Text = "";
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                button1.Visible = true;
                button4.Visible = false;
                button2.Enabled = false;
            }
            
            BD.leitor.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BD.executar("DELETE FROM alunos WHERE matricula = '" + textBox2.Text + "'");
            textBox1.Clear();
            textBox2.Clear();
            comboBox2.Items.Clear();
            comboBox2.Items.Add("1º ano");
            comboBox2.Items.Add("2º ano");
            comboBox2.Items.Add("3º ano");
            comboBox2.Items.Add("4º ano");
            comboBox2.Items.Add("5º ano");
            comboBox3.Items.Clear();
            maskedTextBox1.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            button1.Visible = true;
            button4.Visible = false;
            MessageBox.Show("Usuário deletado.");
            button2.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                a = "Sim";
            else
                a = "Não";
            if (checkBox2.Checked == true)
                b = "Sim";
            else
                b = "Não";
            if (radioButton1.Checked == true)
            {
                c = "Sim";
                d = "Não";
            }
            else if (radioButton2.Checked == true)
            {
                c = "Não";
                d = "Sim";
            }
            BD.executar("UPDATE alunos SET nome = '"+ textBox1.Text +"', turma = '"+ comboBox3.Text +"', data_nasc = '"+ maskedTextBox1.Text +"', ne_pa = '"+ a +"', ne_npa = '"+ b +"', napne_srm = '"+ c +"', napne_la = '"+ d +"' WHERE matricula = '"+ textBox2.Text+"'");
            MessageBox.Show("Usuário atualizado com sucesso.");
            textBox1.Clear();
            textBox2.Clear();
            comboBox2.Items.Clear();
            comboBox2.Items.Add("1º ano");
            comboBox2.Items.Add("2º ano");
            comboBox2.Items.Add("3º ano");
            comboBox2.Items.Add("4º ano");
            comboBox2.Items.Add("5º ano");
            comboBox3.Items.Clear();
            maskedTextBox1.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            button1.Visible = true;
            button4.Visible = false;
            button2.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox2.Items.Clear();
            comboBox2.Items.Add("1º ano");
            comboBox2.Items.Add("2º ano");
            comboBox2.Items.Add("3º ano");
            comboBox2.Items.Add("4º ano");
            comboBox2.Items.Add("5º ano");
            comboBox3.Items.Clear();
            maskedTextBox1.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            button1.Visible = true;
            button4.Visible = false;
            button2.Enabled = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                checkBox3.Visible = true;
                checkBox4.Visible = true;
                checkBox5.Visible = true;         
            }
            else
            {
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                checkBox5.Visible = false;
                radioButton3.Visible = false;
                radioButton4.Visible = false;
            }
            
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox3.Checked == true)
            {
                radioButton3.Visible = true;
                radioButton4.Visible = true;
            }
            else
            {
                radioButton3.Visible = false;
                radioButton4.Visible = false;
            }
        }
    }
    }

