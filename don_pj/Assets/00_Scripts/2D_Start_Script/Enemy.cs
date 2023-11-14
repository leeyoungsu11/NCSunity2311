using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float x = 0;
    float y = 0;
    float speed = 5;
    float Direction = 1;
    Vector3 vec = Vector3.zero;
    Vector3 scaleVec = Vector3.one;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetComponent<Animator>();
        StartCoroutine(SetDirection());
    }

    // Update is called once per frame
    void Update()
    {
        x = Direction;

        vec.x = x;
        vec.y = y;

        transform.Translate(vec.normalized * Time.deltaTime * speed);
       
        if (vec.x != 0)
        {
            scaleVec.x = -vec.x;
            animator.SetBool("isMove", true);
        }
        else
        {
            animator.SetBool("isMove", false);
        }
        transform.localScale = scaleVec; //1,1,1 // -1,1,1
    }

    IEnumerator SetDirection()
    {
        while (true)
        {
            Direction = Random.Range(-1, 2);
            yield return new WaitForSeconds(3.0f);

        }
    }
}
