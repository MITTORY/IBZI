using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace IBZI__5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputText = textBox1.Text;

            if (!string.IsNullOrWhiteSpace(inputText))
            {
                string md5Hash = CalculateMD5Hash(inputText);
                textBox2.Text = $"{md5Hash}";
            }
            else
            {
                MessageBox.Show("Введите текст для хеширования.");
            }
        }

        private string CalculateMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}