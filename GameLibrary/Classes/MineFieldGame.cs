using GameLibrary.Enums;
using GameLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Classes
{
    public class MineFieldGame : IGame
    {
        private readonly IUtilities _utilities;
        public IMineFieldBoard Board { get; set; }
        public IPlayer Player { get; set; }

        public MineFieldGame(IUtilities utilities)
        {
            _utilities = utilities;
        }

        public void Initialise()
        {
            Board.Rows = 10;
            Board.Columns = 10;
            Board.Player = Player;
            Board.NumberOfMines = 10;
        }

        async public Task Play()
        {
            Console.WriteLine($"Game Begins {Player.Name} is at {_utilities.GetColumnAsString(Board.PlayerColumn - 1)},{Board.PlayerRow}");
            Console.WriteLine($"Use up/down left/right arrow keys to move across the board and try to avoid the mines. You have {Player.LivesAllowed} lives available.");

            int moves = 0;
            while (true)
            {
                var playerInput = Console.ReadKey().Key;
                var movement = PlayerMovement.Invalid;
                moves++;
                switch (playerInput)
                {
                    case ConsoleKey.UpArrow:movement = PlayerMovement.Up;break;
                    case ConsoleKey.DownArrow: movement = PlayerMovement.Down; break;
                    case ConsoleKey.LeftArrow: movement = PlayerMovement.Left; break;
                    case ConsoleKey.RightArrow: movement = PlayerMovement.Right; break;
                }
                if(movement != PlayerMovement.Invalid)
                {
                    var validMove = Board.MovePlayer(movement);
                    if (validMove)
                    {
                        if (Board.IsMineAtPlayersPosition())
                        {
                            Console.WriteLine("BOOM you hit a mine.");
                            Player.LivesUsed++;
                            if (Player.IsDead())
                            {
                                Console.WriteLine("Sorry no more lives left; you have lost");
                                break;
                            }
                            else
                            {
                                Board.MovePlayerBack(movement);
                                Console.WriteLine($"You have lost a life but you have {Player.LivesAllowed - Player.LivesUsed} lives remaining");
                            }
                        }
                        else if (Board.HasPlayerReachedEnd())
                        {
                            Console.WriteLine($"Congratulations you reached the end in {moves} moves.");
                            break;
                        }
                        Console.WriteLine($"You are now at position {_utilities.GetColumnAsString(Board.PlayerColumn - 1)},{Board.PlayerRow}");
                    }
                    else
                    {
                        Console.WriteLine($"You would have fallen off the board so you are still at position {_utilities.GetColumnAsString(Board.PlayerColumn - 1)},{Board.PlayerRow}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid key pressed, just up/down left/right arrow keys");
                }
            }

            Console.WriteLine("GameOver");
        }
    }
}
