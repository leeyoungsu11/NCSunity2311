using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //오브젝트 풀에 내가 쓸 최대 객체들을 만들어줄것
    //젤리 하나가 태어나서 땅에 떨어져 죽을때까지
    //한화면에 최대 20개의 젤리는 안넘을것같다 라고 셍각하면
    //FoodFrefab친구를 20개 만들고 오브젝트풀에 넣어둠
    //해당오브젝트 풀의 내용들을 모두 꺼둠(food)
    private static GameManager instance = null;
    public static GameManager Instance => instance;
   void Awake()
   {
       if (instance == null)
       {
            instance = this;
           DontDestroyOnLoad(this.gameObject);
       }
       else
       {
           if (instance != this)
           {
               Destroy(this.gameObject);
           }
       }
   }
    

    public Text scoreText;
    public GameObject foodPrefab;

    int score = 0;

    public void Food()
    {
        GameObject obj = Instantiate(foodPrefab);
        int Xval = Random.Range(-8, 9);

        obj.transform.position = new Vector3(Xval, 10, 0);
        obj.GetComponent<SpriteRenderer>().color = Color.black;
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "점수 : " + score;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        Debug.Log("cc");
    }
    


}
