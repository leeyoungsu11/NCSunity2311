using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region �̱��� ����
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
    public Transform[] posRange; //Ǫ�尡 ������� ���� Ʈ������..
    public Text scoreText; //���� ��¿�
    public GameObject foodPrefab; //Ǫ�� ����...
    public Sprite[] AllItemSprites;//Ǫ���� �׸��� �Ǿ��� ģ����
    //public Queue<GameObject> gameObjects;

    float generateTime=0;
    [SerializeField] //�����̺��̾ �ν�����â�� ���̵����ϴ� attribute
    float generateTime_Min = 0;
    [SerializeField] //�����̺��̾ �ν�����â�� ���̵����ϴ� attribute
    float generateTime_Max = 0;
    int score = 0;

    int picnum = 0;

    //�����ð����� foodprefab�����ؼ�
    //��ģ���� ����������...
    GameObject tmpobj; //�ӽú���        
    Food tmpFood; //���� ��ũ��Ʈ �޾��� �ӽú���
    Vector3 vec = Vector3.zero;

    Queue<Food> objectPool = new Queue<Food>();
    //������ƮǮ �� ��������.    

    void Start()
    {
        //���� ������Ʈ Ǯ�� ���� �� �ִ� ��ü���� �����Ѱ���...
        //���� �ϳ��� �¾�� ���� ������ ����������
        //��ȭ�鿡 �ִ� 20���� ������ �ȳ����Ͱ���. ��� �����Ǹ�,
        //foodPrefabģ���� 20�� �����ΰ� ������ƮǮ�� �־��.
        //�ش� ������Ʈ Ǯ�� ������� ��� ����. (setactive(false)) 
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

            //�����ð����� ������ ���� �ƴϰ�
            //������Ʈ Ǯ���ִ� ��ģ���� ������ ������ ����
            //setactive�� true�� �Ұ�..

            tmpFood = GetFoodFromPool();
            tmpobj = Instantiate(foodPrefab);
            vec.y = posRange[0].position.y;
            vec.x = Random.Range(posRange[0].position.x, posRange[1].position.x);
            tmpFood.transform.position = vec;
            //tmpobj.transform.position = vec; //��ġ ���� �Ϸ�
            picnum = Random.Range(0, AllItemSprites.Length);
            //tmpobj.GetComponent<Food>().SetInfo(AllItemSprites[picnum], picnum+1);
            tmpFood.SetInfo(AllItemSprites[picnum], picnum + 1);
            tmpFood.gameObject.SetActive(true);
            //������ �������� ��ġ ���� //���� foodprefab�� �����ϰ� �����ϱ� ���� ��ġ ����������.
            //�׷��� �¾ ģ���� �Ʒ��� �̵��ؾ���//������ٵ� �ָ� �ذ�Ǳ���.
            //������ �׷��� ���� �����ϸ� ������ߵ�...
        }        
    }

    public void AddScore(int _score)
    {
        this.score+= _score;
        scoreText.text = "���� : " + this.score;
    }
}
