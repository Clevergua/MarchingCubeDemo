using System.Collections;
using NUnit.Framework;
using Terrain;
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
            var terrainGenerator = new TerrainGenerator();
            var temperateLayer = new TemperateLayer();
            Biome tropicalLayer = new TropicalLayer();
            var layer = terrainGenerator.CreateLayer(0, 16, temperateLayer);
            var a = Vector3.one * 6;
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
