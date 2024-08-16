using UnityEngine;

public class Enemies : MonoBehaviour
{

    public float moveSpeed = 2f;
    public Transform pointA;
    public Transform pointB;
    public float detectionRange = 5f;
    public Transform player;

    private Vector3 target;
    private bool chasing = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = pointB.position;
    }

    // Update is called once per frame
    void Update()
    {
        BasicPatrolAndChase();
    }

    void BasicPatrolAndChase()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRange)
        {
            chasing = true;
        }
        else
        {
            chasing = false;
        }


        if (chasing)
        {
            target = player.position;
        }
        else
        {
            if (transform.position == pointA.position)
            {
                target = pointB.position;
            }
            else if (transform.position == pointB.position)
            {
                target = pointA.position;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

    }
}
