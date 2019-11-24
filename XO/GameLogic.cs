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
        int[,] gameBoard = new int[3, 3]; //{ {1, 0, 0}, {0, 1, 0 }, { 0, 0, 1 } }; //The Game board
        public int turn; // X - 1 O - 2
        public bool won;
        string debug;
        int winner;

        public void Start()
        {
            turn = 1; //X starts
            won = false;
            InitBoard();
        }

        private void InitBoard()
        {
            for (int x = 0; x < gameBoard.GetLength(0); x++) //Go over x
            {
                for (int y = 0; y < gameBoard.GetLength(0); y++) //Go over y
                {
                    gameBoard[x, y] = 0; // Makes the x y position equals to 0 to init the board
                }
            }
        }

        public void GetPos(int pos)
        {
         //   Toast.MakeText(context, pos + "", ToastLength.Short).Show();
            int first = pos / 10; //Get row
            int second = pos % 10; //Get column



            if (turn == 1)
                gameBoard[first, second] = 1;
            else if (turn == 2)
                gameBoard[first, second] = 2;
        }

        void CheckDig()
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
                won = true;
            }
        }

        void CheckDigRight()
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
                won = true;
            }
        }

        void CheckVertical()
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
                    won = true;
                }


            }
        }

        void CheckHorizontal()
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
                    won = true;
                }


            }
        }
        public void CheckWinCond()
        {
            CheckDig();
            CheckDigRight();
            CheckVertical();
            CheckHorizontal();

            //if(won == true)
            //{
            //    debug = "won true";
            //}
            //else if(won == false)
            //{
            //    debug = "won false";
            //}

            //Toast.MakeText(Application.Context, debug, ToastLength.Short).Show();

            if(won)
            {
                if (turn == 1)
                {
                    Toast.MakeText(Application.Context, "Player 1 wins", ToastLength.Long).Show();
                }
                else if (turn == 2)
                {
                    Toast.MakeText(Application.Context, "Player 2 wins", ToastLength.Long).Show();
                }
            }
            
        }

        public void ChangeTurn()
        {
            if (turn == 1)
                turn = 2;
            else if (turn == 2)
                turn = 1;
        }
    }
}