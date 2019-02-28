using System.Threading.Tasks;

namespace GameLibrary.Interfaces
{
    public interface IGame
    {        
        void Initialise();
        Task Play();
    }
}
