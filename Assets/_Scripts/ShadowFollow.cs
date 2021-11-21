using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowFollow : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(Player.Instance.transform.position.x, transform.position.y, transform.position.z);
    }
}
