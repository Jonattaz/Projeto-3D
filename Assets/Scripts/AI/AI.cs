using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
   NavMeshAgent agent;
    [SerializeField]
    private Transform[] waypoints;
    int waypointIndex;
    Vector3 target;
    [SerializeField]
    bool stop;
    Animator anim;
   
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
   
        if (Vector3.Distance(transform.position, target) < 1)
        {
            ResetWaypointIndex();
            UpdateDestination();
        }
    }

    void UpdateDestination()
    {
        if (!stop)
        {
            anim.SetBool("Walking", true);
            target = waypoints[waypointIndex].position;
        }
        else
        {
            target = this.transform.position;
        }
        agent.SetDestination(target);
         if(this.transform.position == target){
            anim.SetBool("Walking", false);
         }
    }

    void ResetWaypointIndex()
    {
        waypointIndex++;
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }
}
