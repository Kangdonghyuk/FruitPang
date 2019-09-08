using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMNG : MonoBehaviour
{
    public Slider timeBar;
    public Text scoreText;
    public Text overScoreText;
    public Transform pausePanel;
    public Transform overPanel;

    void Start()
    {
        pausePanel.localPosition = Vector3.right * 1500;
        overPanel.localPosition = Vector3.left * 1500;
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

    public void ShowOverPanel() {
        overScoreText.text = scoreText.text;
        overPanel.localPosition = Vector3.zero;
        SystemMNG.I.rankScore = int.Parse(overScoreText.text);
    }
}
