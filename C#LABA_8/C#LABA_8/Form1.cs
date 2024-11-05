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
        private static long[] ints;
        private static long key = 234583;
        int keyInt = 45678;
        private static long quad = key * key;
        private static int adress = 100;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        static long GetMiddleDigits(long num, long count)
        {
            // Находим количество цифр в числе
            long length = GetLength(num);
            // Находим середину
            long middleIndex = length / 2;

            // Если длина четная, начинаем с middleIndex - 1
            // Если длина нечетная, начинаем с middleIndex - count / 2
            long startIndex = (length % 2 == 0) ? (middleIndex - count / 2 - 1) : (middleIndex - count / 2);

            return Convert.ToInt64(GetMedian(startIndex, count));

        }

        static long GetHashMiddleSquare()
        {
            long middleCount = GetLength(adress); //(adress % 10 == 0) ? GetLength(adress) : 
            ints = new long[GetLength(quad)];
            SetValueArray(quad);
            // Получаем середину числа
            var result = GetMiddleDigits(quad, middleCount);
            // коэффициент (умножаем на результат в случае не кратности его на 10)
            double koef = (double)adress / 1000;
            long hashCode = (adress % 10 != 0) ? (long)(result * koef) : GetMiddleDigits(quad, middleCount);
            long m = GetLength(quad);
            ints = new long[m];
            return hashCode;
        }

        static long GetLength(long num)
        {
            long length = 0;
            while (num > 0)
            {
                num /= 10;
                length++;
            }
            return length;
        }

        static string GetMedian(long startIndex, long count)
        {
            string resultString = string.Empty;

            for (int i = 0; i < count; i++)
            {
                resultString += ints[startIndex + i];
            }

            return resultString;
        }

        static void SetValueArray(long num)
        {

            for (long i = GetLength(num) - 1; i >= 0; i--)
            {
                ints[i] = num % 10;
                num /= 10;
            }
        }

        static int MultiplicationMethod(int key, int adress)
        {
            const double A = 0.618033988749895;
            double result = key * A;
            double fractionalPart = result - Math.Floor(result); //получение дробной части от умножения
            int heshKey = (int)(fractionalPart * adress);
            return heshKey;
        }

        static int GetHashFoldingMethod(int key, int address)
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

        public int GetHashCodeDivisionMethod(int n)
        {
            return n / 1000;
        }

        private void ButtonExitClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonCalculateClick(object sender, EventArgs e)
        {

            
            textBoxMiddleOfSquare.Text = GetHashMiddleSquare().ToString();
            textBoxDivisionMethod.Text = GetHashCodeDivisionMethod(keyInt).ToString();
            textBoxMultiplication.Text = MultiplicationMethod(keyInt, adress).ToString();
            textBoxFolding.Text = GetHashFoldingMethod(keyInt, adress).ToString();
        }
    }
}
