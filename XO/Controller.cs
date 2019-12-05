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
    class Controller
    {
        private int turn;
        private GameLogic gameBoard;
        private bool over;

        public Controller()
        {
            gameBoard = new GameLogic();
        }

        public void StartGame()
        {
            gameBoard.InitBoard();
            turn = 0;
            over = false;
        }

        public string SetMove(int loc)
        {
            string player = "X";
            if (turn % 2 == 1)
                player = "O";
            gameBoard.GetPos(loc, turn);
            turn = (turn + 1) % 2;
            over = gameBoard.CheckWinCond();
            return player;
        }

        public bool IsOver()
        {
            return gameBoard.CheckWinCond();
        }

        public string GetWinner()
        {
            int win = gameBoard.GetWinner();
            if (win == 0)
                return "X";
            if (win == 1)
                return "O";
            return "tie";
        }
    }
}