using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
            anim.SetTrigger("attack");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.transform.name);
    }
}