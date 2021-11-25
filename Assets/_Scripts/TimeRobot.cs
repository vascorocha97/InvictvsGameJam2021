using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeRobot : MonoBehaviour
{
    // Start is called before the first frame update
    // public List<Vector3> _positions;
    public bool _isRewinding = false;

    public List<ObjState> _state;

    private robot robot;

    private Animation animation;
    private Animator animator;

    private AnimatorClipInfo[] CurrentClipInfo;

    private CapsuleCollider2D collider;

    private string word;


    void Start()
    {
        _state = new List<ObjState>();
        // May not work if we have more than one instance!
        robot = gameObject.GetComponent<robot>();
        animation = gameObject.GetComponent<Animation>();
        animator = gameObject.GetComponent<Animator>();
        collider = gameObject.GetComponent<CapsuleCollider2D>();


    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("Fire1")) && SlotMachine.Instance.canRewind)
        // if ((Input.GetButtonDown("Fire1")))
        {
            StartRewind();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopRewind();
        }
    }

    public void StartRewind()
    {
        _isRewinding = true;
        robot.isRewinding = true;


    }

    public void StopRewind()
    {
        _isRewinding = false;
        robot.isRewinding = false;
        animator.SetFloat("Direction", 1);

    }

    public void FixedUpdate()
    {
        if (_isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }

    void Record()
    {
        collider.enabled = true;

        // may require kinematic replay!!
        CurrentClipInfo = animator.GetCurrentAnimatorClipInfo(0);
        //Debug.Log(CurrentClipInfo[0].clip.name);
        //string name = CurrentClipInfo[0].clip.name;
        _state.Insert(0, new ObjState(transform.position, transform.rotation, robot.checkPointIndex, robot.walkingAnimationState, robot.state));

    }

    void Rewind()
    {

        if (_state.Count > 0)
        {
            collider.enabled = false;
            ObjState objState = _state[0];
            transform.position = objState.position;
            transform.rotation = objState.rotation;
            robot.checkPointIndex = objState.checkPointIndex;
            robot.state = objState.state;
            animator.SetFloat("Direction", -1);
            animator.SetBool("AtackBool", objState.isWalking);
            _state.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }

    }

    public class ObjState
    {
        public Vector3 position;
        public Quaternion rotation;

        public int checkPointIndex;

        public string animationName;

        public bool isWalking;

        public int state;


        public ObjState(Vector3 _position, Quaternion _rotation, int _checkPointIndex, string _animationName)
        {

            this.position = _position;
            this.rotation = _rotation;
            this.checkPointIndex = _checkPointIndex;
            this.animationName = _animationName;
        }

        public ObjState(Vector3 _position, Quaternion _rotation, int _checkPointIndex)
        {

            this.position = _position;
            this.rotation = _rotation;
            this.checkPointIndex = _checkPointIndex;
        }

        public ObjState(Vector3 _position, Quaternion _rotation, int _checkPointIndex, bool _isWalkingState, int state)
        {

            this.position = _position;
            this.rotation = _rotation;
            this.checkPointIndex = _checkPointIndex;
            this.isWalking = _isWalkingState;
        }




    }

}


