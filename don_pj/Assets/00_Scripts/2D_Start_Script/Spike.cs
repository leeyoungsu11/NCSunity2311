using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public Transform[] posRange;
    float x = 0;
    float y = 0;
    float speed = 3;
    float Direction = 1;
    Vector3 vec = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        if(transform.position.x > 0)
        {
            Direction = -1;
        }
        else if(transform.position.x < 0)
        {
            Direction = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        x = Direction;

        vec.x = x;
        vec.y = y;
        transform.Translate(vec.normalized * Time.deltaTime * speed);

        if (transform.position.x < posRange[0].position.x)
        {
            Direction = 1;
        }
        else if (transform.position.x > posRange[1].position.x)
        {
            Direction = -1;
        }
    }

   
}
