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

    private IslandGenerator generator;
    private Task<Island> task;
    // Start is called before the first frame update
    void Start()
    {
        seed = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
        generator = new IslandGenerator();
        task = Task.Run(() =>
        {
            return generator.GenerateAsync(seed, 4);
        });
    }
    private void Update()
    {
        text.text = $"{generator.currentOperation}";
        if (task != null && task.IsCompleted)
        {
            islandView.Init(task.Result, block2Color);
            task = null;
        }
    }
}
