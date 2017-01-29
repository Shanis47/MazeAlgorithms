using MazeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeBuilder
{
    public delegate void BuildingAlgorithm(MazeMap map);

    public class MazeBuilder
    {
        public BuildingAlgorithm Algorithm { get; set; }

        public MazeMap BuildMaze(UInt32 width, UInt32 height)
        {
            var map = new MazeMap(width, height);

            Algorithm?.Invoke(map);

            return map;
        }
    }
}
