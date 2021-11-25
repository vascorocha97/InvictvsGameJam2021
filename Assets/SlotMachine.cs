using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlotMachine : MonoBehaviour
{
    public bool canRewind = false;

    public Door porta;

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
            // Debug.Log(porta.isActive);
            if (!porta.isActive)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
            canRewind = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
            canRewind = false;
    }
}
