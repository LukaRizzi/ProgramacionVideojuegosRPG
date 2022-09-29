using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGUNDAV.Gameplay{
    public class ExplosiveBehaviour : MonoBehaviour
    {
        public float timeTillExplosion;
        public float explosionRadius;
        private CircleCollider2D bombCollider;
        private float timeAtActivation;
        // Logica incompleta terminar explosion
        void Start()
        {
            bombCollider = GetComponentInParent<CircleCollider2D>();
            timeAtActivation = Time.fixedTime;
            bombCollider.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            if(Time.fixedTime >= timeAtActivation + timeTillExplosion){
                bombCollider.enabled = true;
                bombCollider.radius = explosionRadius;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("PlayerHurtBox")){
                GameObject playerHurtBox = other.gameObject;
                playerHurtBox.GetComponentInParent<PlayerStateManager>().Attacked(this.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}