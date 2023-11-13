using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float x = 0;
    float y = 0;
    float speed = 5;
    float JumpPower = 5;
    Vector3 vec = Vector3.zero;//0,0,0
    Vector3 scaleVec = Vector3.one;
    int JumpCount = 0;
    Rigidbody2D rigid;
    SpriteRenderer sd;
    void Start()
    {
        rigid = transform.GetComponent<Rigidbody2D>();
        sd = GetComponent<SpriteRenderer>();
        StartCoroutine("JumpCo");
    }


    void Update()
    {
        //Input.GetAxis; //인풋을 세밀하게 받아옴 ex -1 ~ 1
        //Input.GetAxisRaw;//인풋을 -1,0,1 이렇게 받아옴

        x = Input.GetAxisRaw("Horizontal");
        //y = Input.GetAxisRaw("Vertical");

        vec.x = x;
        vec.y = y;
        //Debug.Log($"x = {x}, y = {y}");

        //if(Input.GetAxisRaw)

        //transform.position += new Vector3(x, y) * Time.deltaTime * speed;
        //transform.position += new Vector3(x, y) * Time.deltaTime * speed;//변수를 직접수정
        transform.Translate(vec.normalized * Time.deltaTime * speed);//position += 누적 더하기와 동일

        //if (Input.GetKeyDown(KeyCode.Space) && JumpCount ==0)
        //{
        //    rigid.AddForce(Vector2.up*speed, ForceMode2D.Impulse);
        //    JumpCount++;
        //    Debug.Log(JumpCount);
        //    return;
        //}
        //
        //if (Input.GetKeyDown(KeyCode.Space) && JumpCount == 1)
        //{
        //    rigid.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
        //    JumpCount++;
        //    Debug.Log(JumpCount);
        //}
        
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(JumpCount<2)
            {
                ++JumpCount;
            }
            else
            {
                return;
            }
            rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        }
        if(vec.x != 0)
        {
            scaleVec.x = vec.x;
        }
        transform.localScale = scaleVec;
        if (vec.x < 0)
        {
            //Scale을 -로...
            //transform.localScale = new Vector3(-1, 1, 1);
            

            //rotation을 180도로...
            //transform.rotation = new Quaternion(0, 180, 0,1);
            //speed = -5;

            //플립을 true로...
            //sd.flipX = true;
        }
        if (vec.x > 0)
        {
            //transform.localScale = new Vector3(1, 1, 1);

            //.rotation = new Quaternion(0, 0, 0, 1);
            //speed = 5;

            //sd.flipX = false;
        }

        
        //if(Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    transform.Rotate(0, 180, 1);
        //}
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    transform.Rotate(0, 0, 0);
        //}
    }
        //StartCoroutine(JumpCo());
    //그냥 2단 점프

    //코루틴을 이용해서 2단점프
    IEnumerator JumpCo()
    {
        //일단 실행
        //GameManager.Instance.Food();
        while(true)
        {
            GameManager.Instance.Food();
            yield return new WaitForSeconds(1.0f);
        }
        //n초후 실행
    }

    //어디한쪽이라도 트리거 체크되어 있으면 무조건 트리거 함수가 불림
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("food"))
        {
            GameManager.Instance.AddScore();
            Destroy(collision.gameObject);//나랑 부딪힌 친구 객체 삭제
        }

        
    }
    //private void OnTriggerExit2D(Collider2D collision)
    //{

    //}
    //private void OnTriggerStay2D(Collider2D collision)
    //{

    //}
    //충돌체크가 안될따
    //둘다 rigidbody가 없음
    //어느 한쪽이 Trigger체크가 되어있음
    //둘다 콜리전이어야 안겹치고 콜리전 함수가 불림
    private void OnCollisionEnter2D(Collision2D collision)
    {
        JumpCount = 0;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
      
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
      
    }
}
