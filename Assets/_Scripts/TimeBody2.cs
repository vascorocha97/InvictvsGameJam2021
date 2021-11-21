using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody2 : MonoBehaviour
{
    // Start is called before the first frame update
    // public List<Vector3> _positions;
    public bool _isRewinding = false;

    public List<ObjState> _state;

    private robot robot;

    private Animation animation;
    private Animator animator;

    private AnimatorClipInfo[] CurrentClipInfo;

    private Door porta;
    private string word;

    public GameObject openDoor;
    public GameObject closedDoor;

    private TimeBody2 timeBody;


    void Start()
    {
        _state = new List<ObjState>();
        // May not work if we have more than one instance!

        porta = gameObject.GetComponent<Door>();
        timeBody = gameObject.GetComponent<TimeBody2>();



    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("Fire1")) && SlotMachine.Instance.canRewind)
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

        Debug.Log(CurrentClipInfo[0].clip.name);
        //string name = CurrentClipInfo[0].clip.name;
        //Debug.Log(name);
        _state.Insert(0, new ObjState(porta.isActive));

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
            // porta.OpenDoor();
            ObjState objState = _state[0];
            if (objState.isWalking == true)
            {
                closedDoor.SetActive(false);
                openDoor.SetActive(true);
            }
            else
            {
                closedDoor.SetActive(true);
                openDoor.SetActive(false);
            }





            animator.SetBool("AtackBool", objState.isWalking);
            // animator.SetBool(objState.animationName, objState.isWalking);
            //animator.SetBool("isWalking", objState.isWalking);

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

        public int state;


        public ObjState(Vector3 _position, Quaternion _rotation, int _checkPointIndex, string _animationName)
        {

            this.position = _position;
            this.rotation = _rotation;
            this.checkPointIndex = _checkPointIndex;
            this.animationName = _animationName;
        }

        public ObjState(bool _isActive)
        {

            this.isWalking = _isActive;
        }


        public ObjState(Vector3 _position, Quaternion _rotation, int _checkPointIndex)
        {

            this.position = _position;
            this.rotation = _rotation;
            this.checkPointIndex = _checkPointIndex;
        }

        public ObjState(Vector3 _position, Quaternion _rotation, int _checkPointIndex, bool _isWalkingState, int state, string _animationName)
        {

            this.position = _position;
            this.rotation = _rotation;
            this.checkPointIndex = _checkPointIndex;
            this.isWalking = _isWalkingState;
        }




    }

}


