using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
   public static GameManager Instance = null;
   void Awake()
   {
       if (Instance == null)
       {
           Instance = this;
           DontDestroyOnLoad(this.gameObject);
       }
       else
       {
           if (Instance != this)
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
        obj.transform.position = new Vector3(0, 10, 0);
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Á¡¼ö : " + score;
    }
}
