using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_15._1
{
    public partial class Form1 : Form
    {
       
            private CancellationTokenSource cancellationTokenSource;
            private CancellationToken cancellationToken;
            private Thread[] threads;
            public Form1()
            {
                InitializeComponent();
                comboBox1.Items.AddRange(new object[] { "Highest", "AboveNormal", "Normal", "BelowNormal", "Lowest" });
                comboBox2.Items.AddRange(new object[] { "Highest", "AboveNormal", "Normal", "BelowNormal", "Lowest" });
                comboBox3.Items.AddRange(new object[] { "Highest", "AboveNormal", "Normal", "BelowNormal", "Lowest" });

                comboBox1.SelectedIndex = 2;
                comboBox2.SelectedIndex = 2;
                comboBox3.SelectedIndex = 2;
            }

            private void StartButton_Click(object sender, EventArgs e)
            {
                cancellationTokenSource = new CancellationTokenSource();
                cancellationToken = cancellationTokenSource.Token;
                threads = new Thread[3];

                for (int i = 0; i < 3; i++)
                {
                    int threadIndex = i;
                    ThreadPriority priority = GetThreadPriority(threadIndex);
                    threads[i] = new Thread(() => GenerateNumber(threadIndex, priority));
                    threads[i].Start();
                }
            }

        private ThreadPriority GetThreadPriority(int threadIndex)
        {
            switch (threadIndex)
            {
                case 0:
                    return GetSelectedPriority(comboBox1);
                case 1:
                    return GetSelectedPriority(comboBox2);
                case 2:
                    return GetSelectedPriority(comboBox3);
                default:
                    return ThreadPriority.Normal;
            }
        }

        private ThreadPriority GetSelectedPriority(ComboBox comboBox)
        {
            switch (comboBox.SelectedItem.ToString())
            {
                case "Highest":
                    return ThreadPriority.Highest;
                case "AboveNormal":
                    return ThreadPriority.AboveNormal;
                case "Normal":
                    return ThreadPriority.Normal;
                case "BelowNormal":
                    return ThreadPriority.BelowNormal;
                case "Lowest":
                    return ThreadPriority.Lowest;
                default:
                    return ThreadPriority.Normal;
            }
        }

        private void GenerateNumber(int threadIndex, ThreadPriority priority)
        {
            Random rand = new Random();
            Thread.CurrentThread.Priority = priority;
            while (!cancellationToken.IsCancellationRequested)
            {
                    int number = rand.Next(0, 10);
                Debug.WriteLine($"Thread {threadIndex}: number {number}");
                    UpdateNumber(threadIndex, number);
                    Thread.Sleep(40);
            }
        }

            private void UpdateNumber(int threadIndex, int number)
            {
                switch (threadIndex)
                {
                    case 0:
                        slot1Label.Invoke((MethodInvoker)(() => slot1Label.Text = number.ToString()));
                        break;
                    case 1:
                        slot2Label.Invoke((MethodInvoker)(() => slot2Label.Text = number.ToString()));
                        break;
                    case 2:
                        slot3Label.Invoke((MethodInvoker)(() => slot3Label.Text = number.ToString()));
                        break;
                    default:
                        break;
                }
            }

            private void AnalyzeButton_Click(object sender, EventArgs e)
            {
                cancellationTokenSource.Cancel();
            int number1 = int.Parse(slot1Label.Text);
            int number2 = int.Parse(slot2Label.Text);
            int number3 = int.Parse(slot3Label.Text);

            if (number1 == number2 && number2 == number3)
            {
                labelResult.Text = "Выигрыш! Три одинаковых числа.";
            }
            else if (number1 == number2 || number1 == number3 || number2 == number3)
            {
                labelResult.Text = "Выигрыш! Два одинаковых числа.";
            }
            else if (number1 + number2 + number3 == 3 || number1 + number2 + number3 == 21)
            {
                labelResult.Text = "Выигрыш! Три единицы или три семерки.";
            }
            else if (number1 == 1 && number2 == 1 || number1 == 1 && number3 == 1 || number2 == 1 && number3 == 1)
            {
                labelResult.Text = "Выигрыш! Две единицы.";
            }
            else if (number1 == 4 || number2 == 4 || number3 == 4)
            {
                labelResult.Text = "Выигрыш! Имеется четверка.";
            }
            else
            {
                labelResult.Text = "К сожалению, вы проиграли.";
            }
        }

    }
}

