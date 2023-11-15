using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IHit
{
    void Hit(float damage, Vector3 dir);

    float GetAtt();
}

