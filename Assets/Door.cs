using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public GameObject openDoor;
    public GameObject closedDoor;

    public bool isActive = false;
    private TimeBody2 timeBody;


    private robot robot;

    private Animation animation;
    private Animator animator;

    private AnimatorClipInfo[] CurrentClipInfo;

    private Door porta;
    private string word;

    private bool isRewinding;



    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        bool didHitDragon = other.GetComponent<FollowRobot>() != null;
        if (isRewinding == false && didHitDragon)
        {
            OpenDoor();

        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (isRewinding == true)
        {
            CloseDoor();
        }
    }

    private void Start()
    {
        timeBody = gameObject.GetComponent<TimeBody2>();


    }

    private void Update()
    {
        isRewinding = timeBody._isRewinding;

    }
    public void OpenDoor()
    {


        isActive = true;
        closedDoor.SetActive(false);
        openDoor.SetActive(true);
    }

    public void CloseDoor()
    {
        StartCoroutine(WaifForScene());
    }

    IEnumerator WaifForScene()
    {
        isActive = false;
        closedDoor.SetActive(true);
        openDoor.SetActive(false);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }



}
