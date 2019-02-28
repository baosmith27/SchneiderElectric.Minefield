namespace GameLibrary.Interfaces
{
    public interface IBoardFactory
    {
        IBoard CreateBoard(string gameName, IPlayer player, int columns, int rows, IUtilities utilities);
    }
}
