using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float delta = 0;
    public float animLength = 0;

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.animLength) {
            this.delta = 0;
            Destroy(this.gameObject);
        }
    }
}
