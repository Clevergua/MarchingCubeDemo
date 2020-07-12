namespace Terrain
{
    internal class Path
    {
        private Territory departure;
        private Territory destination;

        public Territory Departure { get => departure; }
        public Territory Destination { get => destination; }

        public Path(Territory departure, Territory destination)
        {
            this.departure = departure;
            this.destination = destination;
        }


    }
}