using GameLibrary.Enums;
using GameLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLibrary.Classes
{
    public class MineFieldBoard : IMineFieldBoard
    {
        public int Columns { get; set; }
        public int Rows { get; set; }
        public IPlayer Player { get; set; }
        public int NumberOfMines { get; set; }
        public int PlayerColumn { get; set; }
        public int PlayerRow { get; set; }

        private readonly IUtilities _utilities;

        public MineFieldBoard(IUtilities utilities)
        {
            _utilities = utilities;
        }

        public int MinesCreated()
        {
            return _mines.Count;
        }

        private List<Mine> _mines;
        

        public void Initialise()
        {
            PlayerColumn = 1;
            PlayerRow = 1;
            BuildBoard();
        }

        private void BuildBoard()
        {
            _mines = new List<Mine>();
            
            //assign a random row and column to each mine, make sure the combination do not clash though and make sure 0,0 is always empty
            for(var lp = 0; lp < NumberOfMines; lp++)
            {
                var column = 0;
                var row = 0;
                while(true)
                {
                    column = GetRandomPosition(1, Columns);
                    row = GetRandomPosition(1, Rows);
                    if(!(column == 1 && row == 1))
                    {
                        if (_mines.Where(m => m.Column == column && m.Row == row).Count() == 0)
                        {
                            //create a mine at this position
                            _mines.Add(new Mine() { Row = row, Column = column });

                            Console.WriteLine($"Mine at {_utilities.GetColumnAsString(column-1)},{row}");
                            break;
                        }   
                    }
                }               
                
            }
        }

        private int GetRandomPosition(int lower, int upper)
        {
            return new Random().Next(lower, upper);
        }

        public bool HasPlayerReachedEnd()
        {
            return PlayerColumn == Columns;
        }

        public bool IsMineAtPlayersPosition()
        {
            return _mines.Where(m => m.Column == PlayerColumn && m.Row == PlayerRow).Count() != 0;
        }

        public bool MovePlayer(PlayerMovement direction)
        {
            //check for an invalid move
            if (PlayerColumn == 1 && direction == PlayerMovement.Left)
                return false;
            else if (PlayerRow == 1 && direction == PlayerMovement.Down)
                return false;
            else if (PlayerRow == Rows && direction == PlayerMovement.Up)
                return false;

            switch (direction)
            {
                case PlayerMovement.Up:PlayerRow++;break;
                case PlayerMovement.Down:PlayerRow--;break;
                case PlayerMovement.Right:PlayerColumn++;break;
                case PlayerMovement.Left: PlayerColumn--; break;
            }

            return true;
        }

        public void MovePlayerBack(PlayerMovement direction)
        {            
            switch (direction)
            {
                case PlayerMovement.Up: PlayerRow--; break;
                case PlayerMovement.Down: PlayerRow++; break;
                case PlayerMovement.Right: PlayerColumn--; break;
                case PlayerMovement.Left: PlayerColumn++; break;
            }
        }        
    }
}
