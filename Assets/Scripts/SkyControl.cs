using UnityEngine;

public class SkyControl : MonoBehaviour
{
    private Light dirLight;
    private float startIntensity;

    public float speed = 10f;

    public void Start()
    {
        dirLight = GetComponent<Light>();
        startIntensity = dirLight.intensity;
    }

    void Update()
    {
        transform.Rotate(speed * Time.deltaTime, 0, 0);
        dirLight.intensity = transform.rotation.eulerAngles.x < 180 ? startIntensity : 0;
    }
}
