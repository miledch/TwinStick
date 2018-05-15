using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour
{
    public bool recording = true;    // Use this for initialization
    public bool pause = false;

    private float fixedDeltaTime;

    private void Start()
    {
        fixedDeltaTime = Time.fixedDeltaTime;
    }

    void Update()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            recording = false;
        }
        else
        {
            recording = true;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            pause = !pause;
            PauseGame(pause);
        }
    }

    void PauseGame(bool pause)
    {
        Time.timeScale = pause ? 0f : 1.0f;
        Time.fixedDeltaTime = pause ? 0f : fixedDeltaTime;
    }

}
