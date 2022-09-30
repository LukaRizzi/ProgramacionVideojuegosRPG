using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGUNDAV.Gameplay{
    public class ExplosiveBehaviour : MonoBehaviour
    {
        public float timeTillExplosion;
        public float explosionDuration;
        public Vector2 explosionDistance;
        public Sprite visibleReachShape;
        private BoxCollider2D bombCollider;
        private float timeAtActivation;
        private Animator animator;
        private GameObject visibleReach;
        // Logica incompleta terminar explosion
        void Start()
        {
            bombCollider = GetComponentInParent<BoxCollider2D>();
            animator = GetComponentInParent<Animator>();
            timeAtActivation = Time.fixedTime;
            bombCollider.enabled = false;
            animator.speed = 1/timeTillExplosion;
            visibleReach = new GameObject();
            visibleReach.AddComponent<Transform>();
            visibleReach.AddComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            if(Time.fixedTime >= timeAtActivation + timeTillExplosion){
                bombCollider.enabled = true;
                bombCollider.size = explosionDistance;

                createVisibleReach();
                if(Time.fixedTime >= timeAtActivation + timeTillExplosion + explosionDuration){
                    Destroy(visibleReach);
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

        private void createVisibleReach(){
            Transform visibleReachTF = visibleReach.GetComponent<Transform>();
            SpriteRenderer sr = visibleReach.GetComponent<SpriteRenderer>();
            visibleReachTF.position = this.gameObject.transform.position;
            visibleReachTF.localScale = new Vector3(explosionDistance.x,explosionDistance.y, 0f);
            sr.sprite = visibleReachShape;
            sr.color = new Color(1,0,0,0.7f);
        }
    }
}