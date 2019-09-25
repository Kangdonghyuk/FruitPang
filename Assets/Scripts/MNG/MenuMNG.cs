using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuMNG : MonoBehaviour
{
    public Button startBtn;
    public Button rankBtn;

    public GameObject rankPanel;

    void Awake() {
        if(SystemMNG.I == null)
            Instantiate(Resources.Load("Prefabs/System/SystemMNG"));
    }

    void Start()
    {
        rankPanel.transform.localPosition = Vector3.right * 1500;
    }

    void Update()
    {
        
    }

    public void GameScene() {
        SystemMNG.I.LoadScene("GameScene");
    }

    public void ShowRankPanel() {
        rankPanel.transform.localPosition = Vector3.zero;
        startBtn.interactable = false;
        rankBtn.interactable = false;
    }

    public void CloseRankPanel() {
        rankPanel.transform.localPosition = Vector3.right * 1500;
        startBtn.interactable = true;
        rankBtn.interactable = true;
    }
}
