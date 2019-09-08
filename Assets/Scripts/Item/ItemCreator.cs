using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreator : MonoBehaviour
{
    public static ItemCreator I;
    public GameObject bombPrefab;

    void Awake() {
        I = this;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            CreateItem();
        }
    }

    public void CreateItem() {
        Instantiate(bombPrefab, new Vector3(Random.Range(-2.08f, 2.09f), 3.3f, 0f), Quaternion.identity);
    }
}
