using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemMNG : MonoBehaviour
{
    public static SystemMNG I = null;

    public int rankScore = 0;

    void Awake() {
        DontDestroyOnLoad(this);
        if(I == null)
            I = this;
        else
            Destroy(gameObject);

        Screen.SetResolution(Screen.width, Screen.width * 18 / 9, true);
    }

    void Start()
    {
        if(SceneManager.GetActiveScene().name == "StartScene")
            StartCoroutine(LogoScene());
    }

    IEnumerator LogoScene() {
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("LogoScene");
    }

    IEnumerator MenuScene() {
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("MenuScene");
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "LogoScene")
            StartCoroutine(MenuScene());

        if(Input.GetKeyDown(KeyCode.Alpha1))
            SceneManager.LoadScene("StartScene");
        if(Input.GetKeyDown(KeyCode.Alpha2))
            SceneManager.LoadScene("MenuScene");
        if(Input.GetKeyDown(KeyCode.Alpha3))
            SceneManager.LoadScene("GameScene");

        if(Input.GetKeyUp(KeyCode.Escape)) {
            if(SceneManager.GetActiveScene().name == "MenuScene")
                Application.Quit();
        }
    }

    public void LoadScene(string loadScene) {
        SceneManager.LoadScene(loadScene);
    }
}
