using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public Transform[] posRange;
    float x = 0;
    float y = 0;
    float speed = 3;
    float Direction = 1;
    Vector3 vec = Vector3.zero;
    Vector3 scaleVec = Vector3.one;
    Animator animator;

    public Slider slider;

    void Start()
    {
        animator = transform.GetComponent<Animator>();
        StartCoroutine(SetDirection());
    }


    void Update()
    {
        x = Direction;

        vec.x = x;
        vec.y = y;
        transform.Translate(vec.normalized * Time.deltaTime * speed);

        if(transform.position.x < posRange[0].position.x)
        {
            Direction = 1;
        }
        else if(transform.position.x > posRange[1].position.x)
        {
            Direction = -1;
        }
       
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

        if(Direction == 1)
        {
            slider.transform.localScale = new Vector3(1, 1, 1);
        }
        else if(Direction == -1)
        {
            slider.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    IEnumerator SetDirection()
    {
        while (true)
        {
            Direction = 0;
            yield return new WaitForSeconds(2.0f);
            int num = Random.Range(0, 2);
            if (num == 0)
            {
                Direction = 1;
                
            }
            else if(num == 1)
            {
                Direction = -1;
                
            }
            yield return new WaitForSeconds(4.0f);

        }
    }
    float Hp = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("?");
            if (transform.position.y + transform.localScale.y / 2 <= collision.gameObject.transform.position.y)
            {
                Hp -= 0.1f;
                slider.value = Hp;
                animator.SetTrigger("Hit");
            }
        }
    }
}
