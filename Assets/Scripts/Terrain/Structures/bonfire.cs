using Core;
using System;

namespace Terrain
{
    internal class Bonfire : DataDrivenStructure
    {
        byte[,,] bonfire;
        public override void InitilazeData(byte[,,] data)
        {
            bonfire = data ?? throw new ArgumentNullException();
        }
        internal StructureData GetData()
        {
            return new StructureData(bonfire);
        }
    }

}