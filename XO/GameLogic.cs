using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XO
{
    class GameLogic
    {
        int[,] gameBoard;
        //public int turn; // X - 1 O - 2
        int winner;
        int step;

        public GameLogic()
        {
            this.gameBoard = new int[3, 3];
        }

        public void InitBoard()
        {
            step = 0;
            winner = -1;
            for (int x = 0; x < gameBoard.GetLength(0); x++) //Go over x
            {
                for (int y = 0; y < gameBoard.GetLength(0); y++) //Go over y
                {
                    gameBoard[x, y] = 0; // Makes the x y position equals to 0 to init the board
                }
            }
        }

        public void GetPos(int pos, int turn)
        {
         //   Toast.MakeText(context, pos + "", ToastLength.Short).Show();
            int first = pos / 10; //Get row
            int second = pos % 10; //Get column

            gameBoard[first, second] = turn;
            step++;
        }

        #region Checks
        bool CheckDig()
        {
            ////Diagonal left
            //int num = gameBoard[0, 0];
            //bool check = true;
            //if (gameBoard[0, 0] == 0)
            //{
            //    return won = false;
            //}
            //else
            //{
            //    for (int x = 1; x < gameBoard.GetLength(0) && check; x++)
            //    {
            //        if (gameBoard[x, x] != num)
            //            check = false;
            //    }


            //}

            if(gameBoard[0,0] == gameBoard[1,1] && gameBoard[2,2] == gameBoard[1,1])
            {
                winner = gameBoard[0, 0];
                return true;
            }
            return false;
        }

        bool CheckDigRight()
        {
            //int num = gameBoard[0, 2];
            //int j = 1;
            //bool check = true;

            ////Diagonal right
            //if (gameBoard[0, 2] == 0)
            //{
            //    won = false;
            //}
            //else
            //{
            //    for (int i = 1; i < gameBoard.GetLength(0) && check; i++)
            //    {
            //        Console.WriteLine(i);
            //        if (gameBoard[i, j] != num)
            //            check = false;
            //        j--;
            //    }


            //}

            if(gameBoard[0,2] == gameBoard[1,1] && gameBoard[2,0] == gameBoard[1,1])
            {
                winner = gameBoard[0, 2];
                return true;
            }
            return false;
        }

        bool CheckVertical()
        {
            bool brak = false;

            //Vertical
            for (int i = 0; i < 3; i++)
            {
                brak = false;
                if (gameBoard[i, 0] == 0)
                {
                    brak = true;
                }

                if (brak != true && (gameBoard[i, 0] == gameBoard[i, 1]) && (gameBoard[i, 1] == gameBoard[i, 2]))
                {
                    winner = gameBoard[i, 0];
                    return true;
                }


            }
            return false;
        }

        bool CheckHorizontal()
        {
            bool brak;
            //Horizontal
            brak = false;
            for (int i = 0; i < 3; i++)
            {
                brak = false;
                if (gameBoard[0, i] == 0)
                {
                    brak = true;
                }

                if (brak != true && (gameBoard[0, i] == gameBoard[1, i]) && (gameBoard[1, i] == gameBoard[2, i]))
                {
                    winner = gameBoard[0, i];
                    return true;
                }


            }
            return false;
        }
        #endregion

        public bool CheckWinCond()
        {
            bool gameOver = false;
            gameOver = CheckDig();
            if(gameOver == false)
                gameOver = CheckDigRight();
            if(gameOver == false)
                gameOver = CheckVertical();
            if(gameOver == false)
                gameOver = CheckHorizontal();

            return gameOver;          
        }

        public int GetWinner()
        {
            return winner;
        }
    }
}