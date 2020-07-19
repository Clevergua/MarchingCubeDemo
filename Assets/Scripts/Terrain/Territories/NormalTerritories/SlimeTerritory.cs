using UnityEngine;
using System.Collections;
namespace Terrain
{
    internal class SlimeTerritory : NormalTerritory
    {
        public override int Range { get { return 32; } }
    }
}