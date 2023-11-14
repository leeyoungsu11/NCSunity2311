using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region 싱글톤 묶음
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
            if (instance !=this)
            {
                Destroy(this.gameObject);
            }
        }
    }
    #endregion
    public Transform[] posRange; //푸드가 만들어질 범위 트랜스폼..
    public Text scoreText; //점수 출력용
    public GameObject foodPrefab; //푸드 원본...
    public Sprite[] AllItemSprites;//푸드의 그림이 되어줄 친구들
    //public Queue<GameObject> gameObjects;

    float generateTime=0;
    [SerializeField] //프라이빗이어도 인스펙터창에 보이도록하는 attribute
    float generateTime_Min = 0;
    [SerializeField] //프라이빗이어도 인스펙터창에 보이도록하는 attribute
    float generateTime_Max = 0;
    int score = 0;

    int picnum = 0;

    //일정시간마다 foodprefab생성해서
    //그친구를 내려보내기...
    GameObject tmpobj; //임시변수        
    Food tmpFood; //음식 스크립트 받아줄 임시변수
    Vector3 vec = Vector3.zero;

    Queue<Food> objectPool = new Queue<Food>();
    //오브젝트풀 용 변수선언.    

    void Start()
    {
        //먼저 오브젝트 풀에 내가 쓸 최대 객체들을 만들어둘것임...
        //젤리 하나가 태어나서 땅에 떨어져 죽을떄까지
        //한화면에 최대 20개의 젤리는 안넘을것같다. 라고 생각되면,
        //foodPrefab친구를 20개 만들어두고 오브젝트풀에 넣어둠.
        //해당 오브젝트 풀의 내용들을 모두 꺼둠. (setactive(false)) 
        //gameObjects = new Queue<GameObject>();

        //for (int i = 0; i < 20; i++)
        //{
        //    gameObjects.Enqueue(SetFood());
        //}
        for (int i = 0; i < 20; i++)
        {
            tmpobj = Instantiate(foodPrefab);
            objectPool.Enqueue(tmpobj.GetComponent<Food>());
            tmpobj.SetActive(false);
        }
        StartCoroutine(GenerateFood());
        
    }
    public Food GetFoodFromPool()
    {
        if(objectPool.Count > 0)
        {
            return objectPool.Dequeue();
        }
        else
        {
            return Instantiate(foodPrefab).GetComponent<Food>();
        }
        
    }
    public void ReturnFoodPool(Food _food)
    {
        objectPool.Enqueue(_food);
        _food.gameObject.SetActive(false);
    }
    IEnumerator GenerateFood()
    {
        while (true)
        {
            generateTime = Random.Range(generateTime_Min, generateTime_Max);
            yield return new WaitForSeconds(generateTime);

            //일정시간마다 만들어내는 것이 아니고
            //오브젝트 풀에있던 ㅇ친구를 꺼내서 데이터 세팅
            //setactive를 true를 할것..

            tmpFood = GetFoodFromPool();
            tmpobj = Instantiate(foodPrefab);
            vec.y = posRange[0].position.y;
            vec.x = Random.Range(posRange[0].position.x, posRange[1].position.x);
            tmpFood.transform.position = vec;
            //tmpobj.transform.position = vec; //위치 설정 완료
            picnum = Random.Range(0, AllItemSprites.Length);
            //tmpobj.GetComponent<Food>().SetInfo(AllItemSprites[picnum], picnum+1);
            tmpFood.SetInfo(AllItemSprites[picnum], picnum + 1);
            tmpFood.gameObject.SetActive(true);
            //생성된 프리팹의 위치 수정 //내가 foodprefab을 생성하고 있으니까 내가 위치 조절가능함.
            //그렇게 태어난 친구는 아래로 이동해야함//리지드바디를 주면 해결되긴함.
            //음식이 그렇게 땅에 도달하면 사라져야됨...
        }        
    }

    public void AddScore(int _score)
    {
        this.score+= _score;
        scoreText.text = "점수 : " + this.score;
    }
}
