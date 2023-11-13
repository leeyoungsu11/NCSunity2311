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
        //Input.GetAxis; //��ǲ�� �����ϰ� �޾ƿ� ex -1 ~ 1
        //Input.GetAxisRaw;//��ǲ�� -1,0,1 �̷��� �޾ƿ�

        x = Input.GetAxisRaw("Horizontal");
        //y = Input.GetAxisRaw("Vertical");

        vec.x = x;
        vec.y = y;
        //Debug.Log($"x = {x}, y = {y}");

        //if(Input.GetAxisRaw)

        //transform.position += new Vector3(x, y) * Time.deltaTime * speed;
        //transform.position += new Vector3(x, y) * Time.deltaTime * speed;//������ ��������
        transform.Translate(vec.normalized * Time.deltaTime * speed);//position += ���� ���ϱ�� ����

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
            //Scale�� -��...
            //transform.localScale = new Vector3(-1, 1, 1);
            

            //rotation�� 180����...
            //transform.rotation = new Quaternion(0, 180, 0,1);
            //speed = -5;

            //�ø��� true��...
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
    //�׳� 2�� ����

    //�ڷ�ƾ�� �̿��ؼ� 2������
    IEnumerator JumpCo()
    {
        //�ϴ� ����
        //GameManager.Instance.Food();
        while(true)
        {
            GameManager.Instance.Food();
            yield return new WaitForSeconds(1.0f);
        }
        //n���� ����
    }

    //��������̶� Ʈ���� üũ�Ǿ� ������ ������ Ʈ���� �Լ��� �Ҹ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("food"))
        {
            GameManager.Instance.AddScore();
            Destroy(collision.gameObject);//���� �ε��� ģ�� ��ü ����
        }

        
    }
    //private void OnTriggerExit2D(Collider2D collision)
    //{

    //}
    //private void OnTriggerStay2D(Collider2D collision)
    //{

    //}
    //�浹üũ�� �ȵɵ�
    //�Ѵ� rigidbody�� ����
    //��� ������ Triggerüũ�� �Ǿ�����
    //�Ѵ� �ݸ����̾�� �Ȱ�ġ�� �ݸ��� �Լ��� �Ҹ�
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
