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
    public partial class Start_Game : Form
    {
        string scores_string;
        bool clicked;
        public Start_Game()
        {
            InitializeComponent();
        }
        // Έξοδος παιχνιδιού από Form[Start Game]
        private void Start_Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult exit = MessageBox.Show("Leave the game?", "Monkey Game", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (exit == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            //Έλεγχος αν έχει γράψει ο χρήστης στο textBox1 ή αν έχει βάλει μόνο Space
            if (textBox1.Text.Length == 0 || textBox1.Text.Contains(" "))
            {
                MessageBox.Show("Λάθος Όνομα");
                textBox1.Focus();
            }
            else
            {
                Form Form2 = new Form2(radioButton1, radioButton2,textBox1.Text);
                Form2.Show();
                this.Hide();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (clicked == false)
            {
                ListBox[] apotelesmata = new ListBox[] { listBox1, listBox2 };

                for (int i = 1; i <= 2; i++)
                {
                    try
                    {
                        scores_string = File.ReadAllText("score" + i + ".txt");
                        List<Class1> scoreslist = new List<Class1>();
                        string[] splitscores = scores_string.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                        foreach (string entry in splitscores)
                        {
                            string[] splitentry = entry.Split('=');

                            if (splitentry.Count() > 1)
                            {
                                scoreslist.Add(new Class1(splitentry[0], Int32.Parse(splitentry[1])));
                            }

                        }
                        Class1[] topscores = scoreslist.OrderByDescending(x => x.Score).ToArray();
                        for (int s = 0; s < topscores.Length; s++)
                        {
                            apotelesmata[i - 1].Items.Add(topscores[s].Name + ": " + topscores[s].Score + " pts" + Environment.NewLine);
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        apotelesmata[i - 1].Items.Add("Δεν υπάρχουν καταγραφές.");
                    }
                }
                listBox1.Visible = true;
                listBox2.Visible = true;
                clicked = true;
            }
            else
            {
                listBox1.Visible = false;
                listBox2.Visible = false;
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                clicked = false;
            }
        }
        private void Start_Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }      
}
