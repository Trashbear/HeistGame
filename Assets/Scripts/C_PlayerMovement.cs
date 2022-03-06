using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_PlayerMovement : MonoBehaviour
{
  public CharacterController controller;
  public float speed = 8f;

  public float stamina;
  private float totalStamina = 50;

    void Start()
    {
        //keeps the game at 60fps, which makes Time.deltaTime consistent
        Application.targetFrameRate = 60;
        stamina = totalStamina;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis ("Horizontal");
        float z = Input.GetAxis ("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetKey("left shift") && stamina > 0)
        {
            Debug.Log("sprinting, stamina is " + stamina);
            speed = 14f;
            stamina -= 0.5f;
        }
        else
        {
            speed = 8f;
            if(stamina < 50 && !Input.GetKey("left shift"))
            {
                stamina += 0.25f;
                Debug.Log("recharging, " + stamina);
            }
        }
    }
}
