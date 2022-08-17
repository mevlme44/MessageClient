
using System.Collections.Generic;
using UnityEngine;

public class ColorsGiver : MonoSingleton<ColorsGiver>
{
    public List<Color> Colors = new List<Color>();
    public Color OwnMessageColor, DefaultMessageColor;
    public Color RandomColor => Colors[Random.Range(0, Colors.Count)];
}
