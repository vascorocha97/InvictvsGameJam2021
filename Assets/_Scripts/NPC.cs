using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject dialogueBox;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject == Player.Instance.gameObject)
            dialogueBox.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == Player.Instance.gameObject)
            dialogueBox.SetActive(false);
    }
}
