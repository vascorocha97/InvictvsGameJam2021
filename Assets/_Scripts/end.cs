using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.PostEvent("lastSplash", this.gameObject);
        // AkSoundEngine.SetState("timeFlow", "");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
