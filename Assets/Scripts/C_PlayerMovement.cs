using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_PlayerMovement : MonoBehaviour
{
  public CharacterController controller;
  public float speed = 8f;

    void Start()
    {
        //keeps the game at 60fps, which makes Time.deltaTime consistent
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis ("Horizontal");
        float z = Input.GetAxis ("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetKey("left shift"))
        {
            Debug.Log("shift is held");
            speed = 14f;
        }
        else
        {
            speed = 8f;
        }
    }
}
