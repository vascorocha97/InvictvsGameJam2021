using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed;
    [SerializeField] private Vector3[] positions;
    private TimeBody timeBody;
    public int checkPointIndex = 0;




    void Start()
    {
        timeBody = gameObject.GetComponent<TimeBody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBody._isRewinding == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, positions[checkPointIndex], Time.deltaTime * speed);
            if (transform.position == positions[checkPointIndex])
            {
                if (checkPointIndex == positions.Length - 1)
                {
                    checkPointIndex = 0;
                }
                else
                {
                    checkPointIndex++;
                }
            }
        }

    }
}
