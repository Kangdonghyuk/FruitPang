using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PangInfo
{
    public readonly static int PANG_MAX = 40;
    public readonly static int TYPE_MAX = 9;

    public readonly static Color[] colorList = new Color[9] {
        Color.white, Color.yellow, Color.red, Color.blue,
        Color.gray, Color.green, Color.magenta, Color.cyan, new Color(1.0f, 0.5f, 0f)
    };
}
