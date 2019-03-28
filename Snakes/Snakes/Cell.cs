namespace Snakes
{
    class Cell
    {
        public CellType Type { get; }

        public Cell(char type)
        {
            switch (type)
            {
                case ' ':
                    Type = CellType.Empty;
                    break;
                case '#':
                    Type = CellType.Stone;
                    break;
                case '%':
                    Type = CellType.Food;
                    break;
            }
        }
    }
}