using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jizn
{
    public partial class Form1 : Form
    {
        int n = 21;             // количество в ряду и столбце
        int dx = -10;            //начало кнопок
        int dy = -5;
        int width_tb = 20;
        TextBox[,] OldGen = new TextBox[21, 21];
        TextBox[,] NewGen = new TextBox[21, 21];

        public Form1()
        {
            InitializeComponent();

            lb_ForL.Items.Add("Новое поколение");
            lb_ForL.Items.Add("Война");
            lb_ForL.SelectedIndex = 0;
            

            for (int i = 0; i < n; i++)                     //начало, где выбор
            {
                for (int j = 0; j < n; j++)
                {

                    OldGen[i, j] = new TextBox();
                    OldGen[i, j].SetBounds(dx + j * 20, dy, width_tb, 20);          //место и размер кнопки
                    OldGen[i, j].BackColor = Color.Black;
                    this.Controls.Add(OldGen[i, j]);
                    OldGen[i, j].Click += new EventHandler(this.FistGeneration);          //действие с кнопкой при нажатииe 
                    OldGen[i, j].Cursor = Cursors.Arrow;                             // *****КАК СДЕЛАТЬ, ЧТОБЫ КУРСОР ВСЕГДА БЫЛ ARROW*****// 
                }
                dy += 20;
            }
            for (int i = 0; i < n; i++)
            {
                OldGen[i, 0].Visible = false;
                OldGen[0, i].Visible = false;
                OldGen[n - 1, i].Visible = false;
                OldGen[i, n - 1].Visible = false;
            }

        }



        public void FistGeneration(object sender,EventArgs e)                   //по нажатию на кнопку
        {
            button1.Focus();

            if (rb_ye.Checked)
            {
                if (((TextBox)sender).BackColor == Color.Black)
                {
                    ((TextBox)sender).BackColor = Color.Yellow;
                }
                else if (((TextBox)sender).BackColor == Color.Yellow)
                {
                    ((TextBox)sender).BackColor = Color.Black;
                }
                else if (((TextBox)sender).BackColor == Color.Red)
                {
                    ((TextBox)sender).BackColor = Color.Yellow;
                }
            }

            else
            {
                if (((TextBox)sender).BackColor == Color.Black)
                {
                    ((TextBox)sender).BackColor = Color.Red;
                }
                else if (((TextBox)sender).BackColor == Color.Red)
                {
                    ((TextBox)sender).BackColor = Color.Black;
                }
                else if (((TextBox)sender).BackColor == Color.Yellow)
                {
                    ((TextBox)sender).BackColor = Color.Red;
                }
            }
        }

        private void OldGeneration()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (NewGen[i, j].BackColor == Color.Yellow) OldGen[i, j].BackColor = Color.Yellow;
                    else if (NewGen[i, j].BackColor == Color.Black) OldGen[i, j].BackColor = Color.Black;
                    else if (NewGen[i, j].BackColor == Color.Red) OldGen[i, j].BackColor = Color.Red;
                    else if (NewGen[i, j].BackColor == Color.Green) OldGen[i, j].BackColor = Color.Green;
                    else OldGen[i, j].BackColor = Color.Black;
                }
            }
            
        }


        private void NewGenerationWar()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    NewGen[i, j] = new TextBox();
                }
            }
            

            for (int i = 1; i < n - 1; i++)
            {
                for (int j = 1; j < n - 1; j++)
                {
                    int count_ye = 0;
                    int count_red = 0;
                    int count_gr = 0;

                    if (OldGen[i - 1, j - 1].BackColor == Color.Green) count_gr++;                //***УСЛОВИЯ ДЛЯ ЗЕЛЕНЫХ!!!!***
                    if (OldGen[i - 1, j].BackColor == Color.Green) count_gr++;
                    if (OldGen[i - 1, j + 1].BackColor == Color.Green) count_gr++;
                    if (OldGen[i, j - 1].BackColor == Color.Green) count_gr++;
                    if (OldGen[i, j + 1].BackColor == Color.Green) count_gr++;
                    if (OldGen[i + 1, j - 1].BackColor == Color.Green) count_gr++;
                    if (OldGen[i + 1, j].BackColor == Color.Green) count_gr++;
                    if (OldGen[i + 1, j + 1].BackColor == Color.Green) count_gr++;

                    if (OldGen[i - 1, j - 1].BackColor == Color.Yellow) count_ye++;                //***УСЛОВИЯ ДЛ ЖЕЛТЫХ!!!!***
                    if (OldGen[i - 1, j].BackColor == Color.Yellow) count_ye++;
                    if (OldGen[i - 1, j + 1].BackColor == Color.Yellow) count_ye++;
                    if (OldGen[i, j - 1].BackColor == Color.Yellow) count_ye++;
                    if (OldGen[i, j + 1].BackColor == Color.Yellow) count_ye++;
                    if (OldGen[i + 1, j - 1].BackColor == Color.Yellow) count_ye++;
                    if (OldGen[i + 1, j].BackColor == Color.Yellow) count_ye++;
                    if (OldGen[i + 1, j + 1].BackColor == Color.Yellow) count_ye++;

                    if (OldGen[i - 1, j - 1].BackColor == Color.Red) count_red++;                //***УСЛОВИЯ ДЛ КРАСНЫХ!!!!***
                    if (OldGen[i - 1, j].BackColor == Color.Red) count_red++;
                    if (OldGen[i - 1, j + 1].BackColor == Color.Red) count_red++;
                    if (OldGen[i, j - 1].BackColor == Color.Red) count_red++;
                    if (OldGen[i, j + 1].BackColor == Color.Red) count_red++;
                    if (OldGen[i + 1, j - 1].BackColor == Color.Red) count_red++;
                    if (OldGen[i + 1, j].BackColor == Color.Red) count_red++;
                    if (OldGen[i + 1, j + 1].BackColor == Color.Red) count_red++;

                    // желтые без расных
                    if (((OldGen[i, j].BackColor == Color.Yellow) && (((count_ye == 2) || (count_ye == 3)))) && (count_red == 0)) NewGen[i, j].BackColor = Color.Yellow;      //***ЕСЛИ РЯДОМ 2-3 ЖИВЫХ, ТО ЖИВЕТ***
                    else if (((OldGen[i, j].BackColor == Color.Yellow) && (((count_ye < 2) || (count_ye > 3)))) && (count_red == 0)) NewGen[i, j].BackColor = Color.Black;         //*** ЕСЛИ РЯДОМ МЕНЬШЕ 2 ИЛИ БОЛЬШЕ 3, ТО УМИРАЕТ***
                    else if (((OldGen[i, j].BackColor == Color.Black) && (count_ye == 3)) && (count_red == 0)) NewGen[i, j].BackColor = Color.Yellow;                         //***ЕСЛИ РЯДОМ ТРИ ЖИВЫЕ, ТО НОВАЯ***

                    //красные без расных
                    else if (((OldGen[i, j].BackColor == Color.Red) && (((count_red == 2) || (count_red == 3)))) && (count_ye == 0)) NewGen[i, j].BackColor = Color.Red;
                    else if (((OldGen[i, j].BackColor == Color.Red) && (((count_red < 2) || (count_red > 3)))) && (count_ye == 0)) NewGen[i, j].BackColor = Color.Black;
                    else if (((OldGen[i, j].BackColor == Color.Black) && (count_red == 3)) && (count_ye == 0)) NewGen[i, j].BackColor = Color.Red;

                    //зеленые
                    else if (((OldGen[i, j].BackColor == Color.Black) && (count_gr == 2)) && (count_red == 0) && (count_ye == 0)) NewGen[i, j].BackColor = Color.Green;

                    //война
                    else if ((count_red > count_ye) && (count_ye != 0) && (count_red >= 3) && (count_red <= 5) && (count_gr == 0)) NewGen[i, j].BackColor = Color.Red;
                    else if ((count_red < count_ye) && (count_red != 0) && (count_ye == 3) && (count_ye <= 5) && (count_gr == 0)) NewGen[i, j].BackColor = Color.Yellow;
                    else if((count_gr > count_red + count_ye) && (count_red != 0) && (count_ye != 0)) NewGen[i, j].BackColor = Color.Green;
                    else NewGen[i, j].BackColor = Color.Black;


                }
            }



            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    NewGen[i, j].Visible = false;
                    NewGen[i, j].SetBounds(dx + j * 20, dy, width_tb, 20);
                    this.Controls.Add(NewGen[i, j]);
                    NewGen[i, j].Cursor = Cursors.Arrow;

                }
                dy += 20;
            }

        }


        private void NewGenerationPeace()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    NewGen[i, j] = new TextBox();
                }
            }

            for (int i = 1; i < n - 1; i++)
            {
                for (int j = 1; j < n - 1; j++)
                {
                    int count_ye = 0;
                    int count_red = 0;
                    int count_gr = 0;

                    if (OldGen[i - 1, j - 1].BackColor == Color.Green) count_gr++;                //***УСЛОВИЯ ДЛЯ ЗЕЛЕНЫХ!!!!***
                    if (OldGen[i - 1, j].BackColor == Color.Green) count_gr++;
                    if (OldGen[i - 1, j + 1].BackColor == Color.Green) count_gr++;
                    if (OldGen[i, j - 1].BackColor == Color.Green) count_gr++;
                    if (OldGen[i, j + 1].BackColor == Color.Green) count_gr++;
                    if (OldGen[i + 1, j - 1].BackColor == Color.Green) count_gr++;
                    if (OldGen[i + 1, j].BackColor == Color.Green) count_gr++;
                    if (OldGen[i + 1, j + 1].BackColor == Color.Green) count_gr++;

                    if (OldGen[i - 1, j - 1].BackColor == Color.Yellow) count_ye++;                //***УСЛОВИЯ ДЛ ЖЕЛТЫХ!!!!***
                    if (OldGen[i - 1, j].BackColor == Color.Yellow) count_ye++;
                    if (OldGen[i - 1, j + 1].BackColor == Color.Yellow) count_ye++;
                    if (OldGen[i, j - 1].BackColor == Color.Yellow) count_ye++;
                    if (OldGen[i, j + 1].BackColor == Color.Yellow) count_ye++;
                    if (OldGen[i + 1, j - 1].BackColor == Color.Yellow) count_ye++;
                    if (OldGen[i + 1, j].BackColor == Color.Yellow) count_ye++;
                    if (OldGen[i + 1, j + 1].BackColor == Color.Yellow) count_ye++;

                    if (OldGen[i - 1, j - 1].BackColor == Color.Red) count_red++;                //***УСЛОВИЯ ДЛ КРАСНЫХ!!!!***
                    if (OldGen[i - 1, j].BackColor == Color.Red) count_red++;
                    if (OldGen[i - 1, j + 1].BackColor == Color.Red) count_red++;
                    if (OldGen[i, j - 1].BackColor == Color.Red) count_red++;
                    if (OldGen[i, j + 1].BackColor == Color.Red) count_red++;
                    if (OldGen[i + 1, j - 1].BackColor == Color.Red) count_red++;
                    if (OldGen[i + 1, j].BackColor == Color.Red) count_red++;
                    if (OldGen[i + 1, j + 1].BackColor == Color.Red) count_red++;

                    // желтые без расных
                    if (((OldGen[i, j].BackColor == Color.Yellow) && (((count_ye == 2) || (count_ye == 3)))) && (count_red == 0)) NewGen[i, j].BackColor = Color.Yellow;      //***ЕСЛИ РЯДОМ 2-3 ЖИВЫХ, ТО ЖИВЕТ***
                    else if (((OldGen[i, j].BackColor == Color.Yellow) && (((count_ye < 2) || (count_ye > 3)))) && (count_red == 0)) NewGen[i, j].BackColor = Color.Black;         //*** ЕСЛИ РЯДОМ МЕНЬШЕ 2 ИЛИ БОЛЬШЕ 3, ТО УМИРАЕТ***
                    else if (((OldGen[i, j].BackColor == Color.Black) && (count_ye == 3)) && (count_red == 0)) NewGen[i, j].BackColor = Color.Yellow;                         //***ЕСЛИ РЯДОМ ТРИ ЖИВЫЕ, ТО НОВАЯ***

                    //красные без расных
                    else if (((OldGen[i, j].BackColor == Color.Red) && (((count_red == 2) || (count_red == 3)))) && (count_ye == 0)) NewGen[i, j].BackColor = Color.Red;
                    else if (((OldGen[i, j].BackColor == Color.Red) && (((count_red < 2) || (count_red > 3)))) && (count_ye == 0)) NewGen[i, j].BackColor = Color.Black;
                    else if (((OldGen[i, j].BackColor == Color.Black) && (count_red == 3)) && (count_ye == 0)) NewGen[i, j].BackColor = Color.Red;

                    //зеленые дети
                    else if ((count_red == count_ye) && (count_ye >= 2)) NewGen[i, j].BackColor = Color.Green;
                    else if (((OldGen[i, j].BackColor == Color.Black) && (count_gr == 2)) && (count_red <= 1) && (count_ye <= 1)) NewGen[i, j].BackColor = Color.Green;

                    
                }
            }
            

            for (int i = 0; i < n; i++) 
            {
                for (int j = 0; j < n; j++)
                {
                    NewGen[i, j].Visible = false;
                    NewGen[i, j].SetBounds(dx + j * 20, dy, width_tb, 20); 
                    this.Controls.Add(NewGen[i, j]);
                    NewGen[i, j].Cursor = Cursors.Arrow; 

                }
                dy += 20;
            }

            for(int i = 0; i < n; i++)
            {
                OldGen[i, 0].Visible = false;
                OldGen[0, i].Visible = false;
                OldGen[n - 1, i].Visible = false;
                OldGen[i, n - 1].Visible = false;
            }

        }

        bool flag = false;

        private void NameBut()
        {
            if (button1.Text == "Старт!") button1.Text = "Стоп!";
            else button1.Text = "Старт!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NameBut();
            
            if (flag == false)
            {
                timer1.Start();
                flag = true;
            }
            else
            {
                timer1.Stop();
                flag = false;
            }
        }

        int gencount = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            label3.Text = gencount.ToString();
            dx = 0;            //начало кнопок
            dy = 10;
            if (lb_ForL.SelectedIndex == 1) NewGenerationWar();
            else if(lb_ForL.SelectedIndex == 0) NewGenerationPeace();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    NewGen[i, j].Parent.Controls.Remove(NewGen[i, j]);
                }
            }
            OldGeneration();
            gencount++;

            int check_space = 0;                        //***ОСТАНОВКА, КОГДА ВСЕ КЛЕТКИ ПУСТЫЕ***
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (OldGen[i, j].BackColor == Color.Black) check_space++;
                }
            }
            if (check_space == 441)
            {
                timer1.Stop();
                DialogResult res = MessageBox.Show("Поколений не осталось. Ваш счет: " + label3.Text + " \n Начать заново?", "Конец игры!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(res == DialogResult.Yes)
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            OldGen[i, j].BackColor = Color.Black;
                        }
                    }
                    NameBut();
                    timer1.Stop();
                    flag = false;

                    gencount = 1;
                    label3.Text = "0";
                }
                else if (res == DialogResult.No)
                    Application.Exit();

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    OldGen[i, j].BackColor = Color.Black;
                }
            }
            timer1.Stop();
            flag = false;
            button1.Text = "Старт!";
            gencount = 1;
            label3.Text = "0";
        }
    }
}
