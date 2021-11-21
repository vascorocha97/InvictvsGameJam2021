using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.PostEvent("levelStart", this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
