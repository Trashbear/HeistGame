using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
[SerializeField] private GameObject pauseMenuUI;

[SerializeField] private bool isPaused;

private void Start()
{
    isPaused = false;
}

private void Update()
{
    if (Input.GetKeyDown(KeyCode.P))
    {
        isPaused = !isPaused;
        
     if (isPaused)
    {
    ActivateMenu();
    }
    else
    {
    DeactivateMenu();
    }
    }
}
public void DeactivateMenu()
{
    pauseMenuUI.SetActive(false);
    Time.timeScale = 1;
    AudioListener.pause = false;
    Cursor.visible = false;
    MouseLook.cameraLook = true;
}

 void ActivateMenu()
{
    pauseMenuUI.SetActive(true);
    Time.timeScale = 0;
    AudioListener.pause = true;
    Cursor.visible = true;
    MouseLook.cameraLook = false;
}
}
