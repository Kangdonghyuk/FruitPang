using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemMNG : MonoBehaviour
{
    public static SystemMNG I = null;

    void Awake() {
        if(I == null) {
            I = this;

            DontDestroyOnLoad(this);
        }
    }

    void Start()
    {
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
    }

    public void LoadScene(string loadScene) {
        SceneManager.LoadScene(loadScene);
    }
}
