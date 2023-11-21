using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            char[,] matrix = new char[10, 10];
            initMatrix(matrix);
            int[] ships = { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 }; //sizes of 10 ships

            for (int i = 0; i < ships.Length; i++)
            {
                int direction = r.Next(2); //0 horizontal, 1 vertical
                int x = r.Next(10); // x or row position of ship 0..9
                int y = r.Next(10); // y or column position
                bool touch = false;
                bool created = false;

                // horizontal ship
                if (direction == 0 && y <= (10 - ships[i]))
                {
                    for (int j = 0; j < ships[i]; j++)
                    {
                        if (matrix[x, y+j] == 'o' || matrix[x, y + j] == 'x') touch = true;
                    }
                    if (touch) 
                    {
                        touch = false;
                        i--;
                        continue; 
                    }
                    for (int j = 0; j < ships[i]; j++)
                    {
                        matrix[x, y + j] = 'o';
                        created = true;
                    }
                    markSurroundings(matrix);
                } else if (direction == 0 && y > (10 - ships[i])) 
                {
                    i--;
                    continue; // ship is outside of matrix boundaries
                }

                // vertical ship
                if (direction == 1 && x <= (10 - ships[i]))
                {
                    for (int j = 0; j < ships[i]; j++)
                    {
                        if (matrix[x+j, y] == 'o' || matrix[x+j, y] == 'x') touch = true;
                    }
                    if (touch)
                    {
                        touch = false;
                        i--;
                        continue;
                    }
                    for (int j = 0; j < ships[i]; j++)
                    {
                        matrix[x+j, y] = 'o';
                        created = true;
                    }
                    markSurroundings(matrix);
                }
                else if (direction == 1 && x > (10 - ships[i]))
                {
                    i--;
                    continue; // ship is outside of matrix boundaries
                }
                if (created)
                {
                    created = false;    
                }
                else 
                {
                    i--; continue;
                }
            }
            printMatrix(matrix);
            Console.WriteLine("\n----------------------");

            // clear x marks
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'x') matrix[i, j] = '.';
                }  
            }
            printMatrix(matrix);
            Console.ReadLine();
        }   


        static void printMatrix(char[,] matrix) 
        {
            string line = "";
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    line += matrix[rows, cols]+" ";
                }
                Console.WriteLine(line);
                line = "";
            }
        }

        static void markSurroundings(char[,] matrix) 
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'o')
                    {
                        for (int k = -1; k < 2; k++)
                        {
                            for (int m = -1; m < 2; m++)
                            {
                                if ((!(k == 0 && m == 0)) && (!(Math.Abs(k) == 1 && Math.Abs(m) == 1))) 
                                    if ((i - k >= 0 && i - k <= 9) && (j - m >= 0 && j - m <= 9))
                                        if (matrix[i - k, j - m] == '.') matrix[i - k, j - m] = 'x';
                            }
                        }
                    }
                }
            }

        }

        static void initMatrix(char[,] matrix) 
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = '.';
                }
            }
        }
    }
}
