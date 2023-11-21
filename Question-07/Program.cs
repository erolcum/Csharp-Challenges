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
        static Random r = new Random();
        static int[,] matrix =  { { 1,2,3},
                                { 4,5,6 },
                                { 7,8,9 } };


        static void Main(string[] args)
        {
            int counter = 0;
            do 
            {
                switchNumbers();
                counter++;
                Console.WriteLine( counter);

            } while (!isMagicSquare());

            Console.WriteLine("\n----------------------");
            printMatrix();
            Console.WriteLine("----------------------");
            Console.WriteLine("\ncounter : "+counter);
            Console.ReadLine();
        }   


        static void printMatrix() 
        {
            string line = "";
            string number;
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    number = matrix[rows, cols].ToString();
                    //if (number.Length ==1) { number = number.PadLeft(2, '0'); }
                    line += number + " ";
                }
                Console.WriteLine(line);
                line = "";
            }
        }

        static void switchNumbers()
        {
            int x1 = r.Next(3);
            int x2 = r.Next(3);
            int y1 = r.Next(3);
            int y2 = r.Next(3);

            int temp = matrix[x1, y1];
            matrix[x1,y1] = matrix[x2,y2];
            matrix[x2,y2] = temp;
        }

        static bool isMagicSquare() 
        {
            // check rows sum
            int tempSum = matrix[0, 0] + matrix[0, 1] + matrix[0, 2] ;
            for (int i = 1; i < 3; i++)
            {
                if (matrix[i, 0] + matrix[i, 1] + matrix[i, 2] != tempSum)
                    return false;
            }
            // check columns sum
            for (int i = 0; i < 3; i++)
            {
                if (matrix[0, i] + matrix[1, i] + matrix[2, i]  != tempSum)
                    return false;
            }
            // check diagonals sum
            if (matrix[0, 0] + matrix[1, 1] + matrix[2, 2] != tempSum)
                return false;
            if (matrix[0, 2] + matrix[1, 1] + matrix[2, 0] != tempSum)
                return false;
            return true;
        }

    }
}
