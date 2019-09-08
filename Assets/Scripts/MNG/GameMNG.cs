using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMNG : MonoBehaviour
{
    public static GameMNG I;
    UIMNG uiMNG;

    public float lifeTime;
    public float nowTime;

    bool isPlay;

    void Awake() {
        if(SystemMNG.I == null)
            Instantiate(Resources.Load("Prefabs/System/SystemMNG"));

        I = this;

        uiMNG = GetComponent<UIMNG>();
    }

    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 60f;
        nowTime = lifeTime;

        isPlay = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(nowTime > 0f) {
            nowTime -= Time.deltaTime;

            uiMNG.SetTimeBarValue(nowTime / lifeTime);
        }
    }
    
    public void PauseBtn() {
        isPlay = !isPlay;

        if(isPlay == true)
            Time.timeScale = 1.0f;
        else
            Time.timeScale = 0.0f;

        uiMNG.ShowPausePanel(!isPlay);
    }

    public void AddScore(int score) {
        uiMNG.AddScore(score);
    }

    public void MenuScene() {
        Time.timeScale = 1.0f;
        SystemMNG.I.LoadScene("MenuScene");
    }
}
