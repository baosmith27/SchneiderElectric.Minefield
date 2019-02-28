using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameLibrary.Interfaces;
using GameLibrary.Classes;

namespace UnitTestMinefield
{
    [TestClass]
    public class FactoryTests
    {
        [TestMethod]
        public void CreatePlayer_Succeeds()
        {
            var player = new PlayerFactory().CreatePlayer(1, "Daniel", 3);
           
            Assert.IsNotNull(player);
        }

        [TestMethod]
        public void CreateBoard_Succeeds()
        {
            var player = new PlayerFactory().CreatePlayer(1, "Daniel", 3);
            var board = new BoardFactory().CreateBoard("MineField", player, 10, 10, new Utilities());

            Assert.IsNotNull(board);
        }

        [TestMethod]
        public void CreateGame_Succeeds()
        {
            var player = new PlayerFactory().CreatePlayer(1, "Daniel", 3);
            var board = new BoardFactory().CreateBoard("MineField", player, 10, 10, new Utilities());
            var game = new GameFactory().CreateGame("MineField", (IMineFieldBoard)board, player, new Utilities());

            Assert.IsNotNull(game);
        }

        
    }
}
