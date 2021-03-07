using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Domain.Data
{
    public class Cell
    {
        public bool Attacked { get; set; }

        public Cell()
        {
            Attacked = false;
        }
    }
}
