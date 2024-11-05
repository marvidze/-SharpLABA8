using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_LABA_8
{
    public partial class Form1 : Form
    {
        private static int key = 45678;
        int keyInt = 45678;
        private static int quad = key * key;
        private static int address = 1000;
        const int HASH_SIZE = 3;
        const int PROSTOE_CHISLO = 997;

        static int GetHashCodeMidleSquare(int key, int hashSize)
        {
            int hashCode = key * key;
            int hashCodeSize = (int)Math.Log10(hashCode) + 1;
            hashCode /= (int)Math.Pow(10, (hashCodeSize - hashSize) / 2);
            hashCode %= (int)Math.Pow(10, hashSize);
            return hashCode;
        }
        static int GetHashCodeMultiplicationMethod(int key, int adress)
        {
            const double A = 0.618033988749895;
            double result = key * A;
            double fractionalPart = result - Math.Floor(result); 
            int heshKey = (int)(fractionalPart * adress);
            return heshKey;
        }

        static int GetHashCodeFoldingMethod(int key, int address)
        {
            int heshKey = 0;

            while (key > 0)
            {
                heshKey += key % address;
                key /= address;
            }
            heshKey %= address;
            return heshKey;
        }

        public int GetHashCodeDivisionMethod(int key, int m)
        {
            return key % m;
        }

        private void ButtonExitClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonCalculateClick(object sender, EventArgs e)
        {

            
            textBoxMiddleOfSquare.Text = GetHashCodeMidleSquare(key, HASH_SIZE).ToString();
            textBoxDivisionMethod.Text = GetHashCodeDivisionMethod(keyInt, PROSTOE_CHISLO).ToString();
            textBoxMultiplication.Text = GetHashCodeMultiplicationMethod(keyInt, address).ToString();
            textBoxFolding.Text = GetHashCodeFoldingMethod(keyInt, address).ToString();
        }

        public Form1()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
