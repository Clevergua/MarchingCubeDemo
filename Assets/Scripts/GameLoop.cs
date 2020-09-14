using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Terrain;
using UnityEngine;
using UnityEngine.UI;

public class GameLoop : MonoBehaviour
{
    [SerializeField]
    private int seed;
    [SerializeField]
    private Text text;
    [SerializeField]
    private List<Color> block2Color;
    [SerializeField]
    private IslandView islandView;

    // Start is called before the first frame update
    async void Start()
    {
        seed = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
        var generator = new IslandGenerator();
        var island = await generator.GenerateAsync(seed, 16);
        islandView.Init(island, block2Color);
    }
    private void Update()
    {
    }
}
