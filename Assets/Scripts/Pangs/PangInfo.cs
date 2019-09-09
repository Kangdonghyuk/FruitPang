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

    public readonly static Sprite[] pangImageList = new Sprite[9] {
        Resources.Load<Sprite>("Image/Pang/0") as Sprite,
        Resources.Load<Sprite>("Image/Pang/1") as Sprite,
        Resources.Load<Sprite>("Image/Pang/2") as Sprite,
        Resources.Load<Sprite>("Image/Pang/3") as Sprite,
        Resources.Load<Sprite>("Image/Pang/4") as Sprite,
        Resources.Load<Sprite>("Image/Pang/5") as Sprite,
        Resources.Load<Sprite>("Image/Pang/6") as Sprite,
        Resources.Load<Sprite>("Image/Pang/7") as Sprite,
        Resources.Load<Sprite>("Image/Pang/8") as Sprite
    };

    public readonly static Sprite[] pangEfectList = new Sprite[4] {
        Resources.Load<Sprite>("Image/Pang/PangEfect1") as Sprite,
        Resources.Load<Sprite>("Image/Pang/PangEfect2") as Sprite,
        Resources.Load<Sprite>("Image/Pang/PangEfect3") as Sprite,
        Resources.Load<Sprite>("Image/Pang/PangEfect4") as Sprite
    };
}
