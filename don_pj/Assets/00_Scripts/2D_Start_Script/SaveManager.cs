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
        /*���ȿ� �����
         ������ġ�� ������Ʈ����...*/
        PlayerPrefs.SetInt("d", 2);
        //int PlayerLev = PlayerPrefs.GetInt("d"); Get�� �ΰ�, ���� �׳� �ҷ����� �Ʒ��� ���尪�� ������ �⺻ ���� ��
        int PlayerLev = PlayerPrefs.GetInt("d",1);

        //PlayerPrefs.SetInt("SceneNum", ����ȣ);
        //PlayerPrefs.SetString("SceneName", ���̸�);

        string infos = "Name:�̸�,HP:100,MaxHp:200";
        PlayerPrefs.SetString("PlayerInfos", infos);
        string info2 = PlayerPrefs.GetString("PlayerInfos");
        string[] splitarr = info2.Split(',');
        string ID = splitarr[0].Split(":")[1];
        string HP = splitarr[1].Split(":")[1];
        string MaxHP = splitarr[2].Split(":")[1];
    }
}
