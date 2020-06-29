using System;
using UnityEngine;

[Serializable]
public class BlockViewData
{
    [SerializeField]
    private Color color;
    [SerializeField]
    private Material material;

    public BlockViewData(Color color, Material material)
    {
        this.color = color;
        this.material = material ?? throw new ArgumentNullException(nameof(material));
    }
    public Color Color { get { return color; } }
    public Material Material { get { return material; } }
}