using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TerrainTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void TerrainTestSimplePasses()
        {
            var terrainSys = new TerrainSystem();
            var temperateLayer = new TemperateLayer();
            Biome tropicalLayer = new TropicalLayer();
            var layer = terrainSys.CreateLayer(0, 16, 4, 16, temperateLayer);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TerrainTestWithEnumeratorPasses()
        {
            yield return null;
        }
    }
}
