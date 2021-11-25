using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggonSound : MonoBehaviour
{

    // Start is called before the first frame update
    private TimeRobot timeBody;
    private robot robot;

    void Start()
    {
        timeBody = gameObject.GetComponent<TimeRobot>();
        robot = gameObject.GetComponent<robot>();
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

    void PlayKillChicken()
    {
        if (timeBody._isRewinding == false)
        {
            AkSoundEngine.PostEvent("dragonStabsChicken", this.gameObject);

        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log(other.collider.gameObject.name);

    }


}
