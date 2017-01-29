using System;

namespace MazeCommon
{
    public class Room: ICloneable
    {
        public bool TopWall { get; set; }
        public bool BottomWall { get; set; }
        public bool LeftWall { get; set; }
        public bool RightWall { get; set; }

        public Room()
        {
            TopWall = BottomWall = LeftWall = RightWall = true;
        }

        public object Clone()
        {
            return new Room
            {
                TopWall = TopWall,
                BottomWall = BottomWall,
                LeftWall = LeftWall,
                RightWall = RightWall
            };
        }
    }
}