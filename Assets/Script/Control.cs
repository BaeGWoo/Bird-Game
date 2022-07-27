using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{

    private Rigidbody2D rigid;


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        
    }

    public void Jump()
    {
        rigid.AddForce(new Vector2(0, 100));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("충돌");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
