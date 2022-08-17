using UnityEngine;

public class FollowInstance : MonoBehaviour
{
    [SerializeField] Transform follow;

    private void Update()
    {
        transform.position = new Vector3(follow.position.x, follow.position.y, transform.position.z);
    }
}
