using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    Touch touch;
    SpriteRenderer sprite;
    public float speed=0.1f;
    private Rigidbody2D rigid;


    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();

       // transform.position = Vector3.zero;
    }

    private void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        if(Input.touchCount>0)
        {
            x = Input.touches[0].deltaPosition.x;
            y = Input.touches[0].deltaPosition.y;
        }

        if(Input.GetAxis("Mouse X")>0)
        {
            sprite.flipX = false;

        }
        else if(Input.GetAxis("Mouse X")<0)
        {
            sprite.flipX = true;
        }

        transform.Translate
            (
           x * speed * Time.deltaTime,
           y * speed * Time.deltaTime,
           transform.position.z

           );
        //월드 좌표를 뷰 포트 좌표계로 변환합니다.
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        //pos.x와 pos.y의 값을 0~1 사이의 값으로 제한
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);

        //다시 월드 좌표로 변환합니다.
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    /* public void Jump()
     {
         rigid.AddForce(new Vector2(0, 100));
     }
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AdManager.instance.ShowAD();
    }
  
}
