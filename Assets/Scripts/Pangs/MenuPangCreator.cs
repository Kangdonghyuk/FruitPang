using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPangCreator : MonoBehaviour
{
    public GameObject pangPrefab;

    void Start()
    {
        StartCoroutine(CreatePang());
    }

    IEnumerator CreatePang() {
        while(true) {
            GameObject newPang = Instantiate(pangPrefab, transform.position, Quaternion.identity, transform);

            yield return new WaitForSeconds(0.4f);

            newPang.GetComponent<Pang>().Create(1, 5f);
        }
    }
}
