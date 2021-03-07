using System;
using System.Collections.Generic;

namespace Battleship.Domain.Data
{
    public class Board
    {
        private readonly int _width;
        private readonly int _height;

        private readonly Cell[,] _cells;
        private readonly IList<Ship> _ships;

        public Board(int width, int height)
        {
            _width = width;
            _height = height;

            _cells = new Cell[_width, _height];

            for (var i = 0; i < _width; i++)
                for (var j = 0; j < _height; j++)
                    _cells[i, j] = new Cell();

            _ships = new List<Ship>();

            BoardId = Guid.NewGuid();
        }

        public bool AttackCell(int x, int y)
        {
            _cells[x, y].Attacked = true;
            
            foreach (var ship in _ships)
            {
                if (ship.IsHit(x, y)) return true;
            }
            
            return false;
        }

        public bool AddShip(Ship newShip)
        {
            if (OverlapsWithAnotherShip(newShip)) return false;
            if (!WithinBounds(newShip)) return false;
            _ships.Add(newShip);
            return true;
        }

        private bool WithinBounds(Ship ship)
        {
            foreach (var newShipCell in ship.GetAllShipCells())
            {
                if (newShipCell.x > _width || newShipCell.y == _height)
                {
                    return false;
                }
            }

            return true;
        }
        private bool OverlapsWithAnotherShip(Ship ship)
        {
            foreach (var existingShip in _ships)
            {
                foreach (var existingShipCell in existingShip.GetAllShipCells())
                {
                    foreach (var newShipCell in ship.GetAllShipCells())
                    {
                        if (existingShipCell.x == newShipCell.x && existingShipCell.y == newShipCell.y)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
        public int ShipCount
        {
            get
            {
                return _ships.Count;
            }
        }

        public Guid BoardId { get; set; } 

        public Ship[] Ships
        {
            get
            {
                return (_ships as List<Ship>).ToArray();
            }
        }

        public Cell[,] Cells
        {
            get
            {
                return _cells;
            }
        }
    }
}
