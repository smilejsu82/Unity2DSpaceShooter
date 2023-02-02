using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum eType { 
        None = -1, 
        Small = 0,
        Midium,
        Big
    }

    [SerializeField]
    private float speed = 1f;

    public int score;

    void Update()
    {
        this.transform.Translate(Vector3.down * this.speed * Time.deltaTime);
        if (this.transform.position.y < -1.677f) {
            Destroy(this.gameObject);
        }
    }
}
