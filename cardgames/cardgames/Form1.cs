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
        public Form1()
        {
            InitializeComponent();
            kartyak = new kartyak();
        }
        int szor = 1;
        int szor_two = 1;
        private void button1_Click(object sender, EventArgs e)
        {
            if (kartyak.player_one == 0)
            {
                Image image = kartyak.get_rnd_pic();
                pictureBox1.Image = image;
                kartyak.player_one += kartyak.get_pic_value(image);
            }
            else
            {
                Image image = kartyak.get_rnd_pic();
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = image;
                kartyak.player_one += kartyak.get_pic_value(image);
                pictureBox.BackColor = Color.White;
                pictureBox.Size = pictureBox1.Size;
                pictureBox.Location = pictureBox1.Location;
                pictureBox.Top -= 50*szor;
                szor++;
                this.Controls.Add(pictureBox);
            }
            label1.Text = kartyak.player_one.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (kartyak.player_two == 0)
            {
                Image image = kartyak.get_rnd_pic();
                pictureBox2.Image = image;
                kartyak.player_two += kartyak.get_pic_value(image);
            }
            else
            {
                Image image = kartyak.get_rnd_pic();
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = image;
                kartyak.player_one += kartyak.get_pic_value(image);
                pictureBox.BackColor = Color.White;
                pictureBox.Size = pictureBox2.Size;
                pictureBox.Location = pictureBox2.Location;
                pictureBox.Top -= 50 * szor_two;
                szor_two++;
                this.Controls.Add(pictureBox);
            }
            label2.Text = kartyak.player_one.ToString();
        }
    }
}
