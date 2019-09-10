using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitMNG : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(Quit());
    }

    IEnumerator Quit() {
        yield return new WaitForSeconds(1.0f);

        Application.Quit();
    }
}
