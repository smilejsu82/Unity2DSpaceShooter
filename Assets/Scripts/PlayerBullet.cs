using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private float speed = 1;
    public System.Action<Vector3> onExplode;

    void Update()
    {
        this.transform.Translate(this.transform.up * this.speed * Time.deltaTime);
        if (this.transform.position.y > 1.637f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy") {

            this.onExplode(collision.gameObject.transform.position);

            var director = GameObject.FindObjectOfType<GameDirector>();
            var enemy = collision.gameObject.GetComponent<Enemy>();
            director.UpdateScore(enemy.score);

            Destroy(collision.gameObject);
            Destroy(this.gameObject);

        }
    }
}
