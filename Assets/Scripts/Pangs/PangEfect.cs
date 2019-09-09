using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PangEfect : MonoBehaviour
{
    SpriteRenderer spRenderer;

    void Awake() {
        spRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        StartCoroutine(DrawAnimation());
    }

    IEnumerator DrawAnimation() {
        int count = 1;

        while(count < 5) {
            yield return new WaitForSeconds(0.05f);

            spRenderer.sprite = PangInfo.pangEfectList[count-1];

            count += 1;
        }

        Destroy(gameObject);
    }
}
