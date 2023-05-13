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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace passwordGen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void Exception(string str)
        {
            if (str == null || str == "")
            {
                throw new ArgumentException("Невозможно");
            }
        }
        public void CheckCheckBox2WithSym(bool a, int len_pas)
        {
            string pas;
            if (a == true)
            {
                pas = GeneratePassWithSym(len_pas);
                label4.Text = ReplaceMiddle(pas).Substring(0, len_pas);
            }
            else
            {
                label4.Text = GeneratePassWithSym(len_pas);
            }
        }

        public void CheckCheckBox2WithoutSym(bool a, int len_pas)
        {
            string pas;
            if (a == true)
            {
                pas = GeneratePassWithoutSym(len_pas);
                label4.Text = ReplaceMiddle(pas).Substring(0, len_pas);
            }
            else
            {
                label4.Text = GeneratePassWithoutSym(len_pas);
            }
        }
        public string GeneratePassWithoutSym(int len)
        {
            string pass = "";
            string[] arr = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "B", "C", "D", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "V", "W", "X", "Z", "b", "c", "d", "f", "g", "h", "j", "k", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "z", "A", "E", "U", "Y", "a", "e", "i", "o", "u", "y" };
            Random rnd = new Random();
            for (int i = 0; i < len; i += 1)
            {
                pass = pass + arr[rnd.Next(0, 57)];
            }
            return pass;
        }

        public string GeneratePassWithSym(int len)
        {
            string pass = "";
            string[] arr = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "B", "C", "D", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "V", "W", "X", "Z", "b", "c", "d", "f", "g", "h", "j", "k", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "z", "A", "E", "U", "Y", "a", "e", "i", "o", "u", "y", "{", "}", "[", "]", "(", ")", "'", "\"", "`", "~", ",", ";", ":", ".", "<", ">" };
            Random rnd = new Random();
            for (int i = 0; i < len; i += 1)
            {
                pass = pass + arr[rnd.Next(0, 72)];
            }
            return pass;
        }
        public static string ReplaceMiddle(string _text)
        {
            string[] badwords = {"Shit","Fuck", "Damn", "Whore", "Slut", "Douchebag","Bitch", "Freak", "Bastard", "Jerk", "Cunt", "Loser", "Sucker","Noob", "Fool", "Stupid", "Dumb", "Retard" };
            Random rnd = new Random();

            return _text.Insert(_text.Length / 2, badwords[rnd.Next(0, 22)]);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int len_pas = (int)numericUpDown1.Value;

            if (checkBox1.Checked == true)
            {
                CheckCheckBox2WithSym(checkBox2.Checked, len_pas);
            }
            else
            {
                CheckCheckBox2WithoutSym(checkBox2.Checked, len_pas);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "FilewithPass (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                streamWriter.WriteLine(textBox1.Text);
                streamWriter.Close();
                MessageBox.Show("Пароль успешно сохранен!");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
