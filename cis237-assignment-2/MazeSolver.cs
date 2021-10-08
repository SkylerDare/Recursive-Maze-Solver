//Skyler Dare
//CIS 237
//10/8/21
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
        /// <param name="maze">Array that contains the maze to be solved</param>
        /// <param name="xStart">starting x coordinate in the maze to be solved</param>
        /// <param name="yStart">starting x coordinate in the maze to be solved</param>
        public void SolveMaze(char[,] maze, int xStart, int yStart)
        {
            // Do work needed to use mazeTraversal recursive call and solve the maze.
            if (mazeTraversal(maze, xStart, yStart))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("SOLVED");
                PrintMaze(maze);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("FAILED");
                PrintMaze(maze);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// Method to print out the char array maze, loops through each element in the array and prints to the console
        /// </summary>
        /// <param name="maze">char array maze to be printed</param>
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
        /// <summary>
        /// Recursive method called to solve the maze, this method checks to see if the position you are in is inside the 
        /// bounds of the array, it then checks to see if the position you are in is a wall, a space that is apart of a 
        /// dead end, or if you have already visited the space. It then calls the solver method on the space below, 
        /// to the right, above, and to the left, based on current position, if it is a valid space,
        /// the '.' is replaced with 'X', or if the position has already been visited ('X') it will be replaced with '0'
        /// as the stack is relieved. This recursive method is called until the base case "exiting the bounds of the array"
        /// is met, or after every space has been visited and there are no more valid moves to be made.
        /// </summary>
        /// <param name="maze">maze to be solved</param>
        /// <param name="x">starting x coordinate</param>
        /// <param name="y">starting y coordinate</param>
        /// <returns></returns>
        private bool mazeTraversal(char [,] maze, int x, int y)
        {
            // Implement maze traversal recursive call
            //base case, if the bounds of the array are exited
            if ( x >= maze.GetLength(0) || x < 0 || y >= maze.GetLength(1) || y < 0)
            {
                return true;
            }
            //if the space is a wall, not apart of the solution, or already visited
            if (maze[x,y] == '#' || maze[x,y] == '0' || maze[x,y] == 'X')
            {
                return false;
            }
            //replace '.' with 'X'
            maze[x, y] = 'X';
            PrintMaze(maze);
            //check below
            if (mazeTraversal(maze, x, y + 1))
            {
                maze[x, y] = 'X';
                PrintMaze(maze);
                return true;
            }
            //check right
            if (mazeTraversal(maze, x + 1, y))
            {
                maze[x, y] = 'X';
                PrintMaze(maze);
                return true;
            }
            //check above
            if (mazeTraversal(maze, x, y - 1))
            {
                maze[x, y] = 'X';
                PrintMaze(maze);
                return true;
            }
            //check left
            if (mazeTraversal(maze, x - 1, y))
            {
                maze[x, y] = 'X';
                PrintMaze(maze);
                return true;
            }
            //if the space has been visited, replace with 0 because the path leads to a dead end
            if(maze[x,y] == 'X')
            {
                maze[x, y] = '0';
                PrintMaze(maze);
                return false;
            }
            return false;
        }
    }
}
