using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    
    public GameObject[] enemyPrefabs;
    private int span = 1;
    private float delta = 0;
    void Start()
    {
        
    }

    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span) {
            //적기 생성 
            GameObject prefab = null;
            var dice = Random.Range(1, 11);
            int idx = -1;
            if (dice <= 1)  //1
            {
                //big
                idx = 2;
            }
            else if (dice >= 2 && dice < 5)         //2 ~ 4
            {
                //mid
                idx = 1;
            }
            else   // 5 ~ 10
            {   
                //small
                idx = 0;    
            }

            //var idx = Random.Range(0, this.enemyPrefabs.Length);
            prefab = this.enemyPrefabs[idx];
            var go = Instantiate(prefab);
            go.transform.position = new Vector3(Random.Range(-0.74f, 0.74f), Random.Range(1.73f, 2.28f), 0);
            this.delta = 0;
        }
    }
}
