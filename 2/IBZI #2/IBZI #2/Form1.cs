using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IBZI__2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textBox4.MaxLength = 100;
            textBox5.MaxLength = 100; 
        }

        private string Encrypt(string text, string key)
        {
            string encryptedText = "";
            for (int i = 0; i < text.Length; i++)
            {
                char charToEncrypt = text[i];
                char encryptionChar = key[i % key.Length];

                // Применяем операцию XOR для шифрования
                char encryptedChar = (char)(charToEncrypt ^ encryptionChar);

                encryptedText += encryptedChar;
            }
            return encryptedText;
        }

        private string Decrypt(string encryptedText, string key)
        {
            string decryptedText = "";
            for (int i = 0; i < encryptedText.Length; i++)
            {
                char charToDecrypt = encryptedText[i];
                char decryptionChar = key[i % key.Length];

                // Применяем операцию XOR для расшифровки
                char decryptedChar = (char)(charToDecrypt ^ decryptionChar);

                decryptedText += decryptedChar;
            }
            return decryptedText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputText = textBox1.Text;
            string encryptionKey = textBox4.Text;

            string encryptedText = Encrypt(inputText, encryptionKey);

            textBox2.Text = encryptedText;
            textBox3.Text = encryptedText;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string encryptedText = textBox2.Text;
            string decryptionKey = textBox5.Text;

            string decryptedText = Decrypt(encryptedText, decryptionKey);

            textBox3.Text = decryptedText;
        }
    }
}

