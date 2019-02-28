using GameLibrary.Interfaces;

namespace GameLibrary.Classes
{
    public class BoardFactory : IBoardFactory
    {
        public IBoard CreateBoard(string gameName, IPlayer player, int columns, int rows, IUtilities utilities)
        {
            switch (gameName)
            {
                case "MineField": return CreateMineFieldBoard(player, columns, rows, utilities);
                default:return null;
            }
        }

        private IBoard CreateMineFieldBoard(IPlayer player, int columns, int rows, IUtilities utilities)
        {
            return new MineFieldBoard(utilities) { Player = player, Columns = columns, Rows = rows };
        }
    }
}
