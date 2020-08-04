using Core;
using System.Collections.Generic;

namespace Terrain
{
    internal class Path
    {
        private Structure departure;
        private Structure destination;
        private IReadOnlyList<Coord2Int> coords;

        public Structure Departure { get => departure; }
        public Structure Destination { get => destination; }
        public IReadOnlyList<Coord2Int> Coords { get => coords; }
        public Path(Structure departure, Structure destination, IReadOnlyList<Coord2Int> coords)
        {
            this.departure = departure;
            this.destination = destination;
            this.coords = coords;
        }
    }
}