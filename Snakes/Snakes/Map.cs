using System;
using System.Collections.Generic;
using System.Linq;

namespace Snakes
{
    class Map
    {
        public Cell[,] Layout { get; }

        public Map(string[] lines)
        {
            lines.Select(line => line.Select(sym => new Cell(sym)));
        }
    }
}