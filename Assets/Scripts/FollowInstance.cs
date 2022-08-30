using UnityEngine;

namespace RPGUNDAV.Gameplay
{
    [ExecuteInEditMode]
    public class FollowInstance : MonoBehaviour
    {
        [SerializeField] Transform follow;
        [SerializeField] private float time = 1;
        [SerializeField] private float maxSpeed = 1;
        private Vector3 velRef;

        private void Start()
        {
            transform.position = GetPos();
        }

        private void Update()
        {
            Vector3 _desiredPos = GetPos();

            transform.position = Vector3.SmoothDamp(transform.position, _desiredPos, ref velRef, time, maxSpeed);
        }

        Vector3 GetPos()
        {
            float _x = Mathf.Floor((follow.position.x + 16 / 2) / 16) * 16;
            float _y = Mathf.Floor((follow.position.y + 9 / 2) / 9) * 9;
            return new Vector3(_x, _y, transform.position.z);
        }
    }
}