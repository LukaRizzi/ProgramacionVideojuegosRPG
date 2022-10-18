using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleSpread : MonoBehaviour
{
    private void OnDestroy()
    {
        float timer = .2f;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.up);
        if (hit && hit.transform.CompareTag("Destructible"))
            Destroy(hit.transform.gameObject, timer);
        hit = Physics2D.Raycast(transform.position, Vector3.down);
        if (hit && hit.transform.CompareTag("Destructible"))
            Destroy(hit.transform.gameObject, timer);
        hit = Physics2D.Raycast(transform.position, Vector3.right);
        if (hit && hit.transform.CompareTag("Destructible"))
            Destroy(hit.transform.gameObject, timer);
        hit = Physics2D.Raycast(transform.position, Vector3.left);
        if (hit && hit.transform.CompareTag("Destructible"))
            Destroy(hit.transform.gameObject, timer);
    }
}
