using GameLibrary.Interfaces;

namespace GameLibrary.Classes
{
    public class Player : IPlayer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LivesAllowed { get; set; }
        public int LivesUsed { get; set; }

        public Player()
        {
            LivesUsed = 0;
        }

        public bool IsDead()
        {
            return LivesUsed >= LivesAllowed;
        }
    }
}
