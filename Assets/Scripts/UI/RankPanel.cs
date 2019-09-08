using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RankPanel : MonoBehaviour
{
    Text[] rankText = new Text[8];
    int[] rankScore = new int[8];

    void Awake() {
        for(int index = 0; index < 8; index++)
            rankText[index] = transform.GetChild(index).GetComponent<Text>();
    }

    void Start()
    {
        for(int index = 0; index < 8; index++)
            rankScore[index] = int.Parse(rankText[index].text);

        Array.Sort(rankScore);
        Array.Reverse(rankScore);

        for(int index = 0; index < 8; index++)
            rankText[index].text = rankScore[index].ToString();
    }


    void Update()
    {
        
    }
}
