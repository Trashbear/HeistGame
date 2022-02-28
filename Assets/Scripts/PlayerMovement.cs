using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
  public CharacterController controller;
  public float speed = 12f;

  public int hp = 3;

  public GameObject hpText;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis ("Horizontal");
        float z = Input.GetAxis ("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (hp < 1)
        {
          SceneManager.LoadScene("GameOver");
        }
    }

    void FixedUpdate()
    {
      hpText.GetComponent<Text>().text = "HP: " + hp;
    }

    private void OnCollision(Collider other)
    {
      GuardNavMesh enemy = other.gameObject.GetComponent<GuardNavMesh>();
      if (enemy != null)
      {
        hp -= 1;
      }
    }
}
