using GameLibrary.Interfaces;
using System.IO;

namespace GameLibrary.Classes
{
    public class GameFactory : IGameFactory
    {
        public IGame CreateGame(string gameName, IBoard board, IPlayer player, IUtilities utilities)
        {            
            switch (gameName)
            {
                case "MineField":return CreateMineFieldGame(board, player, utilities);
                default:return null;
            }
                
        }

        private IGame CreateMineFieldGame(IBoard board, IPlayer player, IUtilities utilities)
        {
            return new MineFieldGame(utilities) { Board = (IMineFieldBoard)board, Player = player };
        }
    }
}
