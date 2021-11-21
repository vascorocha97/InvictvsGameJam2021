using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggonSound : MonoBehaviour
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

    }

    void PlayFlame()
    {
        if (timeBody._isRewinding == false)
        {
            AkSoundEngine.PostEvent("dragonFire", this.gameObject);

        }

    }

    void PlayFootsteps()
    {
        if (timeBody._isRewinding == false)
        {
            AkSoundEngine.PostEvent("dragonStep", this.gameObject);

        }

    }
}
