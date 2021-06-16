using UnityEngine;

public class HpBomb : MonoBehaviour
{
    public int damage;
    public GameObject boom;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Health>())
        {
            other.GetComponent<Health>().GetDamage(damage);
            GameObject clone = Instantiate(boom, other.transform);
            Destroy(clone, 3f);
            Destroy(gameObject);
        }
    }
}
