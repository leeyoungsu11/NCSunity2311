using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MobileTouch : MonoBehaviour, IPointerClickHandler,IBeginDragHandler, IEndDragHandler
//IBeginDragHandler 드래그의 시작, IEndDragHandler 드래그의 끝
//핸들러사용은 클릭을 받을 준비가 되어있어야 가능
//대상이 캔버스에 있는 애들이다 == EventSystem이 존재, 내가 Raycast target 활성화 되어있어야함
//대상이 만약 필드에 있는 애들이다 ex object == 반드시 콜라이더가 있어야함
{
    
    public void OnBeginDrag(PointerEventData ss)
    {

    }
    public void OnPointerUp(PointerEventData ss)
    {

    }
    public void OnPointerDown(PointerEventData ss)
    {

    }
    public void OnDrag(PointerEventData ss)
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.LogWarning("내가 원하는 워링");//노란 세모로 내가 지정한 메세지 뜸
        Debug.LogError("내가 원하는 애러");//빨간원으로 내가 지정한 메세지 뜸
        //종료버튼을 반들고
        //종료 함수에 이 Quit하기전에
        //내 프로그램에서 돌리던것들 다 정지, 삭제 하고
        //Application.Quit();어플리 케이션의 완전한 종료.
        Application.targetFrameRate = 60; // 프레임 속도 동적으로 조정;
        if(Input.touchCount > 0)
        {
            Touch touch1 = Input.GetTouch(0);//첫번째 터치
            Touch touch2 = Input.GetTouch(1);//다른 손가락 터치

            //핸드폰은 일반적으로 x축은 오른쪽을따라 양의 값
            //y축은 위쪽을 따라 양의값

            if(touch1.phase == TouchPhase.Moved)//터치의 시작
            {

            }
        }
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }
}
