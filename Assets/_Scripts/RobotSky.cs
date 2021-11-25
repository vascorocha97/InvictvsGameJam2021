using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSky : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 1;
    [SerializeField] private Vector3[] positions;

    [SerializeField] private List<int> stateLock;


    private TimeSky timeBody;
    public int checkPointIndex = 0;

    public bool walkingAnimationState;

    public string pAnimationName;


    private Animator animator;

    public int state = 0;

    void Start()
    {
        timeBody = gameObject.GetComponent<TimeSky>();
        //animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //  StartCoroutine(MoveDragon());
        walkingAnimationState = false;

        if (timeBody._isRewinding == false && checkPointIndex < positions.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, positions[checkPointIndex], Time.deltaTime * speed);



            if (transform.position == positions[checkPointIndex] && state == stateLock[checkPointIndex])
            {
                //   if (checkPointIndex == positions.Length - 1)
                //{
                //  checkPointIndex = 0;
                //}
                // else
                //{
                checkPointIndex++;
                //}
            }
        }
    }

    public void updateState()
    {
        // We could increment or not
        state++;
    }


    //IEnumerator MoveDragon()


    public class AnimationState
    {
        public string animationName;
        public bool boolState;

        public Vector3 position;

        public AnimationState(Vector3 _position, string _name, bool state)
        {
            this.animationName = _name;
            this.boolState = state;
        }

        public AnimationState(Vector3 position, string _name)
        {
            this.animationName = _name;
        }

    }



}
