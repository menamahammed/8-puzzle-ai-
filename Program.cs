using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_puzzle
{
    static partial class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

class Node
    {
        public int[,] state { get; set; }
        public Node parent { get; set; }
        public int cost { get; set; }
        public int depth { get; set; }

        public Node(int[,] state, Node parent, int cost, int depth)
        {
            state = state;
            parent = parent;
            cost = cost;
                depth = depth;
        }
    }

        class _8_puzzle
        {
        static void Main(string[] args)
        {
            int[,] initialState = {
            {1, 2, 3},
            {4, 5, 6},
            {0, 7, 8}
        };

            int[,] goalState = {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 0}
        };

         
        }

        
        }
    }

}

