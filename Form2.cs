using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GsmeMonkey
{
    public partial class Form2 : Form
    {
        int level;
        int timegame = 50;
        int score = 0;
        Random r = new Random();
        

        public Form2(RadioButton rb1, RadioButton rb2,string username)
        {
            InitializeComponent();
            if (rb1.Checked)
            {
                timer2.Interval = 1000;
                level = 1;
            }
            else
            {
                timer2.Interval = 500;
                level = 2;
            }
            timer2.Enabled = true;
            label5.Text = username;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            score += 10;
            label1.Text = score.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timegame--;
            if (timegame == 0)
            {
                timer1.Stop();
                File.AppendAllText("Score"+level+".txt",label5.Text+"="+score +Environment.NewLine);
                this.Hide();
                var form1 = new Start_Game();
                form1.Show();
            }
            label2_Timer.Text = timegame.ToString();


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int rx = r.Next(24, 700);
            int ry = r.Next(25, 400);
            pictureBox1.Location = new Point(rx, ry);
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }

  
    
}
