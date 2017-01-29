using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeCommon
{
    public class MazeMap
    {
        public UInt32 Width { get; private set; }
        public UInt32 Height { get; private set; }
        public Room this[UInt32 x, UInt32 y]
        {
            get { return _rooms[y, x].Clone() as Room; }
            private set
            {
                if (CheckCorrect(value, x, y))
                {
                    _rooms[y, x] = value;
                    ModifyNeighbors(x, y);
                }
            }
        }

        private Room[,] _rooms;

        public MazeMap(UInt32 width, UInt32 height)
        {
            Width = width;
            Height = height;
            _rooms = new Room[Height, Width];
            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Width; j++)
                    _rooms[i, j] = new Room;
        }

        private bool CheckCorrect(Room room, uint x, uint y)
        {
            return ((x == 0 && room.LeftWall) || (x == Width - 1 && room.RightWall) || (x > 0 && x < Width - 1))
                && ((y == 0 && room.TopWall) || (y == Height - 1 && room.BottomWall) || (y > 0 && y < Height - 1));
        }

        private void ModifyNeighbors(uint x, uint y)
        {
            if (x > 0)
                _rooms[y, x - 1].RightWall = _rooms[y, x].LeftWall;
            else if (x < Width - 1)
                _rooms[y, x + 1].LeftWall = _rooms[y, x].RightWall;

            if (y > 0)
                _rooms[y - 1, x].BottomWall = _rooms[y, x].TopWall;
            else if (y < Height - 1)
                _rooms[y + 1, x].TopWall = _rooms[y, x].BottomWall;
        }
    }
}
