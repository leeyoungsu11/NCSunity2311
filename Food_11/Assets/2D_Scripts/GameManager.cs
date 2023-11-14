using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //������Ʈ Ǯ�� ���� �� �ִ� ��ü���� ������ٰ�
    //���� �ϳ��� �¾�� ���� ������ ����������
    //��ȭ�鿡 �ִ� 20���� ������ �ȳ����Ͱ��� ��� �İ��ϸ�
    //FoodFrefabģ���� 20�� ����� ������ƮǮ�� �־��
    //�ش������Ʈ Ǯ�� ������� ��� ����(food)
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
        scoreText.text = "���� : " + score;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        Debug.Log("cc");
    }
    


}
