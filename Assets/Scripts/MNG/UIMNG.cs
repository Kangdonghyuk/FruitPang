using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMNG : MonoBehaviour
{
    public Slider timeBar;
    public Text scoreText;
    public Transform pausePanel;

    void Start()
    {
        pausePanel.localPosition = Vector3.right * 1500;
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

    public void ShowPausePanel(bool isShow) {
        if(isShow == true)
            pausePanel.localPosition = Vector3.zero;
        else if(isShow == false)
            pausePanel.localPosition = Vector3.right * 1500;
    }
}
