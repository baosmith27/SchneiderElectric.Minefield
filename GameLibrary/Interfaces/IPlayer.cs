namespace GameLibrary.Interfaces
{
    public interface IPlayer
    {
        int Id { get; set; }
        string Name { get; set; }
        int LivesAllowed { get; set; }
        int LivesUsed { get; set; }

        bool IsDead();
    }
}
