using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour, IHit
{
    float x = 0;
    float y = 0;
    float speed = 5;
    float power = 3;
    Rigidbody2D rigid;
    int jumpCount = 0;
    bool onHit = false;
    Vector3 vec = Vector3.zero; //vec == 0,0,0
    Vector3 scaleVec = Vector3.one;
    Vector3 direction = Vector3.zero;
    SpriteRenderer sprend;
    Animator animator;
    public Slider slider;
    Constructure.Stat stat;

    void Start()
    {
        stat = new Constructure.Stat(100, 10);
        rigid = transform.GetComponent<Rigidbody2D>();        
        sprend = transform.GetComponent<SpriteRenderer>();
        animator = transform.GetComponent<Animator>();
        //slider = transform.GetComponent<Slider>();

        slider.maxValue = stat.MaxHp;
        slider.value = stat.Hp;
    }

    void Update() 
    {
        if (onHit == true)
        {
            return;
        }
        //y = Input.GetAxisRaw("Vertical"); //세로값        

        x = Input.GetAxisRaw("Horizontal"); //가로값
        vec.x = x;
        vec.y = y;
        transform.Translate(vec.normalized * Time.deltaTime * speed);

        if (vec.x != 0)
        {
            scaleVec.x = vec.x;
            animator.SetBool("isMove", true);
        }
        else
        {
            animator.SetBool("isMove", false);
        }
        transform.localScale = scaleVec; //1,1,1 // -1,1,1

        //if(Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    animator.speed += 1;
        //}
        //else if(Input.GetKeyDown(KeyCode.DownArrow))
        //    animator.speed -= 1;
        //{
        //}
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (jumpCount<2)
            {
                jumpCount++;
            }
            else
            {
                return;
            }
            rigid.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
            //animator.SetTrigger("Jump2");
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            rigid.AddForce(new Vector3(-4,8,0) , ForceMode2D.Impulse);
        }
    }

    public void Hit(float damage, Vector3 dir)
    {
        if(stat.Hp <= 0)
        {
            return;
        }
        animator.SetTrigger("Hit");
        this.stat.Hp = Mathf.Clamp(this.stat.Hp - damage, 0, this.stat.MaxHp);
        rigid.AddForce(dir, ForceMode2D.Impulse);
        Debug.Log(dir);
    }

    public float GetAtt()
    {
        return stat.Att;
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        

        if (collision.gameObject.CompareTag("Spike"))
        {
            direction = (transform.position - collision.transform.position).normalized;
            if(direction.y < 2)
            {
                direction.y = 2;
            }

            direction *= power;
            //rigid.AddForce(direction, ForceMode2D.Impulse);
            //Debug.Log(direction);
            Hit(10, direction);
            slider.value = stat.Hp;
            onHit = true;
        }

        else if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            onHit = false;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            jumpCount = 0;
            if(transform.position.y > collision.transform.position.y + 0.3f)
            {
               
                direction = (collision.transform.position - transform.position).normalized;
                direction.y *= -2;
                direction *= power;

               
                collision.transform.GetComponent<IHit>().Hit(stat.Att, direction);

            }
            else //적이 나를 때림
            {
                Debug.Log("때림");
                onHit = true;
                direction = (transform.position - collision.transform.position).normalized;
                direction.y += 2;
                
                direction *= power;

                Hit(collision.transform.GetComponent<IHit>().GetAtt(), direction);
                slider.value = stat.Hp;
            }
        }
    }
}
