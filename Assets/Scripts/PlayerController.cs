using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject explosionPrefab;

    private float reloadTime = 0.7f;
    private float delta;
    private bool isReloaded = false;
    private bool isImmotal = false;
    private float immotalTime = 2f;
    private SpriteRenderer sr;
    private bool isImmotalMoving = false;

    public System.Action onDie;


    void Start()
    {
        this.sr = this.GetComponent<SpriteRenderer>();
        this.isReloaded = true;
        
    }

    void Update()
    {
        float dirx = 0;
        float diry = 0;
        if (!this.isImmotalMoving) {
            dirx = Input.GetAxisRaw("Horizontal");  //반환 타입 float 
            diry = Input.GetAxisRaw("Vertical");
        }
        var dir = new Vector3(dirx, diry, 0);
        
        this.transform.Translate(dir.normalized * 1f * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && !isImmotalMoving)
        {
            if (this.isReloaded)
            {
                //총알 발사 
                this.Shoot();
                this.isReloaded = false;
            }
            else 
            {
                Debug.Log("재 장전 중");
            }
        }

        if (this.isReloaded == false) {
            this.delta += Time.deltaTime;
            if (this.delta > this.reloadTime) {
                this.delta = 0;
                this.isReloaded = true;
                Debug.Log("재 장전 완료");
            }
        }
    }

    private void Shoot()
    {
        //총알 생성 
        var bulletGo = Instantiate(this.bulletPrefab);
        bulletGo.transform.position = this.transform.position;

        var bullet = bulletGo.GetComponent<PlayerBullet>();
        bullet.onExplode = (tpos) => {
            var fx = Instantiate(this.explosionPrefab);
            fx.transform.position = tpos;
        };
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.isImmotal) return;   //무적이면 충돌 안함 

        if (collision.gameObject.tag == "Enemy") {
            //Destroy(this.gameObject);
            //die 
            this.onDie();

            var fx = Instantiate(this.explosionPrefab);
            fx.transform.position = this.transform.position;

            this.StartCoroutine(this.Immotal());
            this.StartCoroutine(this.ImmotalMove());

            this.transform.position = new Vector3(0, -1.744f, 0);
            this.isImmotal = true;
        }
    }

    private IEnumerator ImmotalMove()
    {
        this.isImmotalMoving = true;
        var tpos = new Vector3(0, -1.09f, 0);
        while (true)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, tpos , Time.deltaTime * 2);
            var dis = Vector2.Distance(tpos, this.transform.position);
            if (dis <= 0.1f)
                break;
            yield return null;
        }
        this.isImmotalMoving = false;
    }
    private IEnumerator Immotal()
    {
        Debug.Log("무적 상태 On");
        var color = this.sr.color;
        color.a = 0.5f;
        this.sr.color = color;

        float delta = 0;

        while (true) {
            delta += Time.deltaTime;
            color.a = Mathf.Lerp(this.sr.color.a, 1, Time.deltaTime);
            this.sr.color = color;

            if (delta > this.immotalTime) {
                break;
            }
            yield return null;
        }
        Debug.Log("무적 상태 Off");
        
        color.a = 1;
        this.sr.color = color;
        this.isImmotal = false;
        
    }
}
