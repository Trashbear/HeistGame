using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_PlayerMovement : MonoBehaviour
{
  public CharacterController controller;
  public GameObject thePlayer;
  public float speed = 8f;

  public float stamina;
  private float totalStamina = 50;
  public float crouchHeight;
  public float normalHeight;
  private Transform theTransform;

    void Start()
    {
        //keeps the game at 60fps, which makes Time.deltaTime consistent
        Application.targetFrameRate = 60;

        stamina = totalStamina;
        
        controller = GetComponent<CharacterController>();
        
        //charHeight = controller.height;

        theTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        //float h = charHeight;

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
        else if(Input.GetKeyDown("left ctrl"))
        {
            speed = 6f;
            
            //changes the x, y, and z of the player object
            thePlayer.transform.localScale = new Vector3(1.2f, (1.235736f/2f), 1.2f);
            //controller.height = crouchHeight;
            //thePlayer.height = crouchHeight;
            //Debug.Log("crouching???");
        }
        else if(Input.GetKeyUp("left ctrl"))
        {
            thePlayer.transform.localScale = new Vector3(1.2f, 1.235736f, 1.2f);
            speed = 8f;
        }
        else
        {
            speed = 8f;

            //float lastHeight = controller.height;
            //controller.height = Mathf.Lerp(controller.height, h, 5*Time.deltaTime);
            //theTransform.position.y += (controller.height-lastHeight)/2;

            //controller.height = normalHeight;
            //thePlayer.height = normalHeight;

            if(stamina < 50 && !Input.GetKey("left shift"))
            {
                stamina += 0.25f;
                Debug.Log("recharging, " + stamina);
            }
        }
    }
}
