using GameLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchneiderElectric.Minefield
{
    class Program
    {
        static void Main(string[] args)
        {
            RunGame();

            Console.WriteLine("PRESS ANY KEY TO EXIT");
            Console.Read();
        }

        async private static void RunGame()
        {
            //get a player
            var player = new PlayerFactory().CreatePlayer(1, "Daniel", 3);
            var utilities = new Utilities();
            //get a board
            var board = new BoardFactory().CreateBoard("MineField", player, 10, 10, utilities);
            ((MineFieldBoard)board).NumberOfMines = 10;
            board.Initialise();
            //get a game
            var game = new GameFactory().CreateGame("MineField", board, player, utilities);

            //run game
            await game.Play();
            
        }
    }
}
