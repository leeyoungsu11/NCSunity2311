using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SpriteShape : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteShapeController sprite;
    Spline spline1;
   
    int pointCount = 0;
    Vector3 vec = Vector3.zero;

    void Start()
    {
        sprite = GetComponent<SpriteShapeController>();

        spline1 = sprite.spline;
        pointCount = spline1.GetPointCount();
        
        for (int i = 0; i < pointCount; i++)
        {
            vec = spline1.GetPosition(i);
            Debug.Log(i + "점의 위치 : " + vec);
            spline1.SetPosition(i, Vector3.right * i);
        }

        StartCoroutine(WaveCoroutine());
    }
    IEnumerator WaveCoroutine()
    {
        //while (true)
        {
            for (int i = 0; i < pointCount; i++)
            {
                vec = spline1.GetPosition(i);
                spline1.SetPosition(i, vec + new Vector3(0, 1, 0));
                yield return new WaitForSeconds(2.0f);
            }
        }
    }
}
