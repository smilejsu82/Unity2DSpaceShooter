using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        this.transform.Translate(Vector3.down * this.speed * Time.deltaTime);

        if (this.transform.position.y < -2.71f)
        {

            var pos = this.transform.position;

            this.transform.Translate(pos.x, 2.71f * 3, pos.z);

            Debug.LogError(this.transform.position);    

            //this.transform.position = pos;    //�̷��� �ϸ� �ð��� ������ �ʰ� �� ���̿� ���� ����� ������ 
        }
    }
}
