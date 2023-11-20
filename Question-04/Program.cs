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
            int temp;
            Console.Write("Number of rows    : ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Number of columns : ");
            int cols = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rows,cols];

         

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"row : {i+1}, column : {j+1} value : ");
                     temp = int.Parse(Console.ReadLine());
                    if (isExistInArray(matrix, temp)) 
                    {
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("Each element must be different !");
                        Console.WriteLine("---------------------------------");
                        j--;
                        continue;
                    }
                    matrix[i, j] = temp; 
                }
            }
            printMatrix(matrix);
            //int[,] copyMatrix = matrix.Clone() as int[,]; //copy matrix to an array

            //Array to list
            var list = new List<int>();
            foreach (var item in matrix)
            {
                list.Add(item);
            }

            var newList = shuffledIntList(list);

            //List to array
            int[,] copyMatrix = new int[rows, cols];
            int k = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                { 
                    copyMatrix[i, j] = newList[k];
                    k++;
                }
            }

            printMatrix(copyMatrix);

            //Calculate max distance for each same element between matrix and copyMatrix
            int maxDist = 0;
            int maxRow = 0;
            int maxCol = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    for (int l = 0; l < rows; l++)
                    {
                        for (int m = 0; m < cols; m++)
                        {
                            if (matrix[i, j] == copyMatrix[l, m]) 
                            { 
                                int dist = Math.Abs(i - l) + Math.Abs(j - m);
                                if (dist > maxDist) 
                                {
                                    maxDist = dist;
                                    maxRow = i;
                                    maxCol = j;
                                }
                            }
                            
                        }
                    }
                }
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine(matrix[maxRow,maxCol] + " has the max distance");

            Console.ReadLine();
        }

        static bool isExistInArray(int[,] matrix, int i) 
        {
            foreach (var item in matrix)
            {
                if (item == i) return true;
            }
            return false;
        }

        static void printMatrix(int[,] matrix) 
        {
            string line = "";
            Console.WriteLine("-----------------------------");
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    line += matrix[rows, cols].ToString() + "\t";
                    
                }
                Console.WriteLine(line);
                line = "";
            }

        }

        static List<int> shuffledIntList(List<int> list) 
        { 
            Random r = new Random();
            for (int i = 0; i < list.Count; i++) 
            { 
                int idx = r.Next(i, list.Count);
                int temp = list[idx];
                list[idx] = list[i];
                list[i] = temp;
            }
            return list;
        }

    }
}
