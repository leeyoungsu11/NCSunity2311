using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleT : MonoBehaviour
{
    Rigidbody2D rigid;
    float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        rigid = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            rigid.AddForce(new Vector3(4, 8, 0), ForceMode2D.Impulse);
        }
    }
}
