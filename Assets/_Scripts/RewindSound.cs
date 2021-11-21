using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindSound : MonoBehaviour
{
    // Start is called before the first frame update
    private TimeBody timeBody;
    void Start()
    {
        timeBody = gameObject.GetComponent<TimeBody>();

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
}
