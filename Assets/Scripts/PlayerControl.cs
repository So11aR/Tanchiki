using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private CharacterController cc;
    private Animator anim;

    public Transform turret;
    public float speed = 6f;
    public float rotSpeed = 40f;
    public float turretSpeed = 50f;
    public Joystick joyMove;
    public Joystick joyRotate;
    public GameObject shootBtn;
    public bool isMobile;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

    #if UNITY_ANDROID || UNITY_IOS
        isMobile = true;
    #else
        isMobile = false;
    #endif

        if(!isMobile)
        {
            joyMove.gameObject.SetActive(false);
            joyRotate.gameObject.SetActive(false);
            shootBtn.SetActive(false);
        }
    }

    void Update()
    {
        float movY = isMobile ? joyMove.Vertical : Input.GetAxis("Vertical");
        float movX = isMobile ? joyMove.Horizontal : Input.GetAxis("Horizontal");
        float rotX = isMobile ? joyRotate.Horizontal : Input.GetAxis("Mouse X");

        cc.SimpleMove(transform.forward * speed * movY);
        transform.Rotate(0, rotSpeed * Time.deltaTime * movX, 0);
        turret.Rotate(0, 0, turretSpeed * Time.deltaTime * rotX);

        anim.SetFloat("right", movX);

        if(!isMobile && Input.GetMouseButtonDown(0))
        {
            GetComponent<Shooting>().Shoot();
        }
    }

    void OnDestroy()
    {
        GameManager.Instance.GameOver();
    }
}
