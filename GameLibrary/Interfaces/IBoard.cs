using GameLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.Interfaces
{
    public interface IBoard
    {
        int Columns { get; set; }
        int Rows { get; set; }
        IPlayer Player { get; set; }

        void Initialise();
                
        bool MovePlayer(PlayerMovement direction);
        void MovePlayerBack(PlayerMovement direction);
        bool HasPlayerReachedEnd();
    }
}
