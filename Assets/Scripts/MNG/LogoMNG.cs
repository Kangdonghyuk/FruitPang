using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoMNG : MonoBehaviour
{

    Transform[] logoList = new Transform[9];

    void Awake() {
        for(int i=0; i<9; i++) {
            logoList[i] = transform.GetChild(i);
            logoList[i].gameObject.SetActive(false);
        }
    }

    void Start()
    {  
        StartCoroutine(ShowLogo());
    }

    IEnumerator ShowLogo() {
        int index = 0;
        while(index < 9) {
            yield return new WaitForSeconds(0.24f);

            logoList[index].gameObject.SetActive(true);
            logoList[index].position = new Vector3(-2f + ((index%4) * 1f), 4.6f, 0f);

            index += 1;
        }

        yield return new WaitForSeconds(1.5f);

        SystemMNG.I.LoadScene("MenuScene");
    }
}
