using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMNG : MonoBehaviour
{
    public Slider timeBar;
    public Text scoreText;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetTimeBarValue(float value) {
        timeBar.value = value;
    }

    public void AddScore(int score) {
        scoreText.text = (int.Parse(scoreText.text) + score).ToString();
    }
}
