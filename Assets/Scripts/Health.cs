using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private float currHP;
    
    public int health = 100;
    public GameObject boom;
    public bool isPlayer;
    [Header("Player")]
    public Slider slider;
    public Text hpText;
    [Header("Enemy")]
    public HpBar hpBar;

    void Start()
    {
        currHP = health;

        if (isPlayer)
        {
            slider.value = currHP / health;
            hpText.text = currHP.ToString("0");
        }
    }

    public void GetDamage(int damage)
    {
        currHP = Mathf.Clamp(currHP - damage, 0, health);

        if (isPlayer)
        {
            slider.value = currHP / health;
            hpText.text = currHP.ToString("0");
            if (currHP <= 0)
            {
                GetComponent<Animator>().SetTrigger("Dead");
                Instantiate(boom, transform);
                Destroy(GetComponent<PlayerControl>());
                Destroy(GetComponent<Collider>());
            }
        }
        else
        {
            hpBar.ChangeValue(currHP / health);
            if (currHP <= 0)
            {
                Destroy(gameObject, 5);
                GetComponent<Animator>().SetTrigger("Dead");
                Instantiate(boom, transform);
                Destroy(GetComponent<EnemyControl>());
                Destroy(GetComponent<NavMeshAgent>());
                Destroy(GetComponent<Collider>());
            }
        }
    }
}
