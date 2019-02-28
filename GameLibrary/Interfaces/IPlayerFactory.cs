namespace GameLibrary.Interfaces
{
    public interface IPlayerFactory
    {
        IPlayer CreatePlayer(int id, string name, int livesAllowed);
    }
}
