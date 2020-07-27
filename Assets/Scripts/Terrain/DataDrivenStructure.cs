using Terrain;

namespace Terrain
{
    internal abstract class DataDrivenStructure : Structure
    {
        public abstract void InitilazeData(byte[,,] data);
    }
}
