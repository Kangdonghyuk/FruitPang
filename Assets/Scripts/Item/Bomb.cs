using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    void OnMouseDown() {
        PangMatchChecker.I.Boom(transform.position);

        Destroy(gameObject);
    }
}
