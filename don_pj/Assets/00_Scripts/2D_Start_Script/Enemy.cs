using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour, IHit
{
    public Transform[] posRange;
    float x = 0;
    float y = 0;
    float speed = 3;
    float Direction = 1;
    Rigidbody2D rigid;

    Vector3 vec = Vector3.zero;
    Vector3 scaleVec = Vector3.one;
    Animator animator;
    public Constructure.Stat stat;
    public Slider slider;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        stat = new Constructure.Stat(100, 10);
        animator = transform.GetComponent<Animator>();
        StartCoroutine(SetDirection());

        slider.maxValue = stat.MaxHp;
        slider.value = stat.Hp;
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

        //Debug.Log(stat.Att);
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

    public void Hit(float damage, Vector3 dir)
    {
        if (stat.Hp <= 0)
        {
            return;
        }

        this.stat.Hp = Mathf.Clamp(this.stat.Hp - damage, 0, this.stat.MaxHp);
        slider.value = this.stat.Hp;
        animator.SetTrigger("Hit");
        rigid.AddForce(dir, ForceMode2D.Impulse);
    }
    public float GetAtt()
    {
        return stat.Att;
    }
}
