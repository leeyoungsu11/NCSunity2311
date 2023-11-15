using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constructure
{
    public float Hp;
    public float MaxHp;
    public float Att;
    public void State(float hp, float att)
    {
        this.Hp = hp;
        this.Att = att;
        this.MaxHp = this.Hp;
    }
}