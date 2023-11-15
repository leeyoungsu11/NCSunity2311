using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constructure
{
    public struct Stat
    {
        public float Hp;
        public float MaxHp;
        public float Att;
        public Stat(float hp, float att)
        {
            this.Hp = hp;
            this.Att = att;
            this.MaxHp = Hp;
        }
    }
    
}