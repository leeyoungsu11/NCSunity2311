using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapT : MonoBehaviour
{
    public Camera camera;
    public Tilemap tilemap;//Ÿ�ϸ�
    public TileBase[] tiles;//Ÿ�� ��������
    List<TileBase> coin;
    public Player player;
    Vector3 vec = Vector3.zero;
    Vector3Int vectorInt = Vector3Int.zero;
    Color[] colors = new Color[] { Color.white, Color.red, Color.blue, Color.green };
    // Update is called once per frame
    void Start()
    {
        
    }
    void Update()
    {
        Debug.Log(player.transform.position.x);
        if(Input.GetMouseButtonDown(0))//���콺 ���� Ŭ��
        {
            vec = camera.ScreenToWorldPoint(Input.mousePosition);
            vectorInt = tilemap.WorldToCell(vec);
            //tilemap.SwapTile(tileA, tileB);//aŸ�ϵ��� b�ιٲ�
            //tilemap.SetTile(position, tileA);//��ġ�� Ÿ�� a�� ������
            tilemap.SetTile(vectorInt, tiles[0]);
        }
        else if(Input.GetMouseButtonDown(1))
        {
            vec = camera.ScreenToWorldPoint(Input.mousePosition);
            vectorInt = tilemap.WorldToCell(vec);
            tilemap.SetTile(vectorInt, null);//����
        }

        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            tilemap.SwapTile(tiles[0], tiles[1]);
        }
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            
            tilemap.color = colors[Random.Range(0, colors.Length)];   
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            vec = (player.transform.position);
            vectorInt = tilemap.WorldToCell(vec);
            tilemap.SetTile(vectorInt, tiles[2]);

        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            vec =(player.transform.position);
            vectorInt = tilemap.WorldToCell(vec);
            tilemap.SetTile(vectorInt, null);
        }
    }
}
