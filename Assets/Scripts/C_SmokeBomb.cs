using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_SmokeBomb : MonoBehaviour
{
    //public bool isLoaded = false;

    private int bombsLeft = 1;

    public GameObject smokeBombObj;

    public Transform bombThrowArea;

    public float power = 100f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bombsLeft > 0 && Input.GetKey("e"))
        {
            Rigidbody rb = smokeBombObj.GetComponent<Rigidbody>();

            rb.velocity = power * bombThrowArea.forward;

            Instantiate(smokeBombObj, bombThrowArea.position, bombThrowArea.rotation);

            bombsLeft -= 1;
        }
    }
}
