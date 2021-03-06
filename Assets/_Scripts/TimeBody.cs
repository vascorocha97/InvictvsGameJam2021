using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    // Start is called before the first frame update
    // public List<Vector3> _positions;
    public bool _isRewinding = false;

    public List<ObjState> _state;

    private robot robot;

    private Animation animation;
    private Animator animator;

    private AnimatorClipInfo[] CurrentClipInfo;

    private string word;


    void Start()
    {
        _state = new List<ObjState>();
        // May not work if we have more than one instance!
        robot = gameObject.GetComponent<robot>();
        animation = gameObject.GetComponent<Animation>();
        animator = gameObject.GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("Fire1")))
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


    }

    public void StopRewind()
    {
        _isRewinding = false;
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
        // may require kinematic replay!!
        // Debug.Log(animation.sprite);
        // animation.enabled = false;
        CurrentClipInfo = animator.GetCurrentAnimatorClipInfo(0);

        // Debug.Log(CurrentClipInfo[0].clip.name);
        //string name = CurrentClipInfo[0].clip.name;
        //Debug.Log(name);
        _state.Insert(0, new ObjState(transform.position, transform.rotation, robot.checkPointIndex, robot.walkingAnimationState));

        //Fetch the current Animation clip information for the base layer

        //Debug.Log(animator.GetCurrentAnimatorStateInfo(0).ToString());
        //Access the current length of the clip
        //  m_CurrentClipLength = m_CurrentClipInfo[0].clip.length;

    }

    void Rewind()
    {
        //animator.StartPlayback();
        if (_state.Count > 0)
        {
            // transform.position = _positions[0];
            // _positions.RemoveAt(0);
            ObjState objState = _state[0];
            transform.position = objState.position;
            transform.rotation = objState.rotation;
            robot.checkPointIndex = objState.checkPointIndex;
            // animation.Rewind();
            // animator.SetFloat("Direction", -1);
            animator.SetBool("isWalking", objState.isWalking);

            // animator.Play(objState.animationName, -1, float.NegativeInfinity);


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

        public ObjState(Vector3 _position, Quaternion _rotation, int _checkPointIndex, bool _isWalkingState)
        {

            this.position = _position;
            this.rotation = _rotation;
            this.checkPointIndex = _checkPointIndex;
            this.isWalking = _isWalkingState;
        }




    }

}


