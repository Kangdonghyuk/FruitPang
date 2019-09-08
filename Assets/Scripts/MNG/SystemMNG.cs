using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemMNG : MonoBehaviour
{
    public static SystemMNG I = null;

    public int rankScore = 0;

    void Awake() {
        if(I == null) {
            I = this;

            DontDestroyOnLoad(this);
        }
    }

    void Start()
    {
        if(SceneManager.GetActiveScene().name == "StartScene")
            SceneManager.LoadScene("MenuScene");
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
            SceneManager.LoadScene("StartScene");
        if(Input.GetKeyDown(KeyCode.Alpha2))
            SceneManager.LoadScene("MenuScene");
        if(Input.GetKeyDown(KeyCode.Alpha3))
            SceneManager.LoadScene("GameScene");

        if(Input.GetKeyUp(KeyCode.Escape)) {
            string nowSceneName = SceneManager.GetActiveScene().name;
            if(nowSceneName == "MenuScene")
                Application.Quit();
            else if(nowSceneName == "GameScene")
                GameMNG.I.PauseBtn();
        }
    }

    public void LoadScene(string loadScene) {
        SceneManager.LoadScene(loadScene);
    }
}
