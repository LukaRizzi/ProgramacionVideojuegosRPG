using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGUNDAV.Gameplay
{
    public class Sword : MonoBehaviour
    {
        [SerializeField] private Animator anim;

        public float secondsToFullyCharge = 1;

        public float normalAttackSpeed = 3;

        public float chargedAttackSpeed = 1;

        private float timeWhenKeyPressed;

        private bool isCharging = false;

        private void Start()
        {
            anim = GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            /*if (Input.GetKeyDown(KeyCode.V)){
                anim.SetTrigger("attack");
                anim.speed = normalAttackSpeed;
                timeWhenKeyPressed = Time.fixedTime;
            }*/
            if (Input.GetKey(KeyCode.V)){
                if(isCharging){
                    anim.SetTrigger("charge");
                    anim.speed = 1/secondsToFullyCharge;
                }else{
                    anim.SetTrigger("attack");
                    anim.speed = normalAttackSpeed;
                    timeWhenKeyPressed = Time.fixedTime;
                    isCharging=true;
                }
            }

            if(Input.GetKeyUp(KeyCode.V)){
                if(Time.fixedTime >= timeWhenKeyPressed + secondsToFullyCharge ){
                    anim.SetTrigger("chargedattack");
                    anim.speed = chargedAttackSpeed;
                }
                isCharging=false;
            }

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