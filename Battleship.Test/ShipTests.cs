using NUnit.Framework;

namespace Battleship.Test
{
    public class ShipTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenAShipIsOnBoard_WhenBoardIsAttackedOnAShipsHead_ThenShipIsAttacked()
        {
            // Arrange
            var ship = TestHelper.GetHorizontalShip();

            // Act
            var wasHit = ship.IsHit(2, 1);

            // Assert
            Assert.IsTrue(wasHit);
        }

        [Test]
        public void GivenAHorizontalShipIsOnBoard_WhenBoardIsAttackedOnACellThatBelongsToTheShip_ThenShipIsAttacked()
        {
            // Arrange
            var ship = TestHelper.GetHorizontalShip();

            // Act
            var wasHit = ship.IsHit(3, 1);

            // Assert
            Assert.IsTrue(wasHit);
        }

        [Test]
        public void GivenAVerticalShipIsOnBoard_WhenBoardIsAttackedOnACellThatBelongsToTheShip_ThenShipIsAttacked()
        {
            // Arrange
            var ship = TestHelper.GetVerticalShip();

            // Act
            var wasHit = ship.IsHit(2, 2);

            // Assert
            Assert.IsTrue(wasHit);
        }

        [Test]
        public void GivenAHorizontalShipIsOnBoard_WhenLoopThroughShipCells_ThenShipCellsCoordinatesAreCalculatedCorrectly()
        {
            // Arrange
            var ship = TestHelper.GetHorizontalShip();
            int i = 0;

            // Assert
            foreach (var cell in ship.GetAllShipCells())
            {
                Assert.AreEqual(cell.y, 1);
                Assert.AreEqual(cell.x, 2 + i++);
            }
        }

        [Test]
        public void GivenAVerticalShipIsOnBoard_WhenLoopThroughShipCells_ThenShipCellsCoordinatesAreCalculatedCorrectly()
        {
            // Arrange
            var ship = TestHelper.GetVerticalShip();
            int i = 0;

            // Assert
            foreach (var cell in ship.GetAllShipCells())
            {
                Assert.AreEqual(cell.x, 2);
                Assert.AreEqual(cell.y, 1 + i++);
            }
        }
    }
}