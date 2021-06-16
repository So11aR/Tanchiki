using UnityEngine;

public class Shooting : MonoBehaviour
{
    private float timer;

    public GameObject bulletPrefab;
    public Transform shootPoint;
    public AudioSource sound;
    public float cooldown = 2f;

    void Update()
    {
        timer += Time.deltaTime;
    }

    public void Shoot()
    {
        if (timer > cooldown)
        {
            timer = 0;
            Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            sound.Play();
        }
    }
}
