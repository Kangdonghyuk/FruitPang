using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    Vector3 scale;
    public TextMesh text;

    int combo;

    void Start() {
        combo = 0;
    }

    void Update()
    {
        if(transform.localScale.x >= 0.05f) {
            float xScale = Mathf.Lerp(transform.localScale.x, 0f, 0.02f);
            transform.localScale = new Vector3(xScale, xScale, 0.5f);
            if(xScale < 0.05f) {
                transform.localScale = Vector3.zero;
                combo = 0;
            }
        }
    }

    public void SetCombo(int combo) {
        text.text = combo.ToString();
        transform.localScale = new Vector3(1.0f, 1.0f, 0.5f);
    }

    public int AddCombo() {
        combo+=1;

        text.text = combo.ToString();
        transform.localScale = new Vector3(1.0f, 1.0f, 0.5f);

        return combo;
    }
}
