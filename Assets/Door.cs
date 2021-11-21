using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject openDoor;
    public GameObject closedDoor;

    public bool isActive = false;
    private TimeBody2 timeBody;



    public bool _isRewinding = false;

    public List<ObjState> _state;

    private robot robot;

    private Animation animation;
    private Animator animator;

    private AnimatorClipInfo[] CurrentClipInfo;

    private Door porta;
    private string word;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (timeBody._isRewinding == false)
        {
            OpenDoor();

        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        CloseDoor();
    }

    private void Start()
    {
        _state = new List<ObjState>();
        timeBody = gameObject.GetComponent<TimeBody2>();


    }
    public void OpenDoor()
    {


        isActive = true;
        closedDoor.SetActive(false);
        openDoor.SetActive(true);
    }

    public void CloseDoor()
    {
        isActive = false;
        closedDoor.SetActive(true);
        openDoor.SetActive(false);
    }


    void Record()
    {

        _state.Insert(0, new ObjState(isActive));


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

            _state.RemoveAt(0);

        }
        else
        {
            StopRewind();
        }

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



    public void StartRewind()
    {
        _isRewinding = true;


    }

    public void StopRewind()
    {
        _isRewinding = false;


    }
    public class ObjState
    {
        public Vector3 position;
        public Quaternion rotation;

        public int checkPointIndex;

        public string animationName;

        public bool isWalking;

        public int state;


        public ObjState(bool _isActive)
        {

            this.isWalking = _isActive;
        }







    }

}
