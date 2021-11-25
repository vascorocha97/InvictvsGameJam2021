using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeParticle : MonoBehaviour
{
    public bool _isRewinding = false;

    public List<ObjState> _state;


    private BoxCollider2D doorCollider;

    private ParticleSystem particles;

    [SerializeField] float speedModifier = 1;

    void Start()
    {
        _state = new List<ObjState>();
        particles = gameObject.GetComponent<ParticleSystem>();




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
        var velocityOverTime = particles.velocityOverLifetime;
        // velocityOverTime.speedModifier = new ParticleSystem.MinMaxCurve(-0.2f);
        velocityOverTime.speedModifier = -speedModifier;




    }

    public void StopRewind()
    {

        _isRewinding = false;
        var velocityOverTime = particles.velocityOverLifetime;
        velocityOverTime.speedModifier = speedModifier;


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


    }

    void Rewind()
    {


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


