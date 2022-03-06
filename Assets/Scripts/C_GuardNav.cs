using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class C_GuardNav : MonoBehaviour
{
    public Transform[] points;

    private int destPoint;
    private NavMeshAgent agent;

    //public float speed;

    private bool playerSpotted = false;

    RaycastHit hit;

    float theDistance;

    public int guardVision;

    private float charHiding = 5.0f;

    private float untilHidden = 5.0f;

    private bool isHiding = true;

    public Transform player;

    public bool smokeHit = false;

    public float smokeTimer = 5.0f;

    public float smokeStop = 5.0f;

    void Start() 
    {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }

    void GotoNextPoint() 
    {
        // Returns if no points have been set up
        if (points.Length == 0)
        {
            return;
        }
            
        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;
        //Debug.Log(agent.destination);

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }

    void Update() 
    {
        if(playerSpotted == false)
        {
            // Choose the next destination point when the agent gets
            // close to the current one.
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                GotoNextPoint();
            }
        }
        else
        {
            Debug.Log("player spotted");
            agent.SetDestination(player.position);
        }

        /*
        does not matter anymore since the smoke is a trigger, I guess
        if(smokeHit == true)
        {
            smokeStop -= Time.deltaTime;

            agent.isStopped = true;

            if(smokeStop < 0)
            {
                smokeStop = 5.0f;
                smokeHit = false;
                agent.isStopped = false;
            }
        } 
        */

        //three rays in a VV to mimic a cone of vision
        Vector3 forward = transform.TransformDirection(Vector3.forward) * guardVision;
        Vector3 right = transform.TransformDirection(Vector3.right-Vector3.back) * guardVision;
        Vector3 left = transform.TransformDirection(Vector3.left-Vector3.back) * guardVision;

        Debug.DrawRay(transform.position, forward, Color.red);
        Debug.DrawRay(transform.position, right, Color.red);
        Debug.DrawRay(transform.position, left, Color.red);

        if(Physics.Raycast(transform.position,(forward), out hit) || Physics.Raycast(transform.position,(right), out hit) || Physics.Raycast(transform.position,(left), out hit))
        {
            theDistance = hit.distance;

            if(hit.collider.gameObject.tag == "Player")
            {
                Debug.Log("from laser: player hit");
                playerSpotted = true;
            }
            else if(playerSpotted)
            {
                untilHidden -= Time.deltaTime;

                Debug.Log(untilHidden + " until hidden");
                
                if(untilHidden <= 0)
                {
                    playerSpotted = false;
                    Debug.Log("now hidden");
                    untilHidden = 5.0f;
                }
            }
        }
    }

    /*
    same here lol
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "smokeLayer")
        {
            smokeHit = true;
        }
    }
    */
}
