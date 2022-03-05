using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_RayCasting : MonoBehaviour
{
    RaycastHit hit;

    float theDistance;

    public int guardVision;

    public bool playerSpotted;

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.right) * guardVision;
        Debug.DrawRay(transform.position, forward, Color.red);

        if(Physics.Raycast(transform.position,(forward), out hit))
        {
            theDistance = hit.distance;
            //Debug.Log(theDistance + "+" + hit.collider.gameObject.name);

            if(hit.collider.gameObject.tag == "Player")
            {
                Debug.Log("from laser: player hit");
            }
        }
    }
}
