using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private void Start()
    {
        AA();
    }
    void AA()
    {
        /*보안에 취약함
         저장위치가 레지스트리에...*/
        PlayerPrefs.SetInt("d", 2);
        //int PlayerLev = PlayerPrefs.GetInt("d"); Get은 두개, 위는 그냥 불러오기 아래는 저장값이 없으면 기본 값을 줌
        int PlayerLev = PlayerPrefs.GetInt("d",1);

        //PlayerPrefs.SetInt("SceneNum", 씬번호);
        //PlayerPrefs.SetString("SceneName", 씬이름);

        string infos = "Name:이름,HP:100,MaxHp:200";
        PlayerPrefs.SetString("PlayerInfos", infos);
        string info2 = PlayerPrefs.GetString("PlayerInfos");
        string[] splitarr = info2.Split(',');
        string ID = splitarr[0].Split(":")[1];
        string HP = splitarr[1].Split(":")[1];
        string MaxHP = splitarr[2].Split(":")[1];
    }
}
