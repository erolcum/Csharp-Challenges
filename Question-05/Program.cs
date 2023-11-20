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

            char[,] matrix = new char[10, 10];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = '.';
                }
            }

            matrix[0, 2] = 'o';
            matrix[0, 3] = 'o';
            matrix[0, 4] = 'o';
            matrix[5, 5] = 'o';
            matrix[8, 8] = 'o';
            matrix[9, 8] = 'o';
            printMatrix(matrix);
            Console.WriteLine("\n----------------------");
            Console.ReadLine();

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
                                if ((!(k == 0 && m == 0)) && (!(Math.Abs(k)==1 && Math.Abs(m) == 1)))
                                    if ((i-k >= 0 && i-k <= 9) && (j - m >= 0 && j - m <= 9))
                                        if (matrix[i - k, j - m] == '.') matrix[i - k, j - m] = 'x'; 
                            }
                        }
                    }
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

       

    }
}
