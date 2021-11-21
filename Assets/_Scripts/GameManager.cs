using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum TimeState {Regular, Rewinding}
    public TimeState timeState = TimeState.Regular;
    public float rewindSpeed = 2f;

    void Update()
    {        
        HandleTimeStates();
    }

    public void HandleTimeStates() 
    {
        if (Input.GetButton("Fire1"))
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
