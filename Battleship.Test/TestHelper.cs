using Battleship.Domain.Data;

namespace Battleship.Test
{
    public class TestHelper
    {
        public const int BoardWidth = 10;
        public const int BoardHeight = 10;

        public static Ship GetHorizontalShip()
        {
            return new Ship(2, 1, 3, Orientation.Horizontal);
        }

        public static Ship GetVerticalShip()
        {
            return new Ship(2, 1, 3, Orientation.Vertical);
        }

        public static Ship GetNonOverlappingVerticalShip()
        {
            return new Ship(4, 3, 4, Orientation.Vertical);
        }

        public static Ship GetOutOfBoundsShip()
        {
            return new Ship(8, 2, 12, Orientation.Horizontal);
        }
    }
}
