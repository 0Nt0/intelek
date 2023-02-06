using System;
using System.Runtime.InteropServices;
using System.Text;

namespace _2Darbas
{
    internal class Program
    {

        static public void MakeBoard(string[,] board)
        {

            for (int i = 0; i < 10; i++)
            {
                for (int m = 0; m < 10; m++)
                {
                    Console.Write(board[i, m] + " ");
                }
                Console.WriteLine();
            }
        }

        static public bool CheckIfSafe(int i, int j, string[,] board)
        {
            for(int m=0;m<j;m++)
            {
                if (board[i,m]=="Q")
                {
                    return false;
                }
            }

            for (int m = 0; m < i; m++)
            {
                if (board[m, j] == "Q")
                {
                    return false;
                }
            }

            for (int m=0; m<10;m++)
            {
                for(int n=0;n<10;n++)
                {
                    if (m + n == i + j || m - n == i - j)
                    {
                        if (board[m, n] == "Q")
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        static public void Sides(int i, int j, string[,] board)
        {
           
            for (int m = 0; m < 10; m++)
            {
                if(m!=i)
                {
                 board[m, j] = "X";
                }
                
            }
            for(int m=0;m<10;m++)
            {
                if(m!=j)
                {
                  board[i, m] = "X";
                }
               
            }

            for(int m=0;m<10;m++)
            { for (int n=0;n<10;n++)
                {
                    if(m==n&& m!=i && n!=j)
                    {
                        board[m, n] = "X";
                    }  
                }
            } 
            
        }
        static public void Sides2(int i, int j, string[,] board)
        {
            for (int m = 0; m < 10; m++)
            {
                if (m != i)
                {
                    board[m, j] = "X";
                }

            }
            for (int m = 0; m < 10; m++)
            {
                if (m != j)
                {
                    board[i, m] = "X";
                }

            }
        }
        static public bool Placement(string[,] board, int j)
        {

            if (j >= 10)
                return true;

            for (int i = 0; i < 10; i++)
            {
                
                    if (CheckIfSafe(i, j, board) == true)
                    {
                    board[i, j] = "Q";
                    if(j+1<10&& j-1<0 && i+1<10&& i-1<0)
                    {
                        board[i, j + 1] = "X";
                        board[i + 1, j] = "X";
                        board[i+1,j+1]= "X";
                        Sides(i,j,board);
                    }
                   if(j+1<10&&j-1>=0 && i-1>=0 && i+1<10)
                    {
                        board[i, j + 1] = "X";
                        board[i, j - 1] = "X";
                        board[i - 1, j] = "X";
                        board[i + 1, j] = "X";
                        board[i - 1, j - 1] = "X";
                        board[i - 1, j + 1] = "X";
                        board[i + 1, j + 1] = "X";
                        board[i+1,j-1]= "X";
                        Sides2(i,j,board);
                    }

                    if (Placement(board, j + 1))
                    { return true; }

                    board[i,j] = "";

                    }
                
            }

            return false;
            
        }


        static void Main(string[] args)
        {
            string[,] board = new string[10, 10];
            Placement(board,0);
            MakeBoard(board);
          
        }
    }
}
