using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDoor : MonoBehaviour
{
    public bool _isRewinding = false;

    public List<ObjState> _state;

    private Door porta;

    public GameObject openDoor;
    public GameObject closedDoor;

    private TimeDoor timeBody;

    private BoxCollider2D doorCollider;


    void Start()
    {
        _state = new List<ObjState>();
        // May not work if we have more than one instance!

        porta = gameObject.GetComponent<Door>();
        timeBody = gameObject.GetComponent<TimeDoor>();
        doorCollider = gameObject.GetComponent<BoxCollider2D>();



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
        porta.isRewinding = true;


    }

    public void StopRewind()
    {

        _isRewinding = false;
        porta.isRewinding = false;


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
        doorCollider.enabled = true;
        _state.Insert(0, new ObjState(porta.isActive));

    }

    void Rewind()
    {
        //animator.StartPlayback();
        if (_state.Count > 0)
        {
            doorCollider.enabled = false;
            ObjState objState = _state[0];
            if (objState.isOpen == true)
            {
                porta.OpenDoor();
            }
            else
            {
                porta.CloseDoor();

            }


            _state.RemoveAt(0);

        }
        else
        {
            StopRewind();
        }

    }



    public class ObjState
    {
        public bool isOpen;

        public ObjState(bool _isOpen)
        {

            this.isOpen = _isOpen;
        }

    }

}


