using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleship.Domain.Data
{
    public enum Orientation
    {
        Horizontal, 
        Vertical
    }

    public class Ship
    {
        private int _length;
        private int _startX;
        private int _startY;
        private Orientation _orientation;

        public Ship(int x, int y, int length, Orientation orientation)
        {
            _startX = x;
            _startY = y;
            _length = length;
            _orientation = orientation;
        }

        public bool IsHit(int x, int y)
        {
            for (var i = 0; i < _length; i++)
            {
                if ((_orientation == Orientation.Vertical && x == _startX && y == i + _startY)
                   ||
                   (_orientation == Orientation.Horizontal && x == _startX + i && y == _startY))
                   return true;
            }

            return false;
        }

        public IEnumerable<ShipCell> GetAllShipCells()
        {
            int i = 0;

            if (_orientation == Orientation.Horizontal)
            {
                while (i < _length)
                {
                    yield return new ShipCell() { x = i++ + _startX, y = _startY }; 
                }
            }
            if (_orientation == Orientation.Vertical)
            {
                while (i < _length)
                {
                    yield return new ShipCell() { x = _startX, y = i++ + _startY };
                }
            }
        }

        // Below is only for debugging, so that the ship cells show up nicely in API responses.
        // There is no need for them in current requirements.
        public ShipCell[] AllShipCells => GetAllShipCells().ToArray();

     }

    public class ShipCell
    {
        public int x { get; set; }
        public int y { get; set; }
    }
}
