using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IBZI__1
{
    public partial class Form1 : Form
    {
        private Dictionary<char, char> cipher = new Dictionary<char, char>();
        private Dictionary<char, char> decipher = new Dictionary<char, char>();

        public Form1()
        {
            InitializeComponent();
            InitializeCipher();
        }

        private void InitializeCipher()
        {
            string source = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя0123456789";
            string encrypted = "ZYXWVUTSRQPONMLKJIHGFEDCBA!?/']№;zyxwvutsrqponmlkjihgfedcba@#$%^&*8647503912";

            int minLength = Math.Min(source.Length, encrypted.Length);

            for (int i = 0; i < minLength; i++)
            {
                cipher[source[i]] = encrypted[i];
                decipher[encrypted[i]] = source[i];
            }
        }

        private string Encrypt(string text)
        {
            char[] encryptedText = new char[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                if (cipher.ContainsKey(text[i]))
                {
                    encryptedText[i] = cipher[text[i]];
                }
                else
                {
                    encryptedText[i] = text[i];
                }
            }

            return new string(encryptedText);
        }

        private string Decrypt(string encryptedText)
        {
            char[] decryptedText = new char[encryptedText.Length];

            for (int i = 0; i < encryptedText.Length; i++)
            {
                if (decipher.ContainsKey(encryptedText[i]))
                {
                    decryptedText[i] = decipher[encryptedText[i]];
                }
                else
                {
                    decryptedText[i] = encryptedText[i];
                }
            }

            return new string(decryptedText);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string source = textBox1.Text;
            string encrypted = Encrypt(source);
            textBox3.Clear();
            textBox3.Text = encrypted;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string encryptedText = textBox2.Text;
            string sourceText = Decrypt(encryptedText);
            textBox3.Clear();
            textBox3.Text = sourceText;
        }
    }
}
