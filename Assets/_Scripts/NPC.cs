using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject dialogueBox;
    private int count = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
        {           
            dialogueBox.SetActive(true);
            if (count > 0)
            {
                Dialogue.Instance.StartDialogue();
            }
            count++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
        {
            dialogueBox.SetActive(false);
        }
    }

}
