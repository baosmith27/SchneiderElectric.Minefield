namespace GameLibrary.Interfaces
{
    public interface IMineFieldBoard : IBoard
    {
        int NumberOfMines { get; set; }
        int PlayerColumn { get; }
        int PlayerRow { get;  }
        bool IsMineAtPlayersPosition();        
    }
}
