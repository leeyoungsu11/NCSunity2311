using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour, IHit
{
    float x = 0;
    float y = 0;
    float speed = 5;
    float power = 4;
    Rigidbody2D rigid;
    int jumpCount = 0;
    bool onHit = false;
    Vector3 vec = Vector3.zero; //vec == 0,0,0
    Vector3 scaleVec = Vector3.one;
    Vector3 direction = Vector3.zero;
    SpriteRenderer sprend;
    Animator animator;
    public Slider slider;
    Constructure stat;

    void Start()
    {
        rigid = transform.GetComponent<Rigidbody2D>();        
        sprend = transform.GetComponent<SpriteRenderer>();
        animator = transform.GetComponent<Animator>();
        //slider = transform.GetComponent<Slider>();
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


        //벡터.normalized == 정규화한 벡터. 크기가 1짜리인 기본 벡터로 줌.

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
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.speed += 1;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
            animator.speed -= 1;
        {
        }
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

    }

    public void Hit(float damage, Vector3 dir)
    {
        //if(stat.Hp <= 0)
        //{
        //    return;
        //}
        //this.stat.Hp -= _att;
        animator.SetTrigger("Hit");
        //this.stat.Hp = Mathf.Clamp(this.stat.Hp - damage, 0, this.stat.MaxHp);
        rigid.AddForce(dir, ForceMode2D.Impulse);
    }

    //public float GetAtt()
    //{
    //    return mystat.Att;
    //}
 
    Color tmpcolor;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //if (collision.CompareTag("Spike"))
        //{
        //    animator.SetTrigger("Hit");
        //    Hp -= 0.25f;
        //    slider.value = Hp;
        //    //tmpcolor = gameObject.GetComponent<SpriteRenderer>().color; 
        //    //gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        //    //Debug.Log("d");
        //    //collision.this.GetComponent<SpriteRenderer>().color = Color.black;
        //}
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.CompareTag("Spike"))
        //    gameObject.GetComponent<SpriteRenderer>().color = tmpcolor;
    }
    ////어느 한쪽이라도 트리거 체크되어있으면 무조건 트리거 함수가 불림.
    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //Debug.Log("트리거의 접촉 시작");
    // // 아래 아이템 체크는, Food스크립트로 옮겨졌음.
    //    if (collision.CompareTag("Item"))  //나와 부딪힌 대상의 태그가 Item이라면...
    //    {
    //        GameManager.Instance.AddScore();
    //        Destroy(collision.gameObject);//나랑 부딪힌 친구 객체를 삭제 
    //    }
    //}

    float Hp = 1;

    void OnCollisionEnter2D(Collision2D collision) 
    {
        

        if (collision.gameObject.CompareTag("Spike"))
        {
            Hp -= 0.1f;
            direction = (transform.position - collision.transform.position).normalized;
            Debug.Log(direction);
            if(direction.y < 2)
            {
                direction.y = 2;
            }
            direction *= power;
            //animator.SetTrigger("Hit");
            Debug.Log(direction);
            //rigid.AddForce(direction, ForceMode2D.Impulse);
            Debug.Log(direction);
            //this.stat.Hp -= 0.25f;
            Hit(0.25f, direction);
            slider.value = Hp;//stat.Hp;
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
            if (transform.position.y  < collision.gameObject.transform.position.y + 0.3f)
            {
                Hp -= 0.1f;
                //this.stat.Hp -= 0.1f;
                //Hit(0.25f, direction);
                slider.value = Hp;//stat.Hp;
                animator.SetTrigger("Hit");
            }
            //collision.transform.GetComponent<Enemy>().Hit(mystat.att);
            //collision.transform.GetComponent<IHit>().Hit(mystat.att);
        }
    }
}
