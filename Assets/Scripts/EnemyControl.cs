using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour
{
    private GameObject[] points;
    private NavMeshAgent agent;
    private Transform target;
    private Transform player;
    private Animator anim;

    public string pointsTag = "Point";
    public float angryDist = 30f;
    public float nearDist = 5f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        points = GameObject.FindGameObjectsWithTag(pointsTag);
        target = points[Random.Range(0, points.Length)].transform;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > angryDist)
        {
            if (Vector3.Distance(transform.position, target.position) < nearDist)
            {
                target = points[Random.Range(0, points.Length)].transform;
            }
            agent.SetDestination(target.position);
            anim.SetBool("isAngry", false);
        }
        else
        {
            agent.SetDestination(player.position);
            GetComponent<Shooting>().Shoot();
            anim.SetBool("isAngry", true);
        }
    }

    void OnDestroy()
    {
        GameManager.Instance.IncKills();
    }
}
