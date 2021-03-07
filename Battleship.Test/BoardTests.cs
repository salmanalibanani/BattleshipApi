using Battleship.Domain.Data;
using NUnit.Framework;

namespace Battleship.Test
{
    
    public class BoardTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void GivenAShipIsOnBoard_WhenAnOverLappingShipIsAdded_ThenAdditionRequestIsDeclined()
        {
            // Arrange
            var ship = TestHelper.GetHorizontalShip();
            var newShip = TestHelper.GetVerticalShip();
            var board = new Board(TestHelper.BoardWidth, TestHelper.BoardHeight);
            board.AddShip(ship);

            // Act
            var success = board.AddShip(newShip);

            // Assert
            Assert.IsFalse(success);
            Assert.AreEqual(1, board.ShipCount);
        }

        [Test]
        public void GivenAShipIsOnBoard_WhenANonOverLappingShipIsAdded_ThenAdditionRequestIsSuccessful()
        {
            // Arrange
            var ship = TestHelper.GetHorizontalShip();
            var newShip = TestHelper.GetNonOverlappingVerticalShip();
            var board = new Board(TestHelper.BoardWidth, TestHelper.BoardHeight);
            board.AddShip(ship);

            // Act
            var success = board.AddShip(newShip);

            // Assert
            Assert.IsTrue(success);
            Assert.AreEqual(2, board.ShipCount);
        }

        [Test]
        public void GivenShipsAreOnBoard_WhenTheBoardIsAttackedAndNoShipIsHit_ThenAMissIsReported()
        {
            // Arrange
            var ship = TestHelper.GetHorizontalShip();
            var newShip = TestHelper.GetNonOverlappingVerticalShip();
            var board = new Board(TestHelper.BoardWidth, TestHelper.BoardHeight);
            board.AddShip(ship);
            board.AddShip(newShip);

            // Act
            var wasAHit = board.AttackCell(9, 9);

            // Assert
            Assert.IsFalse(wasAHit);
        }

        [Test]
        public void GivenShipsAreOnBoard_WhenTheBoardIsAttackedAndAShipIsHit_ThenAHitIsReported()
        {
            // Arrange
            var horizontalShip = TestHelper.GetHorizontalShip();
            var verticalShip = TestHelper.GetNonOverlappingVerticalShip();
            var board = new Board(TestHelper.BoardWidth, TestHelper.BoardHeight);
            board.AddShip(horizontalShip);
            board.AddShip(verticalShip);

            var horizontalShipWasHit = false;
            var verticalShipWasHit = false;

            // Act
            foreach (var cell in horizontalShip.GetAllShipCells())
            {
                horizontalShipWasHit = board.AttackCell(cell.x, cell.y);
                if (!horizontalShipWasHit) break;
            }

            foreach(var cell in verticalShip.GetAllShipCells())
            {
                verticalShipWasHit = board.AttackCell(cell.x, cell.y);
                if (!verticalShipWasHit) break;
            }

            // Assert
            Assert.IsTrue(horizontalShipWasHit);
            Assert.IsTrue(verticalShipWasHit);
        }


        [Test]
        public void GivenABoard_WhenAShipIsAddedThatDoesntFit_ThenAdditionRequestIsDeclined()
        {
            // Arrange
            var ship = TestHelper.GetOutOfBoundsShip();
            var board = new Board(TestHelper.BoardWidth, TestHelper.BoardHeight);

            // Act
            var success = board.AddShip(ship);

            // Assert
            Assert.IsFalse(success);
        }
    }
}
