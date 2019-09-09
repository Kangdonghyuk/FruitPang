using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RankPanel : MonoBehaviour
{
    Text[] rankText = new Text[5];
    int[] rankScore = new int[6];

    void Awake() {
        for(int index = 0; index < 5; index++) {
            rankText[index] = transform.GetChild(index).GetComponent<Text>();
            rankScore[index] = 0;
        }
        rankScore[5] = 0;
    }

    void Start()
    {
        PlayerPrefs.GetInt("score1", 0);

        for(int index = 0; index < 5; index++) {
            rankText[index].text = PlayerPrefs.GetInt("save_score_" + index.ToString(), 0).ToString();
            rankScore[index] = int.Parse(rankText[index].text);
        }

        rankScore[5] = SystemMNG.I.rankScore;
        SystemMNG.I.rankScore = 0;

        Array.Sort(rankScore);
        Array.Reverse(rankScore);

        for(int index = 0; index < 5; index++) {
            rankText[index].text = rankScore[index].ToString();
            PlayerPrefs.SetInt("save_score_"+index.ToString(), rankScore[index]);
        }

        PlayerPrefs.Save();
    }


    void Update()
    {
        
    }
}
