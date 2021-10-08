using System;

namespace cis237_assignment_2
{
    /// <summary>
    /// This class is used for solving a char array maze.
    /// You might want to add other methods to help you out.
    /// A print maze method would be very useful, and probably neccessary to print the solution.
    /// If you are real ambitious, you could make a seperate class to handle that.
    /// </summary>
    class MazeSolver
    {
        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
        public void SolveMaze(char[,] maze, int xStart, int yStart)
        {
            // Do work needed to use mazeTraversal recursive call and solve the maze.
            mazeTraversal(maze, xStart, yStart);
            PrintMaze(maze);
        }

        private void PrintMaze(char [,] maze)
        {
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    Console.Write(maze[x, y]);
                }
                Console.WriteLine("\t");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// This should be the recursive method that gets called to solve the maze.
        /// Feel free to change the return type if you like, or pass in parameters that you might need.
        /// This is only a very small starting point.
        /// More than likely you will need to pass in at a minimum the current position
        /// in X and Y maze coordinates. EX: mazeTraversal(int currentX, int currentY)
        /// </summary>
        private bool mazeTraversal(char [,] maze, int x, int y)
        {
            // Implement maze traversal recursive call
            //base case
            if ( x >= maze.GetLength(0) || x < 0 || y >= maze.GetLength(1) || y < 0)
            {
                return true;
            }
            if (maze[x,y] == '#' || maze[x,y] == '0' || maze[x,y] == 'X')
            {
                return false;
            }
            maze[x, y] = 'X';

            if (mazeTraversal(maze, x, y + 1))
            {
                maze[x, y] = 'X';
                return true;
            }
            if (mazeTraversal(maze, x + 1, y))
            {
                maze[x, y] = 'X';
                return true;
            }
            if (mazeTraversal(maze, x, y - 1))
            {
                maze[x, y] = 'X';
                return true;
            }
            if (mazeTraversal(maze, x - 1, y))
            {
                maze[x, y] = 'X';
                return true;
            }
            if(maze[x,y] == 'X')
            {
                maze[x, y] = '0';
                return false;
            }
            return false;
        }
    }
}
