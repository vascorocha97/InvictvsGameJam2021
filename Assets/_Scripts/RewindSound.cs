using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindSound : MonoBehaviour
{
    // Start is called before the first frame update
    private TimeRobot timeBody;
    void Start()
    {
        timeBody = gameObject.GetComponent<TimeRobot>();

    }

    // Update is called once per frame
    void Update()
    {
        if (timeBody._isRewinding == true)
        {
            AkSoundEngine.SetState("timeFlow", "backwards");
        }
        else
        {
            AkSoundEngine.SetState("timeFlow", "forwards");

        }
    }

    private void OnDestroy()
    {
        // Debug.Log("OnDestroy1");
        AkSoundEngine.SetState("timeFlow", "None");
        // AkSoundEngine.PostEvent("levelStop", this.gameObject);
    }
}
