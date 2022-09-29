using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGUNDAV.Gameplay{
    public class ExplosiveBehaviour : MonoBehaviour
    {
        public float timeTillExplosion;

        public float explosionDuration;
        public float explosionRadius;
        private CircleCollider2D bombCollider;
        private float timeAtActivation;
        private Animator animator;
        // Logica incompleta terminar explosion
        void Start()
        {
            bombCollider = GetComponentInParent<CircleCollider2D>();
            animator = GetComponentInParent<Animator>();
            timeAtActivation = Time.fixedTime;
            bombCollider.enabled = false;
            animator.speed = 1/timeTillExplosion;
        }

        // Update is called once per frame
        void Update()
        {
            if(Time.fixedTime >= timeAtActivation + timeTillExplosion){
                bombCollider.enabled = true;
                bombCollider.radius = explosionRadius;
                if(Time.fixedTime >= timeAtActivation + timeTillExplosion + explosionDuration){
                    //Cambio a animacion de explocion
                    Destroy(this.gameObject);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("PlayerHurtBox")){
                GameObject playerHurtBox = other.gameObject;
                playerHurtBox.GetComponentInParent<PlayerStateManager>().Attacked(this.gameObject);
            }
        }
    }
}