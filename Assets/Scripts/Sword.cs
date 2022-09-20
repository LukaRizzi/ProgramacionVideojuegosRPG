using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGUNDAV.Gameplay
{
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
            GameObject collided = collision.gameObject;
            
            if (collided.layer == 7)
            {
                EnemyStateManager enemyManager = collision.GetComponent<EnemyStateManager>();
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                enemyManager.Attacked(player);
            }
        }
    }
}