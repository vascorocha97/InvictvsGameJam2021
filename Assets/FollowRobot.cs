using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRobot : MonoBehaviour
{
    public GameObject dragon;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(dragon.transform.position.x, dragon.transform.position.y, dragon.transform.position.z);
    }
}
