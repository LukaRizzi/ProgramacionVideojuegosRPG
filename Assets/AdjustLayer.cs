using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustLayer : MonoBehaviour
{
    [SerializeField] Transform target;
    SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void Update()
    {
        float _targetY = target.position.y;
        bool _behindTarget = _targetY > transform.position.y;

        if (_behindTarget)
        {
            sr.sortingOrder = 2;
        }
        else
        {
            sr.sortingOrder = 0;
        }
    }
}