using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMNG : MonoBehaviour
{
    void Awake() {
        if(SystemMNG.I == null)
            Instantiate(Resources.Load("Prefabs/System/SystemMNG"));
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GameScene() {
        SystemMNG.I.LoadScene("GameScene");
    }
}
