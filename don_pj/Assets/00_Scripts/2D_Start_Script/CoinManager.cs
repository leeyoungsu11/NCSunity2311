using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Coin : MonoBehaviour
{
    public void Die()
    {
        //Destroy(this.gameObject);
        CoinManager.Instance.ReturnQueue(this);
    }
}
public class CoinManager : MonoBehaviour
{
    Vector3 vec = Vector3.zero;
    public Transform[] posRange;
    public static CoinManager Instance = null;
    public Sprite[] AllItemSprites;

    int picnum = 0;

    public GameObject CoinPrefab;

    Queue<Coin> pool = new Queue<Coin>();

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
    void Start()
    {
        GameObject _obj;
        for (int i = 0; i < 20; i++)
        {
             _obj = Instantiate(CoinPrefab, this.transform);
            vec.y = posRange[0].position.y;
            vec.x = Random.Range(posRange[0].position.x, posRange[1].position.x);
            _obj.transform.position = vec; //위치 설정 완료
            picnum = Random.Range(0, AllItemSprites.Length);
            _obj.GetComponent<Food>().SetInfo(AllItemSprites[picnum], picnum + 1);
            //pool.Enqueue(_obj.GetComponent<Coin>());
            //ReturnQueue(_obj.GetComponent<Coin>());
        }
        StartCoroutine(MakeFood());
    }

    IEnumerator MakeFood()
    {
        GameObject _obj;
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(1.0f);
            _obj = Instantiate(CoinPrefab, this.transform);
            vec.y = posRange[0].position.y;
            vec.x = Random.Range(posRange[0].position.x, posRange[1].position.x);
            _obj.transform.position = vec; //위치 설정 완료
            picnum = Random.Range(0, AllItemSprites.Length);
            _obj.GetComponent<Food>().SetInfo(AllItemSprites[picnum], picnum + 1);
            pool.Enqueue(_obj.GetComponent<Coin>());
            _obj.SetActive(true);
        }
        
    }
    //IEnumerator MakeFood()
    //{
    //    for (int i = 0; i < 20; i++)
    //    {
    //        GetObject();
    //        yield return new WaitForSeconds(1.0f);
    //    }
    //}
    public Coin GetObject() //Coin가져오기
    {
        if (pool.Count > 0)
        {
            return pool.Dequeue();
        }
        else
        {
            GameObject obj = Instantiate(CoinPrefab, this.transform);
            return obj.GetComponent<Coin>();
        }
    }

    public void ReturnQueue(Coin coin) //Coin의 등록
    {
        pool.Enqueue(coin);
        coin.gameObject.SetActive(false);
    }
}
