using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 40f;
	public float lifeTime = 7f;
	public GameObject boom;
	public int damage = 10;

	void Start()
	{
		Destroy(gameObject, lifeTime);
	}

	void Update()
	{
		transform.position += transform.up * speed * Time.deltaTime;
	}

	void OnTriggerEnter(Collider other)
	{
		GameObject clone = Instantiate(boom, transform.position, Quaternion.identity);
		Destroy(clone, 3f);

		if (other.GetComponent<Health>())
			other.GetComponent<Health>().GetDamage(damage);

		Destroy(gameObject);
	}
}
