using Core;
using System.Collections.Generic;

namespace Terrain
{
    internal class Path
    {
        private Territory departure;
        private Territory destination;
        private IReadOnlyList<Coord2Int> coords;

        public Territory Departure { get => departure; }
        public Territory Destination { get => destination; }
        public IReadOnlyList<Coord2Int> Coords { get => coords; }
        public Path(Territory departure, Territory destination, IReadOnlyList<Coord2Int> coords)
        {
            this.departure = departure;
            this.destination = destination;
            this.coords = coords;
        }
    }
}