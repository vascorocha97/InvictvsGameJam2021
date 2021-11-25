using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public GameObject openDoor;
    public GameObject closedDoor;

    public bool isActive = false;

    private Door porta;

    public bool isRewinding;



    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log(other.gameObject.name);
        bool didHitDragon = other.GetComponent<FollowRobot>() != null;
        if (isRewinding == false && didHitDragon)
        {
            OpenDoor();

        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        bool didHitDragon = other.GetComponent<FollowRobot>() != null;
        if (isRewinding == true && didHitDragon)
        {
            CloseDoor();
        }
    }


    public void OpenDoor()
    {
        closedDoor.SetActive(false);
        openDoor.SetActive(true);
        isActive = true;
    }

    public void CloseDoor()
    {
        isActive = false;
        closedDoor.SetActive(true);
        openDoor.SetActive(false);
        // END DEMO
        StartCoroutine(WaifForScene());


    }

    IEnumerator WaifForScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }



}
