using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.IO;
using cardgames.Properties;

namespace cardgames
{
    public partial class Form1 : Form
    {
        kartyak kartyak;
        List<PictureBox> add_boxes;
        public Form1()
        {
            InitializeComponent();
            kartyak = new kartyak();
            //Marking picture which are static value
            pictureBox1.Name = "marked";
            pictureBox2.Name = "marked";
            add_boxes = new List<PictureBox>();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            more_card(pictureBox1, ref kartyak.player_one, ref kartyak.szor, label1);
            check_number(kartyak.player_one, button1,button3);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            more_card(pictureBox2,ref kartyak.player_two,ref kartyak.szor_two, label2);
            check_number(kartyak.player_two, button2,button4);
        }
        private void more_card(PictureBox pictureBox_,ref int player,ref int szor,Label label)
        {
            if (player == 0)
            {
                Image image = kartyak.get_rnd_pic();
                pictureBox_.Image = image;
                player += kartyak.get_pic_value(image);
            }
            else
            {
                Image image = kartyak.get_rnd_pic();
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = image;
                player += kartyak.get_pic_value(image);
                pictureBox.BackColor = Color.White;
                pictureBox.Size = pictureBox_.Size;
                pictureBox.Location = pictureBox_.Location;
                pictureBox.Top -= 50 * szor;
                szor++;
                this.Controls.Add(pictureBox);
                add_boxes.Add(pictureBox);
            }
            label.Text = player.ToString();
        }
        private void check_number(int number,Button kerek,Button done)
        {
            if (number >= 21)
            {
                kerek.Enabled = false;
                done.Enabled = false;
                kartyak.done_palyer++;
            }
            check_done_player();
        }
        private void no_more_card(Button kerek,Button done)
        {
            kerek.Enabled = false;
            done.Enabled = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            no_more_card(button1, button3);
            kartyak.done_palyer++;
            check_done_player();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            no_more_card(button2, button4);
            kartyak.done_palyer++;
            check_done_player();
        }
        private void check_done_player()
        {
            if (kartyak.done_palyer == 2)
            {
                if (from_21(kartyak.player_one) < from_21(kartyak.player_two))
                {
                    MessageBox.Show("Az első játékos nyert");
                }
                else if(from_21(kartyak.player_one) > from_21(kartyak.player_two)){
                    MessageBox.Show("A Második játékos nyert");
                }
                else
                {
                    MessageBox.Show("Döntetlen!");
                }
                new_Game();
            }
        }
        private int from_21(int number)
        {
            return Math.Abs(21 - number);
        }
        private void clear_form_object()
        {
            label1.Text = "";
            label2.Text = "";
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            for (int i = 0; i < add_boxes.Count; i++)
            {
                this.Controls.Remove(add_boxes[i]);
                System.Threading.Thread.Sleep(50);
            }
        }
        private void new_Game()
        {
            kartyak.new_Game();
            clear_form_object();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            botmode botmode = new botmode();
            botmode.Show();
            this.Hide();
        }
    }
}
