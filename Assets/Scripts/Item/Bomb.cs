using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    void OnMouseDown() {
        if(Time.timeScale == 0.0f)
            return ;

        PangMatchChecker.I.Boom(transform.position);

        Destroy(gameObject);
    }
}
