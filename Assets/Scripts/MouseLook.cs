using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
  public float mouseSensitivity = 150f;

  public Transform playerBody;

  private float xRotation = 0f;

  public static bool cameraLook;




    // Start is called before the first frame update
    void Start()
    {
      Cursor.lockState = CursorLockMode.Locked;
      cameraLook = true;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


        xRotation -= mouseY;
        xRotation = Mathf.Clamp (xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
      if (cameraLook == false)
      {
        Cursor.lockState = CursorLockMode.None;
      }
      else
      {
        Cursor.lockState = CursorLockMode.Locked;
      }

    }
}
