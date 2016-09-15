using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Program
    {
        static void Main()
        {

            int[,] a = new int[4, 2];
            int[,] b = new int[4, 2];
            int[,] c = new int[4, 2];
            Matrix C = new Matrix(4, 2, c);
            Matrix A = new Matrix(4, 2, a);
            Matrix B = new Matrix(4, 2, b);
            Console.WriteLine("Input Matrix A.");
            A.Input();
            Console.WriteLine("Input Matrix B.");
            B.Input();
            Console.WriteLine("Print out Matrix A.");
            A.printMatrix();
            Console.WriteLine("Print out Matrix A+B.");
            (A.Addition(B,C)).printMatrix();
            Console.WriteLine("Print out Matrix A-B.");
            (A.Subtraction(B)).printMatrix();
            Console.WriteLine("Print out Matrix A*B.");
            (A.Nhanmatran(B)).printMatrix();

            Console.Read();
        }
    }
}
