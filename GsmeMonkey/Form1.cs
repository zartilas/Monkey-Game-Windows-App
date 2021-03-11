using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GsmeMonkey
{

    public partial class Monkey : Form
    {

        public Monkey()
        {
            InitializeComponent();
        }
        // Έξοδος παιχνιδιού 1
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Leave the game?", "Monkey Game",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if(exit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        // Έξοδος παιχνιδιού 2
        private void Monkey_KeyDown(object sender, KeyEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Start = new Start_Game();
            Start.Show();
        }
    }
}
