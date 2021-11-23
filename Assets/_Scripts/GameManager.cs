using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum TimeState { Regular, Rewinding }
    public TimeState timeState = TimeState.Regular;
    public float rewindSpeed = 2f;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
            Time.timeScale = 1;
        HandleTimeStates();
    }

    public void HandleTimeStates()
    {
        if (Input.GetButton("Fire1") && SlotMachine.Instance.canRewind)
        {
            timeState = TimeState.Rewinding;
        }
        else
        {
            timeState = TimeState.Regular;
        }

        switch (timeState)
        {
            case (TimeState.Regular):
                Time.timeScale = 1;
                break;
            case (TimeState.Rewinding):
                Time.timeScale = rewindSpeed;
                break;
            default:
                break;

        }
    }
}
