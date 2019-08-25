using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csBullet : MonoBehaviour {
    [HideInInspector]
    public GameObject playerFrom;

    private void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        var health = hit.GetComponent<csHealth>();

        if (health != null)
        {
            health.TakeDamage(playerFrom, 10);
        }

        Destroy(gameObject);
    }
}
