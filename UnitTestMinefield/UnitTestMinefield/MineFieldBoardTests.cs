using System;
using GameLibrary.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestMinefield
{
    [TestClass]
    public class MineFieldBoardTests
    {
        [TestMethod]
        public void BuildBoard_Succeeds()
        {
            var player = new PlayerFactory().CreatePlayer(1, "Daniel", 3);
            var board = (MineFieldBoard)new BoardFactory().CreateBoard("MineField", player, 10, 10, new Utilities());
            board.NumberOfMines = 10;
            board.Initialise();
            Assert.IsTrue(board.NumberOfMines == board.MinesCreated());
        }

        [TestMethod]
        public void PlayerFallsOffBottomOfBoard_Handled()
        {
            var player = new PlayerFactory().CreatePlayer(1, "Daniel", 3);
            var board = (MineFieldBoard)new BoardFactory().CreateBoard("MineField", player, 10, 10, new Utilities());
            board.NumberOfMines = 10;
            board.Initialise();
            Assert.IsFalse(board.MovePlayer(GameLibrary.Enums.PlayerMovement.Down));
        }

        [TestMethod]
        public void PlayerFallsOffLeftOfBoard_Handled()
        {
            var player = new PlayerFactory().CreatePlayer(1, "Daniel", 3);
            var board = (MineFieldBoard)new BoardFactory().CreateBoard("MineField", player, 10, 10, new Utilities());
            board.NumberOfMines = 10;
            board.Initialise();
            Assert.IsFalse(board.MovePlayer(GameLibrary.Enums.PlayerMovement.Left));
        }

        [TestMethod]
        public void PlayerFallsOffTopOfBoard_Handled()
        {
            var player = new PlayerFactory().CreatePlayer(1, "Daniel", 3);
            var board = (MineFieldBoard)new BoardFactory().CreateBoard("MineField", player, 10, 10, new Utilities());
            board.NumberOfMines = 10;
            board.Initialise();
            board.PlayerRow = 10;
            Assert.IsFalse(board.MovePlayer(GameLibrary.Enums.PlayerMovement.Up));
        }

        [TestMethod]
        public void PlayerWins()
        {
            var player = new PlayerFactory().CreatePlayer(1, "Daniel", 3);
            var board = (MineFieldBoard)new BoardFactory().CreateBoard("MineField", player, 10, 10, new Utilities());
            board.NumberOfMines = 10;
            board.Initialise();
            board.PlayerColumn = 10;
            Assert.IsTrue(board.HasPlayerReachedEnd());
        }
    }
}
