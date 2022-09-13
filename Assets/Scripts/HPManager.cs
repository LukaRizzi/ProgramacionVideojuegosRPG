using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HPManager : MonoBehaviour
{
    [SerializeField] private int hp;
    public int Hp
    {
        get { return hp; }
        set
        {
            hp = Mathf.Clamp(value, 0, hpMax);

            if (hp <= 0)
            {
                OnDeath();
            }
        }
    }
    public int hpMax = 100;

    public abstract void OnDeath();
}