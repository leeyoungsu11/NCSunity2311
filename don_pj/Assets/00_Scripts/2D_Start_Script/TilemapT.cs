using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapT : MonoBehaviour
{
    public Camera camera;
    public Tilemap tilemap;//타일맵
    public TileBase[] tiles;//타일 한장한장
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
        if(Input.GetMouseButtonDown(0))//마우스 왼쪽 클릭
        {
            vec = camera.ScreenToWorldPoint(Input.mousePosition);
            vectorInt = tilemap.WorldToCell(vec);
            //tilemap.SwapTile(tileA, tileB);//a타일들을 b로바꿈
            //tilemap.SetTile(position, tileA);//위치를 타일 a로 세팅함
            tilemap.SetTile(vectorInt, tiles[0]);
        }
        else if(Input.GetMouseButtonDown(1))
        {
            vec = camera.ScreenToWorldPoint(Input.mousePosition);
            vectorInt = tilemap.WorldToCell(vec);
            tilemap.SetTile(vectorInt, null);//지움
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
