using GameLibrary.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestMinefield
{
    [TestClass]
    public class UtilitiesTests
    {
        [TestMethod]
        public void Test_GetColumnAsString()
        {
            var player = new PlayerFactory().CreatePlayer(1, "Daniel", 3);
            var utilities = new Utilities();
            var board = (MineFieldBoard)new BoardFactory().CreateBoard("MineField", player, 10, 10, utilities);
            Assert.IsTrue(utilities.GetColumnAsString(0) == "A");
            Assert.IsTrue(utilities.GetColumnAsString(25) == "Z");

            Assert.IsTrue(utilities.GetColumnAsString(26) == "AA");

        }    
    }
}
