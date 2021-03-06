﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTDCalc_01
{
    public partial class Form1 : Form
    { 
        private double[] TableOfMediaToHome01= new double [15];//создали одномерный массив для мелких колонн
        private double[] TableOfMediaToHome02 = new double [15];//создали одномерный массив для мелких колонн для РС002



        public Form1()
        {
            InitializeComponent();
        }
        
          

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBox1.Text); в мелком окне выведет то, что указано в комбобоксе
            if(comboBox1.Text == "Экотар А"||
                comboBox1.Text == "Экотар В" || 
                comboBox1.Text == "Экотар С" ||
                comboBox1.Text == "Экотар В30" || 
                comboBox1.Text == "Экотар С30")
            {
                label20.Text = 20.ToString();
                label19.Text = 25.ToString();
                label18.Text = 37.5.ToString();
                label17.Text = 50.ToString();
                label16.Text = 50.ToString();
                label15.Text = "75"; //Это изначально мы кладем туда стринг, просто другой вариант
                label14.Text = "112.5";
                label46.Text = "150"; 
                label45.Text = "187.5";
                label44.Text = "275"; 
                label43.Text = "425";
                label42.Text = "625";
                label41.Text = "850"; 
                label40.Text = "1050";
                label59.Text = "1200";

            }
            else
            {
                label20.Text = 20.ToString();
                label19.Text = 28.3.ToString();
                label18.Text = 42.45.ToString();
                label17.Text = 56.6.ToString();
                label16.Text = 56.6.ToString();
                label15.Text = "84.9"; //Это изначально мы кладем туда стринг, просто другой вариант
                label14.Text = "113.2";
                label46.Text = "155.65";
                label45.Text = "198.1";
                label44.Text = "283";
                label43.Text = "424.5";
                label42.Text = "622.6";
                label41.Text = "850";
                label40.Text = "1050";
                label59.Text = "1200";
            }
        }

        private void button1_Click(object sender, EventArgs e) // Обрабатываем нажатие клавиши "Расчитать"
        {

            double Fe = double.Parse(textBox8.Text); //берём значение железа
            double Mn = double.Parse(textBox9.Text);
            double Hard = double.Parse(textBox10.Text);
            double Organic = double.Parse(textBox11.Text);

            TextBox[] Capacity = new TextBox[15];//создаем массив из текстбоксов, чтобы потом разместить там ресурс
            Capacity[0] = textBox1; //привязываем текстбоксы к элементам массива 
            Capacity[1] = textBox2;
            Capacity[2] = textBox3;
            Capacity[3] = textBox6;
            Capacity[4] = textBox5;
            Capacity[5] = textBox4;
            Capacity[6] = textBox7;
            Capacity[7] = textBox18; 
            Capacity[8] = textBox17;
            Capacity[9] = textBox16;
            Capacity[10] = textBox15;
            Capacity[11] = textBox14;
            Capacity[12] = textBox13;
            Capacity[13] = textBox12;
            Capacity[14] = textBox19;// закончили привязывать

            TableOfMediaToHome01[0] = 20; //назначаем элементам массива значения объёмов смолы. Массив создали ранее
            TableOfMediaToHome01[1] = 25;
            TableOfMediaToHome01[2] = 37.5;
            TableOfMediaToHome01[3] = 50;
            TableOfMediaToHome01[4] = 50;
            TableOfMediaToHome01[5] = 75;
            TableOfMediaToHome01[6] = 112.5;
            TableOfMediaToHome01[7] = 150;
            TableOfMediaToHome01[8] = 187.5;
            TableOfMediaToHome01[9] = 275;
            TableOfMediaToHome01[10] =425;
            TableOfMediaToHome01[11] = 625;
            TableOfMediaToHome01[12] = 850;
            TableOfMediaToHome01[13] = 1050;
            TableOfMediaToHome01[14] = 1200;//закончили


            //в зависимост от того какую смолу выбрали(|| - логическое ИЛИ)
            if (comboBox1.Text == "Экотар В" ||
                   comboBox1.Text == "Экотар В30")
            {
                for (int i = 0; i < 15; i++)
                {
                    double MediaValue; // для результата 
                    MediaValue = (1.2 * TableOfMediaToHome01[i]) / (1.37 * (Fe + Mn) + Hard);
                    Capacity[i].Text = MediaValue.ToString("0.0");

                }
            }
            else if (comboBox1.Text == "PC002") // т.к. формула ресурса одна, а значения  объёма смолы разные
            {
                TableOfMediaToHome02[0] = 20;
                TableOfMediaToHome02[1] = 28.3;
                TableOfMediaToHome02[2] = 42.45;
                TableOfMediaToHome02[3] = 56.6;
                TableOfMediaToHome02[4] = 56.6;
                TableOfMediaToHome02[5] = 84.9;
                TableOfMediaToHome02[6] = 113.2;
                TableOfMediaToHome01[7] = 155.65;
                TableOfMediaToHome01[8] = 198.1;
                TableOfMediaToHome01[9] = 283;
                TableOfMediaToHome01[10] = 424.5;
                TableOfMediaToHome01[11] = 622.6;
                TableOfMediaToHome01[12] = 850;
                TableOfMediaToHome01[13] = 1050;
                TableOfMediaToHome01[14] = 1210;//закончили
                for (int i = 0; i < 15; i++)
                {
                    double MediaValue;
                    MediaValue = (1.2 * TableOfMediaToHome02[i]) / (1.37 * (Fe + Mn) + Hard);
                    Capacity[i].Text = MediaValue.ToString("0.0");

                }
            }
            else if (comboBox1.Text == "Экотар С" || comboBox1.Text == "Экотар С30" || comboBox1.Text == "Экотар А")
            {
                for (int i = 0; i < 15; i++)
                {
                    double MediaValue;
                    MediaValue = (0.6 * TableOfMediaToHome01[i]) / (1.37 * (Fe + Mn) + Hard);
                    Capacity[i].Text = MediaValue.ToString("0.0");


                }
            }
            double Y = Fe + Mn;
            /*1. смотрим ходит ли в квадрат
             * 2. смотрим попадает ли в треугольник примерно)
             * 3. больше ли 0 железо и марганец
             * 4-5. исходя из уравнений смотрим где по отношению к гипотенузе находится точка - выше или ниже. Если ниже - попали,выше - не попали
            */
            if (double.Parse(textBox11.Text) <= 4.5)
            {
                if (Fe < 0.3 && Mn < 0.1 && Hard <= 20)
                {
                    label56.Text = "PC002";
                }

                else if ((Y < 15 && Hard <= 11) ||
                     ((Y < 15) && (Hard > 11 && Hard < 30)
                     && (Y > 0) &&
                     (Hard < (428 - 19 * Y) / 13)))

                {
                    label56.Text = "Экотар B";
                }
                else if ((Y < 30 && Hard < 12) ||
                    ((Y < 30) && (Hard < 30 && Hard >= 12)
                    && (Y > 0) &&
                    (Hard < (876 - 18 * Y) / 28)))
                {
                    label56.Text = "Экотар B30";
                }
                else
                {
                    label56.Text = "Даже экотар тут не поможет";
                }
            }


            else if (double.Parse(textBox11.Text) > 4.5 && double.Parse(textBox11.Text) <= 10)
            {
                if ((Y < 8 && Hard < 10) ||
                    ((Y < 8) && (Hard < 15 && Hard >= 10)
                    && (Y > 0) &&
                    (Hard < (102 - 4*Y) / 7)))
                {
                    label56.Text = "Экотар А";
                }
                else
                {
                    label56.Text = "Даже экотар тут не поможет";
                }
            }
            else if (double.Parse(textBox11.Text) > 10 && double.Parse(textBox11.Text) <= 20)
            {
                if ((Y < 2 && Hard < 10) ||
                        ((Y < 2) && (Hard < 12 && Hard >= 10)
                        && (Y > 0) &&
                        (Hard < (Y - 7))))
                        
                {
                    label56.Text = "Экотар С";

                }
                else
                {
                    label56.Text = "Даже экотар тут не поможет";
                }
            }

            else
            {
                label56.Text = "Даже экотар тут не поможет";
            }
            



        }

        private void Point(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar) && !(e.KeyChar == 44))
            {
                e.Handled = true;
            }
        }
    }
}
