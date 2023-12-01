using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IBZI__6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string hardwareID = GetHardwareID();
            string expectedSerialNumber = "bccd9543209ebfbc7fe9dce45455abd6";

            if (!string.IsNullOrWhiteSpace(hardwareID) && hardwareID.Equals(expectedSerialNumber, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Спасибо, что пользуетесь лицензионной копией!");
            }
            else
            {
                MessageBox.Show("Вы используете нелицензированную копию программы!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

        private string GetHardwareID()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
                ManagementObjectCollection managementObjects = searcher.Get();

                string hardwareID = "";
                foreach (ManagementObject managementObject in managementObjects)
                {
                    hardwareID += managementObject["SerialNumber"].ToString();
                }

                return hardwareID.ToLower();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении информации о компьютере: {ex.Message}");
                return null;
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
