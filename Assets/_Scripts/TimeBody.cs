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


    void Start()
    {
        _state = new List<ObjState>();
        // May not work if we have more than one instance!
        robot = gameObject.GetComponent<robot>();



    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("Jump")))
        {
            StartRewind();
        }

        if (Input.GetButtonUp("Jump"))
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
        Debug.Log(transform.position);

        _state.Insert(0, new ObjState(transform.position, transform.rotation, robot.checkPointIndex));

    }

    void Rewind()
    {
        if (_state.Count > 0)
        {
            // transform.position = _positions[0];
            // _positions.RemoveAt(0);
            ObjState objState = _state[0];
            transform.position = objState.position;
            transform.rotation = objState.rotation;
            robot.checkPointIndex = objState.checkPointIndex;
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

        public ObjState(Vector3 _position, Quaternion _rotation, int _checkPointIndex)
        {

            this.position = _position;
            this.rotation = _rotation;
            this.checkPointIndex = _checkPointIndex;
        }




    }

}


