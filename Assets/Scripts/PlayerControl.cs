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

    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        cc.SimpleMove(transform.forward * speed * (Input.GetAxis("Vertical") + joyMove.Vertical));
        transform.Rotate(0, rotSpeed * Time.deltaTime * (Input.GetAxis("Horizontal") + joyMove.Horizontal), 0);
        turret.Rotate(0, 0, turretSpeed * Time.deltaTime * (Input.GetAxis("Mouse X") + joyRotate.Horizontal));

        anim.SetFloat("right", (Input.GetAxis("Horizontal") + joyMove.Horizontal));
    }

    void OnDestroy()
    {
        GameManager.Instance.GameOver();
    }
}
