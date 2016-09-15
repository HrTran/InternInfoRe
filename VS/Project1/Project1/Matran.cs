using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    
        public class Matrix
        {
            public int row = 4;
            public int column = 2;
            public int[,] phantu=new int[4, 2];
            public Matrix(int Row, int Column, int[,] Phantu)
            {
                Row = row;
                Column = column;
                Phantu = phantu;

            }

            public void Input()
            {
                for (int j = 0; j < column; j++)
                {
                    for (int i = 0; i < row; i++)
                    {
                        Console.Write("[{0}, {1}] =",i,j);
                        this.phantu[i, j] = int.Parse(Console.ReadLine());
                        
                    }
                }
            }
            public void printMatrix()  //in ra ma tran a
            {
                for (int j = 0; j < column; j++)
                {
                    for (int i = 0; i < row; i++)
                    {
                        System.Console.Write(phantu[i, j]);
                        System.Console.Write(" ");

                    }
                    System.Console.WriteLine();
                }
            }
            public Matrix Addition(Matrix B, Matrix C) //cong voi ma tran b
            {
                
                for (int j = 0; j < column; j++)
                {
                    for (int i = 0; i < row; i++)
                    {
                        C.phantu[i, j] = this.phantu[i, j] + B.phantu[i, j];
                    }

                }
                return C;
            }
            public Matrix Subtraction(Matrix B)//a - b
            {
                int[,] c = new int[4, 2];
                Matrix C = new Matrix(4, 2, c);
                for (int j = 0; j < column; j++)
                {
                    for (int i = 0; i < row; i++)
                    {
                        c[i, j] = this.phantu[i, j] - B.phantu[i, j];

                    }

                }
                return C;
            }
            public Matrix Nhanmatran(Matrix B) //a * b
            {
                int[,] c = new int[4, 2];
                Matrix C = new Matrix(4, 2, c);
                for (int i = 0; i < row; i++)
                    for (int j = 0; j < column; j++)
                    {
                        c[i, j] = 0;
                        for (int k = 0; k < 2; k++)
                            c[i, j] = c[i, j] + this.phantu[i, k] * B.phantu[k, j];
                    }
                return C;
            }

            public Matrix Transpose()
            {
                int[,] c = new int[2, 4];
                Matrix C = new Matrix(2, 4, c);
                for (int j = 0; j < 2; j++)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        c[i, j] = this.phantu[j, i];

                    }

                }
                return C;
            }
        }
        
    }

