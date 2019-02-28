using GameLibrary.Interfaces;

namespace GameLibrary.Classes
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(int id, string name, int livesAllowed)
        {
            return new Player() { Id = id, Name = name, LivesAllowed = livesAllowed };
        }
    }
}
