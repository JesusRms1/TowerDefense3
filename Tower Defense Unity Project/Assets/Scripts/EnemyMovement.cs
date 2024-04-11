using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{

    private Transform target;
    private int wavepointIndex = 0;

    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();

        target = Waypoints.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

}


/*
  [RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

	private Transform destination;
	//private int wavepointIndex = 0;

	private Enemy enemy;
    public Camera Cam;
    public NavMeshAgent agent;

    void Start()
	{
		enemy = GetComponent<Enemy>();

        agent = GetComponent<NavMeshAgent>();


        destination = GameObject.Find("END").transform;
        SetDestination(destination.position);

    }
    void SetDestination(Vector3 destination)
    {
        if (agent != null)
        {
            agent.SetDestination(destination);
        }
    }

    void Update()
	{
        /*Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint();
		}

		enemy.speed = enemy.startSpeed;
		
if (agent.remainingDistance <= agent.stoppingDistance)
 {
     if (!agent.hasPath || Mathf.Abs(agent.velocity.sqrMagnitude) < float.Epsilon)
     {
         ReachDestination();
     }
 }

}

 void GetNextWaypoint()
{
  if (wavepointIndex >= Waypoints.points.Length - 1)
  {
      EndPath();
      return;
  }

  wavepointIndex++;
  target = Waypoints.points[wavepointIndex];
}

 void ReachDestination()
 {
     PlayerStats.Lives--;
     WaveSpawner.EnemiesAlive--;
     Destroy(gameObject);
 }

}
*/
