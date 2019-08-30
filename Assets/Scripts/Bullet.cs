using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    private void Update()
    {
        transform.Translate(0f, 10f * Time.deltaTime, 0f);
    }
    [HideInInspector]
	public GameObject playerFrom;

	void OnCollisionEnter(Collision collision)
	{
		var hit = collision.gameObject;
		var health = hit.GetComponent<Health>();
		if (health != null)
		{
			health.TakeDamage(playerFrom, 10);
		}

		Destroy(gameObject);
	}
}
