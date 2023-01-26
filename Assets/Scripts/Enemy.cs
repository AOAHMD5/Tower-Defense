using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(Enemy))]
public class Enemy : MonoBehaviour
{
  //  private Enemy enemy;
    public float speed = 10f;

    private Transform target;
    private int WavePointIndex = 0;

     void Start()
    {
        // enemy = GetComponent<Enemy>();

        target = Waypoints.waypoints[0];
    }

     void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {
        if(WavePointIndex >= Waypoints.waypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        WavePointIndex++;
        target = Waypoints.waypoints[WavePointIndex];
    }
}
