using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_puzzle
{

public class PuzzleState
    {
        public int[,] Board { get; private set; }
        public int Size { get; private set; }

        public PuzzleState(int[,] board)
        {
            Board = board;
            Size = (int)Math.Sqrt(board.Length);
        }

        // Implement other necessary methods like MoveBlankTile, Equals, etc.
    }

public class EightPuzzle
    {
        private int[,] goalState = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } }; // Goal state
        private int[,] initialState; // Initial state
        private Queue<Node> queue = new Queue<Node>(); // Queue for BFS

        public EightPuzzle(int[,] initial)
        {
            initialState = initial;
        }

        public void Solve()
        {
            Node root = new Node(initialState, null, 0);
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();

                if (IsGoalState(current.State))
                {
                    PrintSolution(current);
                    return;
                }

                foreach (Node child in GetChildren(current))
                {
                    queue.Enqueue(child);
                }
            }

            Console.WriteLine("No solution found.");
        }

        private List<Node> GetChildren(Node parent)
        {
            List<Node> children = new List<Node>();

            int[,] directions = { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } }; // Possible movements

            for (int i = 0; i < 4; i++)
            {
                int newX = parent.ZeroX + directions[i, 0];
                int newY = parent.ZeroY + directions[i, 1];

                if (newX >= 0 && newX < 3 && newY >= 0 && newY < 3)
                {
                    int[,] newState = (int[,])parent.State.Clone();
                    newState[parent.ZeroX, parent.ZeroY] = newState[newX, newY];
                    newState[newX, newY] = 0;
                    Node child = new Node(newState, parent, parent.Depth + 1);
                    children.Add(child);
                }
            }

            return children;
        }

        private bool IsGoalState(int[,] state)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (state[i, j] != goalState[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void PrintSolution(Node node)
        {
            Stack<Node> path = new Stack<Node>();
            while (node != null)
            {
                path.Push(node);
                node = node.Parent;
            }

            while (path.Count > 0)
            {
                node = path.Pop();
                PrintState(node.State);
                Console.WriteLine();
            }
        }

        private void PrintState(int[,] state)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(state[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }

    public class Node
    {
        public int[,] State { get; }
        public Node Parent { get; }
        public int Depth { get; }
        public int ZeroX { get; }
        public int ZeroY { get; }

        public Node(int[,] state, Node parent, int depth)
        {
            State = state;
            Parent = parent;
            Depth = depth;

            // Find the position of the zero (blank) tile
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (state[i, j] == 0)
                    {
                        ZeroX = i;
                        ZeroY = j;
                        return;
                    }
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Example initial state
            int[,] initialState = {
            {1, 2, 3},
            {4, 5, 6},
            {0, 7, 8}
        };

            EightPuzzle puzzle = new EightPuzzle(initialState);
            puzzle.Solve();
        }
    }

}

