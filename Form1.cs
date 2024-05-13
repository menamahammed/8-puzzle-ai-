using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_puzzle
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            init();
            shuffle();
        }
        List<Puzzle> buttons = new List<Puzzle>();
        void init()
        {
            buttons.Add(button1);
            buttons.Add(button2); 
            buttons.Add(button3);
            buttons.Add(button4);
            buttons.Add(button5);
            buttons.Add(button6);
            buttons.Add(button7);
            buttons.Add(button8);
            buttons.Add(button9);
            place(1, null, button2, null, button4);
            place(2, button1, button3, null, button5);
            place(3, button2, null, null, button6);
            place(4, null, button5, button1, button7);
            place(5, button4, button6, button2, button8);
            place(6, button5, null, button3, button9);
            place(7, null, button8, button4, null);
            place(8, button7, button9, button5, null);
            place(9, button8, null, button6, null);

        }
        void place(int i , Puzzle left, Puzzle right, Puzzle up, Puzzle down)
        {
            buttons[i - 1].left = left;
            buttons[i - 1].right = right;
            buttons[i - 1].up = up;
            buttons[i - 1].down = down;
        }
        void shuffle()
        {
            List<int> values = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Random rand = new Random();
            values = values.OrderBy(x => rand.Next()).ToList();

            for (int i = 0; i < buttons.Count; i++)
            {
                if (values[i] == 9)
                {
                    buttons[i].Text = "";
                }
                else
                {
                    buttons[i].Text = values[i].ToString();
                }

            }
        }
        void swap(Puzzle a, Puzzle b)
        {
            string temp = a.Text;
            a.Text = b.Text;
            b.Text = temp;
        }
        bool goal()
        {
            for (int i = 0; i < buttons.Count - 1; i++)
            {
                if (!(buttons[i].Text == (i + 1).ToString()))
                {
                    return false;
                }
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (((Puzzle)sender).left != null && ((Puzzle)sender).left.Text == "")
            {
                swap((Puzzle)sender, ((Puzzle)sender).left);
            }
            else if (((Puzzle)sender).right != null && ((Puzzle)sender).right.Text == "")
            {
                swap((Puzzle)sender, ((Puzzle)sender).right);
            }
            else if (((Puzzle)sender).up != null && ((Puzzle)sender).up.Text == "")
            {
                swap((Puzzle)sender, ((Puzzle)sender).up);
            }
            else if (((Puzzle)sender).down != null && ((Puzzle)sender).down.Text == "")
            {
                swap((Puzzle)sender, ((Puzzle)sender).down);
            }


            if (goal())
            {
                MessageBox.Show("Congrats");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
        }
    }
}
