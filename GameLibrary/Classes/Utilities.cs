using GameLibrary.Interfaces;

namespace GameLibrary.Classes
{
    public class Utilities : IUtilities
    {
        public string GetColumnAsString(int column)
        {
            var A = 65;
            var output = "";
            while (column >= 26)
            {
                column -= 26;
                output = GetColumnAsString(column) + output;
            }
            char character = (char)(column + A);
            output = character.ToString() + output;
            return output;
        }
    }
}
