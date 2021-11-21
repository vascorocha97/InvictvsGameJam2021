using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    public bool canRewind = false;

    private Animator anim;

    //Singleton Instantiation
    private static SlotMachine instance;
    public static SlotMachine Instance
    {
        get
        {
            if (instance == null) instance = GameObject.FindObjectOfType<SlotMachine>();
            return instance;
        }
    }

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (canRewind && Input.GetButtonDown("Fire1")) 
        {
            anim.SetTrigger("Rewind");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canRewind = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canRewind = false;
    }
}
