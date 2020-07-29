using System.Collections;
using Core;
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
            var folderPath = System.IO.Path.Combine(Application.streamingAssetsPath, "StructureData");
            Debug.Log(folderPath);
        }


        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator 测试二维噪声概率()
        {
            var sampleCount = 10000;
            var density = 0.0007f;
            var range2Count = new int[10];
            var min = 0f;
            var max = 0f;
            for (int x = 0; x < sampleCount; x++)
            {
                for (int y = 0; y < sampleCount; y++)
                {
                    var value = PerlinNoise.PerlinNoise2D(Random.Range(int.MinValue, int.MaxValue), x * density, y * density) * 1.5789f;
                    var t = (value * value);
                    value *= 1.4f - 0.4f * t;
                    if (value < -0.8f)
                    {
                        range2Count[0] += 1;
                    }
                    else if (value < -0.6f)
                    {
                        range2Count[1] += 1;
                    }
                    else if (value < -0.4f)
                    {
                        range2Count[2] += 1;
                    }
                    else if (value < -0.2f)
                    {
                        range2Count[3] += 1;
                    }
                    else if (value < 0f)
                    {
                        range2Count[4] += 1;
                    }
                    else if (value < 0.2f)
                    {
                        range2Count[5] += 1;
                    }
                    else if (value < 0.4f)
                    {
                        range2Count[6] += 1;
                    }
                    else if (value < 0.6f)
                    {
                        range2Count[7] += 1;
                    }
                    else if (value < 0.8f)
                    {
                        range2Count[8] += 1;
                    }
                    else
                    {
                        range2Count[9] += 1;
                    }
                    min = value < min ? value : min;
                    max = value > max ? value : max;
                }
                yield return null;
            }
            for (int i = 0; i < range2Count.Length; i++)
            {
                Debug.Log($"{i}阶段数量:{range2Count[i]}:占比:{(float)range2Count[i] / (sampleCount * sampleCount) * 100}%");
            }
            Debug.Log($"Min:{min}, Max:{max}");
        }
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator 测试二维随机数()
        {
            var sampleCount = 100;
            var range2Count = new int[10];
            for (int x = 0; x < sampleCount; x++)
            {
                for (int y = 0; y < sampleCount; y++)
                {
                    var r = RNG.Random2(x, y, Random.Range(int.MinValue, int.MaxValue));
                    var value = r % 50 + 50;

                    if (value < 10)
                    {
                        range2Count[0] += 1;
                    }
                    else if (value < 20)
                    {
                        range2Count[1] += 1;
                    }
                    else if (value < 30)
                    {
                        range2Count[2] += 1;
                    }
                    else if (value < 40)
                    {
                        range2Count[3] += 1;
                    }
                    else if (value < 50)
                    {
                        range2Count[4] += 1;
                    }
                    else if (value < 60)
                    {
                        range2Count[5] += 1;
                    }
                    else if (value < 70)
                    {
                        range2Count[6] += 1;
                    }
                    else if (value < 80)
                    {
                        range2Count[7] += 1;
                    }
                    else if (value < 90)
                    {
                        range2Count[8] += 1;
                    }
                    else
                    {
                        range2Count[9] += 1;
                    }
                }
            }
            yield return null;

            for (int i = 0; i < range2Count.Length; i++)
            {
                Debug.Log($"{i}阶段数量:{range2Count[i]}:占比:{(float)range2Count[i] / (sampleCount * sampleCount) * 100}%");
            }
        }

        [UnityTest]
        public IEnumerator 测试三维随机数()
        {
            var sampleCount = 1000;
            var range2Count = new int[10];
            for (int x = 0; x < sampleCount; x++)
            {
                for (int y = 0; y < 256; y++)
                {
                    for (int z = 0; z < sampleCount; z++)
                    {
                        var r = RNG.Random3(x, y, z, 3254);
                        var value = r % 50 + 50;

                        if (value < 10)
                        {
                            range2Count[0] += 1;
                        }
                        else if (value < 20)
                        {
                            range2Count[1] += 1;
                        }
                        else if (value < 30)
                        {
                            range2Count[2] += 1;
                        }
                        else if (value < 40)
                        {
                            range2Count[3] += 1;
                        }
                        else if (value < 50)
                        {
                            range2Count[4] += 1;
                        }
                        else if (value < 60)
                        {
                            range2Count[5] += 1;
                        }
                        else if (value < 70)
                        {
                            range2Count[6] += 1;
                        }
                        else if (value < 80)
                        {
                            range2Count[7] += 1;
                        }
                        else if (value < 90)
                        {
                            range2Count[8] += 1;
                        }
                        else
                        {
                            range2Count[9] += 1;
                        }
                    }

                }
            }
            yield return null;

            for (int i = 0; i < range2Count.Length; i++)
            {
                Debug.Log($"{i}阶段数量:{range2Count[i]}:占比:{(float)range2Count[i] / (sampleCount * sampleCount * 256) * 100}%");
            }
        }

        [UnityTest]
        public IEnumerator 测试三维噪声概率()
        {
            var sampleCount = 1000;
            var density = 0.007f;
            var range2Count = new int[10];
            var min = 0f;
            var max = 0f;
            var seed = 0;
            for (int x = 0; x < sampleCount; x++)
            {
                for (int y = 0; y < 256; y++)
                {
                    for (int z = 0; z < sampleCount; z++)
                    {
                        var value = PerlinNoise.PerlinNoise3D(seed, x * density, y * density, z * density) ;
                        //var t = (value * value);
                        //value *= 1.4f - 0.4f * t;
                        if (value < -0.8f)
                        {
                            range2Count[0] += 1;
                        }
                        else if (value < -0.6f)
                        {
                            range2Count[1] += 1;
                        }
                        else if (value < -0.4f)
                        {
                            range2Count[2] += 1;
                        }
                        else if (value < -0.2f)
                        {
                            range2Count[3] += 1;
                        }
                        else if (value < 0f)
                        {
                            range2Count[4] += 1;
                        }
                        else if (value < 0.2f)
                        {
                            range2Count[5] += 1;
                        }
                        else if (value < 0.4f)
                        {
                            range2Count[6] += 1;
                        }
                        else if (value < 0.6f)
                        {
                            range2Count[7] += 1;
                        }
                        else if (value < 0.8f)
                        {
                            range2Count[8] += 1;
                        }
                        else
                        {
                            range2Count[9] += 1;
                        }
                        min = value < min ? value : min;
                        max = value > max ? value : max;
                    }
                }
                yield return null;
            }
            for (int i = 0; i < range2Count.Length; i++)
            {
                Debug.Log($"{i}阶段数量:{range2Count[i]}:占比:{(float)range2Count[i] / (sampleCount * sampleCount) * 100}%");
            }
            Debug.Log($"Min:{min}, Max:{max}");
        }
    }
}
