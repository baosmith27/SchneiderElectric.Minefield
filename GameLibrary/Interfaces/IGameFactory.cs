using System.IO;

namespace GameLibrary.Interfaces
{
    public interface IGameFactory
    {
        IGame CreateGame(string gameName, IBoard board, IPlayer player, IUtilities utilities);
    }
}
