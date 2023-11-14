using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    SpriteRenderer spren;
    float speedMin = 0;
    [SerializeField]
    float speedMax = 0;
    float speed = 0;
    [SerializeField]
    int score = 0;

    private void Start()
    {
        
    }
    public void SetInfo(Sprite _spr, int score)
    {
        if(spren == null)
        {
            spren = this.transform.GetComponent<SpriteRenderer>();
        }
        spren.sprite = _spr;
        this.score = score;
        speed = Random.Range(speedMin, speedMax);
    }
    void FixedUpdate()
    {
        transform.Translate(Vector3.down * Time.fixedDeltaTime*speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //AddScore();
            Destroy(this.gameObject);
        }
        else if(collision.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
        //destroy로 없에는것이아닌 게임메니저에 비활성화시켜달라고함
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
